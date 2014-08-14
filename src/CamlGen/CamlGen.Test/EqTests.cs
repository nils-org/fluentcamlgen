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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test
{
    [TestClass]
    public class EqTests : TestBase
    {
        [TestMethod]
        public void BareCgJoinReturnsAJoinTagWithNoAttributes()
        {
            var lhs = new CG(Fixture.Create<string>());
            var rhs = new CG(Fixture.Create<string>());
            var sut = CG.Eq(lhs, rhs);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Eq>
  {0}  {1}</Eq>
", lhs, rhs));
        }
    }
}