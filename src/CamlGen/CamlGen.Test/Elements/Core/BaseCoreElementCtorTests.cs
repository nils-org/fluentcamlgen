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

using FluentCamlGen.CamlGen.Elements.Core;

using NSubstitute;

using NUnit.Framework;

using System;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class BaseCoreElementCtorTests : TestBase
    {
        [Test]
        public void ATagWithoutAdditionalParamsReturnsTheBareTag()
        {
            var tag = Fixture.Create<string>();
            var sut = Substitute.ForPartsOf<BaseCoreElement>(tag);
            var actual = sut.ToString(false, 0);
            actual.Should().BeEquivalentTo(string.Format(@"<{0} />", tag));
        }

        [Test]
        public void ATagWithAnAttributeReturnsTheTagAndTheAttribute()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();

            var sut = Substitute.ForPartsOf<BaseCoreElement>(tag, new Tuple<string, string>(attrName, attrVal));
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} {1}=""{2}"" />", tag, attrName, attrVal));
        }

        [Test]
        public void ATagWithAnInnerTagReturnsTheTagAndTheNested()
        {
            var tag = Fixture.Create<string>();
            var inner = Fixture.Create<BaseCoreElement>();

            var sut = Substitute.ForPartsOf<BaseCoreElement>(tag, inner);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}>{1}</{0}>", tag, inner));
        }

        [Test]
        public void CamlTagAttributeAndInnerCgReturnsTheTagWithAttributeAndTheNestedCg()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();
            var inner = Fixture.Create<BaseCoreElement>();
            var attrs = new[] { new Tuple<string, string>(attrName, attrVal) };
            var inners = new[] { inner };

            var sut = Substitute.ForPartsOf<BaseCoreElement>(tag, attrs, inners);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} {1}=""{2}"">{3}</{0}>", tag, attrName, attrVal, inner));
        }
    }
}