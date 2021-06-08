USE [postdb]
GO
INSERT [dbo].[RegisteredUser] ([id], [username], [first_name], [last_name], [isPrivate], [isAcceptingTags], [profilePicturePath]) VALUES (N'bedab539-de67-47d3-b529-2bbcaa483313', N'aleksa', N'Aleksa', N'Santrac', 0, 1, N'manprof3.jpg')
INSERT [dbo].[RegisteredUser] ([id], [username], [first_name], [last_name], [isPrivate], [isAcceptingTags], [profilePicturePath]) VALUES (N'3968bebf-8d8c-4ae5-a888-462cb3e20a6e', N'marko', N'Marko', N'Markovic', 0, 0, N'')
INSERT [dbo].[RegisteredUser] ([id], [username], [first_name], [last_name], [isPrivate], [isAcceptingTags], [profilePicturePath]) VALUES (N'40155abe-5df8-4f74-816e-4b0c0ab8ce47', N'luna', N'Luna', N'Lunic', 1, 1, N'')
INSERT [dbo].[RegisteredUser] ([id], [username], [first_name], [last_name], [isPrivate], [isAcceptingTags], [profilePicturePath]) VALUES (N'360129ab-19c2-4b47-8c53-56eea0c9e126', N'nemanja', N'Nemanja', N'Dimitrijevic', 0, 1, N'nemanja profile.jpg')
INSERT [dbo].[RegisteredUser] ([id], [username], [first_name], [last_name], [isPrivate], [isAcceptingTags], [profilePicturePath]) VALUES (N'cc9f96ec-ed1c-4ed5-9c47-61cf231cc0d6', N'stefan', N'Stefan', N'Santrac', 1, 1, N'manprof.jpg')
GO
INSERT [dbo].[Collection] ([id], [collection_name], [registered_user_id]) VALUES (N'bdd17b47-8a8d-4495-afc8-12a75edacaf7', N'favourites', N'3968bebf-8d8c-4ae5-a888-462cb3e20a6e')
INSERT [dbo].[Collection] ([id], [collection_name], [registered_user_id]) VALUES (N'3406ca51-a92b-46a6-8090-4d38d121d168', N'favourites', N'40155abe-5df8-4f74-816e-4b0c0ab8ce47')
INSERT [dbo].[Collection] ([id], [collection_name], [registered_user_id]) VALUES (N'5e6aa386-13ab-45ca-8c01-54ccef3e4b7a', N'favourites', N'cc9f96ec-ed1c-4ed5-9c47-61cf231cc0d6')
INSERT [dbo].[Collection] ([id], [collection_name], [registered_user_id]) VALUES (N'2908db34-0b89-47f9-ada9-7781587f5cfa', N'favourites', N'bedab539-de67-47d3-b529-2bbcaa483313')
INSERT [dbo].[Collection] ([id], [collection_name], [registered_user_id]) VALUES (N'60566dd6-d2e2-4e3a-85fb-9ca73832a4cb', N'New Collection 1', N'360129ab-19c2-4b47-8c53-56eea0c9e126')
INSERT [dbo].[Collection] ([id], [collection_name], [registered_user_id]) VALUES (N'16722bbb-ac1b-4231-bf00-edf995aac80f', N'favourites', N'360129ab-19c2-4b47-8c53-56eea0c9e126')
GO
INSERT [dbo].[Location] ([id], [city_name], [street], [country]) VALUES (N'12345678-1234-1234-1234-123456789123', N'Belgrade', N'Knez Mihailova 15', N'Serbia')
INSERT [dbo].[Location] ([id], [city_name], [street], [country]) VALUES (N'12345678-1234-1234-1234-123456789124', N'Novi Sad', N'Veljka Petrovica 10', N'Serbia')
INSERT [dbo].[Location] ([id], [city_name], [street], [country]) VALUES (N'12345678-1234-1234-1234-123456789125', N'Belgrade', N'Cara Dusana 25', N'Serbia')
INSERT [dbo].[Location] ([id], [city_name], [street], [country]) VALUES (N'12345678-1234-1234-1234-123456789126', N'Novi Sad', N'Radnicka 99', N'Serbia')
INSERT [dbo].[Location] ([id], [city_name], [street], [country]) VALUES (N'12345678-1234-1234-1234-123456789127', N'Novi Sad', N'Temerinska 72', N'Serbia')
GO
INSERT [dbo].[Post] ([id], [timestamp], [description], [registered_user_id], [type], [location_id]) VALUES (N'710007eb-889f-486d-971a-2b4ee36a17c8', CAST(N'2021-06-08T15:02:23.0000000' AS DateTime2), N'Motorcycle', N'bedab539-de67-47d3-b529-2bbcaa483313', N'single', N'12345678-1234-1234-1234-123456789123')
INSERT [dbo].[Post] ([id], [timestamp], [description], [registered_user_id], [type], [location_id]) VALUES (N'74a81aa9-f140-4556-8ff4-572b835e9f35', CAST(N'2021-06-08T15:21:59.0000000' AS DateTime2), N'Album', N'360129ab-19c2-4b47-8c53-56eea0c9e126', N'album', N'12345678-1234-1234-1234-123456789124')
INSERT [dbo].[Post] ([id], [timestamp], [description], [registered_user_id], [type], [location_id]) VALUES (N'033b282b-fcb7-4625-ba49-6ac71ac55708', CAST(N'2021-06-08T14:58:15.0000000' AS DateTime2), N'Weeb', N'cc9f96ec-ed1c-4ed5-9c47-61cf231cc0d6', N'single', N'12345678-1234-1234-1234-123456789127')
INSERT [dbo].[Post] ([id], [timestamp], [description], [registered_user_id], [type], [location_id]) VALUES (N'ecd748d5-23c5-4a4f-abbf-7b50ded6195e', CAST(N'2021-06-08T15:03:56.0000000' AS DateTime2), N'Beach', N'cc9f96ec-ed1c-4ed5-9c47-61cf231cc0d6', N'single', N'12345678-1234-1234-1234-123456789125')
INSERT [dbo].[Post] ([id], [timestamp], [description], [registered_user_id], [type], [location_id]) VALUES (N'71a4500f-7bbb-4c9f-81ae-8ba7c09ee966', CAST(N'2021-06-08T15:07:39.0000000' AS DateTime2), N'Bunny', N'bedab539-de67-47d3-b529-2bbcaa483313', N'single', N'12345678-1234-1234-1234-123456789124')
GO
INSERT [dbo].[CollectionContent] ([id], [collection_id], [post_id]) VALUES (N'1f22c98f-6bb5-4770-a150-52bf03516b5f', N'16722bbb-ac1b-4231-bf00-edf995aac80f', N'710007eb-889f-486d-971a-2b4ee36a17c8')
GO
INSERT [dbo].[Comment] ([id], [timestamp], [comment_text], [registered_user_id], [post_id]) VALUES (N'2cb6c92d-efaf-4981-bc6f-ade2750a4136', CAST(N'2021-06-08T15:06:35.0000000' AS DateTime2), N'Nice pic!', N'360129ab-19c2-4b47-8c53-56eea0c9e126', N'710007eb-889f-486d-971a-2b4ee36a17c8')
GO
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'b6821669-736d-47b0-afee-1e2fa7269a81', N'710007eb-889f-486d-971a-2b4ee36a17c8', N'wallhaven-6olw9x.jpg')
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'48ce86d0-9132-48e1-95f6-2d89fb671ed6', N'033b282b-fcb7-4625-ba49-6ac71ac55708', N'wallhaven-281d5y.png')
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'c9b65bdf-7ccd-4725-8382-4a2a358cb6fd', N'71a4500f-7bbb-4c9f-81ae-8ba7c09ee966', N'SampleVideo_1280x720_1mb.mp4')
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'cccf9bbf-7d30-46fb-9d0e-5d23954ce3e8', N'74a81aa9-f140-4556-8ff4-572b835e9f35', N'wallhaven-6olw9x.jpg')
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'a73bf102-783c-4859-aac5-781fd0ff2128', N'74a81aa9-f140-4556-8ff4-572b835e9f35', N'sample1.jpeg')
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'c3e9939a-d2e9-49c2-996c-a480902c1393', N'74a81aa9-f140-4556-8ff4-572b835e9f35', N'wallhaven-281d5y.png')
INSERT [dbo].[Content] ([id], [post_id], [content_path]) VALUES (N'8ebb253f-9fae-4075-9d2c-ee8ad39ad98b', N'ecd748d5-23c5-4a4f-abbf-7b50ded6195e', N'video.mp4')
GO
INSERT [dbo].[HashTags] ([id], [post_id], [text]) VALUES (N'd33e15c9-0a30-4298-937b-07e46d43468f', N'033b282b-fcb7-4625-ba49-6ac71ac55708', N'#anime')
INSERT [dbo].[HashTags] ([id], [post_id], [text]) VALUES (N'a5be40e6-9321-487f-acef-578494d36c00', N'ecd748d5-23c5-4a4f-abbf-7b50ded6195e', N'')
INSERT [dbo].[HashTags] ([id], [post_id], [text]) VALUES (N'5cdd0669-f338-42d3-9947-7e01c924fc3b', N'74a81aa9-f140-4556-8ff4-572b835e9f35', N'#album')
INSERT [dbo].[HashTags] ([id], [post_id], [text]) VALUES (N'220014e0-5073-454f-8e59-efe528d745af', N'710007eb-889f-486d-971a-2b4ee36a17c8', N'#motorcycle')
INSERT [dbo].[HashTags] ([id], [post_id], [text]) VALUES (N'1f0ad770-c5b5-4032-8345-f74870fa0a22', N'71a4500f-7bbb-4c9f-81ae-8ba7c09ee966', N'#bunny')
GO
INSERT [dbo].[Likes] ([id], [post_id], [registered_user_id]) VALUES (N'86b7fad2-3b30-4a3f-acc0-c2b5cd31cc91', N'710007eb-889f-486d-971a-2b4ee36a17c8', N'360129ab-19c2-4b47-8c53-56eea0c9e126')
GO
INSERT [dbo].[PostProfileTags] ([id], [post_id], [registered_user_id]) VALUES (N'7315e32d-3089-41a3-8d2c-4f461a47bcde', N'74a81aa9-f140-4556-8ff4-572b835e9f35', N'bedab539-de67-47d3-b529-2bbcaa483313')
INSERT [dbo].[PostProfileTags] ([id], [post_id], [registered_user_id]) VALUES (N'57bece4a-3919-4d71-b400-d822f50f0545', N'033b282b-fcb7-4625-ba49-6ac71ac55708', N'bedab539-de67-47d3-b529-2bbcaa483313')
GO
