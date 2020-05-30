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
    public class WhereTests : TestBase
    {
        [Test]
        public void CgWhereReturnsAnEmptyWhereTag()
        {
            var sut = CG.Where();
            sut.ToString().Should().BeEquivalentTo(@"<Where />");
        }

        [Test]
        public void WhereCanAddAnd()
        {
            var sut = new Where();
            sut.And();

            sut.ToString().Should().BeEquivalentTo(@"<Where><And /></Where>");
        }

        [Test]
        public void WhereCanAddOr()
        {
            var sut = new Where();
            sut.Or(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<Where><Or /></Where>");
        }

        [Test]
        public void WhereCanAddEq()
        {
            var sut = new Where().Eq(x => { });
            sut.ToString().Should().BeEquivalentTo(@"<Where><Eq /></Where>");
        }

        [Test]
        public void WhereCanAddNeq()
        {
            var sut = new Where().Neq(x => { });
            sut.ToString().Should().BeEquivalentTo(@"<Where><Neq /></Where>");
        }

        [Test]
        public void WhereCanAddGt()
        {
            var sut = new Where().Gt(x => { });
            sut.ToString().Should().BeEquivalentTo(@"<Where><Gt /></Where>");
        }

        [Test]
        public void WhereCanAddGeq()
        {
            var sut = new Where().Geq(x => { });
            sut.ToString().Should().BeEquivalentTo(@"<Where><Geq /></Where>");
        }

        [Test]
        public void WhereCanAddLt()
        {
            var sut = new Where().Lt(x => { });
            sut.ToString().Should().BeEquivalentTo(@"<Where><Lt /></Where>");
        }

        [Test]
        public void WhereCanAddLeq()
        {
            var sut = new Where().Leq(x => { });
            sut.ToString().Should().BeEquivalentTo(@"<Where><Leq /></Where>");
        }
    }
}