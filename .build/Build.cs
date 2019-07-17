using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Buildalyzer;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.ProjectModel;
using Rocket.Surgery.Nuke;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Program : DotNetCoreBuild
{
    /// <summary>
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    /// </summary>

    public static int Main() => Execute<Program>(x => x.Default);

    public Target Default => _ => _.DependsOn(Core);
}
