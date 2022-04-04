#region copyright

// Copyright 2021-2022 Cliesta Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Cliesta.Diagnostics
{
    public class ReflectEqualityObject
    {

        static Dictionary<Type, PropertyInfo[]> _properties;

        static ReflectEqualityObject()
        {
            _properties = new Dictionary<Type, PropertyInfo[]>();
        }

        public ReflectEqualityObject()
        {
            Type type = GetType();

            if ( !_properties.ContainsKey( type ) )
            {
                _properties[ type ] = type.GetProperties();
            }
        }

        public override bool Equals( object obj )
        {
            Type type = GetType();

            if ( type.IsAssignableFrom( obj.GetType() ) )
            {
                foreach ( PropertyInfo property in _properties[ type ] )
                {
                    var v1 = property.GetValue( this, null );
                    var v2 = property.GetValue( obj, null );
                    if ( property.PropertyType.IsGenericType &&
                        property.PropertyType.GetGenericTypeDefinition().IsAssignableFrom( typeof( List<> ) ) )
                    {
                        Type itemType = v1.GetType().GenericTypeArguments[ 0 ];
                        var list1 = (IList)v1;
                        var list2 = (IList)v2;
                        for ( var i = 0; i < list1.Count; i++ )
                        {
                            var obj1 = Convert.ChangeType( list1[ i ], itemType );
                            var obj2 = Convert.ChangeType( list2[ i ], itemType );
                            if ( !obj1.Equals( obj2 ) ) return false;
                        }
                    }
                    else if ( property.PropertyType.IsArray )
                    {
                        Type itemType = v1.GetType().GetElementType();
                        var list1 = (Array)v1;
                        var list2 = (Array)v2;

                        for ( var i = 0; i < list1.Length; i++ )
                        {
                            var obj1 = Convert.ChangeType( list1.GetValue( i ), itemType );
                            var obj2 = Convert.ChangeType( list2.GetValue( i ), itemType );
                            if ( !obj1.Equals( obj2 ) ) return false;
                        }
                    }
                    else
                    {
                        if ( !v1.Equals( v2 ) ) return false;
                    }
                }

                return true;
            }
            else
            {
                return base.Equals( obj );
            }
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach ( PropertyInfo property in _properties[ GetType() ] )
            {
                var value = property.GetValue( this, null );
                if ( value == null )
                {
                    hash ^= 0;
                }
                else
                {
                    hash ^= value.GetHashCode();
                }
            }

            return hash;
        }
    }
}