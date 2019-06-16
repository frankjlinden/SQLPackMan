SET IDENTITY_INSERT [dbo].[Status] ON
INSERT INTO [dbo].[Status] ([Id], [Label], [IsItemLevel]) VALUES (1, N'Development', 0)
INSERT INTO [dbo].[Status] ([Id], [Label], [IsItemLevel]) VALUES (2, N'Admin Review', 0)
INSERT INTO [dbo].[Status] ([Id], [Label], [IsItemLevel]) VALUES (3, N'Queued', 0)
INSERT INTO [dbo].[Status] ([Id], [Label], [IsItemLevel]) VALUES (4, N'Test Review', 0)
INSERT INTO [dbo].[Status] ([Id], [Label], [IsItemLevel]) VALUES (5, N'Current', 0)
INSERT INTO [dbo].[Status] ([Id], [Label], [IsItemLevel]) VALUES (6, N'Error', 0)
SET IDENTITY_INSERT [dbo].[Status] OFF
