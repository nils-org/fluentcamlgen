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
using System.Linq;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;FieldRef Name="..." ... />.
    /// <seealso href="https://learn.microsoft.com/en-us/sharepoint/dev/schema/fieldref-element-contenttype"/>
    /// </summary>
    public class FieldRef : BaseCoreElement
    {
        internal FieldRef(string name)
            : this(name, Enumerable.Empty<Tuple<string, string>>())
        {
        }

        internal FieldRef(string name, IEnumerable<Tuple<string, string>> additionalAttributes)
            : base("FieldRef", JoinNameAttr(name, additionalAttributes), null)
        {
        }

        private static IEnumerable<Tuple<string, string>> JoinNameAttr(
            string name,
            IEnumerable<Tuple<string, string>>
            additionalAttributes)
        {
            return new[] { new Tuple<string, string>("Name", name) }
                .Union(additionalAttributes);
        }
    }
}
