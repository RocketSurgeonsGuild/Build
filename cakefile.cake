#load "nuget:?package=Rocket.Surgery.Cake.Library&version=0.9.9";

Task("Default")
    .IsDependentOn("dotnetcore");

RunTarget(Target);
