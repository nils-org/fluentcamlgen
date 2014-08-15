/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test
{
    [TestFixture]
    public class CtorTests : TestBase
    {
        [Test]
        public void CgWithoutAdditionalParamsReturnsTheBareTag()
        {
            var tag = Fixture.Create<string>();
            var sut = new CG(tag);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} />", tag));
        }

        [Test]
        public void CgWithAttributeReturnsTheTagAndTheAttribute()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();

            var sut = new CG(tag, new Tuple<string, string>(attrName, attrVal));
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} {1}=""{2}"" />", tag, attrName, attrVal));
        }

        [Test]
        public void CgWithInnerCgReturnsTheTagAndTheNestedCg()
        {
            var tag = Fixture.Create<string>();
            var inner = Fixture.Create<CG>();

            var sut = new CG(tag, inner);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0}>{1}</{0}>", tag, inner));
        }

        [Test]
        public void CgWithAttributeAndInnerCgReturnsTheTagWithAttributeAndTheNestedCg()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();
            var inner = Fixture.Create<CG>();
            var attrs = new[] {new Tuple<string, string>(attrName, attrVal)};
            var inners = new[] {inner};

            var sut = new CG(tag, attrs, inners);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} {1}=""{2}"">{3}</{0}>", tag, attrName, attrVal, inner));
        }
    }
}