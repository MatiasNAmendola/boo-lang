﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo Barreto de Oliveira
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

using System;
using System.Collections;

namespace Boo.Lang.Compiler.TypeSystem
{
	public delegate bool InfoFilter(IEntity tag);
	
	public class Ambiguous : IEntity
	{
		IEntity[] _entitys;
		
		public Ambiguous(IEntity[] tags)
		{
			if (null == tags)
			{
				throw new ArgumentNullException("tags");
			}
			if (0 == tags.Length)
			{
				throw new ArgumentException("tags");
			}
			_entitys = tags;
		}
		
		public string Name
		{
			get
			{
				return _entitys[0].Name;
			}
		}
		
		public string FullName
		{
			get
			{
				return _entitys[0].FullName;
			}
		}
		
		public EntityType EntityType
		{
			get
			{
				return EntityType.Ambiguous;
			}
		}
		
		public IEntity[] Entities
		{
			get
			{
				return _entitys;
			}
		}
		
		public Boo.Lang.List Filter(InfoFilter condition)
		{
			Boo.Lang.List found = new Boo.Lang.List();
			foreach (IEntity tag in _entitys)
			{
				if (condition(tag))
				{
					found.Add(tag);
				}
			}
			return found;
		}
		
		override public string ToString()
		{
			return "";
		}
	}
}
