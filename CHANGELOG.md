# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.3] (29/10/2025)

### Changed
- **Version Update**: Bumped package version from 1.1.2 to 1.1.3
- **Build Configuration**: 
  - Simplified package output path from `C:\local.nuget\$(Configuration)` to `C:\local.nuget`
- **Dependencies**: Updated to latest versions:
  - `Cobilas.Core.Net4x` from 2.7.1 to 2.7.2
  - `Cobilas.Godot.Utility` from 7.0.1 to 7.0.2
- **Project Structure**: 
  - Updated .gitignore to simplified structure focusing on essential folders and files
  - Removed Godot-specific ignores in favor of minimal C# project structure

## [1.1.2] (29/10/2025)

### Changed
- **Project Configuration**: Consolidated all property definitions into a single `<PropertyGroup>` section
- **Version Management**: Replaced `<PackageVersion>` with `<Version>` element
- **Build Output**: Modified output path to include configuration: `C:\local.nuget\$(Configuration)` (was `C:\local.nuget`)
- **Package Metadata**: Updated package tags, removing `netstandard2.1`

### Dependencies
- Updated `Cobilas.Core.Net4x` from version 2.7.0 to 2.7.1
- Added `Cobilas.Godot.Utility` version 7.0.1 as a regular package reference (previously conditional)

### Build System
- **Enhanced Configuration**: 
  - Added `<WarningLevel>4</WarningLevel>` for all configurations
  - Enabled `<CheckForOverflowUnderflow>True</CheckForOverflowUnderflow>`
  - Added specific warning suppressions via `<NoWarn>`
- **Symbol Packages**: Added `<IncludeSymbols>True</IncludeSymbols>` and `<SymbolPackageFormat>snupkg</SymbolPackageFormat>`

### Removed
- Conditional package reference to `Cobilas.Godot.Utility` (now always included)
- Project reference to `com.cobilas.godot.utility`
- `<DebugType>portable</DebugType>` configuration

## [1.1.1] (17/10/2025)
### Changed
- Updated package dependencies to latest versions

## [1.1.0] (28/08/2025)
### Changed
- Updated package dependencies to latest versions

## [1.0.0] (31/07/2025)
### Changed
- Comprehensive documentation of all objects and functions for better understanding

## [1.0.0] (17/07/2025)
### Added
- Initial implementation of interfaces for transforming Node objects into pseudo-components in Unity Engine style
- Core functionality for facilitating object retrieval and child object management in Godot Engine