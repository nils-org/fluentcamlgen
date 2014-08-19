/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System;
using System.Collections.Generic;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// &lt;Eq> ... &lt;/Eq>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ms479601(v=office.15).aspx"/>
    /// </summary>
    public class Eq : BaseCoreElement
    {
        internal Eq()
            : base("Eq", null, (IEnumerable<BaseElement>) null)
        {
        }

        internal Eq(BaseElement lhs, BaseElement rhs)
            : this()
        {
            Childs.Add(lhs);
            Childs.Add(rhs);
        }

        /// <summary>
        /// Add a &lt;FieldRef>-Attribute
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Eq AddFieldRef(string name)
        {
            return AddFieldRef(name, x => { });
        }

        /// <summary>
        /// Add a &lt;FieldRef>-Attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public Eq AddFieldRef(string name, Action<FieldRef> action)
        {
            var fieldRef = new FieldRef(name);
            action(fieldRef);
            Childs.Add(fieldRef);
            return this;
        }

        /// <summary>
        /// Add a &lt;Value>-Attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Eq AddValue(Value.Value.ValueType type, string value)
        {
            return AddValue(type, value, x => { });
        }

        /// <summary>
        /// Add a &lt;Value>-Attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public Eq AddValue(Value.Value.ValueType type, string value, Action<Value.Value> action)
        {
            var val = new Value.Value(type, value);
            action(val);
            Childs.Add(val);
            return this;
        }

        /// <summary>
        /// Add a &lt;Value Type="Number">-Attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Eq AddNumberValue(double value)
        {
            return AddNumberValue(value, x => { });
        }

        /// <summary>
        /// Add a &lt;Value Type="Number">-Attribute
        /// </summary>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public Eq AddNumberValue(double value, Action<Value.Value> action)
        {
            var val = new Value.NumberValue(value);
            action(val);
            Childs.Add(val);
            return this;
        }

    }
}