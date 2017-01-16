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
    /// &lt;Neq> ... &lt;/Neq>
    /// <seealso href="http://msdn.microsoft.com/en-us/library/ms452901.aspx"/>
    /// </summary>
    public class Neq : BaseCoreCompareElement<Neq>
    {
        internal Neq(params BaseElement[] operands)
            : base("Neq", operands)
        {
        }
    }
}