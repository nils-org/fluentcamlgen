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

using System.Linq;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class ViewTests : TestBase
    {
        [Test]
        public void BareCgViewReturnsAViewTagWithNoAttributes()
        {
            var sut = CG.View();
            sut.ToString().Should().BeEquivalentTo(@"<View />");
        }

        [Test]
        public void JoinsOnViewReturnsAViewTagWithJoins()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.Joins(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<View><Joins /></View>");
        }

        [Test]
        public void ProjectedFieldsOnViewReturnsAViewTagWithProjectedFields()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.ProjectedFields(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<View><ProjectedFields /></View>");
        }

        [Test]
        public void QueryOnViewReturnsAViewTagWithQuery()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.Query();

            sut.ToString().Should().BeEquivalentTo(@"<View><Query /></View>");
        }

        [Test]
        public void QueryOptionsOnViewReturnsAViewTagWithQueryOptions()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.QueryOptions(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<View><QueryOptions /></View>");
        }

        [Test]
        public void ViewFieldsOnViewReturnsAViewTagWithViewFields()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.ViewFields(x => { });

            sut.ToString().Should().BeEquivalentTo(@"<View><ViewFields /></View>");
        }
    }
}