﻿using System.Collections.Generic;
using System.Text;
using Cake.Common;
using Cake.Common.IO;
using Cake.Common.Tools.GitVersion;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Rocket.Surgery.Build.Cake
{

    public static class CommonCakeAliases
    {
        [CakeMethodAlias]
        public static IEnumerable<FilePath> GetArtifacts(this ICakeContext context, string glob)
        {
            return context.GetFiles($"{context.ArtifactsPath()}/{glob}");
        }

        private static readonly string ByteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

        [CakeMethodAlias]
        public static void CleanBom(this ICakeContext context, FilePath file)
        {
            var withBom = System.IO.File.ReadAllText(file.FullPath);
            System.IO.File.WriteAllText(file.FullPath, withBom.Replace(ByteOrderMarkUtf8, ""));
        }

        [CakeMethodAlias]
        public static void CleanBom(this ICakeContext context, string filePath)
        {
            CleanBom(context, FilePath.FromString(filePath));
        }
    }
}
