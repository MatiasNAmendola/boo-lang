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
// astgenerator.boo on 03/25/2004 14:42:29
//

namespace Boo.Lang.Ast.Impl
{	
	using Boo.Lang.Ast;
	using System.Collections;
	using System.Runtime.Serialization;
	
	[System.Serializable]
	public abstract class TupleLiteralExpressionImpl : ListLiteralExpression
	{


		protected TupleLiteralExpressionImpl()
		{
			InitializeFields();
		}
		
		protected TupleLiteralExpressionImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		new public TupleLiteralExpression CloneNode()
		{
			return Clone() as TupleLiteralExpression;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.TupleLiteralExpression;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			TupleLiteralExpression thisNode = (TupleLiteralExpression)this;
			Expression resultingTypedNode = thisNode;
			transformer.OnTupleLiteralExpression(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_items != null)
			{
				Expression item = existing as Expression;
				if (null != item)
				{
					Expression newItem = (Expression)newNode;
					if (_items.Replace(item, newItem))
					{
						return true;
					}
				}
			}

			return false;
		}

		override public object Clone()
		{
			TupleLiteralExpression clone = FormatterServices.GetUninitializedObject(typeof(TupleLiteralExpression)) as TupleLiteralExpression;
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = _properties.Clone() as Hashtable;
			

			if (null != _items)
			{
				clone._items = _items.CloneNode();
				clone._items.InitializeParent(clone);
			}
			
			return clone;
		}
			
		private void InitializeFields()
		{

		}
	}
}
