create table `Resource` (
  `Id` char(36) not null,
  `Classification` varchar(100) not null,
  `Name` varchar(100) not null,
  `Description` varchar(200) default null,
  primary key (`Id`)
);

create table `ResourceTranslation` (
  `Id` char(36) not null,
  `ResourceId` char(36) not null,
  `Language` varchar(10) not null,
  `Translation` varchar(100) not null,
  primary key (`Id`)
);

create table `Distro` (
  `Id` char(36) not null,
  `Name` varchar(50) not null,
  `BasedOn` char(36) default null,
  `HomePage` varchar(250) default null,
  `Start` datetime default null,
  `End` datetime default null,
  `Icon` varchar(200) default null,
  primary key (`Id`)
);

-- Browser, Desktop Environment, Email Client, etc
create table `PackageType` (
  `Id` char(36) not null,
	`ResourceId` varchar(36) not null,
  `Description` varchar(200) default null,
  primary key (`Id`)
);

create table `Package` (
  `Id` char(36) not null,
  `Name` varchar(100) not null,
  `PackageTypeId` char(36) not null,
  primary key (`Id`)
);

-- Wikipedia, YouTube, DistroWatch, HomePage Link, Download Mirror, etc
create table `ExternalResourceType` (
  `Id` char(36) not null,
  `ResourceId` char(36) not null,
  `Description` varchar(200) default null,
  primary key (`Id`)
);

create table `ExternalResource` (
  `Id` char(36) not null,
  `ExternalResourceTypeId` char(36) not null, 
  `Resource` varchar(200) not null,
  `IsPrincipal` boolean not null,
  primary key (`Id`)
);

create table `PackageDistro` (
  `Id` char(36) not null,
  `DistroId` char(36) not null,
  `PackageId` char(36) not null,
  `IsOficial` boolean not null,
  `IsPrincipal` boolean not null,
  primary key (`Id`)
);

create table `PackageExternalResource` (
  `Id` char(36) not null,
  `PackageId` char(36) not null,
  `ExternalResourceId` char(36) not null,
  primary key (`Id`)
);

create table `DistroExternalResource` (
  `Id` char(36) not null,
  `DistroId` char(36) not null,
  `ExternalResourceId` char(36) not null,
  primary key (`Id`)
);
