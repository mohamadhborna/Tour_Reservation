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

# 2020-03-1

Migrations added and sql server conecting handled by @bornaamir8@gmail.com .

# Unrealeased

-Apply Configurations dynamiclly.

# Added
- Migration files 
- Apply  all configuration in packageDbcontex staticlly by @bornaamir8@gmail.com.
- Connection string in appsetting.json  and  it's configuration in startup.cs by @bornaamir8@gmail.com
- Dbcontext option builder methods in statrup.cs in configuresqlserver method by @bornaamir8@gmail.com
- EntityFramework Directory in Infrastructure by @bornaamir8@gmail.com

# Changed
- Base configuration by @bornaamir8@gmail.com
- Hotel configuration by @bornaamir8@gmail.com

 