# Changelog

All notable changes to this project will be documented in this file.

## 2020-02-28

Configuration files fixed. Renaming due to convention.

## Unreleased

- Enumeration.
- Extention method for repetitive configurations.

### Added

- Some fields added to Entities for relationships: PackageId to Hotel and Transportation, OriginCityId and DestinationCityId to Package, HotelInformation to Hotel and TransportationInformation to Transportation
- BaseConfiguration added.
- HasConstraintName and HasName added to indexes, primary keys and foreign keys to maintain the SQL object name convention.
- IsUnique method for indexes.

### Changed

- Fields named as Name renamed to Title
- Cascade deleted changed to Restricted.
- (h => h.Field) ====> (e => e.Field)

### Removed

- ValueGeneratedOnAdd removed.

