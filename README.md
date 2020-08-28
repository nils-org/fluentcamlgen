# FluentCamlGen 

![CI](https://github.com/nils-org/fluentcamlgen/workflows/CI/badge.svg)
[![Nuget](https://img.shields.io/nuget/v/FluentCamlGen)](https://www.nuget.org/packages/FluentCamlGen/)
[![Coverage Status](https://coveralls.io/repos/github/nils-org/fluentcamlgen/badge.svg?branch=develop)](https://coveralls.io/github/nils-org/fluentcamlgen?branch=develop)

> The fluent CAML Generator
>
> This is a Generator for CAML, as used in SharePoint environments.

## Installation

Using [nuget](https://www.nuget.org/packages/FluentCamlGen/) use one of:

```
Install-Package FluentCamlGen
dotnet add package FluentCamlGen 
paket add FluentCamlGen
```

## Status

Some features of [CAML](https://docs.microsoft.com/en-us/sharepoint/dev/schema/collaborative-application-markup-language-caml-schemas) are supported. Some are not. Create an issue if you miss something.

## Usage

### Example 1

to create 
```xml
<View>
  <Query />
  <ViewFields>
    <FieldRef Name="Title" />
    <FieldRef Name="Contact" />
    <FieldRef Name="UserName" />
    <FieldRef Name="UserEMail" />
    <FieldRef Name="UserMobilePhone" />
  </ViewFields>
  <ProjectedFields>
    <Field Type="Lookup" Name="UserName"  List="User Information List" ShowField="Name" />
    <Field Name="UserEMail" Type="Lookup" List="User Information List" ShowField="EMail" />
    <Field Name="UserMobilePhone" Type="Lookup" List="User Information List" ShowField="MobilePhone" />
  </ProjectedFields>
  <Joins>
    <Join Type="INNER" ListAlias="User Information List">
      <Eq>
        <FieldRef RefType="Id" Name="Contact"/>
        <FieldRef Name="ID" List="User Information List" />
      </Eq>
    </Join>
  </Joins>
</View>
```

one can write:

```cs
CG.View(
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
    ).ToString();
```

or alternatively:

```cs
CG.View()
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
    .Joins(js => js.AddInnerJoin("User Information List", "Contact"))
    .ToString();
```


### Example 2
to create 
```xml
<View>
  <Query>
    <Where>
      <And>
        <Eq>
        <FieldRef Name="Year" />
        <Value Type="Number">2014</Value>
        </Eq>
        <Eq>
        <FieldRef Name="CalendarWeek" />
        <Value Type="Number">51</Value>
        </Eq>
      </And>
    </Where>
  </Query>
  <ViewFields>
    <FieldRef Name="Year" />
    <FieldRef Name="CalendarWeek" />
    <FieldRef Name="Workload" />
  </ViewFields>
  <QueryOptions>
    <ExpandUserField>False</ExpandUserField>
  </QueryOptions>
</View>
```

one can write:

```cs
CG.View(
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
        CG.ExpandUserField(false))).ToString();
```

or alternatively:

```cs
CG.View()
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
        .ExpandUserField(false))
    .ToString();
```

### Example 3
to create 
```xml
<And>
    <Eq>
        <FieldRef Name='Year' />
        <Value Type='Number'>{0}</Value>
    </Eq>
    <And>
        <Geq>
            <FieldRef Name='CalendarWeek' />
            <Value Type='Number'>{1}</Value>
        </Geq>
        <Lt>
            <FieldRef Name='CalendarWeek' />
            <Value Type='Number'>{2}</Value>
        </Lt>
    </And>
</And>
```

one can write:

```cs
CG.And(
    CG.Eq(CG.FieldRef("Year"), CG.NumberValue(year)),
    CG.And(
        CG.Geq(CG.FieldRef("CalendarWeek"), CG.NumberValue(start)),
        CG.Lt(CG.FieldRef("CalendarWeek"), CG.NumberValue(end))
        )
    ).ToString();
```

or alternatively:

```cs
CG.And()
    .Eq(eq => eq.AddFieldRef("Year").AddNumberValue(year))
    .And(and => and
        .Geq(geq => geq.AddFieldRef("CalendarWeek").AddNumberValue(start))
        .Lt(lt => lt.AddFieldRef("CalendarWeek").AddNumberValue(end)))
    .ToString();
```
