﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// As a special exception, if you link this library with other files to
// produce an executable, this library does not by itself cause the
// resulting executable to be covered by the GNU General Public License.
// This exception does not however invalidate any other reasons why the
// executable file might be covered by the GNU General Public License.
//
// Contact Information
//
// mailto:rbo@acm.org
#endregion

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by
// astgenerator.boo on 3/10/2004 9:00:00 PM
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class MethodInvocationExpressionImpl : Expression, INodeWithArguments
	{

		protected Expression _target;
		protected ExpressionCollection _arguments;
		protected ExpressionPairCollection _namedArguments;

		protected MethodInvocationExpressionImpl()
		{
			InitializeFields();
		}
		
		protected MethodInvocationExpressionImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected MethodInvocationExpressionImpl(Expression target)
		{
			InitializeFields();
			Target = target;
		}
			
		protected MethodInvocationExpressionImpl(LexicalInfo lexicalInfo, Expression target) : base(lexicalInfo)
		{
			InitializeFields();
			Target = target;
		}
			
		new public Boo.Lang.Ast.MethodInvocationExpression CloneNode()
		{
			return Clone() as Boo.Lang.Ast.MethodInvocationExpression;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.MethodInvocationExpression;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.MethodInvocationExpression thisNode = (Boo.Lang.Ast.MethodInvocationExpression)this;
			Boo.Lang.Ast.Expression resultingTypedNode = thisNode;
			transformer.OnMethodInvocationExpression(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_target == existing)
			{
				this.Target = ((Boo.Lang.Ast.Expression)newNode);
				return true;
			}

			if (_arguments != null)
			{
				Boo.Lang.Ast.Expression item = existing as Boo.Lang.Ast.Expression;
				if (null != item)
				{
					if (_arguments.Replace(item, (Boo.Lang.Ast.Expression)newNode))
					{
						return true;
					}
				}
			}

			if (_namedArguments != null)
			{
				Boo.Lang.Ast.ExpressionPair item = existing as Boo.Lang.Ast.ExpressionPair;
				if (null != item)
				{
					if (_namedArguments.Replace(item, (Boo.Lang.Ast.ExpressionPair)newNode))
					{
						return true;
					}
				}
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.MethodInvocationExpression clone = (Boo.Lang.Ast.MethodInvocationExpression)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.MethodInvocationExpression));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _target)
			{
				clone._target = ((Expression)_target.Clone());
				clone._target.InitializeParent(clone);
			}

			if (null != _arguments)
			{
				clone._arguments = ((ExpressionCollection)_arguments.Clone());
				clone._arguments.InitializeParent(clone);
			}

			if (null != _namedArguments)
			{
				clone._namedArguments = ((ExpressionPairCollection)_namedArguments.Clone());
				clone._namedArguments.InitializeParent(clone);
			}
			
			return clone;
		}
			
		public Expression Target
		{
			get
			{
				return _target;
			}
			

			set
			{
				if (_target != value)
				{
					_target = value;
					if (null != _target)
					{
						_target.InitializeParent(this);

					}
				}
			}
			

		}
		

		public ExpressionCollection Arguments
		{
			get
			{
				return _arguments;
			}
			

			set
			{
				if (_arguments != value)
				{
					_arguments = value;
					if (null != _arguments)
					{
						_arguments.InitializeParent(this);

					}
				}
			}
			

		}
		

		public ExpressionPairCollection NamedArguments
		{
			get
			{
				return _namedArguments;
			}
			

			set
			{
				if (_namedArguments != value)
				{
					_namedArguments = value;
					if (null != _namedArguments)
					{
						_namedArguments.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{
			_arguments = new ExpressionCollection(this);
			_namedArguments = new ExpressionPairCollection(this);

		}
	}
}
