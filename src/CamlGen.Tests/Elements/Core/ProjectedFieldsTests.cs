/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using AutoFixture;

using Shouldly;

using FluentCamlGen.CamlGen.Elements.Core;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class ProjectedFieldsTests : TestBase
    {
        [Fact]
        public void BareCgProjectedFieldsReturnsAProjectedFieldsTagWithNoAttributes()
        {
            var sut = CG.ProjectedFields();
            sut.ToString().ShouldBe(@"<ProjectedFields />");
        }

        [Fact]
        public void AddFieldReturnsAProjectedFieldsTagWithAField()
        {
            var name = Fixture.Create<string>();
            var type = Fixture.Create<string>();
            var list = Fixture.Create<string>();
            var showField = Fixture.Create<string>();

            var sut = new ProjectedFields();
            sut.AddField(name, type, list, showField);

            sut.ToString().ShouldBe(string.Format(@"<ProjectedFields><Field Name=""{0}"" Type=""{1}"" List=""{2}"" ShowField=""{3}"" /></ProjectedFields>", name, type, list, showField));
        }
    }
}