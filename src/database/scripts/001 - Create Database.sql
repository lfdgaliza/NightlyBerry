CREATE TABLE `Distro` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BasedOn` char(36) DEFAULT NULL,
  `HomePage` varchar(250) DEFAULT NULL,
  `Start` datetime DEFAULT NULL,
  `End` datetime DEFAULT NULL,
  `Icon` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Translation` (
  `Module` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ResourceName` varchar(100) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Language` varchar(10) NOT NULL,
  `Translation` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
