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
	using Boo.Lang.Compiler.Services;
	
	public class ArrayTypeInfo : ITypeInfo, INamespace
	{	
		TaxonomyManager _bindingService;
		
		ITypeInfo _elementType;
		
		ITypeInfo _array;
		
		public ArrayTypeInfo(TaxonomyManager bindingManager, ITypeInfo elementType)
		{
			_bindingService = bindingManager;
			_array = bindingManager.ArrayTypeInfo;
			_elementType = elementType;
		}
		
		public string Name
		{
			get
			{
				return string.Format("({0})", _elementType.FullName);
			}
		}
		
		public InfoType InfoType
		{
			get			
			{
				return InfoType.Array;
			}
		}
		
		public string FullName
		{
			get
			{
				return Name;
			}
		}
		
		public ITypeInfo BoundType
		{
			get
			{
				return this;
			}
		}
		
		public bool IsClass
		{
			get
			{
				return false;
			}
		}
		
		public bool IsInterface
		{
			get
			{
				return false;
			}
		}
		
		public bool IsEnum
		{
			get
			{
				return false;
			}
		}
		
		public bool IsValueType
		{
			get
			{
				return false;
			}
		}
		
		public bool IsArray
		{
			get
			{
				return true;
			}
		}
		
		public int GetTypeDepth()
		{
			return 2;
		}
		
		public int GetArrayRank()
		{
			return 1;
		}		
		
		public ITypeInfo GetElementType()
		{
			return _elementType;
		}
		
		public ITypeInfo BaseType
		{
			get
			{
				return _array;
			}
		}
		
		public IInfo GetDefaultMember()
		{
			return null;
		}
		
		public virtual bool IsSubclassOf(ITypeInfo other)
		{
			return other.IsAssignableFrom(_array);
		}
		
		public virtual bool IsAssignableFrom(ITypeInfo other)
		{			
			if (other == this)
			{
				return true;
			}
			
			if (other.IsArray)
			{
				ITypeInfo otherElementType = other.GetElementType();
				if (_elementType.IsValueType || otherElementType.IsValueType)
				{
					return _elementType == otherElementType;
				}
				return _elementType.IsAssignableFrom(otherElementType);
			}
			return false;
		}
		
		public IConstructorInfo[] GetConstructors()
		{
			return new IConstructorInfo[0];
		}
		
		public ITypeInfo[] GetInterfaces()
		{
			return null;
		}
		
		public IInfo[] GetMembers()
		{
			return null;
		}
		
		public INamespace ParentNamespace
		{
			get
			{
				return _array.ParentNamespace;
			}
		}
		
		public IInfo Resolve(string name)
		{
			return _array.Resolve(name);
		}
		
		override public string ToString()
		{
			return Name;
		}
	}
}
