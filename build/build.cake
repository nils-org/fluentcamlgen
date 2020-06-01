#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1
#tool nuget:?package=coveralls.io&version=1.4.2
#tool nuget:?package=OpenCover&version=4.7.922
#addin nuget:?package=Cake.Coveralls&version=0.10.1
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
    .Does(() =>
{
    var file = srcDir + File("CamlGen/CamlGen.sln");
    NuGetRestore(file);
    MSBuild(file, settings => settings
        .SetVerbosity(Verbosity.Minimal)
        .SetConfiguration(configuration)
        .WithTarget("Build")
    );
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    var tests = GetFiles(srcDir + File($"**/bin/{configuration}/*.Test.dll"));
    var coverFile = binDir + File("Coverage.xml");

    OpenCover(cc => {
        cc.NUnit3(tests);
    },
        coverFile,
        new OpenCoverSettings()
        .WithFilter("+[FluentCamlGen.CamlGen]*")
        .WithFilter("-[FluentCamlGen.CamlGen.Tests]*")
    );

    var coverallsRepoToken = EnvironmentVariable("COVERALLS_REPO_TOKEN");
    if(coverallsRepoToken == null) {
        Warning("no coveralls repo-token. NOT pushing coverage!");
        DeleteFile(coverFile);
        return;
    }

    Information("sending coverage to coveralls.io");
    CoverallsIo(coverFile.Path, new CoverallsIoSettings{
        RepoToken = coverallsRepoToken
    });
    DeleteFile(coverFile);
});

Task("Dist")
    .IsDependentOn("Build")
    .Does(() =>
{
    var nuspec = (srcDir + File("CamlGen/CamlGen.nuspec")).Path;
    var nugetFiles = new List<NuSpecContent>();
    var dependencies = new List<NuSpecDependency>();
    var frameworkAssemblies = new List<NuSpecFrameworkAssembly>();

    // add the dlls
    var targets = GetDirectories(binDir + File("*"));
    var xmlDoc = (binDir + File("FluentCamlGen.CamlGen.xml")).Path; // include this in all targets..
    foreach(var t in targets)
    {
        var target = t.GetDirectoryName();
    
        // dependencyGruop
        dependencies.Add(new NuSpecDependency(){
            TargetFramework = target
        });

        // frameworkAssemblies
        frameworkAssemblies.Add(new NuSpecFrameworkAssembly{
            AssemblyName = "System.Core",
            TargetFramework = target
        });

        // files
        var files = GetFiles(t + File("**/*"));
        nugetFiles.AddRange(files.Select(f => new NuSpecContent { Source = f.FullPath, Target = "lib/"+target} ));
        nugetFiles.Add(new NuSpecContent { Source = xmlDoc.FullPath, Target = "lib/"+target} );
    }

    // add readme, license
    foreach(var file in new[]{
        (rootDir + File("AUTHORS.md")).Path,
        //(rootDir + File("CHANGELG.md")).Path,
        (rootDir + File("LICENSE.md")).Path,
        (rootDir + File("README.md")).Path
    }) {
        nugetFiles.Add(new NuSpecContent { Source = file.FullPath, Target = ""} );
    }

    // version etc?!
    var assemblyInfo = ParseAssemblyInfo( rootDir + File("resources/GlobalAssemblyInfo.cs"));
    
    var additionalSettings = new NuGetPackSettings{ 
        OutputDirectory     = distDir,
        Files               = nugetFiles.ToArray(),
        BasePath            = srcDir,
        Copyright           = assemblyInfo.Copyright,
        Version             = assemblyInfo.AssemblyVersion,
        Dependencies        = dependencies,
        FrameworkAssemblies = frameworkAssemblies
    };

    // TODO: authors form authors-file?!
    // TODO: releasenotes from Changelog?!

    NuGetPack(nuspec, additionalSettings);
});

Task("Default")
    .IsDependentOn("Test")
    .IsDependentOn("Dist");

RunTarget(target);