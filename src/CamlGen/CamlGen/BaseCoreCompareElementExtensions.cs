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
using FluentCamlGen.CamlGen.Elements.Core;
using FluentCamlGen.CamlGen.Elements.Value;

namespace FluentCamlGen.CamlGen
{
    /// <summary>
    /// Nice Extensions to work on Compare-Elements
    /// </summary>
    public static class BaseCoreCompareElementExtensions
    {
        /// <summary>
        /// Add a &lt;FieldRef>-Attribute
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T AddFieldRef<T>(this T @this, string name)
            where T : BaseCoreCompareElement<T>
        {
            return AddFieldRef(@this, name, x => { });
        }

        /// <summary>
        /// Add a &lt;FieldRef>-Attribute
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T AddFieldRef<T>(this T @this, string name, Action<FieldRef> action)
            where T : BaseCoreCompareElement<T>
        {
            var fieldRef = new FieldRef(name);
            action(fieldRef);
            @this.Childs.Add(fieldRef);
            return @this;
        }

        /// <summary>
        /// Add a &lt;Value>-Attribute
        /// </summary>
        /// <param name="this"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddValue<T>(this T @this, CG.ValueType type, string value)
            where T : BaseCoreCompareElement<T>
        {
            return AddValue(@this, type, value, x => { });
        }

        /// <summary>
        /// Add a &lt;Value>-Attribute
        /// </summary>
        /// <param name="this"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T AddValue<T>(this T @this, CG.ValueType type, string value, Action<Value> action)
            where T : BaseCoreCompareElement<T>
        {
            var val = new Value(type, value);
            action(val);
            @this.Childs.Add(val);
            return @this;
        }

        /// <summary>
        /// Add a &lt;Value Type="Number">-Attribute
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T AddNumberValue<T>(this T @this, double value)
            where T : BaseCoreCompareElement<T>
        {
            return AddNumberValue(@this, value, x => { });
        }

        /// <summary>
        /// Add a &lt;Value Type="Number">-Attribute
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T AddNumberValue<T>(this T @this, double value, Action<Value> action)
            where T : BaseCoreCompareElement<T>
        {
            var val = new NumberValue(value);
            action(val);
            @this.Childs.Add(val);
            return @this;
        }

    }
}