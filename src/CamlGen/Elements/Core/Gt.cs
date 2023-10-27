/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

namespace FluentCamlGen.CamlGen.Elements.Core
{
    /// <summary>
    /// &lt;Gt> ... &lt;/Gt>.
    /// <seealso href="https://learn.microsoft.com/en-us/sharepoint/dev/schema/gt-element-query"/>
    /// </summary>
    public class Gt : BaseCoreCompareElement<Gt>
    {
        internal Gt(params BaseElement[] operands)
            : base("Gt", operands)
        {
        }
    }
}
