/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

namespace FluentCamlGen.CamlGen
{
    public class BaseValueTag : ITag
    {
        private readonly string _tagName;
        private readonly string _value;

        internal BaseValueTag(string tagName, string value)
        {
            _tagName = tagName;
            _value = value;
        }

        public override string ToString()
        {
            return ToString(false, 0);
        }

        public string ToString(bool formatCaml, int indent)
        {
            var spaces = new string(' ', indent);
            return string.Format("{0}<{1}>{2}</{1}>", spaces, _tagName, _value);
        }
    }
}