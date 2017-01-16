/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using FluentCamlGen.CamlGen.Elements.Core;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace FluentCamlGen.CamlGen.Test.Features
{
    [TestFixture]
    public class Feature3 : TestBase
    {
        const string Snippet = @"
<And>
    <Eq>
        <FieldRef Name='Year' />
        <Value Type='Number'>{0}</Value>
    </Eq>
    <And>
        <Geq>
            <FieldRef Name='CalendarWeek' />
            <Value Type='Number'>{1}</Value>
        </Geq>
        <Lt>
            <FieldRef Name='CalendarWeek' />
            <Value Type='Number'>{2}</Value>
        </Lt>
    </And>
</And>
"; 
        [Test]
        public void GenerateASnippetTheOldWay()
        {
            var year = Fixture.Create<int>();
            var start = Fixture.Create<int>();
            var end = Fixture.Create<int>();
            var expected = string.Format(Snippet, year, start, end);

            var sut =
                CG.And(
                    CG.Eq(CG.FieldRef("Year"), CG.NumberValue(year)),
                    CG.And(
                        CG.Geq(CG.FieldRef("CalendarWeek"), CG.NumberValue(start)),
                        CG.Lt(CG.FieldRef("CalendarWeek"), CG.NumberValue(end))
                        )
                    );
            sut.ToString().AsXml().Should().BeLooselyEquivalentTo(expected.AsXml());
        }

        [Test]
        public void GenerateASnippetNewFluentWay()
        {
            var year = Fixture.Create<int>();
            var start = Fixture.Create<int>();
            var end = Fixture.Create<int>();
            var expected = string.Format(Snippet, year, start, end);

            var sut =
                CG.And()
                  .Eq(eq => eq.AddFieldRef("Year").AddNumberValue(year))
                  .And(and => and
                    .Geq(geq => geq.AddFieldRef("CalendarWeek").AddNumberValue(start))
                    .Lt(lt => lt.AddFieldRef("CalendarWeek").AddNumberValue(end)));

            sut.ToString().AsXml().Should().BeLooselyEquivalentTo(expected.AsXml());
        }
    }
}