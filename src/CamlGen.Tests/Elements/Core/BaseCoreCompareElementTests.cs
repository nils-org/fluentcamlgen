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
    
    public class BaseCoreCompareElementTests : TestBase
    {
        [Fact]
        public void EmptyEq()
        {
            var sut = CG.Eq();
            sut.ToString().ShouldBe(@"<Eq />");
        }

        [Fact]
        public void EmptyNeq()
        {
            var sut = CG.Neq();
            sut.ToString().ShouldBe(@"<Neq />");
        }

        [Fact]
        public void EmptyGt()
        {
            var sut = CG.Gt();
            sut.ToString().ShouldBe(@"<Gt />");
        }

        [Fact]
        public void EmptyGeq()
        {
            var sut = CG.Geq();
            sut.ToString().ShouldBe(@"<Geq />");
        }

        [Fact]
        public void EmptyLt()
        {
            var sut = CG.Lt();
            sut.ToString().ShouldBe(@"<Lt />");
        }

        [Fact]
        public void EmptyLeq()
        {
            var sut = CG.Leq();
            sut.ToString().ShouldBe(@"<Leq />");
        }
    }
}
