/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using FluentCamlGen.CamlGen.Elements.Value;

namespace FluentCamlGen.CamlGen.Elements.Core
{
    // DO NOT ADD CHILD-CG's OR ATTRIBUTES HERE!

    /// <summary>
    /// Create &lt;QueryOptions> ... &lt;/QueryOptions>
    /// </summary>
    public class QueryOptions : BaseCoreElement
    {
        public QueryOptions(params BaseValueElement[] inner) :
            base("QueryOptions", null, inner)
        {
        }

        /// <summary>
        /// Add an &lt;ExpandUserFields>-Tag 
        /// </summary>
        /// <param name="value"></param>
        /// <returns><seealso cref="QueryOptions"/></returns>
        public QueryOptions ExpandUserField(bool value)
        {
            Childs.Add(new ExpandUserField(value));
            return this;
        }

        /// <summary>
        /// Add an &lt;DatesInUtc>-Tag 
        /// </summary>
        /// <param name="value"></param>
        /// <returns><seealso cref="QueryOptions"/></returns>
        public QueryOptions DatesInUtc(bool value)
        {
            Childs.Add(new DatesInUtc(value));
            return this;
        }
    }
}