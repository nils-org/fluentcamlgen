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
    public class ViewTests : TestBase
    {
        [Test]
        public void BareCgViewReturnsAViewTagWithNoAttributes()
        {
            var sut = CG.View();
            sut.ToString().Should().BeEquivalentTo(@"<View />");
        }
    }
}