SET IDENTITY_INSERT [dbo].[DdsEnvironment] ON
INSERT INTO [dbo].[DdsEnvironment] ([Id], [Name], [Server], [SchemaPath]) VALUES (1, N'DEV', N'(localdb)\mssqllocaldb', N'G:\RedGate\DBSource')
INSERT INTO [dbo].[DdsEnvironment] ([Id], [Name], [Server], [SchemaPath]) VALUES (2, N'QA', N'(localdb)\mssqllocaldb', N'G:\RedGate\DBSource')
INSERT INTO [dbo].[DdsEnvironment] ([Id], [Name], [Server], [SchemaPath]) VALUES (3, N'STAG', N'(localdb)\mssqllocaldb', N'G:\RedGate\DBSource')
INSERT INTO [dbo].[DdsEnvironment] ([Id], [Name], [Server], [SchemaPath]) VALUES (4, N'PROD', N'(localdb)\mssqllocaldb', N'G:\RedGate\DBSource')
SET IDENTITY_INSERT [dbo].[DdsEnvironment] OFF
