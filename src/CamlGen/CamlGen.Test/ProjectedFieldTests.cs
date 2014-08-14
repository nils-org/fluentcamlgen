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
    public class ProjectedFieldTests : TestBase
    {
        [TestMethod]
        public void BareCgProjectedFieldReturnsAProjectedFieldTagWithAttributes()
        {
            var name = Fixture.Create<string>();
            var type = Fixture.Create<string>();
            var list = Fixture.Create<string>();
            var showFileld = Fixture.Create<string>();
            var sut = CG.ProjectedField(name, type, list, showFileld);
            sut.ToString().Should().BeEquivalentTo(string.Format(@"<Field Name=""{0}"" Type=""{1}"" List=""{2}"" ShowField=""{3}"" />
", name, type, list, showFileld));

        }
    }
}