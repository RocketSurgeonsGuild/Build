#load "nuget:?package=Rocket.Surgery.Cake.Library&version=0.9.11";

Task("Default")
    .IsDependentOn("dotnetcore");

RunTarget(Target);
