INSERT INTO Distro
(Id, Name)
VALUES
(NEWID(), 'Debian'),
(NEWID(), 'RedHat'),
(NEWID(), 'Ubuntu'),
(NEWID(), 'Kubuntu'),
(NEWID(), 'Xubuntu'),
(NEWID(), 'Fedora'),
(NEWID(), 'Linux Mint'),
(NEWID(), 'Linux Mint (Debian Edition)')
GO

INSERT INTO DistroDerivation
(Id, DistroId, BasedOnId)
VALUES
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Ubuntu'), (SELECT Id FROM Distro WHERE Name = 'Debian')),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Kubuntu'), (SELECT Id FROM Distro WHERE Name = 'Ubuntu')),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Xubuntu'), (SELECT Id FROM Distro WHERE Name = 'Ubuntu')),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Fedora'), (SELECT Id FROM Distro WHERE Name = 'RedHat')),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Linux Mint'), (SELECT Id FROM Distro WHERE Name = 'Ubuntu')),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Linux Mint (Debian Edition)'), (SELECT Id FROM Distro WHERE Name = 'Debian'))
GO
