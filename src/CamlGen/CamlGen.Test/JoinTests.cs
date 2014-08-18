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
    public class JoinTests : TestBase
    {
        [Test]
        public void BareCgJoinReturnsAJoinTagWithNoAttributes()
        {
            var list = Fixture.Create<string>();
            var lhs = Fixture.Create<BaseCamlTag>();
            var rhs = Fixture.Create<BaseCamlTag>();

            var sut = CG.Join(list, CamlJoin.JoinType.Inner, lhs, rhs);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Join Type=""INNER"" ListAlias=""{0}""><Eq>{1}{2}</Eq></Join>", list, lhs, rhs));
        }
    }
}