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
// astgenerator.boo on 2/29/2004 12:21:43 AM
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class SlicingExpressionImpl : Expression
	{

		protected Expression _target;
		protected Expression _begin;
		protected Expression _end;
		protected Expression _step;

		protected SlicingExpressionImpl()
		{
			InitializeFields();
		}
		
		protected SlicingExpressionImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected SlicingExpressionImpl(Expression target, Expression begin, Expression end, Expression step)
		{
			InitializeFields();
			Target = target;
			Begin = begin;
			End = end;
			Step = step;
		}
			
		protected SlicingExpressionImpl(LexicalInfo lexicalInfo, Expression target, Expression begin, Expression end, Expression step) : base(lexicalInfo)
		{
			InitializeFields();
			Target = target;
			Begin = begin;
			End = end;
			Step = step;
		}
			
		new public Boo.Lang.Ast.SlicingExpression CloneNode()
		{
			return Clone() as Boo.Lang.Ast.SlicingExpression;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.SlicingExpression;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.SlicingExpression thisNode = (Boo.Lang.Ast.SlicingExpression)this;
			Boo.Lang.Ast.Expression resultingTypedNode = thisNode;
			transformer.OnSlicingExpression(thisNode, ref resultingTypedNode);
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

			if (_begin == existing)
			{
				this.Begin = ((Boo.Lang.Ast.Expression)newNode);
				return true;
			}

			if (_end == existing)
			{
				this.End = ((Boo.Lang.Ast.Expression)newNode);
				return true;
			}

			if (_step == existing)
			{
				this.Step = ((Boo.Lang.Ast.Expression)newNode);
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.SlicingExpression clone = (Boo.Lang.Ast.SlicingExpression)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.SlicingExpression));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			if (null != _target)
			{
				clone._target = ((Expression)_target.Clone());
			}

			if (null != _begin)
			{
				clone._begin = ((Expression)_begin.Clone());
			}

			if (null != _end)
			{
				clone._end = ((Expression)_end.Clone());
			}

			if (null != _step)
			{
				clone._step = ((Expression)_step.Clone());
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
		

		public Expression Begin
		{
			get
			{
				return _begin;
			}
			

			set
			{
				if (_begin != value)
				{
					_begin = value;
					if (null != _begin)
					{
						_begin.InitializeParent(this);

					}
				}
			}
			

		}
		

		public Expression End
		{
			get
			{
				return _end;
			}
			

			set
			{
				if (_end != value)
				{
					_end = value;
					if (null != _end)
					{
						_end.InitializeParent(this);

					}
				}
			}
			

		}
		

		public Expression Step
		{
			get
			{
				return _step;
			}
			

			set
			{
				if (_step != value)
				{
					_step = value;
					if (null != _step)
					{
						_step.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{

		}
	}
}
