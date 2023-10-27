/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using Shouldly;

using FluentCamlGen.CamlGen.Elements.Core;

using Xunit;

using System.Linq;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class ViewTests : TestBase
    {
        [Fact]
        public void BareCgViewReturnsAViewTagWithNoAttributes()
        {
            var sut = CG.View();
            sut.ToString().ShouldBe(@"<View />");
        }

        [Fact]
        public void JoinsOnViewReturnsAViewTagWithJoins()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.Joins(x => { });

            sut.ToString().ShouldBe(@"<View><Joins /></View>");
        }

        [Fact]
        public void ProjectedFieldsOnViewReturnsAViewTagWithProjectedFields()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.ProjectedFields(x => { });

            sut.ToString().ShouldBe(@"<View><ProjectedFields /></View>");
        }

        [Fact]
        public void QueryOnViewReturnsAViewTagWithQuery()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.Query();

            sut.ToString().ShouldBe(@"<View><Query /></View>");
        }

        [Fact]
        public void QueryOptionsOnViewReturnsAViewTagWithQueryOptions()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.QueryOptions(x => { });

            sut.ToString().ShouldBe(@"<View><QueryOptions /></View>");
        }

        [Fact]
        public void ViewFieldsOnViewReturnsAViewTagWithViewFields()
        {
            var sut = new View(Enumerable.Empty<BaseCoreElement>());
            sut.ViewFields(x => { });

            sut.ToString().ShouldBe(@"<View><ViewFields /></View>");
        }
    }
}
