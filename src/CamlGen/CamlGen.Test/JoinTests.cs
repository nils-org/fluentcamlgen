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
    public class JoinTests : TestBase
    {
        [TestMethod]
        public void BareCgJoinReturnsAJoinTagWithNoAttributes()
        {
            var list = Fixture.Create<string>();
            var sut = CG.Join(list);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Join Type=""INNER"" ListAlias=""{0}"" />
", list));
        }
    }
}