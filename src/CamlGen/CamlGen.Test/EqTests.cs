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
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test
{
    [TestFixture]
    public class EqTests : TestBase
    {
        [Test]
        public void BareCgJoinReturnsAJoinTagWithNoAttributes()
        {
            var lhs = Fixture.Create<CG>();
            var rhs = Fixture.Create<CG>();
            var sut = CG.Eq(lhs, rhs);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Eq>{0}{1}</Eq>", lhs, rhs));
        }
    }
}