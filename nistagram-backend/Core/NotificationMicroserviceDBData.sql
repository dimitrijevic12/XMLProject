USE [notificationdb]
GO
INSERT [dbo].[NotificationOptions] ([id], [is_notified_by_follow_requests], [is_notified_by_messages], [is_notified_by_posts], [is_notified_by_stories], [is_notified_by_comments]) VALUES (N'12345678-1234-1234-1234-123456789123', 1, 1, 1, 0, 0)
INSERT [dbo].[NotificationOptions] ([id], [is_notified_by_follow_requests], [is_notified_by_messages], [is_notified_by_posts], [is_notified_by_stories], [is_notified_by_comments]) VALUES (N'9eaf82ae-b1d7-4989-837c-574753791a5b', 1, 1, 1, 1, 1)
INSERT [dbo].[NotificationOptions] ([id], [is_notified_by_follow_requests], [is_notified_by_messages], [is_notified_by_posts], [is_notified_by_stories], [is_notified_by_comments]) VALUES (N'abcb7a97-185e-4b2c-98e3-ab37029314ad', 1, 1, 1, 1, 1)
INSERT [dbo].[NotificationOptions] ([id], [is_notified_by_follow_requests], [is_notified_by_messages], [is_notified_by_posts], [is_notified_by_stories], [is_notified_by_comments]) VALUES (N'ba077073-4a86-4d68-bf5c-f74b116ee44d', 1, 1, 1, 1, 1)
GO
INSERT [dbo].[RegisteredUser] ([id], [username], [notification_options_id], [profilePicturePath]) VALUES (N'12345678-1234-1234-1234-123456789123', N'stefan', N'12345678-1234-1234-1234-123456789123', NULL)
INSERT [dbo].[RegisteredUser] ([id], [username], [notification_options_id], [profilePicturePath]) VALUES (N'9eaf82ae-b1d7-4989-837c-574753791a5b', N'sanja', N'9eaf82ae-b1d7-4989-837c-574753791a5b', NULL)
INSERT [dbo].[RegisteredUser] ([id], [username], [notification_options_id], [profilePicturePath]) VALUES (N'abcb7a97-185e-4b2c-98e3-ab37029314ad', N'New user', N'abcb7a97-185e-4b2c-98e3-ab37029314ad', N'')
INSERT [dbo].[RegisteredUser] ([id], [username], [notification_options_id], [profilePicturePath]) VALUES (N'ba077073-4a86-4d68-bf5c-f74b116ee44d', N'stanko', N'ba077073-4a86-4d68-bf5c-f74b116ee44d', NULL)
GO
INSERT [dbo].[Notification] ([id], [timestamp], [type], [content_id], [registered_user_id]) VALUES (N'8ce094a0-85e4-4ad6-8a5a-06af1dc35eda', CAST(N'2021-06-16T01:17:53.0000000' AS DateTime2), N'Post', N'3fe702f7-a438-4e9e-ac82-922a58740367', N'12345678-1234-1234-1234-123456789123')
INSERT [dbo].[Notification] ([id], [timestamp], [type], [content_id], [registered_user_id]) VALUES (N'94f51850-5baa-4be3-b5a6-290896d624ef', CAST(N'2021-06-16T01:52:41.0000000' AS DateTime2), N'Post', N'a1c4f2e0-f6c6-452a-9842-45ed7d05afd8', N'ba077073-4a86-4d68-bf5c-f74b116ee44d')
INSERT [dbo].[Notification] ([id], [timestamp], [type], [content_id], [registered_user_id]) VALUES (N'1bf38ac0-caa6-4724-9c1a-98924c4cba59', CAST(N'2021-06-16T01:54:40.0000000' AS DateTime2), N'Comment', N'12345678-1234-1234-1234-123456789123', N'ba077073-4a86-4d68-bf5c-f74b116ee44d')
INSERT [dbo].[Notification] ([id], [timestamp], [type], [content_id], [registered_user_id]) VALUES (N'840e1f0e-5109-4e8f-94f4-c77cc38cb2c8', CAST(N'2021-06-16T12:41:01.0000000' AS DateTime2), N'Comment', N'00000000-0000-0000-0000-000000000000', N'9eaf82ae-b1d7-4989-837c-574753791a5b')
INSERT [dbo].[Notification] ([id], [timestamp], [type], [content_id], [registered_user_id]) VALUES (N'cc042c84-56c5-417d-9073-d017fb00e675', CAST(N'2021-06-16T12:21:36.0000000' AS DateTime2), N'Story', N'12345678-1234-1234-1234-123456789123', N'ba077073-4a86-4d68-bf5c-f74b116ee44d')
GO
