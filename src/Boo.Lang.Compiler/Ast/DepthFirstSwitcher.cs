﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// Permission is hereby granted, free of charge, to any person 
// obtaining a copy of this software and associated documentation 
// files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, 
// publish, distribute, sublicense, and/or sell copies of the Software, 
// and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included 
// in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// Contact Information
//
// mailto:rbo@acm.org
#endregion

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by
// astgenerator.boo on 4/24/2004 9:18:28 PM
//

namespace Boo.Lang.Compiler.Ast
{
	using System;
	
	public class DepthFirstSwitcher : IAstSwitcher
	{
		public bool Switch(Node node)
		{			
			if (null != node)
			{
				try
				{
					node.Switch(this);
					return true;
				}
				catch (Boo.Lang.Compiler.CompilerError)
				{
					throw;
				}
				catch (Exception error)
				{
					throw Boo.Lang.Compiler.CompilerErrorFactory.InternalError(node, error);
				}
			}
			return false;
		}
		
		public void Switch(Node[] array, NodeType nodeType)
		{
			foreach (Node node in array)
			{
				if (node.NodeType == nodeType)
				{
					Switch(node);
				}
			}
		}
		
		public bool Switch(NodeCollection collection, NodeType nodeType)
		{
			if (null != collection)
			{
				Switch(collection.ToArray(), nodeType);
				return true;
			}
			return false;
		}
		
		public void Switch(Node[] array)
		{
			foreach (Node node in array)
			{
				Switch(node);
			}
		}
		
		public bool Switch(NodeCollection collection)
		{
			if (null != collection)
			{
				Switch(collection.ToArray());
				return true;
			}
			return false;
		}
		
		public virtual void OnCompileUnit(Boo.Lang.Compiler.Ast.CompileUnit node)
		{				
			if (EnterCompileUnit(node))
			{
				Switch(node.Modules);
				LeaveCompileUnit(node);
			}
		}
			
		public virtual bool EnterCompileUnit(Boo.Lang.Compiler.Ast.CompileUnit node)
		{
			return true;
		}
		
		public virtual void LeaveCompileUnit(Boo.Lang.Compiler.Ast.CompileUnit node)
		{
		}
			
		public virtual void OnSimpleTypeReference(Boo.Lang.Compiler.Ast.SimpleTypeReference node)
		{
		}
			
		public virtual void OnArrayTypeReference(Boo.Lang.Compiler.Ast.ArrayTypeReference node)
		{				
			if (EnterArrayTypeReference(node))
			{
				Switch(node.ElementType);
				LeaveArrayTypeReference(node);
			}
		}
			
		public virtual bool EnterArrayTypeReference(Boo.Lang.Compiler.Ast.ArrayTypeReference node)
		{
			return true;
		}
		
		public virtual void LeaveArrayTypeReference(Boo.Lang.Compiler.Ast.ArrayTypeReference node)
		{
		}
			
		public virtual void OnNamespaceDeclaration(Boo.Lang.Compiler.Ast.NamespaceDeclaration node)
		{
		}
			
		public virtual void OnImport(Boo.Lang.Compiler.Ast.Import node)
		{				
			if (EnterImport(node))
			{
				Switch(node.AssemblyReference);
				Switch(node.Alias);
				LeaveImport(node);
			}
		}
			
		public virtual bool EnterImport(Boo.Lang.Compiler.Ast.Import node)
		{
			return true;
		}
		
		public virtual void LeaveImport(Boo.Lang.Compiler.Ast.Import node)
		{
		}
			
		public virtual void OnModule(Boo.Lang.Compiler.Ast.Module node)
		{				
			if (EnterModule(node))
			{
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
				Switch(node.Namespace);
				Switch(node.Imports);
				Switch(node.Globals);
				LeaveModule(node);
			}
		}
			
		public virtual bool EnterModule(Boo.Lang.Compiler.Ast.Module node)
		{
			return true;
		}
		
		public virtual void LeaveModule(Boo.Lang.Compiler.Ast.Module node)
		{
		}
			
		public virtual void OnClassDefinition(Boo.Lang.Compiler.Ast.ClassDefinition node)
		{				
			if (EnterClassDefinition(node))
			{
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
				LeaveClassDefinition(node);
			}
		}
			
		public virtual bool EnterClassDefinition(Boo.Lang.Compiler.Ast.ClassDefinition node)
		{
			return true;
		}
		
		public virtual void LeaveClassDefinition(Boo.Lang.Compiler.Ast.ClassDefinition node)
		{
		}
			
		public virtual void OnInterfaceDefinition(Boo.Lang.Compiler.Ast.InterfaceDefinition node)
		{				
			if (EnterInterfaceDefinition(node))
			{
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
				LeaveInterfaceDefinition(node);
			}
		}
			
		public virtual bool EnterInterfaceDefinition(Boo.Lang.Compiler.Ast.InterfaceDefinition node)
		{
			return true;
		}
		
		public virtual void LeaveInterfaceDefinition(Boo.Lang.Compiler.Ast.InterfaceDefinition node)
		{
		}
			
		public virtual void OnEnumDefinition(Boo.Lang.Compiler.Ast.EnumDefinition node)
		{				
			if (EnterEnumDefinition(node))
			{
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
				LeaveEnumDefinition(node);
			}
		}
			
		public virtual bool EnterEnumDefinition(Boo.Lang.Compiler.Ast.EnumDefinition node)
		{
			return true;
		}
		
		public virtual void LeaveEnumDefinition(Boo.Lang.Compiler.Ast.EnumDefinition node)
		{
		}
			
		public virtual void OnEnumMember(Boo.Lang.Compiler.Ast.EnumMember node)
		{				
			if (EnterEnumMember(node))
			{
				Switch(node.Attributes);
				Switch(node.Initializer);
				LeaveEnumMember(node);
			}
		}
			
		public virtual bool EnterEnumMember(Boo.Lang.Compiler.Ast.EnumMember node)
		{
			return true;
		}
		
		public virtual void LeaveEnumMember(Boo.Lang.Compiler.Ast.EnumMember node)
		{
		}
			
		public virtual void OnField(Boo.Lang.Compiler.Ast.Field node)
		{				
			if (EnterField(node))
			{
				Switch(node.Attributes);
				Switch(node.Type);
				Switch(node.Initializer);
				LeaveField(node);
			}
		}
			
		public virtual bool EnterField(Boo.Lang.Compiler.Ast.Field node)
		{
			return true;
		}
		
		public virtual void LeaveField(Boo.Lang.Compiler.Ast.Field node)
		{
		}
			
		public virtual void OnProperty(Boo.Lang.Compiler.Ast.Property node)
		{				
			if (EnterProperty(node))
			{
				Switch(node.Attributes);
				Switch(node.Parameters);
				Switch(node.Getter);
				Switch(node.Setter);
				Switch(node.Type);
				LeaveProperty(node);
			}
		}
			
		public virtual bool EnterProperty(Boo.Lang.Compiler.Ast.Property node)
		{
			return true;
		}
		
		public virtual void LeaveProperty(Boo.Lang.Compiler.Ast.Property node)
		{
		}
			
		public virtual void OnLocal(Boo.Lang.Compiler.Ast.Local node)
		{
		}
			
		public virtual void OnMethod(Boo.Lang.Compiler.Ast.Method node)
		{				
			if (EnterMethod(node))
			{
				Switch(node.Attributes);
				Switch(node.Parameters);
				Switch(node.ReturnType);
				Switch(node.ReturnTypeAttributes);
				Switch(node.Body);
				Switch(node.Locals);
				LeaveMethod(node);
			}
		}
			
		public virtual bool EnterMethod(Boo.Lang.Compiler.Ast.Method node)
		{
			return true;
		}
		
		public virtual void LeaveMethod(Boo.Lang.Compiler.Ast.Method node)
		{
		}
			
		public virtual void OnConstructor(Boo.Lang.Compiler.Ast.Constructor node)
		{				
			if (EnterConstructor(node))
			{
				Switch(node.Attributes);
				Switch(node.Parameters);
				Switch(node.ReturnType);
				Switch(node.ReturnTypeAttributes);
				Switch(node.Body);
				Switch(node.Locals);
				LeaveConstructor(node);
			}
		}
			
		public virtual bool EnterConstructor(Boo.Lang.Compiler.Ast.Constructor node)
		{
			return true;
		}
		
		public virtual void LeaveConstructor(Boo.Lang.Compiler.Ast.Constructor node)
		{
		}
			
		public virtual void OnParameterDeclaration(Boo.Lang.Compiler.Ast.ParameterDeclaration node)
		{				
			if (EnterParameterDeclaration(node))
			{
				Switch(node.Type);
				Switch(node.Attributes);
				LeaveParameterDeclaration(node);
			}
		}
			
		public virtual bool EnterParameterDeclaration(Boo.Lang.Compiler.Ast.ParameterDeclaration node)
		{
			return true;
		}
		
		public virtual void LeaveParameterDeclaration(Boo.Lang.Compiler.Ast.ParameterDeclaration node)
		{
		}
			
		public virtual void OnDeclaration(Boo.Lang.Compiler.Ast.Declaration node)
		{				
			if (EnterDeclaration(node))
			{
				Switch(node.Type);
				LeaveDeclaration(node);
			}
		}
			
		public virtual bool EnterDeclaration(Boo.Lang.Compiler.Ast.Declaration node)
		{
			return true;
		}
		
		public virtual void LeaveDeclaration(Boo.Lang.Compiler.Ast.Declaration node)
		{
		}
			
		public virtual void OnAttribute(Boo.Lang.Compiler.Ast.Attribute node)
		{				
			if (EnterAttribute(node))
			{
				Switch(node.Arguments);
				Switch(node.NamedArguments);
				LeaveAttribute(node);
			}
		}
			
		public virtual bool EnterAttribute(Boo.Lang.Compiler.Ast.Attribute node)
		{
			return true;
		}
		
		public virtual void LeaveAttribute(Boo.Lang.Compiler.Ast.Attribute node)
		{
		}
			
		public virtual void OnStatementModifier(Boo.Lang.Compiler.Ast.StatementModifier node)
		{				
			if (EnterStatementModifier(node))
			{
				Switch(node.Condition);
				LeaveStatementModifier(node);
			}
		}
			
		public virtual bool EnterStatementModifier(Boo.Lang.Compiler.Ast.StatementModifier node)
		{
			return true;
		}
		
		public virtual void LeaveStatementModifier(Boo.Lang.Compiler.Ast.StatementModifier node)
		{
		}
			
		public virtual void OnBlock(Boo.Lang.Compiler.Ast.Block node)
		{				
			if (EnterBlock(node))
			{
				Switch(node.Modifier);
				Switch(node.Statements);
				LeaveBlock(node);
			}
		}
			
		public virtual bool EnterBlock(Boo.Lang.Compiler.Ast.Block node)
		{
			return true;
		}
		
		public virtual void LeaveBlock(Boo.Lang.Compiler.Ast.Block node)
		{
		}
			
		public virtual void OnDeclarationStatement(Boo.Lang.Compiler.Ast.DeclarationStatement node)
		{				
			if (EnterDeclarationStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Declaration);
				Switch(node.Initializer);
				LeaveDeclarationStatement(node);
			}
		}
			
		public virtual bool EnterDeclarationStatement(Boo.Lang.Compiler.Ast.DeclarationStatement node)
		{
			return true;
		}
		
		public virtual void LeaveDeclarationStatement(Boo.Lang.Compiler.Ast.DeclarationStatement node)
		{
		}
			
		public virtual void OnAssertStatement(Boo.Lang.Compiler.Ast.AssertStatement node)
		{				
			if (EnterAssertStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Condition);
				Switch(node.Message);
				LeaveAssertStatement(node);
			}
		}
			
		public virtual bool EnterAssertStatement(Boo.Lang.Compiler.Ast.AssertStatement node)
		{
			return true;
		}
		
		public virtual void LeaveAssertStatement(Boo.Lang.Compiler.Ast.AssertStatement node)
		{
		}
			
		public virtual void OnMacroStatement(Boo.Lang.Compiler.Ast.MacroStatement node)
		{				
			if (EnterMacroStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Arguments);
				Switch(node.Block);
				LeaveMacroStatement(node);
			}
		}
			
		public virtual bool EnterMacroStatement(Boo.Lang.Compiler.Ast.MacroStatement node)
		{
			return true;
		}
		
		public virtual void LeaveMacroStatement(Boo.Lang.Compiler.Ast.MacroStatement node)
		{
		}
			
		public virtual void OnTryStatement(Boo.Lang.Compiler.Ast.TryStatement node)
		{				
			if (EnterTryStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.ProtectedBlock);
				Switch(node.ExceptionHandlers);
				Switch(node.SuccessBlock);
				Switch(node.EnsureBlock);
				LeaveTryStatement(node);
			}
		}
			
		public virtual bool EnterTryStatement(Boo.Lang.Compiler.Ast.TryStatement node)
		{
			return true;
		}
		
		public virtual void LeaveTryStatement(Boo.Lang.Compiler.Ast.TryStatement node)
		{
		}
			
		public virtual void OnExceptionHandler(Boo.Lang.Compiler.Ast.ExceptionHandler node)
		{				
			if (EnterExceptionHandler(node))
			{
				Switch(node.Declaration);
				Switch(node.Block);
				LeaveExceptionHandler(node);
			}
		}
			
		public virtual bool EnterExceptionHandler(Boo.Lang.Compiler.Ast.ExceptionHandler node)
		{
			return true;
		}
		
		public virtual void LeaveExceptionHandler(Boo.Lang.Compiler.Ast.ExceptionHandler node)
		{
		}
			
		public virtual void OnIfStatement(Boo.Lang.Compiler.Ast.IfStatement node)
		{				
			if (EnterIfStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Condition);
				Switch(node.TrueBlock);
				Switch(node.FalseBlock);
				LeaveIfStatement(node);
			}
		}
			
		public virtual bool EnterIfStatement(Boo.Lang.Compiler.Ast.IfStatement node)
		{
			return true;
		}
		
		public virtual void LeaveIfStatement(Boo.Lang.Compiler.Ast.IfStatement node)
		{
		}
			
		public virtual void OnUnlessStatement(Boo.Lang.Compiler.Ast.UnlessStatement node)
		{				
			if (EnterUnlessStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Condition);
				Switch(node.Block);
				LeaveUnlessStatement(node);
			}
		}
			
		public virtual bool EnterUnlessStatement(Boo.Lang.Compiler.Ast.UnlessStatement node)
		{
			return true;
		}
		
		public virtual void LeaveUnlessStatement(Boo.Lang.Compiler.Ast.UnlessStatement node)
		{
		}
			
		public virtual void OnForStatement(Boo.Lang.Compiler.Ast.ForStatement node)
		{				
			if (EnterForStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Declarations);
				Switch(node.Iterator);
				Switch(node.Block);
				LeaveForStatement(node);
			}
		}
			
		public virtual bool EnterForStatement(Boo.Lang.Compiler.Ast.ForStatement node)
		{
			return true;
		}
		
		public virtual void LeaveForStatement(Boo.Lang.Compiler.Ast.ForStatement node)
		{
		}
			
		public virtual void OnWhileStatement(Boo.Lang.Compiler.Ast.WhileStatement node)
		{				
			if (EnterWhileStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Condition);
				Switch(node.Block);
				LeaveWhileStatement(node);
			}
		}
			
		public virtual bool EnterWhileStatement(Boo.Lang.Compiler.Ast.WhileStatement node)
		{
			return true;
		}
		
		public virtual void LeaveWhileStatement(Boo.Lang.Compiler.Ast.WhileStatement node)
		{
		}
			
		public virtual void OnGivenStatement(Boo.Lang.Compiler.Ast.GivenStatement node)
		{				
			if (EnterGivenStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Expression);
				Switch(node.WhenClauses);
				Switch(node.OtherwiseBlock);
				LeaveGivenStatement(node);
			}
		}
			
		public virtual bool EnterGivenStatement(Boo.Lang.Compiler.Ast.GivenStatement node)
		{
			return true;
		}
		
		public virtual void LeaveGivenStatement(Boo.Lang.Compiler.Ast.GivenStatement node)
		{
		}
			
		public virtual void OnWhenClause(Boo.Lang.Compiler.Ast.WhenClause node)
		{				
			if (EnterWhenClause(node))
			{
				Switch(node.Condition);
				Switch(node.Block);
				LeaveWhenClause(node);
			}
		}
			
		public virtual bool EnterWhenClause(Boo.Lang.Compiler.Ast.WhenClause node)
		{
			return true;
		}
		
		public virtual void LeaveWhenClause(Boo.Lang.Compiler.Ast.WhenClause node)
		{
		}
			
		public virtual void OnBreakStatement(Boo.Lang.Compiler.Ast.BreakStatement node)
		{				
			if (EnterBreakStatement(node))
			{
				Switch(node.Modifier);
				LeaveBreakStatement(node);
			}
		}
			
		public virtual bool EnterBreakStatement(Boo.Lang.Compiler.Ast.BreakStatement node)
		{
			return true;
		}
		
		public virtual void LeaveBreakStatement(Boo.Lang.Compiler.Ast.BreakStatement node)
		{
		}
			
		public virtual void OnContinueStatement(Boo.Lang.Compiler.Ast.ContinueStatement node)
		{				
			if (EnterContinueStatement(node))
			{
				Switch(node.Modifier);
				LeaveContinueStatement(node);
			}
		}
			
		public virtual bool EnterContinueStatement(Boo.Lang.Compiler.Ast.ContinueStatement node)
		{
			return true;
		}
		
		public virtual void LeaveContinueStatement(Boo.Lang.Compiler.Ast.ContinueStatement node)
		{
		}
			
		public virtual void OnRetryStatement(Boo.Lang.Compiler.Ast.RetryStatement node)
		{				
			if (EnterRetryStatement(node))
			{
				Switch(node.Modifier);
				LeaveRetryStatement(node);
			}
		}
			
		public virtual bool EnterRetryStatement(Boo.Lang.Compiler.Ast.RetryStatement node)
		{
			return true;
		}
		
		public virtual void LeaveRetryStatement(Boo.Lang.Compiler.Ast.RetryStatement node)
		{
		}
			
		public virtual void OnReturnStatement(Boo.Lang.Compiler.Ast.ReturnStatement node)
		{				
			if (EnterReturnStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Expression);
				LeaveReturnStatement(node);
			}
		}
			
		public virtual bool EnterReturnStatement(Boo.Lang.Compiler.Ast.ReturnStatement node)
		{
			return true;
		}
		
		public virtual void LeaveReturnStatement(Boo.Lang.Compiler.Ast.ReturnStatement node)
		{
		}
			
		public virtual void OnYieldStatement(Boo.Lang.Compiler.Ast.YieldStatement node)
		{				
			if (EnterYieldStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Expression);
				LeaveYieldStatement(node);
			}
		}
			
		public virtual bool EnterYieldStatement(Boo.Lang.Compiler.Ast.YieldStatement node)
		{
			return true;
		}
		
		public virtual void LeaveYieldStatement(Boo.Lang.Compiler.Ast.YieldStatement node)
		{
		}
			
		public virtual void OnRaiseStatement(Boo.Lang.Compiler.Ast.RaiseStatement node)
		{				
			if (EnterRaiseStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Exception);
				LeaveRaiseStatement(node);
			}
		}
			
		public virtual bool EnterRaiseStatement(Boo.Lang.Compiler.Ast.RaiseStatement node)
		{
			return true;
		}
		
		public virtual void LeaveRaiseStatement(Boo.Lang.Compiler.Ast.RaiseStatement node)
		{
		}
			
		public virtual void OnUnpackStatement(Boo.Lang.Compiler.Ast.UnpackStatement node)
		{				
			if (EnterUnpackStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Declarations);
				Switch(node.Expression);
				LeaveUnpackStatement(node);
			}
		}
			
		public virtual bool EnterUnpackStatement(Boo.Lang.Compiler.Ast.UnpackStatement node)
		{
			return true;
		}
		
		public virtual void LeaveUnpackStatement(Boo.Lang.Compiler.Ast.UnpackStatement node)
		{
		}
			
		public virtual void OnExpressionStatement(Boo.Lang.Compiler.Ast.ExpressionStatement node)
		{				
			if (EnterExpressionStatement(node))
			{
				Switch(node.Modifier);
				Switch(node.Expression);
				LeaveExpressionStatement(node);
			}
		}
			
		public virtual bool EnterExpressionStatement(Boo.Lang.Compiler.Ast.ExpressionStatement node)
		{
			return true;
		}
		
		public virtual void LeaveExpressionStatement(Boo.Lang.Compiler.Ast.ExpressionStatement node)
		{
		}
			
		public virtual void OnOmittedExpression(Boo.Lang.Compiler.Ast.OmittedExpression node)
		{
		}
			
		public virtual void OnExpressionPair(Boo.Lang.Compiler.Ast.ExpressionPair node)
		{				
			if (EnterExpressionPair(node))
			{
				Switch(node.First);
				Switch(node.Second);
				LeaveExpressionPair(node);
			}
		}
			
		public virtual bool EnterExpressionPair(Boo.Lang.Compiler.Ast.ExpressionPair node)
		{
			return true;
		}
		
		public virtual void LeaveExpressionPair(Boo.Lang.Compiler.Ast.ExpressionPair node)
		{
		}
			
		public virtual void OnMethodInvocationExpression(Boo.Lang.Compiler.Ast.MethodInvocationExpression node)
		{				
			if (EnterMethodInvocationExpression(node))
			{
				Switch(node.Target);
				Switch(node.Arguments);
				Switch(node.NamedArguments);
				LeaveMethodInvocationExpression(node);
			}
		}
			
		public virtual bool EnterMethodInvocationExpression(Boo.Lang.Compiler.Ast.MethodInvocationExpression node)
		{
			return true;
		}
		
		public virtual void LeaveMethodInvocationExpression(Boo.Lang.Compiler.Ast.MethodInvocationExpression node)
		{
		}
			
		public virtual void OnUnaryExpression(Boo.Lang.Compiler.Ast.UnaryExpression node)
		{				
			if (EnterUnaryExpression(node))
			{
				Switch(node.Operand);
				LeaveUnaryExpression(node);
			}
		}
			
		public virtual bool EnterUnaryExpression(Boo.Lang.Compiler.Ast.UnaryExpression node)
		{
			return true;
		}
		
		public virtual void LeaveUnaryExpression(Boo.Lang.Compiler.Ast.UnaryExpression node)
		{
		}
			
		public virtual void OnBinaryExpression(Boo.Lang.Compiler.Ast.BinaryExpression node)
		{				
			if (EnterBinaryExpression(node))
			{
				Switch(node.Left);
				Switch(node.Right);
				LeaveBinaryExpression(node);
			}
		}
			
		public virtual bool EnterBinaryExpression(Boo.Lang.Compiler.Ast.BinaryExpression node)
		{
			return true;
		}
		
		public virtual void LeaveBinaryExpression(Boo.Lang.Compiler.Ast.BinaryExpression node)
		{
		}
			
		public virtual void OnTernaryExpression(Boo.Lang.Compiler.Ast.TernaryExpression node)
		{				
			if (EnterTernaryExpression(node))
			{
				Switch(node.Condition);
				Switch(node.TrueExpression);
				Switch(node.FalseExpression);
				LeaveTernaryExpression(node);
			}
		}
			
		public virtual bool EnterTernaryExpression(Boo.Lang.Compiler.Ast.TernaryExpression node)
		{
			return true;
		}
		
		public virtual void LeaveTernaryExpression(Boo.Lang.Compiler.Ast.TernaryExpression node)
		{
		}
			
		public virtual void OnReferenceExpression(Boo.Lang.Compiler.Ast.ReferenceExpression node)
		{
		}
			
		public virtual void OnMemberReferenceExpression(Boo.Lang.Compiler.Ast.MemberReferenceExpression node)
		{				
			if (EnterMemberReferenceExpression(node))
			{
				Switch(node.Target);
				LeaveMemberReferenceExpression(node);
			}
		}
			
		public virtual bool EnterMemberReferenceExpression(Boo.Lang.Compiler.Ast.MemberReferenceExpression node)
		{
			return true;
		}
		
		public virtual void LeaveMemberReferenceExpression(Boo.Lang.Compiler.Ast.MemberReferenceExpression node)
		{
		}
			
		public virtual void OnStringLiteralExpression(Boo.Lang.Compiler.Ast.StringLiteralExpression node)
		{
		}
			
		public virtual void OnTimeSpanLiteralExpression(Boo.Lang.Compiler.Ast.TimeSpanLiteralExpression node)
		{
		}
			
		public virtual void OnIntegerLiteralExpression(Boo.Lang.Compiler.Ast.IntegerLiteralExpression node)
		{
		}
			
		public virtual void OnDoubleLiteralExpression(Boo.Lang.Compiler.Ast.DoubleLiteralExpression node)
		{
		}
			
		public virtual void OnNullLiteralExpression(Boo.Lang.Compiler.Ast.NullLiteralExpression node)
		{
		}
			
		public virtual void OnSelfLiteralExpression(Boo.Lang.Compiler.Ast.SelfLiteralExpression node)
		{
		}
			
		public virtual void OnSuperLiteralExpression(Boo.Lang.Compiler.Ast.SuperLiteralExpression node)
		{
		}
			
		public virtual void OnBoolLiteralExpression(Boo.Lang.Compiler.Ast.BoolLiteralExpression node)
		{
		}
			
		public virtual void OnRELiteralExpression(Boo.Lang.Compiler.Ast.RELiteralExpression node)
		{
		}
			
		public virtual void OnStringFormattingExpression(Boo.Lang.Compiler.Ast.StringFormattingExpression node)
		{				
			if (EnterStringFormattingExpression(node))
			{
				Switch(node.Arguments);
				LeaveStringFormattingExpression(node);
			}
		}
			
		public virtual bool EnterStringFormattingExpression(Boo.Lang.Compiler.Ast.StringFormattingExpression node)
		{
			return true;
		}
		
		public virtual void LeaveStringFormattingExpression(Boo.Lang.Compiler.Ast.StringFormattingExpression node)
		{
		}
			
		public virtual void OnHashLiteralExpression(Boo.Lang.Compiler.Ast.HashLiteralExpression node)
		{				
			if (EnterHashLiteralExpression(node))
			{
				Switch(node.Items);
				LeaveHashLiteralExpression(node);
			}
		}
			
		public virtual bool EnterHashLiteralExpression(Boo.Lang.Compiler.Ast.HashLiteralExpression node)
		{
			return true;
		}
		
		public virtual void LeaveHashLiteralExpression(Boo.Lang.Compiler.Ast.HashLiteralExpression node)
		{
		}
			
		public virtual void OnListLiteralExpression(Boo.Lang.Compiler.Ast.ListLiteralExpression node)
		{				
			if (EnterListLiteralExpression(node))
			{
				Switch(node.Items);
				LeaveListLiteralExpression(node);
			}
		}
			
		public virtual bool EnterListLiteralExpression(Boo.Lang.Compiler.Ast.ListLiteralExpression node)
		{
			return true;
		}
		
		public virtual void LeaveListLiteralExpression(Boo.Lang.Compiler.Ast.ListLiteralExpression node)
		{
		}
			
		public virtual void OnArrayLiteralExpression(Boo.Lang.Compiler.Ast.ArrayLiteralExpression node)
		{				
			if (EnterArrayLiteralExpression(node))
			{
				Switch(node.Items);
				LeaveArrayLiteralExpression(node);
			}
		}
			
		public virtual bool EnterArrayLiteralExpression(Boo.Lang.Compiler.Ast.ArrayLiteralExpression node)
		{
			return true;
		}
		
		public virtual void LeaveArrayLiteralExpression(Boo.Lang.Compiler.Ast.ArrayLiteralExpression node)
		{
		}
			
		public virtual void OnIteratorExpression(Boo.Lang.Compiler.Ast.IteratorExpression node)
		{				
			if (EnterIteratorExpression(node))
			{
				Switch(node.Expression);
				Switch(node.Declarations);
				Switch(node.Iterator);
				Switch(node.Filter);
				LeaveIteratorExpression(node);
			}
		}
			
		public virtual bool EnterIteratorExpression(Boo.Lang.Compiler.Ast.IteratorExpression node)
		{
			return true;
		}
		
		public virtual void LeaveIteratorExpression(Boo.Lang.Compiler.Ast.IteratorExpression node)
		{
		}
			
		public virtual void OnSlicingExpression(Boo.Lang.Compiler.Ast.SlicingExpression node)
		{				
			if (EnterSlicingExpression(node))
			{
				Switch(node.Target);
				Switch(node.Begin);
				Switch(node.End);
				Switch(node.Step);
				LeaveSlicingExpression(node);
			}
		}
			
		public virtual bool EnterSlicingExpression(Boo.Lang.Compiler.Ast.SlicingExpression node)
		{
			return true;
		}
		
		public virtual void LeaveSlicingExpression(Boo.Lang.Compiler.Ast.SlicingExpression node)
		{
		}
			
		public virtual void OnAsExpression(Boo.Lang.Compiler.Ast.AsExpression node)
		{				
			if (EnterAsExpression(node))
			{
				Switch(node.Target);
				Switch(node.Type);
				LeaveAsExpression(node);
			}
		}
			
		public virtual bool EnterAsExpression(Boo.Lang.Compiler.Ast.AsExpression node)
		{
			return true;
		}
		
		public virtual void LeaveAsExpression(Boo.Lang.Compiler.Ast.AsExpression node)
		{
		}
			
		public virtual void OnCastExpression(Boo.Lang.Compiler.Ast.CastExpression node)
		{				
			if (EnterCastExpression(node))
			{
				Switch(node.Type);
				Switch(node.Target);
				LeaveCastExpression(node);
			}
		}
			
		public virtual bool EnterCastExpression(Boo.Lang.Compiler.Ast.CastExpression node)
		{
			return true;
		}
		
		public virtual void LeaveCastExpression(Boo.Lang.Compiler.Ast.CastExpression node)
		{
		}
			
		public virtual void OnTypeofExpression(Boo.Lang.Compiler.Ast.TypeofExpression node)
		{				
			if (EnterTypeofExpression(node))
			{
				Switch(node.Type);
				LeaveTypeofExpression(node);
			}
		}
			
		public virtual bool EnterTypeofExpression(Boo.Lang.Compiler.Ast.TypeofExpression node)
		{
			return true;
		}
		
		public virtual void LeaveTypeofExpression(Boo.Lang.Compiler.Ast.TypeofExpression node)
		{
		}
			
	}
}
