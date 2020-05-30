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

using FluentCamlGen.CamlGen.Elements.Value;

using NUnit.Framework;

using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    [TestFixture]
    public class RowLimitTests : TestBase
    {
        [Test]
        public void RowLimitWitANumberPrintsTheRowLimit()
        {
            var limit = Fixture.Create<int>();
            var sut = new RowLimit(limit);

            sut.ToString().Should().Be(string.Format("<RowLimit>{0}</RowLimit>", limit));
        }

        [Test]
        public void AViewCanSetARowLimit()
        {
            var limit = Fixture.Create<int>();
            var sut = CG.View().RowLimit(limit);

            sut.ToString().Should().Be(string.Format("<View><RowLimit>{0}</RowLimit></View>", limit));
        }
    }
}