USE [reportdb]
GO
INSERT [dbo].[RegisteredUser] ([id], [username]) VALUES (N'12345678-1234-1234-1234-123456789123', N'stefan')
INSERT [dbo].[RegisteredUser] ([id], [username]) VALUES (N'9eaf82ae-b1d7-4989-837c-574753791a5b', N'sanja')
INSERT [dbo].[RegisteredUser] ([id], [username]) VALUES (N'ba077073-4a86-4d68-bf5c-f74b116ee44d', N'stanko')
GO
INSERT [dbo].[Report] ([id], [timestamp], [report_reason], [registered_user_id], [type], [content_id]) VALUES (N'd6babc27-3254-4fc5-b4f3-19cfce85c7ce', CAST(N'2021-06-11T15:08:51.0000000' AS DateTime2), N'Bad post', N'12345678-1234-1234-1234-123456789123', N'Post', N'12345678-1234-1234-1234-123456789123')
INSERT [dbo].[Report] ([id], [timestamp], [report_reason], [registered_user_id], [type], [content_id]) VALUES (N'a16b56a6-9cb0-477d-b22f-c83aea9340a6', CAST(N'2021-06-13T13:36:52.0000000' AS DateTime2), N'Stanko', N'ba077073-4a86-4d68-bf5c-f74b116ee44d', N'Story', N'b7f7985f-5d33-4f6c-892d-5c68a49e34fb')
INSERT [dbo].[Report] ([id], [timestamp], [report_reason], [registered_user_id], [type], [content_id]) VALUES (N'6cbdc305-d860-4420-a680-d54eadfcacf4', CAST(N'2021-06-11T23:46:26.0000000' AS DateTime2), N'report', N'12345678-1234-1234-1234-123456789123', N'Post', N'a74180f1-1550-4478-9e9b-cdbb51c84533')
GO
