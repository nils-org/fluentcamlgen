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

namespace FluentCamlGen.CamlGen.Test.Features
{
    /// <summary>
    /// 1. Ensure that a join to the "User Information List" is possible, see http://social.msdn.microsoft.com/Forums/de-DE/e5d607fe-b437-4a67-ad9c-5cc5a8284a66/csom-javascript-inner-join-caml-query-on-user-information-list?forum=sharepointdevelopment
    /// </summary>
    [TestFixture]
    public class Feature1
    {
        private const string ExpectedXml = @"<View>
  <Query />
  <ViewFields>
    <FieldRef Name=""Title"" />
    <FieldRef Name=""Contact"" />
    <FieldRef Name=""UserName"" />
    <FieldRef Name=""UserEMail"" />
    <FieldRef Name=""UserMobilePhone"" />
  </ViewFields>
  <ProjectedFields>
    <Field Type=""Lookup"" Name=""UserName""  List=""User Information List"" ShowField=""Name"" />
    <Field Name=""UserEMail"" Type=""Lookup"" List=""User Information List"" ShowField=""EMail"" />
    <Field Name=""UserMobilePhone"" Type=""Lookup"" List=""User Information List"" ShowField=""MobilePhone"" />
  </ProjectedFields>
  <Joins>
    <Join Type=""INNER"" ListAlias=""User Information List"">
      <Eq>
        <FieldRef RefType=""Id"" Name=""Contact""/>
        <FieldRef Name=""ID"" List=""User Information List"" />
      </Eq>
    </Join>
  </Joins>
</View>";

        [Test]
        public void Feature1Passes()
        {
            var expected = ExpectedXml.AsXml();

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
                    CG.InnerJoin("User Information List", "Contact")
                    )
                );

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Feature1PassesFluently()
        {
            var expected = ExpectedXml.AsXml();

            var sut = CG.View()
                        .Query()
                        .ViewFields(vf =>
                                    vf.AddFieldRef("Title")
                                      .AddFieldRef("Contact")
                                      .AddFieldRef("UserName")
                                      .AddFieldRef("UserEMail")
                                      .AddFieldRef("UserMobilePhone"))
                        .ProjectedFields(pf =>
                                         pf.AddField("UserName", "Lookup", "User Information List", "Name")
                                           .AddField("UserEMail", "Lookup", "User Information List", "EMail")
                                           .AddField("UserMobilePhone", "Lookup", "User Information List", "MobilePhone"))
                        .Joins(js => js.AddInnerJoin("User Information List", "Contact"));

            sut.ToString().AsXml().Should().BeEquivalentTo(expected);
        }
    }
}