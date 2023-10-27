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

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    
    public class QueryOptionsTest
    {
        [Fact]
        public void EmptyQueryOptionsReturnsAQueryOptionsTag()
        {
            var sut = CG.QueryOptions();
            sut.ToString().ShouldBe("<QueryOptions />");
        }

        [Fact]
        public void QueryOptionsWithDatesInUtcReturnsAFilledQueryOptionsTag()
        {
            var sut = CG.QueryOptions(
                        CG.DatesInUtc(true));
            sut.ToString().ShouldBe("<QueryOptions><DatesInUtc>True</DatesInUtc></QueryOptions>");
        }

        [Fact]
        public void QueryOptionsInAViewWithFluentlyDatesInUtcReturnsAllNestedTags()
        {
            var sut = CG.View()
                        .QueryOptions(qo => qo
                        .DatesInUtc(true));
            sut.ToString().ShouldBe("<View><QueryOptions><DatesInUtc>True</DatesInUtc></QueryOptions></View>");
        }

        [Fact]
        public void QueryOptionsWithFluentlyExpandUserFieldReturnsTheNestedExpandUserField()
        {
            var sut = CG.QueryOptions()
                        .ExpandUserField(true);
            sut.ToString().ShouldBe("<QueryOptions><ExpandUserField>True</ExpandUserField></QueryOptions>");
        }
    }
}
