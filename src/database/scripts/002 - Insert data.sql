INSERT INTO `distro-guide`.`Translation` 
	(Id, Module,ResourceName,Description,`Language`,`Translation`) 
VALUES 
	(UUID(), 'DistroDetail','Intro',NULL,'en','Here is what we know about <distro> so far...')
	,(UUID(), 'DistroDetail','Intro',NULL,'pt','Isso é o que sabemos sobre <distro> até então...')
	,(UUID(), 'MainSearch','TryPlaceholder',NULL,'en','Try "<distro>"...')
	,(UUID(), 'MainSearch','TryPlaceholder',NULL,'pt','Tente "<distro>"...')
	;
