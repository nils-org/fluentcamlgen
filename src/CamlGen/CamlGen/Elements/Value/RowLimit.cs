/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System.Globalization;

namespace FluentCamlGen.CamlGen.Elements.Value
{
    internal class RowLimit : BaseValueElement
    {
        internal RowLimit(int rowLimit)
            : base("RowLimit", rowLimit.ToString(CultureInfo.InvariantCulture))
        {
        }
    }
}