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
// astgenerator.boo on 2/28/04 8:05:40 a
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class IfStatementImpl : Statement
	{

		protected Expression _condition;
		protected Block _trueBlock;
		protected Block _falseBlock;

		protected IfStatementImpl()
		{
			InitializeFields();
		}
		
		protected IfStatementImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected IfStatementImpl(Expression condition, Block trueBlock, Block falseBlock)
		{
			InitializeFields();
			Condition = condition;
			TrueBlock = trueBlock;
			FalseBlock = falseBlock;
		}
			
		protected IfStatementImpl(LexicalInfo lexicalInfo, Expression condition, Block trueBlock, Block falseBlock) : base(lexicalInfo)
		{
			InitializeFields();
			Condition = condition;
			TrueBlock = trueBlock;
			FalseBlock = falseBlock;
		}
			
		new public Boo.Lang.Ast.IfStatement CloneNode()
		{
			return Clone() as Boo.Lang.Ast.IfStatement;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.IfStatement;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.IfStatement thisNode = (Boo.Lang.Ast.IfStatement)this;
			Boo.Lang.Ast.Statement resultingTypedNode = thisNode;
			transformer.OnIfStatement(thisNode, ref resultingTypedNode);
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

			if (_condition == existing)
			{
				this.Condition = ((Boo.Lang.Ast.Expression)newNode);
				return true;
			}

			if (_trueBlock == existing)
			{
				this.TrueBlock = ((Boo.Lang.Ast.Block)newNode);
				return true;
			}

			if (_falseBlock == existing)
			{
				this.FalseBlock = ((Boo.Lang.Ast.Block)newNode);
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.IfStatement clone = (Boo.Lang.Ast.IfStatement)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.IfStatement));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _modifier)
			{
				clone._modifier = ((StatementModifier)_modifier.Clone());
			}

			if (null != _condition)
			{
				clone._condition = ((Expression)_condition.Clone());
			}

			if (null != _trueBlock)
			{
				clone._trueBlock = ((Block)_trueBlock.Clone());
			}

			if (null != _falseBlock)
			{
				clone._falseBlock = ((Block)_falseBlock.Clone());
			}
			
			return clone;
		}
			
		public Expression Condition
		{
			get
			{
				return _condition;
			}
			

			set
			{
				if (_condition != value)
				{
					_condition = value;
					if (null != _condition)
					{
						_condition.InitializeParent(this);

					}
				}
			}
			

		}
		

		public Block TrueBlock
		{
			get
			{
				return _trueBlock;
			}
			

			set
			{
				if (_trueBlock != value)
				{
					_trueBlock = value;
					if (null != _trueBlock)
					{
						_trueBlock.InitializeParent(this);

					}
				}
			}
			

		}
		

		public Block FalseBlock
		{
			get
			{
				return _falseBlock;
			}
			

			set
			{
				if (_falseBlock != value)
				{
					_falseBlock = value;
					if (null != _falseBlock)
					{
						_falseBlock.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{

		}
	}
}
