/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using AutoFixture;

using FluentAssertions;

using FluentCamlGen.CamlGen.Elements.Value;

using NSubstitute;

using NUnit.Framework;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    [TestFixture]
    public class BaseValueElementCtorTests : TestBase
    {
        [Test]
        public void AnEmptyTagoutReturnsTheBareTag()
        {
            var tag = Fixture.Create<string>();
            var sut = Substitute.ForPartsOf<BaseValueElement>(tag, string.Empty);
            var actual = sut.ToString(false, 0);
            actual.Should().BeEquivalentTo(string.Format(@"<{0}></{0}>", tag));
        }

        [Test]
        public void CamlTagAttributeReturnsTheTagAndTheAttribute()
        {
            var tag = Fixture.Create<string>();
            var value = Fixture.Create<string>();

            var sut = Substitute.ForPartsOf<BaseValueElement>(tag, value);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}>{1}</{0}>", tag, value));
        }
    }
}