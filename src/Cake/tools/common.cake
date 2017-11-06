var target = Local.Target;
var configuration = Local.Configuration;
var artifacts = Local.Artifacts;

Task("CleanArtifacts")
    .WithCriteria(BuildSystem.IsLocalBuild)
    .Does(() => {
        CleanDirectory(artifacts);
    });
