/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

namespace FluentCamlGen.CamlGen.Elements
{
    /// <summary>
    /// Base-Interface for a Tag.
    /// </summary>
    public abstract class BaseElement
    {
        /// <summary>
        /// Call this to get the Caml-String
        /// <seealso cref="ToString(bool)"/>
        /// </summary>
        /// <returns>CAML</returns>
        public override string ToString()
        {
            return ToString(false, 0);
        }

        /// <summary>
        /// Call this to get the Caml-String
        /// </summary>
        /// <param name="formatCaml">true, if CAML should be pretty formatted</param>
        /// <returns></returns>
        public string ToString(bool formatCaml)
        {
            return ToString(formatCaml, 0);
        }

        /// <summary>
        /// Call this to get the Caml-String
        /// </summary>
        /// <param name="formatCaml">true, if CAML should be pretty formatted</param>
        /// <param name="indent">number of spaces to insert for indentation.</param>
        /// <returns></returns>
        public abstract string ToString(bool formatCaml, int indent);
    }
}