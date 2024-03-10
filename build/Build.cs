using Nuke.Common;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.GitVersion;
using Serilog;

partial class Build : NukeBuild
{
    // public static int Main() => Execute<Build>(x => x.Compile);

    static int Main()
    {
        return Execute<Build>(build => build.Compile);
    }

    protected override void OnBuildInitialized()
    {
        Log.Information("Build version: {Version}", Version.SemVer);
        CreateArtifactDirectories();
    }
}
