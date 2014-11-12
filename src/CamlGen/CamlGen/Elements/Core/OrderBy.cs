/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// Create &lt;OrderBy>... &lt;/OrderBy>
    /// <see cref="http://msdn.microsoft.com/en-us/library/office/ms467378.aspx"/>
    /// </summary>
    public class OrderBy : BaseCoreElement
    {
         internal OrderBy(params BaseElement[] fields)
             :base("OrderBy", fields)
         {
         }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ascending">true, for ascending</param>
        /// <returns>Fluent <see cref="OrderBy"/></returns>
        public OrderBy AddFieldRef(string name, bool ascending)
        {
            var field = new FieldRef(name);
            field.AddAttribute("Ascending", ascending ? "TRUE" : "FALSE");
            Childs.Add(field);
            return this;
        }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Fluent <see cref="OrderBy"/></returns>
        public OrderBy AddFieldRefDescending(string name)
        {
            return AddFieldRef(name, false);
        }

        /// <summary>
        /// Add a FieldRef
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Fluent <see cref="OrderBy"/></returns>
        public OrderBy AddFieldRefAscending(string name)
        {
            return AddFieldRef(name, true);
        }
    }
}