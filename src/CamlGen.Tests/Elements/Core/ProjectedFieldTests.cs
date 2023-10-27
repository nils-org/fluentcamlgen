/*
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
*/

using AutoFixture;

using Shouldly;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class ProjectedFieldTests : TestBase
    {
        [Fact]
        public void BareCgProjectedFieldReturnsAProjectedFieldTagWithAttributes()
        {
            var name = Fixture.Create<string>();
            var type = Fixture.Create<string>();
            var list = Fixture.Create<string>();
            var showFileld = Fixture.Create<string>();
            var sut = CG.ProjectedField(name, type, list, showFileld);
            sut.ToString()
               .ShouldBe($@"<Field Name=""{name}"" Type=""{type}"" List=""{list}"" ShowField=""{showFileld}"" />");
        }
    }
}
