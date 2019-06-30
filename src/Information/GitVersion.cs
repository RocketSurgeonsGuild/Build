using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Rocket.Surgery.Build.Information
{
    /// <summary>
    /// GitVersion.
    /// Implements the <see cref="System.IEquatable{Rocket.Surgery.Build.Information.GitVersion}" />
    /// </summary>
    /// <seealso cref="System.IEquatable{Rocket.Surgery.Build.Information.GitVersion}" />
    /// <seealso cref="IEquatable{GitVersion}" />
    public class GitVersion : IEquatable<GitVersion>
    {
        private readonly InformationProvider _information;

        /// <summary>
        /// Fors the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>GitVersion.</returns>
        public static GitVersion For(Assembly assembly)
        {
            return new GitVersion(assembly);
        }

        /// <summary>
        /// Fors the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns>IDictionary&lt;Assembly, GitVersion&gt;.</returns>
        public static IDictionary<Assembly, GitVersion> For(IEnumerable<Assembly> assemblies)
        {
            return assemblies.Distinct().ToDictionary(x => x, For);
        }

        /// <summary>
        /// Fors the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns>IDictionary&lt;Assembly, GitVersion&gt;.</returns>
        public static IDictionary<Assembly, GitVersion> For(params Assembly[] assemblies)
        {
            return assemblies.Distinct().ToDictionary(x => x, For);
        }

        /// <summary>
        /// Fors the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>GitVersion.</returns>
        public static GitVersion For(Type type)
        {
            return new GitVersion(type.GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Fors the specified types.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>IDictionary&lt;Assembly, GitVersion&gt;.</returns>
        public static IDictionary<Assembly, GitVersion> For(IEnumerable<Type> types)
        {
            return For(types.Select(x => x.GetTypeInfo().Assembly).Distinct());
        }

        /// <summary>
        /// Fors the specified types.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>IDictionary&lt;Assembly, GitVersion&gt;.</returns>
        public static IDictionary<Assembly, GitVersion> For(params Type[] types)
        {
            return For(types.Select(x => x.GetTypeInfo().Assembly).Distinct());
        }

        /// <summary>
        /// Fors the specified type information.
        /// </summary>
        /// <param name="typeInfo">The type information.</param>
        /// <returns>GitVersion.</returns>
        public static GitVersion For(TypeInfo typeInfo)
        {
            return new GitVersion(typeInfo.Assembly);
        }

        /// <summary>
        /// Fors the specified type infos.
        /// </summary>
        /// <param name="typeInfos">The type infos.</param>
        /// <returns>IDictionary&lt;Assembly, GitVersion&gt;.</returns>
        public static IDictionary<Assembly, GitVersion> For(IEnumerable<TypeInfo> typeInfos)
        {
            return For(typeInfos.Select(x => x.Assembly).Distinct());
        }

        /// <summary>
        /// Fors the specified type infos.
        /// </summary>
        /// <param name="typeInfos">The type infos.</param>
        /// <returns>IDictionary&lt;Assembly, GitVersion&gt;.</returns>
        public static IDictionary<Assembly, GitVersion> For(params TypeInfo[] typeInfos)
        {
            return For(typeInfos.Select(x => x.Assembly).Distinct());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GitVersion" /> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        private GitVersion(Assembly assembly)
        {
            _information = new InformationProvider(assembly);
            _information.Infer(this);
        }

        /// <summary>
        /// Does this assembly has any of these attributes?
        /// </summary>
        /// <value><c>true</c> if this instance has version; otherwise, <c>false</c>.</value>
        public bool HasVersion => _information.HasPrefix("GitVersion_");

        /// <summary>
        /// Gets the major.
        /// </summary>
        /// <value>The major.</value>
        [Prefix("GitVersion_")] public int Major { get; private set; }
        /// <summary>
        /// Gets the minor.
        /// </summary>
        /// <value>The minor.</value>
        [Prefix("GitVersion_")] public int Minor { get; private set; }
        /// <summary>
        /// Gets the patch.
        /// </summary>
        /// <value>The patch.</value>
        [Prefix("GitVersion_")] public int Patch { get; private set; }
        /// <summary>
        /// Gets the pre release tag.
        /// </summary>
        /// <value>The pre release tag.</value>
        [Prefix("GitVersion_")] public string PreReleaseTag { get; private set; }
        /// <summary>
        /// Gets the pre release tag with dash.
        /// </summary>
        /// <value>The pre release tag with dash.</value>
        [Prefix("GitVersion_")] public string PreReleaseTagWithDash { get; private set; }
        /// <summary>
        /// Gets the build meta data.
        /// </summary>
        /// <value>The build meta data.</value>
        [Prefix("GitVersion_")] public string BuildMetaData { get; private set; }
        /// <summary>
        /// Gets the build meta data padded.
        /// </summary>
        /// <value>The build meta data padded.</value>
        [Prefix("GitVersion_")] public string BuildMetaDataPadded { get; private set; }
        /// <summary>
        /// Gets the full build meta data.
        /// </summary>
        /// <value>The full build meta data.</value>
        [Prefix("GitVersion_")] public string FullBuildMetaData { get; private set; }
        /// <summary>
        /// Gets the major minor patch.
        /// </summary>
        /// <value>The major minor patch.</value>
        [Prefix("GitVersion_")] public string MajorMinorPatch { get; private set; }
        /// <summary>
        /// Gets the sem ver.
        /// </summary>
        /// <value>The sem ver.</value>
        [Prefix("GitVersion_")] public string SemVer { get; private set; }
        /// <summary>
        /// Gets the legacy sem ver.
        /// </summary>
        /// <value>The legacy sem ver.</value>
        [Prefix("GitVersion_")] public string LegacySemVer { get; private set; }
        /// <summary>
        /// Gets the legacy sem ver padded.
        /// </summary>
        /// <value>The legacy sem ver padded.</value>
        [Prefix("GitVersion_")] public string LegacySemVerPadded { get; private set; }
        /// <summary>
        /// Gets the assembly sem ver.
        /// </summary>
        /// <value>The assembly sem ver.</value>
        [Prefix("GitVersion_")] public string AssemblySemVer { get; private set; }
        /// <summary>
        /// Gets the full sem ver.
        /// </summary>
        /// <value>The full sem ver.</value>
        [Prefix("GitVersion_")] public string FullSemVer { get; private set; }
        /// <summary>
        /// Gets the informational version.
        /// </summary>
        /// <value>The informational version.</value>
        [Prefix("GitVersion_")] public string InformationalVersion { get; private set; }
        /// <summary>
        /// Gets the name of the branch.
        /// </summary>
        /// <value>The name of the branch.</value>
        [Prefix("GitVersion_")] public string BranchName { get; private set; }
        /// <summary>
        /// Gets the sha.
        /// </summary>
        /// <value>The sha.</value>
        [Prefix("GitVersion_")] public string Sha { get; private set; }
        /// <summary>
        /// Gets the nu get version v2.
        /// </summary>
        /// <value>The nu get version v2.</value>
        [Prefix("GitVersion_")] public string NuGetVersionV2 { get; private set; }
        /// <summary>
        /// Gets the nu get version.
        /// </summary>
        /// <value>The nu get version.</value>
        [Prefix("GitVersion_")] public string NuGetVersion { get; private set; }
        /// <summary>
        /// Gets the commits since version source.
        /// </summary>
        /// <value>The commits since version source.</value>
        [Prefix("GitVersion_")] public int CommitsSinceVersionSource { get; private set; }
        /// <summary>
        /// Gets the commits since version source padded.
        /// </summary>
        /// <value>The commits since version source padded.</value>
        [Prefix("GitVersion_")] public string CommitsSinceVersionSourcePadded { get; private set; }
        /// <summary>
        /// Gets the commit date.
        /// </summary>
        /// <value>The commit date.</value>
        [Prefix("GitVersion_")] public string CommitDate { get; private set; }

        /// <summary>
        /// Gets the repository url.
        /// </summary>
        /// <value>The repository URL.</value>
        public string RepositoryUrl { get; private set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as GitVersion);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        public bool Equals(GitVersion other)
        {
            return other != null &&
                   Major == other.Major &&
                   Minor == other.Minor &&
                   Patch == other.Patch &&
                   PreReleaseTag == other.PreReleaseTag &&
                   PreReleaseTagWithDash == other.PreReleaseTagWithDash &&
                   InformationalVersion == other.InformationalVersion &&
                   BranchName == other.BranchName &&
                   Sha == other.Sha &&
                   CommitDate == other.CommitDate;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            var hashCode = -1073977946;
            hashCode = hashCode * -1521134295 + Major.GetHashCode();
            hashCode = hashCode * -1521134295 + Minor.GetHashCode();
            hashCode = hashCode * -1521134295 + Patch.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PreReleaseTag);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PreReleaseTagWithDash);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(InformationalVersion);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BranchName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Sha);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CommitDate);
            return hashCode;
        }

        /// <summary>
        /// Implements the == operator.
        /// </summary>
        /// <param name="version1">The version1.</param>
        /// <param name="version2">The version2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GitVersion version1, GitVersion version2)
        {
            return EqualityComparer<GitVersion>.Default.Equals(version1, version2);
        }

        /// <summary>
        /// Implements the != operator.
        /// </summary>
        /// <param name="version1">The version1.</param>
        /// <param name="version2">The version2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GitVersion version1, GitVersion version2)
        {
            return !(version1 == version2);
        }
    }
}
