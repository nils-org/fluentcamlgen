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
using FluentCamlGen.CamlGen.Elements.Core;
using NUnit.Framework;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class AndTests : TestBase
    {
        [Test]
        public void SimpleAndReturnsEmptyAndTag()
        {
            var sut = CG.And();
            sut.ToString().Should().BeEquivalentTo(@"<And />");
        }

        [Test]
        public void EqOnAndReturnsAnEqTagInAnAndTag()
        {
            var sut = new And();
            sut.Eq();

            sut.ToString().Should().BeEquivalentTo(@"<And><Eq /></And>");
        }

        [Test]
        public void NeqOnAndReturnsAnNeqTagInAnAndTag()
        {
            var sut = new And();
            sut.Neq();

            sut.ToString().Should().BeEquivalentTo(@"<And><Neq /></And>");
        }

        [Test]
        public void GeqOnAndReturnsAnGeqTagInAnAndTag()
        {
            var sut = new And();
            sut.Geq();

            sut.ToString().Should().BeEquivalentTo(@"<And><Geq /></And>");
        }

        [Test]
        public void GtOnAndReturnsAnGtTagInAnAndTag()
        {
            var sut = new And();
            sut.Gt();

            sut.ToString().Should().BeEquivalentTo(@"<And><Gt /></And>");
        }

        [Test]
        public void LeqOnAndReturnsAnLeqTagInAnAndTag()
        {
            var sut = new And();
            sut.Leq();

            sut.ToString().Should().BeEquivalentTo(@"<And><Leq /></And>");
        }

        [Test]
        public void LtOnAndReturnsAnLtTagInAnAndTag()
        {
            var sut = new And();
            sut.Lt();

            sut.ToString().Should().BeEquivalentTo(@"<And><Lt /></And>");
        }

        [Test]
        public void OrOnAndReturnsAnOrTagInAnAndTag()
        {
            var sut = new And();
            sut.Or(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<And><Or /></And>");
        }

        [Test]
        public void NestedAndOnAndReturnsAnAndTagInAnAndTag()
        {
            var sut = new And();
            sut.And(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<And><And /></And>");
        }
    }
}