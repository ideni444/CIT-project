INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e43bc1be-63a0-4918-b9f6-d6fd5d0a78d8', N'admin@school.com', N'ADMIN@SCHOOL.COM', N'admin@school.com', N'ADMIN@SCHOOL.COM', 1, N'AQAAAAEAACcQAAAAEHeIX5/vTomJKZo8LciWuWA9Nra9pYKLWHMWFlzn9EChkN8IKPjHo43f1dD5dU00Kw==', N'CBB77Z5AQSNMZ3LLXFCDDXGWYAYVTLAI', N'731ec30c-bb62-437f-842a-51ef996c4b11', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Subject] ON
INSERT INTO [dbo].[Subject] ([Id], [Name], [Credits]) VALUES (1, N'Mathematics', 75)
INSERT INTO [dbo].[Subject] ([Id], [Name], [Credits]) VALUES (3, N'Physics', 60)
INSERT INTO [dbo].[Subject] ([Id], [Name], [Credits]) VALUES (4, N'Chemistry', 60)
INSERT INTO [dbo].[Subject] ([Id], [Name], [Credits]) VALUES (5, N'Art', 60)
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON
INSERT INTO [dbo].[Teacher] ([Id], [Name], [ContactNumber]) VALUES (1, N'John Smithkkk', N'02189456789')
INSERT INTO [dbo].[Teacher] ([Id], [Name], [ContactNumber]) VALUES (2, N'Richard Harris', N'0213456789')
INSERT INTO [dbo].[Teacher] ([Id], [Name], [ContactNumber]) VALUES (3, N'Frank Houston', N'02122298764')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[TimeTable] ON
INSERT INTO [dbo].[TimeTable] ([Id], [SubjectId], [TeacherId], [StarTime], [EndTime], [Day]) VALUES (1, 1, 1, N'2019-11-05 08:00:00', N'2019-11-05 08:45:00', 5)
INSERT INTO [dbo].[TimeTable] ([Id], [SubjectId], [TeacherId], [StarTime], [EndTime], [Day]) VALUES (2, 1, 2, N'2019-11-05 08:54:00', N'2019-11-05 09:00:00', 1)
INSERT INTO [dbo].[TimeTable] ([Id], [SubjectId], [TeacherId], [StarTime], [EndTime], [Day]) VALUES (3, 5, 3, N'2019-11-05 10:00:00', N'2019-11-05 10:45:00', 2)
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
