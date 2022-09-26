#load nuget:?package=Cake.Recipe&version=3.0.1

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
  shouldRunCodecov: true,
  shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
