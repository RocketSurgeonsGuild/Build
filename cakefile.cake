#load "nuget:?package=Rocket.Surgery.Cake.Library&version=0.9.4";

Task("Default")
    .IsDependentOn("dotnetcore");

RunTarget(Target);
