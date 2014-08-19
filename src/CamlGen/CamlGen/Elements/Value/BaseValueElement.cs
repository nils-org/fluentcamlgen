/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

namespace FluentCamlGen.CamlGen.Elements.Value
{
    public class BaseValueElement : BaseElement
    {
        private readonly string _tagName;
        private readonly string _value;

        internal BaseValueElement(string tagName, string value)
        {
            _tagName = tagName;
            _value = value;
        }

        /// <summary>
        /// Call this to get the Caml-String
        /// </summary>
        /// <param name="formatCaml">true, if CAML should be pretty formatted</param>
        /// <param name="indent">number of spaces to insert for indentation.</param>
        /// <returns></returns>
        public override string ToString(bool formatCaml, int indent)
        {
            var spaces = new string(' ', indent);
            return string.Format("{0}<{1}>{2}</{1}>", spaces, _tagName, _value);
        }

        internal static string GetValue(bool value)
        {
            return value ? "True" : "False";
        }
    }
}