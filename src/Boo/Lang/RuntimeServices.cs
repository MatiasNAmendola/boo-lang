﻿#region license
// Copyright (c) 2004, Rodrigo B. de Oliveira (rbo@acm.org)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Rodrigo B. de Oliveira nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

namespace Boo.Lang
{
	using System;
	using System.Reflection;
	using System.Collections;
	using System.IO;
	using System.Text;
	using System.Text.RegularExpressions;

	public class RuntimeServices
	{
		const BindingFlags DefaultBindingFlags = BindingFlags.Public |
												BindingFlags.OptionalParamBinding |
												BindingFlags.Instance;
									
		const BindingFlags InvokeBindingFlags = DefaultBindingFlags |
												BindingFlags.InvokeMethod;												
												
		const BindingFlags SetPropertyBindingFlags = DefaultBindingFlags |
												BindingFlags.SetProperty;
												
		const BindingFlags GetPropertyBindingFlags = DefaultBindingFlags |
												BindingFlags.GetProperty;
			
		public static object Invoke(object target, string name, object[] args)
		{
			try
			{
				return target.GetType().InvokeMember(name,
													InvokeBindingFlags,
													null,
													target,
													args);
													
			}
			catch (TargetInvocationException x)
			{
				throw x.InnerException;
			}				
		}
		
		public static object SetProperty(object target, string name, object value)
		{
			try
			{
				target.GetType().InvokeMember(name,
										SetPropertyBindingFlags,
										null, 
										target,
										new object[] { value });
				return value;
			}
			catch (TargetInvocationException x)
			{
				throw x.InnerException;
			}
		}
		
		public static object GetProperty(object target, string name, object[] args)
		{
			try
			{
				return target.GetType().InvokeMember(name,
										GetPropertyBindingFlags,
										null, 
										target,
										args);
			}
			catch (TargetInvocationException x)
			{
				throw x.InnerException;
			}
		}
		
		public static object MoveNext(IEnumerator enumerator)
		{
			if (null == enumerator)
			{
				Error("CantUnpackNull");
			}
			if (!enumerator.MoveNext())
			{
				Error("UnpackListOfWrongSize");
			}
			return enumerator.Current;
		}
		
		public static int Len(object obj)
		{
			if (null != obj)
			{
				ICollection collection = obj as ICollection;
				if (null != collection)
				{
					return collection.Count;
				}
				string s = obj as string;
				if (null != s)
				{
					return s.Length;
				}
			}
			return 0;
		}
		
		public static string Mid(string s, int begin, int end)
		{
			if (begin < 0)
			{
				begin += s.Length;
			}
			if (end < 0)
			{
				end += s.Length;
			}
			return s.Substring(begin, end-begin);
		}
		
		public static Array GetRange1(Array source, int begin)
		{
			return GetRange2(source, begin, source.Length);
		}
		
		public static Array GetRange2(Array source, int begin, int end)
		{
			if (begin < 0)
			{
				begin += source.Length;
			}
			if (end < 0)
			{
				end += source.Length;
			}
			
			int targetLen = end-begin;
			Array target = Array.CreateInstance(source.GetType().GetElementType(), targetLen);
			Array.Copy(source, begin, target, 0, targetLen);
			return target;
		}
		
		public static void CheckArrayUnpack(Array array, int expected)
		{
			if (null == array)
			{
				Error("CantUnpackNull");
			}			
			if (expected > array.Length)
			{
				Error("UnpackArrayOfWrongSize", expected, array.Length);
			}
		}
		
		public static int NormalizeArrayIndex(Array array, int index)
		{
			return index < 0 ? array.Length + index : index;
		}
		
		public static IEnumerable GetEnumerable(object enumerable)
		{
			if (null == enumerable)
			{
				Error("CantEnumerateNull");
			}
			
			IEnumerable iterator = enumerable as IEnumerable;
			if (null == iterator)
			{
				TextReader reader = enumerable as TextReader;
				if (null != reader)
				{
					iterator = new Boo.IO.TextReaderEnumerator(reader);
				}
				else
				{
					Error("ArgumentNotEnumerable");
				}
			}
			return iterator;
		}
		
		#region global operators
		
		public static string op_Addition(string lhs, object rhs)
		{
			return string.Concat(lhs, rhs);
		}
		
		public static string op_Addition(object lhs, string rhs)
		{
			return string.Concat(lhs, rhs);
		}
		
		public static Array op_Multiply(Array lhs, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			
			Type type = lhs.GetType();
			if (1 != type.GetArrayRank())
			{
				throw new ArgumentException("lhs");
			}
			
			int length = lhs.Length;
			Array result = Array.CreateInstance(type.GetElementType(), length*count);
			int destinationIndex = 0;
			for (int i=0; i<count; ++i)
			{
				Array.Copy(lhs, 0, result, destinationIndex, length);
				destinationIndex += length;
			}
			return result;
		}
		
		public static Array op_Multiply(int count, Array rhs)
		{
			return op_Multiply(rhs, count);
		}
		
		public static string op_Multiply(string lhs, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			
			string result = null;
			if (null != lhs)
			{
				StringBuilder builder = new StringBuilder(lhs.Length * count);
				for (int i=0; i<count; ++i)
				{
					builder.Append(lhs);
				}
				result = builder.ToString();
			}
			return result;
		}
		
		public static string op_Multiply(int count, string rhs)
		{
			return op_Multiply(rhs, count);
		}
		
		public static bool op_NotMember(string lhs, string rhs)
		{
			return !op_Member(lhs, rhs);
		}
		
		public static bool op_Member(string lhs, string rhs)
		{			
			if (null == lhs || null == rhs)
			{
				return false;
			}
			return rhs.IndexOf(lhs) > -1;
		}
		
		public static bool op_Match(string input, Regex pattern)
		{
			return pattern.IsMatch(input);
		}
		
		public static bool op_Match(string input, string pattern)
		{			
			return Regex.IsMatch(input, pattern);
		}
		
		public static bool op_NotMatch(string input, string pattern)
		{
			return !op_Match(input, pattern);
		}
		
		public static bool op_Member(object lhs, IList rhs)
		{
			if (null == rhs)
			{
				return false;
			}
			return rhs.Contains(lhs);
		}
		
		public static bool op_NotMember(object lhs, IList rhs)
		{
			return !op_Member(lhs, rhs);
		}
		
		public static bool op_Member(object lhs, IDictionary rhs)
		{
			if (null == rhs)
			{
				return false;
			}
			return rhs.Contains(lhs);
		}
		
		public static bool op_NotMember(object lhs, IDictionary rhs)
		{
			return !op_Member(lhs, rhs);
		}
		
		public static bool op_Equality(Array lhs, Array rhs)
		{
			if (lhs == rhs)
			{
				return true;
			}
			
			if (null == lhs || null == rhs)
			{
				return false;
			}
			
			if (1 != lhs.Rank || 1 != rhs.Rank)
			{
				throw new ArgumentException("array rank must be 1"); 
			}
			
			if (lhs.Length != rhs.Length)
			{
				return false;
			}
			
			for (int i=0; i<lhs.Length; ++i)
			{
				if (!Object.Equals(lhs.GetValue(i), rhs.GetValue(i)))
				{
					return false;
				}
			}
			return true;
		}
		#endregion
		
		/*
		public static int UnboxToInt(object value)
		{
			CheckNumericPromotion(value);
			return ((IConvertible)value).ToInt32();
		}
		*/
		
		public static bool ToBool(object value)
		{
			if (null == value)
			{
				return false;
			}
			
			if (value is ValueType)
			{		
				if (value is bool)
				{
					return ((bool)value);
				}
				if (value is int)
				{
					return 0 != ((int)value);
				}
				if (value is long)
				{
					return 0 != ((long)value);
				}
			}
			
			return true;
		}
		
		static void Error(string name, params object[] args)
		{
			throw new ApplicationException(Boo.ResourceManager.Format(name, args));
		}
		
		static void Error(string name)
		{
			throw new ApplicationException(Boo.ResourceManager.GetString(name));
		}
	}
}
