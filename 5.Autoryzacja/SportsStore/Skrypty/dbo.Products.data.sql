SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (1, N'Kajak', N'Łódka przeznaczona dla jednej osoby', N'Sporty wodne', CAST(275.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (2, N'Kamizelka ratunkowa', N'Chroni przed utonięciem', N'Sporty wodne', CAST(48.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (3, N'Piłka', N'Zatwierdzone przez FIFA rozmiar i waga', N'Piłka nożna', CAST(19.50 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (4, N'Flagi narożne', N'Do oznaczania boiska', N'Piłka nożna', CAST(34.95 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (5, N'Stadion', N'Składany stadion z trybunami', N'Piłka nożna', CAST(20000.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (6, N'Czapka', N'Zwiększa efektywnośc mózgu o 35%', N'Szachy', CAST(29.99 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (7, N'Ludzka szachownica', N'Wspaniała zabawa dla całej rodziny!', N'Szachy', CAST(75.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (8, N'Błyszczący król', N'Figura pokryta złotem', N'Szachy', CAST(1200.00 AS Decimal(16, 2)))
INSERT INTO [dbo].[Products] ([ProductId], [Name], [Description], [Category], [Price]) VALUES (9, N'Niestabilne krzeszło', N'Zmniejsza szanse przeciwnika', N'Szachy', CAST(43.99 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
