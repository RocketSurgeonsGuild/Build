# Rocket Surgeons Build Metadata

Every good Rocket Surgeon needs a way to know where there code came from.  This package embededs metadata into your assemblies for a few purposes:


# What does it do?
1) Build Validation
  * Know where your assembly came from.  Was it built on appveyor, gitlab, or azure pipelines
    * Current supports:
    * AppVeyor
    * GitLab
    * Azure Pipelines
2) Storing `GitVersion` information, useful for validating versions of assemblies in your application.
3) Build Source Linking
  * Enables some sane defaults for SourceLink packages
4) JetBrains.Annotations
  * Brings in `JetBrains.Annotations` automagically as a source file.
5) Adds support for a new `ItemGroup` Item `<InternalsVisibleTo Include="MyAssembly" />`
5) Adds support for a new `ItemGroup` Item `<AssemblyMetadata Include="Key" Value="Value" />`
6) The information package allows for exatracting

# Status
<!-- badges -->
[![github-release-badge]][github-release]
[![github-license-badge]][github-license]
[![codecov-badge]][codecov]
<!-- badges -->

<!-- history badges -->
| Azure Pipelines | AppVeyor |
| --------------- | -------- |
| [![azurepipelines-badge]][azurepipelines] | [![appveyor-badge]][appveyor] |
| [![azurepipelines-history-badge]][azurepipelines-history] | [![appveyor-history-badge]][appveyor-history] |
<!-- history badges -->

<!-- nuget packages -->
| Package | NuGet | MyGet |
| ------- | ----- | ----- |
| Rocket.Surgery.Build.Information | [![nuget-version-8k3un2tofhma-badge]![nuget-downloads-8k3un2tofhma-badge]][nuget-8k3un2tofhma] | [![myget-version-8k3un2tofhma-badge]![myget-downloads-8k3un2tofhma-badge]][myget-8k3un2tofhma] |
| Rocket.Surgery.Build.Metadata | [![nuget-version-feevisq63few-badge]![nuget-downloads-feevisq63few-badge]][nuget-feevisq63few] | [![myget-version-feevisq63few-badge]![myget-downloads-feevisq63few-badge]][myget-feevisq63few] |
<!-- nuget packages -->

# Whats next?
TBD

<!-- generated references -->
[github-release]: https://github.com/RocketSurgeonsGuild/Build/releases/latest
[github-release-badge]: https://img.shields.io/github/release/RocketSurgeonsGuild/Build.svg?logo=github&style=flat "Latest Release"
[github-license]: https://github.com/RocketSurgeonsGuild/Build/blob/master/LICENSE
[github-license-badge]: https://img.shields.io/github/license/RocketSurgeonsGuild/Build.svg?style=flat "License"
[codecov]: https://codecov.io/gh/RocketSurgeonsGuild/Build
[codecov-badge]: https://img.shields.io/codecov/c/github/RocketSurgeonsGuild/Build.svg?color=E03997&label=codecov&logo=codecov&logoColor=E03997&style=flat "Code Coverage"
[azurepipelines]: https://rocketsurgeonsguild.visualstudio.com/Libraries/_build/latest?definitionId=5&branchName=master
[azurepipelines-badge]: https://img.shields.io/azure-devops/build/rocketsurgeonsguild/Libraries/5.svg?color=98C6FF&label=azure%20pipelines&logo=azuredevops&logoColor=98C6FF&style=flat "Azure Pipelines Status"
[azurepipelines-history]: https://rocketsurgeonsguild.visualstudio.com/Libraries/_build?definitionId=5&branchName=master
[azurepipelines-history-badge]: https://buildstats.info/azurepipelines/chart/rocketsurgeonsguild/Libraries/5?includeBuildsFromPullRequest=false "Azure Pipelines History"
[appveyor]: https://ci.appveyor.com/project/RocketSurgeonsGuild/Build
[appveyor-badge]: https://img.shields.io/appveyor/ci/RocketSurgeonsGuild/Build.svg?color=00b3e0&label=appveyor&logo=appveyor&logoColor=00b3e0&style=flat "AppVeyor Status"
[appveyor-history]: https://ci.appveyor.com/project/RocketSurgeonsGuild/Build/history
[appveyor-history-badge]: https://buildstats.info/appveyor/chart/RocketSurgeonsGuild/Build?includeBuildsFromPullRequest=false "AppVeyor History"
[nuget-8k3un2tofhma]: https://www.nuget.org/packages/Rocket.Surgery.Build.Information/
[nuget-version-8k3un2tofhma-badge]: https://img.shields.io/nuget/v/Rocket.Surgery.Build.Information.svg?color=004880&logo=nuget&style=flat-square "NuGet Version"
[nuget-downloads-8k3un2tofhma-badge]: https://img.shields.io/nuget/dt/Rocket.Surgery.Build.Information.svg?color=004880&logo=nuget&style=flat-square "NuGet Downloads"
[myget-8k3un2tofhma]: https://www.myget.org/feed/rocket-surgeons-guild/package/nuget/Rocket.Surgery.Build.Information
[myget-version-8k3un2tofhma-badge]: https://img.shields.io/myget/rocket-surgeons-guild/vpre/Rocket.Surgery.Build.Information.svg?label=myget&color=004880&logo=nuget&style=flat-square "MyGet Pre-Release Version"
[myget-downloads-8k3un2tofhma-badge]: https://img.shields.io/myget/rocket-surgeons-guild/dt/Rocket.Surgery.Build.Information.svg?color=004880&logo=nuget&style=flat-square "MyGet Downloads"
[nuget-feevisq63few]: https://www.nuget.org/packages/Rocket.Surgery.Build.Metadata/
[nuget-version-feevisq63few-badge]: https://img.shields.io/nuget/v/Rocket.Surgery.Build.Metadata.svg?color=004880&logo=nuget&style=flat-square "NuGet Version"
[nuget-downloads-feevisq63few-badge]: https://img.shields.io/nuget/dt/Rocket.Surgery.Build.Metadata.svg?color=004880&logo=nuget&style=flat-square "NuGet Downloads"
[myget-feevisq63few]: https://www.myget.org/feed/rocket-surgeons-guild/package/nuget/Rocket.Surgery.Build.Metadata
[myget-version-feevisq63few-badge]: https://img.shields.io/myget/rocket-surgeons-guild/vpre/Rocket.Surgery.Build.Metadata.svg?label=myget&color=004880&logo=nuget&style=flat-square "MyGet Pre-Release Version"
[myget-downloads-feevisq63few-badge]: https://img.shields.io/myget/rocket-surgeons-guild/dt/Rocket.Surgery.Build.Metadata.svg?color=004880&logo=nuget&style=flat-square "MyGet Downloads"
<!-- generated references -->

<!-- nuke-data
github:
  owner: RocketSurgeonsGuild
  repository: Build
azurepipelines:
  account: rocketsurgeonsguild
  teamproject: Libraries
  builddefinition: 5
appveyor:
  account: RocketSurgeonsGuild
  build: Build
myget:
  account: rocket-surgeons-guild
-->