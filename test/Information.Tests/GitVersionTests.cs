using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Rocket.Surgery.Build.Information;
using Rocket.Surgery.Extensions.Testing;
using Xunit.Abstractions;

namespace Rocket.Surgery.Build.Information.Tests
{
    public class GitVersionTests : AutoFakeTest
    {
        public GitVersionTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        [Fact]
        public void ReturnsInformationForVersionedAssembly()
        {
            var version = GitVersion.For(typeof(GitVersion).GetTypeInfo().Assembly);

            version.Should().NotBeNull();
            version.SemVer.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void EqualToEachOther()
        {
            var version = GitVersion.For(typeof(GitVersion).GetTypeInfo().Assembly);
            var version2 = GitVersion.For(typeof(GitVersion).GetTypeInfo().Assembly);
            version.Should().NotBeNull();
            version.Should().Be(version2);
        }

        [Fact]
        public void NotHaveAVersionForNonVersionedAssembly()
        {
            var version = GitVersion.For(typeof(string).GetTypeInfo().Assembly);
            version.HasVersion.Should().BeFalse();
        }

        [Fact]
        public void ForTypeInfo()
        {
            var version = GitVersion.For(typeof(GitVersion).GetTypeInfo());

            version.Should().NotBeNull();
            version.HasVersion.Should().BeTrue();
        }

        [Fact]
        public void ForType()
        {
            var version = GitVersion.For(typeof(GitVersion));

            version.Should().NotBeNull();
            version.HasVersion.Should().BeTrue();
        }

        [Fact]
        public void ForManyTypesAndReduce()
        {
            var version = GitVersion.For(typeof(GitVersion), typeof(GitVersion));

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyTypeInfosAndReduce()
        {
            var version = GitVersion.For(typeof(GitVersion).GetTypeInfo(), typeof(GitVersion).GetTypeInfo());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyAssembliesAndReduce()
        {
            var version = GitVersion.For(typeof(GitVersion).GetTypeInfo().Assembly, typeof(GitVersion).GetTypeInfo().Assembly);

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyTypesAndReduceEnumerable()
        {
            var version = GitVersion.For(new[] { typeof(GitVersion), typeof(GitVersion) }.AsEnumerable());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyTypeInfosAndReduceEnumerable()
        {
            var version = GitVersion.For(new[] { typeof(GitVersion).GetTypeInfo(), typeof(GitVersion).GetTypeInfo() }.AsEnumerable());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyAssembliesAndReduceEnumerable()
        {
            var version = GitVersion.For(new[] { typeof(GitVersion).GetTypeInfo().Assembly, typeof(GitVersion).GetTypeInfo().Assembly }.AsEnumerable());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }
    }
}
