insert into Resource
	 (Id, Classification, Name, Description)
values
	 ('33b28303-28e6-478d-80a3-ca218f504906', 'MainSearch','TryPlaceholder', null)

	,('10e3caa8-c33a-414c-af08-f309fe66f7fd', 'DistroDetail','Intro', null)

	,('057f22d5-21f7-448a-bb75-0c7525e2a7d4', 'PackageType','Browser', null)
	,('953476e0-f188-40c3-8d55-6f2eac50010c', 'PackageType','DesktopEnvironment', null)
	,('d6d4c948-a5f0-4d51-b098-4bde44c08ac6', 'PackageType','MusicPlayer', null)
	,('d9579d61-1bb0-43b0-b03b-6bc6d0e11ab6', 'PackageType','Mailing', null)
	,('b6fddec8-53c9-44b2-ab8d-2986866fe24f', 'PackageType','Productivity', null)
	,('8830846b-1d43-4368-915f-c713f386c938', 'PackageType','VideoPlayer', null)

	,('46c1bf12-a1b5-42f2-a793-9b3292595b1d', 'ExternalResource','YouTube', null)
	,('842324c6-6415-45ff-9e47-f05999cb9b9c', 'ExternalResource','Wikipedia', null)
	,('cca1a909-11f8-446f-b417-f6e967493c2e', 'ExternalResource','DistroWatch', null)
	,('f6c6f18f-dfc8-413d-ac6d-ad212bf32e92', 'ExternalResource','Home Page', null)
	,('d2bf7c5c-a9a9-4f20-9f4b-13637fd407ee', 'ExternalResource','Downloadx86', null)
	,('cc1172ba-891b-4226-9cc1-da4877500f3e', 'ExternalResource','Downloadx64', null)
	
	;

insert into ResourceTranslation 
	 (Id, ResourceId, Language, Translation) 
values 
	 ('c8ef97f6-43d8-4fea-9f0e-9d9b0df9a024', '33b28303-28e6-478d-80a3-ca218f504906', 'en', 'Try "<distro>"...')
	,('6faa5d85-c7aa-4c7d-aed2-2267e1da5d6a', '10e3caa8-c33a-414c-af08-f309fe66f7fd', 'en', 'Here is what we know about <distro> so far...')

	,('380c53ed-da56-42d4-b670-64149307a882', '057f22d5-21f7-448a-bb75-0c7525e2a7d4', 'en', 'Browser')
	,('8a8e204b-92b8-43bd-b64a-d7831e8c2023', '953476e0-f188-40c3-8d55-6f2eac50010c', 'en', 'Desktop Environment')
	,('a954a90e-da0f-497a-99dc-ab4b4a118f66', 'd6d4c948-a5f0-4d51-b098-4bde44c08ac6', 'en', 'Music Player')
	,('394d54b4-1c42-4dc7-a4ec-14b67b3ad09d', 'd9579d61-1bb0-43b0-b03b-6bc6d0e11ab6', 'en', 'Mailing')
	,('8c13becb-fc7f-4a58-b92c-d67f32ef551e', 'b6fddec8-53c9-44b2-ab8d-2986866fe24f', 'en', 'Productivity Suite')
	,('f976c9cd-3fdb-4423-9509-441049348f9a', '8830846b-1d43-4368-915f-c713f386c938', 'en', 'Video Player')

	,('c64d0251-91f4-4760-8156-ec02296c79d9', '33b28303-28e6-478d-80a3-ca218f504906', 'pt', 'Tente "<distro>"...')
	,('6dca101d-aa81-4573-ac31-78a7b54960c3', '10e3caa8-c33a-414c-af08-f309fe66f7fd', 'pt', 'Isso é o que sabemos sobre <distro> até então...')

	,('846dd927-0d40-4a0f-8cd1-484cfb3380e4', '057f22d5-21f7-448a-bb75-0c7525e2a7d4', 'pt', 'Navegador')
	,('467d9ef0-408f-4bb5-90e5-dfe42fef5aae', '953476e0-f188-40c3-8d55-6f2eac50010c', 'pt', 'Ambiente gráfico')
	,('81a47467-01e9-4a53-bcf5-02f51a8f9288', 'd6d4c948-a5f0-4d51-b098-4bde44c08ac6', 'pt', 'Player de música')
	,('97b373c2-01bd-45df-ae2d-2e6859967e60', 'd9579d61-1bb0-43b0-b03b-6bc6d0e11ab6', 'pt', 'Cliente de e-mail')
	,('8fe540da-2f30-48bb-a0cc-9c4cbbb7677f', 'b6fddec8-53c9-44b2-ab8d-2986866fe24f', 'pt', 'Aplicativos de escritório')
	,('44ac49af-4758-4456-b622-7a10c789788c', '8830846b-1d43-4368-915f-c713f386c938', 'pt', 'Player de vídeo')
	
	;

insert into PackageType
	 (Id, ResourceId, Description)
values
	 ('078ae56a-de3c-4a94-a077-44b4d9b35806', '057f22d5-21f7-448a-bb75-0c7525e2a7d4', 'Browser')
	,('a422ccf4-61d5-4859-8876-ab664bfaaa7a', '953476e0-f188-40c3-8d55-6f2eac50010c', 'DesktopEnvironment')
	,('72ef084e-75aa-4131-8a83-3b097bb35f6b', 'd6d4c948-a5f0-4d51-b098-4bde44c08ac6', 'MusicPlayer')
	,('7eb2e197-bcbe-4f43-893a-44f8995df38d', 'd9579d61-1bb0-43b0-b03b-6bc6d0e11ab6', 'Mailing')
	,('7cf4e7f1-2c9b-4733-b226-928b5c64a5ca', 'b6fddec8-53c9-44b2-ab8d-2986866fe24f', 'Productivity')
	,('9cee5aa3-b83f-4ab8-8434-cea3dd1c49a7', '8830846b-1d43-4368-915f-c713f386c938', 'VideoPlayer')

	;

insert into Package
	 (Id, Name, PackageTypeId)
values
	 ('f753be61-9c29-4405-aa0b-735c4a4e841c', '078ae56a-de3c-4a94-a077-44b4d9b35806', 'Mozilla Firefox')
	,('e27261c6-8a2b-4f71-b2a1-94ea62da4660', '078ae56a-de3c-4a94-a077-44b4d9b35806', 'Opera')
	,('fe91a7e5-1cb3-4094-b381-0a00062abaf6', '078ae56a-de3c-4a94-a077-44b4d9b35806', 'Iceweasel')
	,('4c91ef26-2849-4893-86b2-52028adeed93', '078ae56a-de3c-4a94-a077-44b4d9b35806', 'Konqueror')
	,('4c2c6e2e-5d9b-45d4-bb8f-2e1a74c35715', '078ae56a-de3c-4a94-a077-44b4d9b35806', 'Google Chrome')

	,('e6b7ee3c-6592-4d3e-a209-27a23ebdfd2c', '7cf4e7f1-2c9b-4733-b226-928b5c64a5ca', 'WPS')
	,('f51c0920-6660-4f40-a20a-a749275a5e32', '7cf4e7f1-2c9b-4733-b226-928b5c64a5ca', 'OpenOffice')

	,('bc7b5aaa-ba0b-4310-960c-385ecdfea5ca', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'KDE')
	,('181ac302-e300-4688-beb7-6bd9216cc12b', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'Gnome')
	,('66af25c9-18bd-4e2d-a283-cd4ce148ffe6', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'LXDE')
	,('ca500802-9872-4b38-b49a-57e88a1016e5', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'XFCE')
	,('97dc4c11-e2e7-4a1f-9c33-2399a72ed51a', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'Cinnamon')
	,('9a2f105d-61df-42ff-881a-2f0094a8890b', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'Mate')
	,('03ed2f6b-fb27-40e9-9ce9-d0b31ff757b8', 'a422ccf4-61d5-4859-8876-ab664bfaaa7a', 'Deepin')

	,('db56810b-0b8a-4296-9eda-0877b6ef02a1', '72ef084e-75aa-4131-8a83-3b097bb35f6b', 'Rhythmbox')

	,('6190f6b8-3b3a-4e4c-8805-8bdf9e98547f', '9cee5aa3-b83f-4ab8-8434-cea3dd1c49a7', 'VLC')

	,('97489b2d-97eb-4868-8874-26ffd75c834c', '7eb2e197-bcbe-4f43-893a-44f8995df38d', 'Thunderbird')
	,('b7d617eb-dbb5-47bb-93a5-3e724519097d', '7eb2e197-bcbe-4f43-893a-44f8995df38d', 'Evolution')

	;

insert into ExternalResourceType
	 (Id, ResourceId, Description)
values
	 ('91855ed8-18bd-4e82-8e66-1f4c29488ad2', '46c1bf12-a1b5-42f2-a793-9b3292595b1d', 'YouTube')
	,('58e2f7b6-936d-4bfc-818c-215771db92e8', '842324c6-6415-45ff-9e47-f05999cb9b9c', 'Wikipedia')
	,('22736348-8f8c-4343-9168-054b1c60f41a', 'cca1a909-11f8-446f-b417-f6e967493c2e', 'DistroWatch')
	,('e35182b6-e94d-4866-988f-efbba491b994', 'f6c6f18f-dfc8-413d-ac6d-ad212bf32e92', 'Home Page')
	,('b76cbc07-6531-4dfe-9e62-74411d4ac4d8', 'd2bf7c5c-a9a9-4f20-9f4b-13637fd407ee', 'Downloadx86')
	,('3f90d2c3-6f9d-4b6d-a29b-46798e50982b', 'cc1172ba-891b-4226-9cc1-da4877500f3e', 'Downloadx64')
	
	;
