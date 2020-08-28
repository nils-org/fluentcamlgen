/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using FluentAssertions;

using NUnit.Framework;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    [TestFixture]
    public class DatesInUtcTests : TestBase
    {
        [Test]
        public void ExpandUserFieldsWithATrueValueReturnsTrue()
        {
            CG.DatesInUtc(true).ToString().Should().Be("<DatesInUtc>True</DatesInUtc>");
        }

        [Test]
        public void ExpandUserFieldsWithAFalseValueReturnsFalse()
        {
            CG.DatesInUtc(false).ToString().Should().Be("<DatesInUtc>False</DatesInUtc>");
        }
    }
}