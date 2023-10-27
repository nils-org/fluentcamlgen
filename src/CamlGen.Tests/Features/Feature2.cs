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
using Xunit;

namespace FluentCamlGen.CamlGen.Test.Features
{
    public class Feature2
    {
        private const string ExpectedXml = @"<View>
<Query>
    <Where>
    <And>
        <Eq>
        <FieldRef Name=""Year"" />
        <Value Type=""Number"">2014</Value>
        </Eq>
        <Eq>
        <FieldRef Name=""CalendarWeek"" />
        <Value Type=""Number"">51</Value>
        </Eq>
    </And>
    </Where>
</Query>
<ViewFields>
    <FieldRef Name=""Year"" />
    <FieldRef Name=""CalendarWeek"" />
    <FieldRef Name=""Workload"" />
</ViewFields>
<QueryOptions>
    <ExpandUserField>False</ExpandUserField>
</QueryOptions>
</View>";

        [Fact]
        public void Feature2Passes()
        {
            var expected = ExpectedXml.AsXml();

            var sut = CG.View(
                        CG.Query(
                            CG.Where(
                                CG.And(
                                    CG.Eq(
                                        CG.FieldRef("Year"),
                                        CG.NumberValue(2014)),
                                    CG.Eq(
                                        CG.FieldRef("CalendarWeek"),
                                        CG.NumberValue(51))))),
                        CG.ViewFields(
                            CG.FieldRef("Year"),
                            CG.FieldRef("CalendarWeek"),
                            CG.FieldRef("Workload")),
                        CG.QueryOptions(
                            CG.ExpandUserField(false)));

            sut.ToString().AsXml().ShouldBe(expected);
        }

        [Fact]
        public void Feature2PassesFluently()
        {
            var expected = ExpectedXml.AsXml();

            var sut = CG.View()
                        .Query(q => q
                            .Where(w => w
                                .And(a => a
                                    .Eq(eq => eq
                                        .AddFieldRef("Year")
                                        .AddNumberValue(2014d))
                                    .Eq(eq => eq
                                        .AddFieldRef("CalendarWeek")
                                        .AddNumberValue(51)))))
                        .ViewFields(vf => vf
                            .AddFieldRef("Year")
                            .AddFieldRef("CalendarWeek")
                            .AddFieldRef("Workload"))
                        .QueryOptions(qo => qo
                            .ExpandUserField(false));

            sut.ToString().AsXml().ShouldBe(expected);
        }
    }
}
