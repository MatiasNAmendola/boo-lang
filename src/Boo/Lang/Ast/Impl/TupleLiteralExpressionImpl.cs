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
// astgenerator.boo on 18/3/2004 03:07:50
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
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
		

		new public Boo.Lang.Ast.TupleLiteralExpression CloneNode()
		{
			return Clone() as Boo.Lang.Ast.TupleLiteralExpression;
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
			Boo.Lang.Ast.TupleLiteralExpression thisNode = (Boo.Lang.Ast.TupleLiteralExpression)this;
			Boo.Lang.Ast.Expression resultingTypedNode = thisNode;
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
				Boo.Lang.Ast.Expression item = existing as Boo.Lang.Ast.Expression;
				if (null != item)
				{
					if (_items.Replace(item, (Boo.Lang.Ast.Expression)newNode))
					{
						return true;
					}
				}
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.TupleLiteralExpression clone = (Boo.Lang.Ast.TupleLiteralExpression)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.TupleLiteralExpression));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _items)
			{
				clone._items = ((ExpressionCollection)_items.Clone());
				clone._items.InitializeParent(clone);
			}
			
			return clone;
		}
			
		private void InitializeFields()
		{

		}
	}
}
