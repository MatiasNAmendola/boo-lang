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
// astgenerator.boo on 3/30/2004 6:14:03 PM
//

namespace Boo.Lang.Ast.Impl
{	
	using Boo.Lang.Ast;
	using System.Collections;
	using System.Runtime.Serialization;
	
	[System.Serializable]
	public abstract class WhenClauseImpl : Node
	{

		protected Expression _condition;
		protected Block _block;

		protected WhenClauseImpl()
		{
			InitializeFields();
		}
		
		protected WhenClauseImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected WhenClauseImpl(Expression condition)
		{
			InitializeFields();
			Condition = condition;
		}
			
		protected WhenClauseImpl(LexicalInfo lexicalInfo, Expression condition) : base(lexicalInfo)
		{
			InitializeFields();
			Condition = condition;
		}
			
		new public WhenClause CloneNode()
		{
			return Clone() as WhenClause;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.WhenClause;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			WhenClause thisNode = (WhenClause)this;
			WhenClause resultingTypedNode = thisNode;
			transformer.OnWhenClause(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_condition == existing)
			{
				this.Condition = (Expression)newNode;
				return true;
			}

			if (_block == existing)
			{
				this.Block = (Block)newNode;
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			WhenClause clone = FormatterServices.GetUninitializedObject(typeof(WhenClause)) as WhenClause;
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = _properties.Clone() as Hashtable;
			

			if (null != _condition)
			{
				clone._condition = _condition.Clone() as Expression;
				clone._condition.InitializeParent(clone);
			}

			if (null != _block)
			{
				clone._block = _block.Clone() as Block;
				clone._block.InitializeParent(clone);
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
		

		public Block Block
		{
			get
			{
				return _block;
			}
			

			set
			{
				if (_block != value)
				{
					_block = value;
					if (null != _block)
					{
						_block.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{

			_block = new Block();
			_block.InitializeParent(this);
			

		}
	}
}
