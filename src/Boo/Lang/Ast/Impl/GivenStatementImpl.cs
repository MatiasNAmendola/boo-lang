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
// astgenerator.boo on 18/3/2004 03:07:46
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class GivenStatementImpl : Statement
	{

		protected Expression _expression;
		protected WhenClauseCollection _whenClauses;
		protected Block _otherwiseBlock;

		protected GivenStatementImpl()
		{
			InitializeFields();
		}
		
		protected GivenStatementImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected GivenStatementImpl(Expression expression, Block otherwiseBlock)
		{
			InitializeFields();
			Expression = expression;
			OtherwiseBlock = otherwiseBlock;
		}
			
		protected GivenStatementImpl(LexicalInfo lexicalInfo, Expression expression, Block otherwiseBlock) : base(lexicalInfo)
		{
			InitializeFields();
			Expression = expression;
			OtherwiseBlock = otherwiseBlock;
		}
			
		new public Boo.Lang.Ast.GivenStatement CloneNode()
		{
			return Clone() as Boo.Lang.Ast.GivenStatement;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.GivenStatement;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.GivenStatement thisNode = (Boo.Lang.Ast.GivenStatement)this;
			Boo.Lang.Ast.Statement resultingTypedNode = thisNode;
			transformer.OnGivenStatement(thisNode, ref resultingTypedNode);
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
				this.Modifier = ((Boo.Lang.Ast.StatementModifier)newNode);
				return true;
			}

			if (_expression == existing)
			{
				this.Expression = ((Boo.Lang.Ast.Expression)newNode);
				return true;
			}

			if (_whenClauses != null)
			{
				Boo.Lang.Ast.WhenClause item = existing as Boo.Lang.Ast.WhenClause;
				if (null != item)
				{
					if (_whenClauses.Replace(item, (Boo.Lang.Ast.WhenClause)newNode))
					{
						return true;
					}
				}
			}

			if (_otherwiseBlock == existing)
			{
				this.OtherwiseBlock = ((Boo.Lang.Ast.Block)newNode);
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.GivenStatement clone = (Boo.Lang.Ast.GivenStatement)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.GivenStatement));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _modifier)
			{
				clone._modifier = ((StatementModifier)_modifier.Clone());
				clone._modifier.InitializeParent(clone);
			}

			if (null != _expression)
			{
				clone._expression = ((Expression)_expression.Clone());
				clone._expression.InitializeParent(clone);
			}

			if (null != _whenClauses)
			{
				clone._whenClauses = ((WhenClauseCollection)_whenClauses.Clone());
				clone._whenClauses.InitializeParent(clone);
			}

			if (null != _otherwiseBlock)
			{
				clone._otherwiseBlock = ((Block)_otherwiseBlock.Clone());
				clone._otherwiseBlock.InitializeParent(clone);
			}
			
			return clone;
		}
			
		public Expression Expression
		{
			get
			{
				return _expression;
			}
			

			set
			{
				if (_expression != value)
				{
					_expression = value;
					if (null != _expression)
					{
						_expression.InitializeParent(this);

					}
				}
			}
			

		}
		

		public WhenClauseCollection WhenClauses
		{
			get
			{
				return _whenClauses;
			}
			

			set
			{
				if (_whenClauses != value)
				{
					_whenClauses = value;
					if (null != _whenClauses)
					{
						_whenClauses.InitializeParent(this);

					}
				}
			}
			

		}
		

		public Block OtherwiseBlock
		{
			get
			{
				return _otherwiseBlock;
			}
			

			set
			{
				if (_otherwiseBlock != value)
				{
					_otherwiseBlock = value;
					if (null != _otherwiseBlock)
					{
						_otherwiseBlock.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{
			_whenClauses = new WhenClauseCollection(this);

		}
	}
}
