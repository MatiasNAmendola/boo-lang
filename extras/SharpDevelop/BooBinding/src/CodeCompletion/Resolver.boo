namespace BooBinding.CodeCompletion

import BooBinding
import System
import System.Collections
import System.Diagnostics
import System.IO
import ICSharpCode.SharpDevelop.Services
import SharpDevelop.Internal.Parser
import Boo.Lang.Compiler
import Boo.Lang.Compiler.Ast as AST
import Boo.Lang.Compiler.IO
import Boo.Lang.Compiler.Steps

class Resolver:
	_parserService as IParserService
	_caretLine as int
	_caretColumn as int
	
	[Getter(CallingClass)]
	_callingClass as IClass
	_compilationUnit as ICompilationUnit
	
	ParentClass as IClass:
		get:
			if _callingClass.BaseTypes.Count > 0:
				return SearchType(_callingClass.BaseTypes[0])
			else:
				return null
	
	_resolvedMember = false
	_currentMember as IMember
	
	CurrentMember as IMember:
		get:
			if not _resolvedMember:
				_resolvedMember = true
				_currentMember = ResolveCurrentMember()
			return _currentMember
	
	private def ResolveCurrentMember() as IMember:
		print "Getting current method... caretLine = ${_caretLine}, caretColumn = ${_caretColumn}"
		best as IMember = null
		line = 0
		for m as IMember in _callingClass.Methods:
			if m.Region.BeginLine <= _caretLine and m.Region.BeginLine > line:
				line = m.Region.BeginLine
				best = m
		for m as IMember in _callingClass.Properties:
			if m.Region.BeginLine <= _caretLine and m.Region.BeginLine > line:
				line = m.Region.BeginLine
				best = m
		return best
	
	_localTypes as Hashtable = {}
	
	def GetTypeFromLocal(name as string) as IReturnType:
		// gets the type of a local variable or method parameter
		print "Trying to get local variable ${name}..."
		return _localTypes[name] if _localTypes.ContainsKey(name)
		_localTypes[name] = null // prevent stack overflow by caching null first
		rt = InnerGetTypeFromLocal(name)
		_localTypes[name] = rt
		return rt
	
	def InnerGetTypeFromLocal(name as string) as IReturnType:
		member = self.CurrentMember
		Print("member", member)
		if member isa BooAbstractMethod:
			method as BooAbstractMethod = member
			for para as IParameter in method.Parameters:
				return para.ReturnType if para.Name == name
			if method.Node != null and method.Node.Body != null:
				varLookup = VariableLookupVisitor(Resolver: self, LookFor: name)
				print "Visiting method body..."
				varLookup.Visit(method.Node.Body)
				print "Finished visiting method body!"
				return varLookup.ReturnType
		elif member isa Property:
			property as Property = member
			return property.ReturnType if name == "value"
			for para as IParameter in property.Parameters:
				return para.ReturnType if para.Name == name
			if property.Node != null:
				varLookup = VariableLookupVisitor(Resolver: self, LookFor: name)
				// TODO: visit only the correct body
				print "Visiting property body..."
				varLookup.Visit(property.Node.Getter) unless property.Node.Getter == null
				varLookup.Visit(property.Node.Setter) unless property.Node.Setter == null
				print "Finished visiting property body!"
				return varLookup.ReturnType
		return null
	
	def SearchType(name as string) as IClass:
		expandedName = BooAmbience.ReverseTypeConversionTable[name]
		return _parserService.GetClass(expandedName) if expandedName != null
		return _parserService.SearchType(name, _callingClass, _caretLine, _caretColumn)
	
	def CtrlSpace(parserService as IParserService, caretLine as int, caretColumn as int, fileName as string) as ArrayList:
		_parserService = parserService
		result = ArrayList(BooAmbience.TypeConversionTable.Values)
		result.Add("System") // system namespace can be used everywhere
		
		parseInfo = parserService.GetParseInformation(fileName)
		cu = parseInfo.MostRecentCompilationUnit as CompilationUnit
		if cu != null:
			curClass = parserService.GetInnermostClass(cu, caretLine, caretColumn) as IClass
			result = AddCurrentClassMembers(result, curClass) if curClass != null
		
		return result
	
	def AddCurrentClassMembers(result as ArrayList, curClass as IClass) as ArrayList:
		result = _parserService.ListMembers(result, curClass, curClass, false)
		// Add static members, but only from this class (not from base classes)
		for method as IMethod in curClass.Methods:
			result.Add(method) if (method.Modifiers & ModifierEnum.Static) == ModifierEnum.Static
		for field as IField in curClass.Fields:
			result.Add(field) if (field.Modifiers & ModifierEnum.Static) == ModifierEnum.Static
		for property as IProperty in curClass.Properties:
			result.Add(property) if (property.Modifiers & ModifierEnum.Static) == ModifierEnum.Static
		for e as Event in curClass.Events:
			result.Add(e) if (e.Modifiers & ModifierEnum.Static) == ModifierEnum.Static
		return result
	
	def Resolve(parserService as IParserService, expression as string, caretLine as int, caretColumn as int, fileName as string, fileContent as string) as ResolveResult:
		if expression == null or expression == '':
			return null
		
		if expression.StartsWith("import "):
			expression = expression.Substring(7).Trim()
			if parserService.NamespaceExists(expression):
				return ResolveResult(parserService.GetNamespaceList(expression))
			return null
		
		_parserService = parserService
		_caretLine = caretLine
		_caretColumn = caretColumn
		
		parseInfo = parserService.GetParseInformation(fileName)
		cu = parseInfo.MostRecentCompilationUnit as CompilationUnit
		_compilationUnit = cu
		if cu == null:
			print "BooResolver: No parse information!"
			return null
		
		callingClass as IClass = parserService.GetInnermostClass(cu, caretLine, caretColumn)
		return null if callingClass == null
		_callingClass = callingClass
		returnClass as IClass = null
		if expression == "self":
			returnClass = callingClass
		elif expression == "super":
			returnClass = self.ParentClass
		else:
			// try looking if the expression is the name of a class
			expressionClass = self.SearchType(expression)
			if expressionClass != null:
				return ResolveResult(expressionClass, parserService.ListMembers(ArrayList(), expressionClass, callingClass, true))
			
			// try if it is the name of a namespace
			if parserService.NamespaceExists(expression):
				return ResolveResult(array(string, 0), parserService.GetNamespaceContents(expression))
			
			expr = Boo.Lang.Parser.BooParser.ParseExpression("expression", expression)
			visitor = ExpressionTypeVisitor(Resolver : self)
			visitor.Visit(expr)
			Print ("result", visitor.ReturnType)
			if visitor.ReturnType != null:
				returnClass = parserService.SearchType(visitor.ReturnType.FullyQualifiedName, callingClass, caretLine, caretColumn)
		
		return null if returnClass == null
		return ResolveResult(returnClass, parserService.ListMembers(ArrayList(), returnClass, callingClass, false))
	
	private def Print(name as string, obj):
		Console.Write(name);
		Console.Write(' = ');
		if obj == null:
			Console.WriteLine('null')
		else:
			Console.WriteLine('{0} ({1})', obj, obj.GetType().FullName)
