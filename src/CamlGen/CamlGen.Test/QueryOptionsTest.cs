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

namespace FluentCamlGen.CamlGen.Test
{
    [TestFixture]
    public class QueryOptionsTest
    {
        /*
          <QueryOptions>
          <ExpandUserField>False</ExpandUserField>
          <DatesInUtc>True</DatesInUtc>
        </QueryOptions>
         */

        [Test]
        public void EmptyQueryOptionsReturnsAQueryOptionsTag()
        {
            var sut = CG.QueryOptions();
            sut.ToString().Should().BeEquivalentTo("<QueryOptions />");
        }

        [Test]
        public void ExpandUserFieldReturnsAnExpandUserFieldTag()
        {
            var sut = CG.ExpandUserField(false);
            sut.ToString().Should().BeEquivalentTo("<ExpandUserField>False</ExpandUserField>");

            sut = CG.ExpandUserField(true);
            sut.ToString().Should().BeEquivalentTo("<ExpandUserField>True</ExpandUserField>");
        }

        [Test]
        public void DatesInUtcReturnsADatesInUtcTag()
        {
            var sut = CG.DatesInUtc(false);
            sut.ToString().Should().BeEquivalentTo("<DatesInUtc>False</DatesInUtc>");

            sut = CG.DatesInUtc(true);
            sut.ToString().Should().BeEquivalentTo("<DatesInUtc>True</DatesInUtc>");
        }

        [Test]
        public void QueryOptionsWithDatesInUtcReturnsAFilledQueryOptionsTag()
        {
            var sut = CG.QueryOptions(
                        CG.DatesInUtc(true));
            sut.ToString().Should().BeEquivalentTo("<QueryOptions><DatesInUtc>True</DatesInUtc></QueryOptions>");
        }

        [Test]
        public void QueryOptionsInAViewWithFluentlyDatesInUtcReturnsAllNestedTags()
        {
            var sut = CG.View()
                        .QueryOptions(qo => qo
                        .DatesInUtc(true));
            sut.ToString().Should().BeEquivalentTo("<View><QueryOptions><DatesInUtc>True</DatesInUtc></QueryOptions></View>");
        }

        [Test]
        public void QueryOptionsWithFluentlyExpandUserFieldReturnsTheNestedExpandUserField()
        {
            var sut = CG.QueryOptions()
                        .ExpandUserField(true);
            sut.ToString().Should().BeEquivalentTo("<QueryOptions><ExpandUserField>True</ExpandUserField></QueryOptions>");
        }
    }
}