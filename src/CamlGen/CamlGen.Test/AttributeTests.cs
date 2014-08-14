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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test
{
    [TestClass]
    public class AttributeTests : TestBase
    {
        [TestMethod]
        public void CGWithoutAttributeReturnsTheBareTag()
        {
            var tag = Fixture.Create<string>();
            var sut = new CG(tag);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} />
", tag));
        }

        [TestMethod]
        public void CGWithOneAttributeReturnsTheTagAndTheAttribute()
        {
            var tag = Fixture.Create<string>();
            var attrName = Fixture.Create<string>();
            var attrVal = Fixture.Create<string>();

            var sut = new CG(tag, new Tuple<string, string>(attrName, attrVal));
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<{0} {1}=""{2}"" />
", tag, attrName, attrVal));
        }
    }
}
