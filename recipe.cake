#load nuget:?package=Chocolatey.Cake.Recipe&version=0.4.2

// test

///////////////////////////////////////////////////////////////////////////////
// ADDINS
///////////////////////////////////////////////////////////////////////////////

// (None)

///////////////////////////////////////////////////////////////////////////////
// RECIPE SETUP
///////////////////////////////////////////////////////////////////////////////

Environment.SetVariableNames();

Func<FilePathCollection> getProjectsToPack = ()=> GetFiles(BuildParameters.SourceDirectoryPath + "/**/*.csproj")
        - GetFiles(BuildParameters.RootDirectoryPath + "/tools/**/*.csproj")
        - GetFiles(BuildParameters.SourceDirectoryPath + "/**/*.Tests.csproj")
        - GetFiles(BuildParameters.SourceDirectoryPath + "/packages/**/*.csproj")
        - GetFiles(BuildParameters.SourceDirectoryPath + "/**/*.AdminTool.csproj");

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    solutionFilePath: "./Rhino.Licensing.sln",
    title: "Rhino.Licensing",
    repositoryOwner: "chocolatey",
    repositoryName: "rhino-licensing",
    productName: "Rhino Licensing",
    productDescription: "Licensing Framework for .NET.",
    productCopyright: "Copyright (c) 2005 - 2009 Ayende Rahien (ayende@ayende.com).",
    shouldStrongNameOutputAssemblies: false,
    shouldObfuscateOutputAssemblies: false,
    shouldAuthenticodeSignOutputAssemblies: false,
    shouldStrongNameSignDependentAssemblies: false,
    shouldRunInspectCode: false,
    treatWarningsAsErrors: false,
    testDirectoryPath: "./test",
    shouldRunDotNetCorePack: true,
    getProjectsToPack: getProjectsToPack);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

///////////////////////////////////////////////////////////////////////////////
// PROJECT SPECIFIC TASKS
///////////////////////////////////////////////////////////////////////////////

// (None)

///////////////////////////////////////////////////////////////////////////////
// RUN IT!
///////////////////////////////////////////////////////////////////////////////

Build.RunDotNetCore();
