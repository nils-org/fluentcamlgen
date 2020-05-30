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

using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class ProjectedFieldsTests : TestBase
    {
        [Test]
        public void BareCgProjectedFieldsReturnsAProjectedFieldsTagWithNoAttributes()
        {
            var sut = CG.ProjectedFields();
            sut.ToString().Should().BeEquivalentTo(@"<ProjectedFields />");
        }

        [Test]
        public void AddFieldReturnsAProjectedFieldsTagWithAField()
        {
            var name = Fixture.Create<string>();
            var type = Fixture.Create<string>();
            var list = Fixture.Create<string>();
            var showField = Fixture.Create<string>();

            var sut = new ProjectedFields();
            sut.AddField(name, type, list, showField);

            sut.ToString().Should().BeEquivalentTo(string.Format(@"<ProjectedFields><Field Name=""{0}"" Type=""{1}"" List=""{2}"" ShowField=""{3}"" /></ProjectedFields>", name, type, list, showField));
        }
    }
}