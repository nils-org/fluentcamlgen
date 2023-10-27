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

using FluentCamlGen.CamlGen.Elements.Value;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    
    public class RowLimitTests : TestBase
    {
        [Fact]
        public void RowLimitWitANumberPrintsTheRowLimit()
        {
            var limit = Fixture.Create<int>();
            var sut = new RowLimit(limit, null);

            sut.ToString().ShouldBe(string.Format("<RowLimit>{0}</RowLimit>", limit));
        }
        
        [Fact]
        public void RowLimitPagedWitANumberPrintsTheRowLimit()
        {
            var limit = Fixture.Create<int>();
            var sut = new RowLimit(limit, true);

            sut.ToString().ShouldBe(string.Format("<RowLimit Paged=\"TRUE\">{0}</RowLimit>", limit));
        }
        
        [Fact]
        public void RowLimitNotPagedWitANumberPrintsTheRowLimit()
        {
            var limit = Fixture.Create<int>();
            var sut = new RowLimit(limit, false);

            sut.ToString().ShouldBe(string.Format("<RowLimit Paged=\"FALSE\">{0}</RowLimit>", limit));
        }

        [Fact]
        public void AViewCanSetARowLimit()
        {
            var limit = Fixture.Create<int>();
            var sut = CG.View().RowLimit(limit);

            sut.ToString().ShouldBe(string.Format("<View><RowLimit>{0}</RowLimit></View>", limit));
        }
    }
}