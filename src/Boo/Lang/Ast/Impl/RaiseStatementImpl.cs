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
// astgenerator.boo on 3/30/2004 4:04:15 PM
//

namespace Boo.Lang.Ast.Impl
{	
	using Boo.Lang.Ast;
	using System.Collections;
	using System.Runtime.Serialization;
	
	[System.Serializable]
	public abstract class RaiseStatementImpl : Statement
	{

		protected Expression _exception;

		protected RaiseStatementImpl()
		{
			InitializeFields();
		}
		
		protected RaiseStatementImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected RaiseStatementImpl(Expression exception)
		{
			InitializeFields();
			Exception = exception;
		}
			
		protected RaiseStatementImpl(LexicalInfo lexicalInfo, Expression exception) : base(lexicalInfo)
		{
			InitializeFields();
			Exception = exception;
		}
			
		new public RaiseStatement CloneNode()
		{
			return Clone() as RaiseStatement;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.RaiseStatement;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			RaiseStatement thisNode = (RaiseStatement)this;
			Statement resultingTypedNode = thisNode;
			transformer.OnRaiseStatement(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_modifier == existing)
			{
				this.Modifier = (StatementModifier)newNode;
				return true;
			}

			if (_exception == existing)
			{
				this.Exception = (Expression)newNode;
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			RaiseStatement clone = FormatterServices.GetUninitializedObject(typeof(RaiseStatement)) as RaiseStatement;
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = _properties.Clone() as Hashtable;
			

			if (null != _modifier)
			{
				clone._modifier = _modifier.Clone() as StatementModifier;
				clone._modifier.InitializeParent(clone);
			}

			if (null != _exception)
			{
				clone._exception = _exception.Clone() as Expression;
				clone._exception.InitializeParent(clone);
			}
			
			return clone;
		}
			
		public Expression Exception
		{
			get
			{
				return _exception;
			}
			

			set
			{
				if (_exception != value)
				{
					_exception = value;
					if (null != _exception)
					{
						_exception.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{

		}
	}
}
