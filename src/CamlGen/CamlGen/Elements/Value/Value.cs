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

namespace FluentCamlGen.CamlGen.Elements.Value
{
    /// <summary>
    /// &lt;Value>-Tag
    /// </summary>
    public class Value : BaseValueElement
    {
        /// <summary>
        /// possible JoinTypes to add on a Join 
        /// </summary>
        public class ValueType
        {
            private readonly string _type;

            private ValueType(string type)
            {
                _type = type;
            }

            /// <summary>
            /// Number
            /// </summary>
            public static readonly ValueType Number = new ValueType("Number");

            public override string ToString()
            {
                return _type;
            }
        }

        internal Value(ValueType type, string value)
            : base("Value", value)
        {
            Attributes.Add(new Tuple<string, string>("Type", type.ToString()));
        }
    }
}