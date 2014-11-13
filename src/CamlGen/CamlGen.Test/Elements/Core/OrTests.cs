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
    public class OrTests : TestBase
    {
        [Test]
        public void SimpleOrReturnsEmptyOrTag()
        {
            var sut = CG.Or();
            sut.ToString().Should().BeEquivalentTo(@"<Or />");
        }

        [Test]
        public void EqOnOrReturnsAnEqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Eq();

            sut.ToString().Should().BeEquivalentTo(@"<Or><Eq /></Or>");
        }

        [Test]
        public void NeqOnOrReturnsAnNeqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Neq();

            sut.ToString().Should().BeEquivalentTo(@"<Or><Neq /></Or>");
        }

        [Test]
        public void GeqOnOrReturnsAnGeqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Geq();

            sut.ToString().Should().BeEquivalentTo(@"<Or><Geq /></Or>");
        }

        [Test]
        public void GtOnOrReturnsAnGtTagInAnOrTag()
        {
            var sut = new Or();
            sut.Gt();

            sut.ToString().Should().BeEquivalentTo(@"<Or><Gt /></Or>");
        }

        [Test]
        public void LeqOnOrReturnsAnLeqTagInAnOrTag()
        {
            var sut = new Or();
            sut.Leq();

            sut.ToString().Should().BeEquivalentTo(@"<Or><Leq /></Or>");
        }

        [Test]
        public void LtOnOrReturnsAnLtTagInAnOrTag()
        {
            var sut = new Or();
            sut.Lt();

            sut.ToString().Should().BeEquivalentTo(@"<Or><Lt /></Or>");
        }

        [Test]
        public void NestedOrOnOrReturnsAnOrTagInAnOrTag()
        {
            var sut = new Or();
            sut.NestedOr(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<Or><Or /></Or>");
        }

        [Test]
        public void AndOnOrReturnsAnAndTagInAnOrTag()
        {
            var sut = new Or();
            sut.And(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<Or><And /></Or>");
        }
    }
}