/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FluentCamlGen.CamlGen.Elements.Value
{
    /// <summary>
    /// BaseClass for Value-Elements.
    /// </summary>
    public class BaseValueElement : BaseElement
    {
        private readonly string _tagName;
        private readonly string _value;

        internal BaseValueElement(string tagName, string value)
        {
            Attributes = new List<Tuple<string, string>>();
            _tagName = tagName;
            _value = value;
        }

        internal IList<Tuple<string, string>> Attributes { get; private set; }

        /// <summary>
        /// Call this to get the Caml-String.
        /// </summary>
        /// <param name="formatCaml">true, if CAML should be pretty formatted.</param>
        /// <param name="indent">number of spaces to insert for indentation.</param>
        /// <returns>The CAML string.</returns>
        public override string ToString(bool formatCaml, int indent)
        {
            var spaces = new string(' ', indent);
            var sb = new StringBuilder();
            sb.Append($"{spaces}<{_tagName}");
            foreach (var attribute in Attributes)
            {
                sb.Append($" {attribute.Item1}=\"{attribute.Item2}\"");
            }

            sb.Append($">{_value}</{_tagName}>");

            return sb.ToString();
        }

        internal static string GetValue(bool value)
        {
            return value ? "True" : "False";
        }

        internal static string GetValue(double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
