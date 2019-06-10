insert into ResourceGroup
	(Id, Name)
values
	('31b02e73-b97d-46c6-a2b9-1201ba13c11a', 'C:MainSearch'),
	('6b7cb70b-37f4-451a-b9b2-4855724d5442', 'C:DistroDetail'),
	('afca2a93-4db3-49bc-8eb8-9b540dd9881e', 'FeedbackMessages')

insert into Resource
	 (Id, ResourceGroupId, Name)
values
	 ('33b28303-28e6-478d-80a3-ca218f504906', '31b02e73-b97d-46c6-a2b9-1201ba13c11a','TryPlaceholder')
	,('10e3caa8-c33a-414c-af08-f309fe66f7fd', '6b7cb70b-37f4-451a-b9b2-4855724d5442','Intro')

insert into ResourceTranslation 
	 (Id, ResourceId, Language, Translation) 
values 
	 ('c8ef97f6-43d8-4fea-9f0e-9d9b0df9a024', '33b28303-28e6-478d-80a3-ca218f504906', 'en', 'Try "<distro>"...')
	,('6faa5d85-c7aa-4c7d-aed2-2267e1da5d6a', '10e3caa8-c33a-414c-af08-f309fe66f7fd', 'en', 'Here is what we know about <distro> so far...')

	,('c64d0251-91f4-4760-8156-ec02296c79d9', '33b28303-28e6-478d-80a3-ca218f504906', 'pt', 'Tente "<distro>"...')
	,('6dca101d-aa81-4573-ac31-78a7b54960c3', '10e3caa8-c33a-414c-af08-f309fe66f7fd', 'pt', 'Isso é o que sabemos sobre <distro> até então...')

insert into Package
	 (Id, PackageType, Name)
values
	 ('f753be61-9c29-4405-aa0b-735c4a4e841c', 1, 'Mozilla Firefox')
	,('e27261c6-8a2b-4f71-b2a1-94ea62da4660', 1, 'Opera')
	,('fe91a7e5-1cb3-4094-b381-0a00062abaf6', 1, 'Iceweasel')
	,('4c91ef26-2849-4893-86b2-52028adeed93', 1, 'Konqueror')
	,('4c2c6e2e-5d9b-45d4-bb8f-2e1a74c35715', 1, 'Google Chrome')

	,('e6b7ee3c-6592-4d3e-a209-27a23ebdfd2c', 5, 'WPS')
	,('f51c0920-6660-4f40-a20a-a749275a5e32', 5, 'OpenOffice')

	,('bc7b5aaa-ba0b-4310-960c-385ecdfea5ca', 2, 'KDE')
	,('181ac302-e300-4688-beb7-6bd9216cc12b', 2, 'Gnome')
	,('66af25c9-18bd-4e2d-a283-cd4ce148ffe6', 2, 'LXDE')
	,('ca500802-9872-4b38-b49a-57e88a1016e5', 2, 'XFCE')
	,('97dc4c11-e2e7-4a1f-9c33-2399a72ed51a', 2, 'Cinnamon')
	,('9a2f105d-61df-42ff-881a-2f0094a8890b', 2, 'Mate')
	,('03ed2f6b-fb27-40e9-9ce9-d0b31ff757b8', 2, 'Deepin')

	,('db56810b-0b8a-4296-9eda-0877b6ef02a1', 3, 'Rhythmbox')

	,('6190f6b8-3b3a-4e4c-8805-8bdf9e98547f', 6, 'VLC')

	,('97489b2d-97eb-4868-8874-26ffd75c834c', 4, 'Thunderbird')
	,('b7d617eb-dbb5-47bb-93a5-3e724519097d', 4, 'Evolution')

	;