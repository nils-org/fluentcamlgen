/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System.Xml;
using System.Xml.Linq;

namespace FluentCamlGen.CamlGen.Test
{
    public static class FluentXmlExtensions
    {
        /// <summary>
        /// Parse the string as XML
        /// </summary>
        /// <param name="this"></param>
        /// <returns><see cref="XmlDocument"/></returns>
        public static XDocument AsXml(this string @this)
        {
            var doc = XDocument.Parse(@this);
            return doc;
        }
    }
}