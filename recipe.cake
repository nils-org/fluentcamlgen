//#load nuget:https://www.myget.org/F/cake-contrib/api/v3/index.json?package=Cake.Recipe&prerelease
#load nuget:?package=Cake.Recipe&version=1.1.2

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "FluentCamlGen",
  masterBranchName: "main",
  repositoryOwner: "nils-org",
  repositoryName: "fluentcamlgen",
  shouldRunDupFinder: false, // for now...
  shouldRunGitVersion: true,
  shouldRunCodecov: true,
  shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
