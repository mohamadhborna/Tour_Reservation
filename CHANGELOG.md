# Changelog

All notable changes to this project will be documented in this file.

## Unreleased

## [1.0.0]

### Added

- Configuration files fixed. Renaming due to convention.
- Some fields added to Entities for relationships: PackageId to Hotel and Transportation, OriginCityId and DestinationCityId to Package, HotelInformation to Hotel and TransportationInformation to Transportation
- BaseConfiguration added.
- HasConstraintName and HasName added to indexes, primary keys and foreign keys to maintain the SQL object name convention.
- IsUnique method for indexes.
- Enumeration.
- Extension method for repetitive configurations.

### Changed

### Removed
