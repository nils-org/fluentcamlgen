///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var rootDir = Directory("..");
var srcDir = rootDir + Directory("src");
var binDir = rootDir + Directory("bin");
var distDir = rootDir + Directory("dist");

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(binDir);
    CleanDirectory(distDir);
});

Task("Build")
    .IsDependentOn("Clean")
    .DoesForEach(new[]{
        "CamlGen"
    } , (f) =>
{
    var file = srcDir + File($"{f}/{f}.sln");
    NuGetRestore(file);
    MSBuild(file, settings => settings
        .SetVerbosity(Verbosity.Normal)
        .SetConfiguration(configuration)
        .WithTarget("Build")
    );
});

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);