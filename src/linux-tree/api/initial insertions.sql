INSERT INTO Distro
(Id, Name)
VALUES
(NEWID(), 'Debian'),
(NEWID(), 'RedHat'),
(NEWID(), 'Ubuntu'),
(NEWID(), 'Fedora'),
(NEWID(), 'Linux Mint');

INSERT INTO DistroVariant
(Id, DistroId, Name, IsMain, IsOficial)
VALUES
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Debian'), 'Debian', 1, 1),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'RedHat'), 'RedHat', 1, 1),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Ubuntu'), 'Ubuntu', 1, 1),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Fedora'), 'Fedora', 1, 1),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Linux Mint'), 'Linux Mint - Ubuntu', 1, 1),
(NEWID(), (SELECT Id FROM Distro WHERE Name = 'Linux Mint'), 'Linux Mint - Debian', 1, 1);

INSERT INTO DistroRelease
(VariantId, Id, Name, ReleaseDate)
VALUES
((SELECT Id FROM DistroVariant WHERE Name = 'Debian'), NEWID(), '15', GETDATE()),
((SELECT Id FROM DistroVariant WHERE Name = 'RedHat'), NEWID(), '1', GETDATE()),
((SELECT Id FROM DistroVariant WHERE Name = 'Ubuntu'), NEWID(), '14.04', GETDATE()),
((SELECT Id FROM DistroVariant WHERE Name = 'Fedora'), NEWID(), '16', GETDATE()),
((SELECT Id FROM DistroVariant WHERE Name = 'Linux Mint - Ubuntu'), NEWID(), '12', GETDATE()),
((SELECT Id FROM DistroVariant WHERE Name = 'Linux Mint - Debian'), NEWID(), '13', GETDATE());

INSERT INTO DistroDerivation (Id, DistroReleaseId, DerivesFromId)
VALUES
(NEWID(), (SELECT Id FROM DistroRelease WHERE Name = '14.04'), (SELECT Id FROM DistroRelease WHERE Name = '15')),
(NEWID(), (SELECT Id FROM DistroRelease WHERE Name = '16'), (SELECT Id FROM DistroRelease WHERE Name = '1')),
(NEWID(), (SELECT Id FROM DistroRelease WHERE Name = '12'), (SELECT Id FROM DistroRelease WHERE Name = '14.04')),
(NEWID(), (SELECT Id FROM DistroRelease WHERE Name = '13'), (SELECT Id FROM DistroRelease WHERE Name = '15'));