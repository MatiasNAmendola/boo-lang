#region license
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

namespace Boo.Lang.Compiler.Taxonomy
{
	using System;
	using System.Collections;
	using Boo.Lang.Compiler.Ast;

	public class InternalMethod : IInternalElement, IMethod, INamespace
	{
		TagService _tagService;
		
		Boo.Lang.Compiler.Ast.Method _method;
		
		IMethod _override;
		
		IType _declaringType;
		
		public ExpressionCollection ReturnExpressions;
		
		public ExpressionCollection SuperExpressions;
		
		internal InternalMethod(TagService manager, Method method) : this(manager, method, false)
		{
		}
		
		internal InternalMethod(TagService manager, Boo.Lang.Compiler.Ast.Method method, bool visited) : base(visited)
		{			
			_tagService = manager;
			_method = method;
			if (method.NodeType != NodeType.Constructor)
			{
				SuperExpressions = new ExpressionCollection();
				ReturnExpressions = new ExpressionCollection();
				if (null == _method.ReturnType)
				{
					if (_method.DeclaringType.NodeType == NodeType.ClassDefinition)
					{
						_method.ReturnType = _tagService.CreateTypeReference(Unknown.Default);
					}
					else
					{
						_method.ReturnType = _tagService.CreateTypeReference(_tagService.VoidType);
					}
				}
			}
		}
		
		public IType DeclaringType
		{
			get
			{
				if (null == _declaringType)
				{
					_declaringType = (IType)TagService.GetTag(_method.DeclaringType);
				}
				return _declaringType;
			}
		}
		
		public bool IsStatic
		{
			get
			{
				return _method.IsStatic;
			}
		}
		
		public bool IsPublic
		{
			get
			{
				return _method.IsPublic;
			}
		}
		
		public bool IsVirtual
		{
			get
			{
				return !_method.IsFinal;
			}
		}
		
		public bool IsSpecialName
		{
			get
			{
				return false;
			}
		}
		
		public string Name
		{
			get
			{
				return _method.Name;
			}
		}
		
		public string FullName
		{
			get
			{
				return _method.DeclaringType.FullName + "." + _method.Name;
			}
		}
		
		public virtual ElementType ElementType
		{
			get
			{
				return ElementType.Method;
			}
		}
		
		public IType BoundType
		{
			get
			{
				return ReturnType;
			}
		}
		
		public Method Method
		{
			get
			{
				return _method;
			}
		}
		
		override public Node Node
		{
			get
			{
				return _method;
			}
		}
		
		public IMethod Override
		{
			get
			{
				return _override;
			}
			
			set
			{
				_override = value;
			}
		}
		
		public IParameter[] GetParameters()
		{
			if (null == _parameters)
			{
				_parameters = _tagService.Map(_method.Parameters);				
			}
			return _parameters;
		}
		
		public IType ReturnType
		{
			get
			{					
				return _tagService.GetType(_method.ReturnType);
			}
		}
		
		public INamespace ParentNamespace
		{
			get
			{
				return DeclaringType;
			}
		}
		
		public IElement Resolve(string name)
		{
			foreach (Boo.Lang.Ast.Local local in _method.Locals)
			{
				if (local.PrivateScope)
				{
					continue;
				}
				
				if (name == local.Name)
				{
					return TagService.GetTag(local);
				}
			}
			
			foreach (ParameterDeclaration parameter in _method.Parameters)
			{
				if (name == parameter.Name)
				{
					return TagService.GetTag(parameter);
				}
			}
			return null;
		}
		
		override public string ToString()
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			builder.Append(_method.FullName);
			builder.Append("(");
			
			int i=0;
			foreach (ParameterDeclaration parameter in _method.Parameters)
			{
				if (i > 0)
				{
					builder.Append(", ");					
				}
				else
				{
					++i;
				}
				if (null == parameter.Type)
				{
					builder.Append("System.Object");
				}
				else
				{
					builder.Append(parameter.Type.ToString());
				}
			}
			
			builder.Append(")");
			return builder.ToString();
		}
	}
	
	public class InternalConstructor : InternalMethod, IConstructor
	{
		bool _hasSuperCall = false;
		
		public InternalConstructor(TagService tagManager,
		                                  Constructor constructor) : base(tagManager, constructor)
		  {
		  }
		  
		public InternalConstructor(TagService tagManager,
		                                  Constructor constructor,
										  bool visited) : base(tagManager, constructor, visited)
		  {
		  }
		  
		public bool HasSuperCall
		{
			get
			{
				return _hasSuperCall;
			}
			
			set
			{
				_hasSuperCall = value;
			}
		}
	      
	    override public ElementType ElementType
	    {
	    	get
	    	{
	    		return ElementType.Constructor;
	    	}
	    }
	}
}
