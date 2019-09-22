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
            var version = GitVersion.For(typeof(GitVersionTests).GetTypeInfo().Assembly);

            version.Should().NotBeNull();
            version.SemVer.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void EqualToEachOther()
        {
            var version = GitVersion.For(typeof(GitVersionTests).GetTypeInfo().Assembly);
            var version2 = GitVersion.For(typeof(GitVersionTests).GetTypeInfo().Assembly);
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
            var version = GitVersion.For(typeof(GitVersionTests).GetTypeInfo());

            version.Should().NotBeNull();
            version.HasVersion.Should().BeTrue();
        }

        [Fact]
        public void ForType()
        {
            var version = GitVersion.For(typeof(GitVersionTests));

            version.Should().NotBeNull();
            version.HasVersion.Should().BeTrue();
        }

        [Fact]
        public void ForManyTypesAndReduce()
        {
            var version = GitVersion.For(typeof(GitVersionTests), typeof(GitVersionTests));

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyTypeInfosAndReduce()
        {
            var version = GitVersion.For(typeof(GitVersionTests).GetTypeInfo(), typeof(GitVersionTests).GetTypeInfo());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyAssembliesAndReduce()
        {
            var version = GitVersion.For(typeof(GitVersionTests).GetTypeInfo().Assembly, typeof(GitVersionTests).GetTypeInfo().Assembly);

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyTypesAndReduceEnumerable()
        {
            var version = GitVersion.For(new[] { typeof(GitVersionTests), typeof(GitVersionTests) }.AsEnumerable());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyTypeInfosAndReduceEnumerable()
        {
            var version = GitVersion.For(new[] { typeof(GitVersionTests).GetTypeInfo(), typeof(GitVersionTests).GetTypeInfo() }.AsEnumerable());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }

        [Fact]
        public void ForManyAssembliesAndReduceEnumerable()
        {
            var version = GitVersion.For(new[] { typeof(GitVersionTests).GetTypeInfo().Assembly, typeof(GitVersionTests).GetTypeInfo().Assembly }.AsEnumerable());

            version.Should().NotBeNull();
            version.Should().HaveCount(1);
        }
    }
}
