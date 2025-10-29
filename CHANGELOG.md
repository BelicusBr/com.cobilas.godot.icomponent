# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.2] (29/10/2025)
### Changed
- Consolidated all property definitions into a single `<PropertyGroup>` section
- Replaced `<PackageVersion>` with `<Version>` element
- Updated package dependencies:
  - `Cobilas.Core.Net4x` from version 2.7.0 to 2.7.1
  - Added `Cobilas.Godot.Utility` version 7.0.1 as a regular package reference (previously conditional)
- Modified output path to include configuration: `C:\local.nuget\$(Configuration)` (was `C:\local.nuget`)
- Removed `netstandard2.1` from package tags
- Updated debug/release configuration properties:
  - Added `<WarningLevel>4</WarningLevel>`
  - Added `<CheckForOverflowUnderflow>True</CheckForOverflowUnderflow>`
  - Removed `<DefineConstants>` configuration
- Made Godot assembly references unconditional (previously only in Debug configuration)
- Removed conditional project reference to `com.cobilas.godot.utility`
- Made package generation on build unconditional (previously only in Release)

### Added
- `<BaseOutputPath>bin\$(Configuration)</BaseOutputPath>`
- `<NoWarn>` element to suppress specific warnings
- `<AssemblyName>com.cobilas.godot.icomponent</AssemblyName>`
- Package description
- `<IncludeSymbols>True</IncludeSymbols>` and `<SymbolPackageFormat>snupkg</SymbolPackageFormat>`

### Removed
- Conditional package reference to `Cobilas.Godot.Utility` (now always included)
- Project reference to `com.cobilas.godot.utility`
- `<DebugType>portable</DebugType>`

## [1.1.1] (17/10/2025)
### Changed
Package dependencies have been updated to the latest versions.
## [1.1.0] (28/08/2025)
### Changed
Package dependencies have been updated to the latest versions.
## [1.0.0] (31/07/2025)
### Changed
All objects have been properly documented for a better understanding of the objects or functions.
## [1.0.0] (17/07/2025)
### Added
Interfaces for transforming node objects into pseudo components have been added.