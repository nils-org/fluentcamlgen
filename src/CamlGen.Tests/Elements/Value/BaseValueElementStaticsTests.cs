/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using Shouldly;

using FluentCamlGen.CamlGen.Elements.Value;

using Xunit;

namespace FluentCamlGen.CamlGen.Test.Elements.Value
{
    
    public class BaseValueElementStaticsTests : TestBase
    {
        [Fact]
        public void GetValueForBoolReturnsTheCorrectWords()
        {
            BaseValueElement.GetValue(true).ShouldBe("True");
            BaseValueElement.GetValue(false).ShouldBe("False");
        }
    }
}