CREATE TABLE `sqr.company`.`users` (
  `Id` INT NOT NULL,
  `Account` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Mobile` VARCHAR(45) NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Account_UNIQUE` (`Account` ASC) VISIBLE);
  
  CREATE TABLE `sqr.company`.`ActionInfo` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Controller` VARCHAR(45) NOT NULL,
  `Action` VARCHAR(45) NOT NULL,
  `Parameters` VARCHAR(45) NOT NULL,
  `Category` VARCHAR(45) NOT NULL,
  `ParentId` int null,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  CREATE TABLE `sqr.company`.`Roles` (
  `Id` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  CREATE TABLE `sqr.company`.`ActionInfoRolesRelation` (
  `Id` INT NOT NULL,
  `ActionInfoId` int NOT NULL,
  `RoleId` int NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  
  CREATE TABLE `sqr.company`.`UserActionRelation` (
  `Id` INT NOT NULL,
  `UserId` int NOT NULL,
  `ActionId` int NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  CREATE TABLE `sqr.company`.`UserRolesRelation` (
  `Id` INT NOT NULL,
  `UserId` int NOT NULL,
  `RoleId` int NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  CREATE TABLE `sqr.company`.`SsoSites` (
  `Id` INT NOT NULL,
  `SiteCode` VARCHAR(45) NOT NULL,
  `SiteName` VARCHAR(45) NOT NULL,
  `SiteUrl` VARCHAR(45) NOT NULL,
  `SiteLoginUrl` VARCHAR(45) NOT NULL,
  `SiteLogoutUrl` VARCHAR(45) NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `SsoSites_UNIQUE` (`SiteCode` ASC) VISIBLE);
  
    CREATE TABLE `sqr.company`.`DicInfo` (
  `Id` INT NOT NULL,
  `Code` VARCHAR(45) NOT NULL,
  `Value` VARCHAR(45) NOT NULL,
  `Category` int NOT NULL,
  `ParentId` int NOT NULL,
  `Remark` VARCHAR(45) NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
   
    CREATE TABLE `sqr.company`.`KeyValueInfo` (
  `Id` INT NOT NULL,
  `Code` VARCHAR(45) NOT NULL,
  `Value` VARCHAR(45) NOT NULL,
  `Remark` VARCHAR(45) NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  CREATE TABLE `sqr.company`.`NewsCategory` (
  `Id` INT NOT NULL,
  `Code` VARCHAR(45) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `ParentId` int NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  CREATE TABLE `sqr.company`.`NewsInfo` (
  `Id` INT NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Title2` VARCHAR(45) NOT NULL,
  `Content` VARCHAR(1000) NOT NULL,
  `Content2` VARCHAR(200) NOT NULL,
  `Imagesmall` VARCHAR(45) NOT NULL,
	`Imagebig` VARCHAR(45) NOT NULL,
	`Ishot` VARCHAR(45) NOT NULL,
	`Ispublished` VARCHAR(45) NOT NULL,
	`PublishedTime` date NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  
  
  CREATE TABLE `sqr.company`.`ProductCategory` (
  `Id` INT NOT NULL,
  `Code` VARCHAR(45) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `ParentId` int NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));
  
  CREATE TABLE `sqr.company`.`ProductInfo` (
  `Id` INT NOT NULL,
  `Title` VARCHAR(45) NOT NULL,
  `Title2` VARCHAR(45) NOT NULL,
  `Content` VARCHAR(1000) NOT NULL,
  `Content2` VARCHAR(200) NOT NULL,
  `Imagesmall` VARCHAR(45) NOT NULL,
	`Imagebig` VARCHAR(45) NOT NULL,
	`Ishot` VARCHAR(45) NOT NULL,
	`Ispublished` VARCHAR(45) NOT NULL,
	`PublishedTime` date NOT NULL,
  `CreateTime` DATE NOT NULL,
  `CreateUser` INT NULL,
  `UpdateTime` DATE NULL,
  `UpdateUser` INT NULL,
  `DeleteTime` DATE NULL,
  `DeleteUser` int NULL,
  PRIMARY KEY (`Id`));