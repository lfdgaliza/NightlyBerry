CREATE TABLE `Distro` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `BasedOn` char(36) DEFAULT NULL,
  `HomePage` varchar(250) DEFAULT NULL,
  `Start` datetime DEFAULT NULL,
  `End` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
