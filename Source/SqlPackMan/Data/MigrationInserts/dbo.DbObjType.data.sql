SET IDENTITY_INSERT [dbo].[DbObjType] ON
INSERT INTO [dbo].[DbObjType] ([Id], [SqlType], [RGType]) VALUES (1, N'U', N'Table')
INSERT INTO [dbo].[DbObjType] ([Id], [SqlType], [RGType]) VALUES (2, N'V', N'View')
INSERT INTO [dbo].[DbObjType] ([Id], [SqlType], [RGType]) VALUES (3, N'P', N'StoredProcedure')
INSERT INTO [dbo].[DbObjType] ([Id], [SqlType], [RGType]) VALUES (4, N'FN,FT,IF', N'Function')
INSERT INTO [dbo].[DbObjType] ([Id], [SqlType], [RGType]) VALUES (5, N'SQ', N'Sequence')
SET IDENTITY_INSERT [dbo].[DbObjType] OFF
