﻿using System.Collections.Generic;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Tools.GitVersion;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Rocket.Surgery.Build.Cake
{
    public static class LocalCakeAliases
    {
        [CakePropertyAlias(Cache = true)]
        public static Local Local(this ICakeContext context)
        {
            return new Local(
                Target(context),
                Configuration(context),
                ArtifactsPath(context),
                GitVer(context)
                );
        }

        [CakePropertyAlias(Cache = true)]
        public static string Target(this ICakeContext context)
        {
            return context.Argument("target", "Build");
        }

        [CakePropertyAlias(Cache = true)]
        public static string Configuration(this ICakeContext context)
        {
            return context.Argument("configuration", "Debug");
        }

        [CakePropertyAlias(Cache = true)]
        public static DirectoryPath ArtifactsPath(this ICakeContext context)
        {
            return DirectoryPath.FromString("./artifacts");
        }

        [CakeMethodAlias]
        public static string Artifact(this ICakeContext context, string path)
        {
            return ArtifactsPath(context) + "/" + path.TrimStart('/', '\\');
        }

        [CakeMethodAlias]
        public static FilePath ArtifactFilePath(this ICakeContext context, string path)
        {
            return FilePath.FromString(ArtifactsPath(context) + "/" + path.TrimStart('/', '\\'));
        }

        [CakeMethodAlias]
        public static DirectoryPath ArtifactDirectoryPath(this ICakeContext context, string path)
        {
            return DirectoryPath.FromString(ArtifactsPath(context) + "/" + path.TrimStart('/', '\\'));
        }

        [CakePropertyAlias(Cache = true)]
        public static GitVersion GitVer(this ICakeContext context)
        {
            return context.GitVersion();
        }
    }

    public static class CommonCakeAliases
    {
        [CakeMethodAlias]
        public static IEnumerable<FilePath> GetArtifacts(this ICakeContext context, string glob)
        {
            return context.GetFiles($"{context.ArtifactsPath()}/{glob}");
        }
    }
}
