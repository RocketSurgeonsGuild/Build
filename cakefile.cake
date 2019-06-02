#load "nuget:?package=Rocket.Surgery.Cake.Library&version=0.9.7";

Task("Default")
    .IsDependentOn("dotnetcore");

RunTarget(Target);
