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
// astgenerator.boo on 3/10/2004 9:00:00 PM
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class ModuleImpl : TypeDefinition
	{

		protected NamespaceDeclaration _namespace;
		protected ImportCollection _imports;
		protected Block _globals;

		protected ModuleImpl()
		{
			InitializeFields();
		}
		
		protected ModuleImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected ModuleImpl(NamespaceDeclaration namespace_)
		{
			InitializeFields();
			Namespace = namespace_;
		}
			
		protected ModuleImpl(LexicalInfo lexicalInfo, NamespaceDeclaration namespace_) : base(lexicalInfo)
		{
			InitializeFields();
			Namespace = namespace_;
		}
			
		new public Boo.Lang.Ast.Module CloneNode()
		{
			return Clone() as Boo.Lang.Ast.Module;
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.Module;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.Module thisNode = (Boo.Lang.Ast.Module)this;
			Boo.Lang.Ast.Module resultingTypedNode = thisNode;
			transformer.OnModule(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_attributes != null)
			{
				Boo.Lang.Ast.Attribute item = existing as Boo.Lang.Ast.Attribute;
				if (null != item)
				{
					if (_attributes.Replace(item, (Boo.Lang.Ast.Attribute)newNode))
					{
						return true;
					}
				}
			}

			if (_members != null)
			{
				Boo.Lang.Ast.TypeMember item = existing as Boo.Lang.Ast.TypeMember;
				if (null != item)
				{
					if (_members.Replace(item, (Boo.Lang.Ast.TypeMember)newNode))
					{
						return true;
					}
				}
			}

			if (_baseTypes != null)
			{
				Boo.Lang.Ast.TypeReference item = existing as Boo.Lang.Ast.TypeReference;
				if (null != item)
				{
					if (_baseTypes.Replace(item, (Boo.Lang.Ast.TypeReference)newNode))
					{
						return true;
					}
				}
			}

			if (_namespace == existing)
			{
				this.Namespace = ((Boo.Lang.Ast.NamespaceDeclaration)newNode);
				return true;
			}

			if (_imports != null)
			{
				Boo.Lang.Ast.Import item = existing as Boo.Lang.Ast.Import;
				if (null != item)
				{
					if (_imports.Replace(item, (Boo.Lang.Ast.Import)newNode))
					{
						return true;
					}
				}
			}

			if (_globals == existing)
			{
				this.Globals = ((Boo.Lang.Ast.Block)newNode);
				return true;
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.Module clone = (Boo.Lang.Ast.Module)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.Module));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			clone._modifiers = _modifiers;

			clone._name = _name;

			if (null != _attributes)
			{
				clone._attributes = ((AttributeCollection)_attributes.Clone());
				clone._attributes.InitializeParent(clone);
			}

			if (null != _members)
			{
				clone._members = ((TypeMemberCollection)_members.Clone());
				clone._members.InitializeParent(clone);
			}

			if (null != _baseTypes)
			{
				clone._baseTypes = ((TypeReferenceCollection)_baseTypes.Clone());
				clone._baseTypes.InitializeParent(clone);
			}

			if (null != _namespace)
			{
				clone._namespace = ((NamespaceDeclaration)_namespace.Clone());
				clone._namespace.InitializeParent(clone);
			}

			if (null != _imports)
			{
				clone._imports = ((ImportCollection)_imports.Clone());
				clone._imports.InitializeParent(clone);
			}

			if (null != _globals)
			{
				clone._globals = ((Block)_globals.Clone());
				clone._globals.InitializeParent(clone);
			}
			
			return clone;
		}
			
		public NamespaceDeclaration Namespace
		{
			get
			{
				return _namespace;
			}
			

			set
			{
				if (_namespace != value)
				{
					_namespace = value;
					if (null != _namespace)
					{
						_namespace.InitializeParent(this);

					}
				}
			}
			

		}
		

		public ImportCollection Imports
		{
			get
			{
				return _imports;
			}
			

			set
			{
				if (_imports != value)
				{
					_imports = value;
					if (null != _imports)
					{
						_imports.InitializeParent(this);

					}
				}
			}
			

		}
		

		public Block Globals
		{
			get
			{
				return _globals;
			}
			

			set
			{
				if (_globals != value)
				{
					_globals = value;
					if (null != _globals)
					{
						_globals.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{
			_imports = new ImportCollection(this);

			_globals = new Block();
			_globals.InitializeParent(this);
			

		}
	}
}
