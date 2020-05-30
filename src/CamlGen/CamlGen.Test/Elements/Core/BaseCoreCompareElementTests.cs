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

namespace FluentCamlGen.CamlGen.Test.Elements.Core
{
    [TestFixture]
    public class BaseCoreCompareElementTests : TestBase
    {
        [Test]
        public void EmptyEq()
        {
            var sut = CG.Eq();
            sut.ToString().Should().Be(@"<Eq />");
        }

        [Test]
        public void EmptyNeq()
        {
            var sut = CG.Neq();
            sut.ToString().Should().Be(@"<Neq />");
        }

        [Test]
        public void EmptyGt()
        {
            var sut = CG.Gt();
            sut.ToString().Should().Be(@"<Gt />");
        }

        [Test]
        public void EmptyGeq()
        {
            var sut = CG.Geq();
            sut.ToString().Should().Be(@"<Geq />");
        }

        [Test]
        public void EmptyLt()
        {
            var sut = CG.Lt();
            sut.ToString().Should().Be(@"<Lt />");
        }

        [Test]
        public void EmptyLeq()
        {
            var sut = CG.Leq();
            sut.ToString().Should().Be(@"<Leq />");
        }
    }
}