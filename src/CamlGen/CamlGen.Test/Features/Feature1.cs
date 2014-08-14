/***
This File is part of FluentCamlGen

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
***/

using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentCamlGen.CamlGen.Test.Features
{
    /// <summary>
    /// 1. Ensure that a join to the "User Information List" is possible, see http://social.msdn.microsoft.com/Forums/de-DE/e5d607fe-b437-4a67-ad9c-5cc5a8284a66/csom-javascript-inner-join-caml-query-on-user-information-list?forum=sharepointdevelopment
    /// </summary>
    [TestClass]
    public class Feature1
    {
        [TestMethod]
        public void Feature1Passes()
        {
            const string expected = @"<View>
  <Query />
  <ViewFields>
    <FieldRef Name=""Title"" />
    <FieldRef Name=""Contact"" />
    <FieldRef Name=""UserName"" />
    <FieldRef Name=""UserEMail"" />
    <FieldRef Name=""UserMobilePhone"" />
  </ViewFields>
  <ProjectedFields>
    <Field Name=""UserName"" Type=""Lookup"" List=""User Information List"" ShowField=""Name"" />
    <Field Name=""UserEMail"" Type=""Lookup"" List=""User Information List"" ShowField=""EMail"" />
    <Field Name=""UserMobilePhone"" Type=""Lookup"" List=""User Information List"" ShowField=""MobilePhone"" />
  </ProjectedFields>
  <Joins>
    <Join Type=""INNER"" ListAlias=""User Information List"">
      <Eq>
        <FieldRef Name=""Contact"" RefType=""Id"" />
        <FieldRef Name=""ID"" List=""User Information List"" />
      </Eq>
    </Join>
  </Joins>
</View>
";

            var sut = CG.View(
                CG.Query(),
                CG.ViewFields(
                    CG.FieldRef("Title"),
                    CG.FieldRef("Contact"),
                    CG.FieldRef("UserName"),
                    CG.FieldRef("UserEMail"),
                    CG.FieldRef("UserMobilePhone")),
                CG.ProjectedFields(
                    CG.ProjectedField("UserName", "Lookup", "User Information List", "Name"),
                    CG.ProjectedField("UserEMail", "Lookup", "User Information List", "EMail"),
                    CG.ProjectedField("UserMobilePhone", "Lookup", "User Information List", "MobilePhone")),
                CG.Joins(
                    CG.Join("User Information List",
                            CG.Eq(
                                CG.FieldRef("Contact", new Tuple<string, string>("RefType", "Id")),
                                CG.FieldRef("ID", new Tuple<string, string>("List", "User Information List"))
                                )
                        )
                    )
                );

            sut.ToString().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [Ignore]
        public void Feature1InFluentPasses()
        {
            const string expected = @"<View>
  <Query />
  <ViewFields>
    <FieldRef Name=""Title"" />
    <FieldRef Name=""Contact"" />
    <FieldRef Name=""UserName"" />
    <FieldRef Name=""UserEMail"" />
    <FieldRef Name=""UserMobilePhone"" />
  </ViewFields>
  <ProjectedFields>
    <Field Name=""UserName"" Type=""Lookup"" List=""User Information List"" ShowField=""Name"" />
    <Field Name=""UserEMail"" Type=""Lookup"" List=""User Information List"" ShowField=""EMail"" />
    <Field Name=""UserMobilePhone"" Type=""Lookup"" List=""User Information List"" ShowField=""MobilePhone"" />
  </ProjectedFields>
  <Joins>
    <Join Type=""INNER"" ListAlias=""User Information List"">
      <Eq>
        <FieldRef Name=""Contact"" RefType=""Id"" />
        <FieldRef Name=""ID"" List=""User Information List"" />
      </Eq>
    </Join>
  </Joins>
</View>
";
            var sut = CG.View();
            /*.Query()
                .ViewFields(vf => 
                    vf.AddFieldRef("Title")
                      .AddFieldRef("Contact"))
                .ProjectedFields(pf => 
                    pf.AddField("a", "b")
                      .AddField("D", "D"))
                .Joins(js => 
                    js.AddJoin(Operators.Eq, eq => 
                        eq.AddFieldRef("Contact", fr => fr.addAttribute("RefType", "Id"))
                          .AddFieldRef("ID"), fr => fr.addAttribute("List", "Some List")))
                 * */

            Assert.Fail("Fluent not implemented");
        }
    }
}