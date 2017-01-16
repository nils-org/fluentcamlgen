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
    /// &lt;Eq> ... &lt;/Eq>
    /// <seealso href="http://msdn.microsoft.com/en-us/library/ms479601.aspx"/>
    /// </summary>
    public class Eq : BaseCoreCompareElement<Eq>
    {
        internal Eq(params BaseElement[] operands)
            : base("Eq", operands)
        {
        }
    }
}