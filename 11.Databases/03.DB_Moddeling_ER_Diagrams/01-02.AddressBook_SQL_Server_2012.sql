USE [AddressBook]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 21.8.2014 г. 00:44:45 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [uniqueidentifier] NOT NULL,
	[Address_Text] [varchar](200) NOT NULL,
	[TownID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Continent]    Script Date: 21.8.2014 г. 00:44:45 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Continent](
	[ContinentID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 21.8.2014 г. 00:44:45 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ContinentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 21.8.2014 г. 00:44:45 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[AddressID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Town]    Script Date: 21.8.2014 г. 00:44:45 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Town](
	[TownID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Person_Location_View]    Script Date: 21.8.2014 г. 00:44:45 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Person_Location_View]
AS
SELECT        dbo.Person.FirstName AS 'Име', dbo.Person.LastName AS 'Фамилия', dbo.Country.Name AS 'Държава', dbo.Continent.Name AS Континент, 
                         dbo.Town.Name AS 'Град'
FROM            dbo.Person INNER JOIN
                         dbo.Address ON dbo.Person.AddressID = dbo.Address.AddressID INNER JOIN
                         dbo.Town ON dbo.Address.TownID = dbo.Town.TownID INNER JOIN
                         dbo.Country INNER JOIN
                         dbo.Continent ON dbo.Country.ContinentID = dbo.Continent.ContinentID ON dbo.Town.CountryID = dbo.Country.CountryID

GO
INSERT [dbo].[Address] ([AddressID], [Address_Text], [TownID]) VALUES (N'2abbdea6-229a-4c0f-b66a-06f15da2c01b', N'Some Str. 20', N'f4b07bce-70de-4b42-978f-2515ca9cb88e')
INSERT [dbo].[Address] ([AddressID], [Address_Text], [TownID]) VALUES (N'6201109c-025a-45ac-a5f9-35e212e25a3f', N'Shipka 10', N'f2698fba-882b-4dc5-8f57-3b1721b74d4f')
INSERT [dbo].[Address] ([AddressID], [Address_Text], [TownID]) VALUES (N'aeca03d7-a494-4f9a-8b61-924858ddfc49', N'Pyramids 22', N'17b5a4cb-8f5d-4e85-8ed1-7ab379ba8a16')
INSERT [dbo].[Address] ([AddressID], [Address_Text], [TownID]) VALUES (N'3619c068-5326-4efd-b87d-a0cca2486e08', N'White House 1', N'68b89c81-93b7-44f1-b5b9-ee5c56c0bcd5')
INSERT [dbo].[Address] ([AddressID], [Address_Text], [TownID]) VALUES (N'815fa1f8-9edc-43e5-87be-ba6c362154bf', N'Main Str. 1', N'93406da6-53cc-47fb-9226-342c47669a69')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'79237382-eb02-461f-b2d8-0c3813ed03fe', N'South America')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'7dc83c9f-34fa-41e4-914d-38434d4c44eb', N'Africa')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'044c8736-6e78-4473-b5b2-3b08b75a744a', N'North America')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'641a7a1d-aab2-4fd6-9bea-54b026d6d387', N'Asia')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'dbbcd1dc-b192-445a-ac44-888eb7b0a594', N'Antarctic')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'93bc7dae-f758-4c65-be13-8ef913d32696', N'Europe')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (N'766a18b6-951f-40d7-8f5a-c252ef3d7c9a', N'Australia')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'01c65963-891f-4b21-9101-04c63965ee7b', N'Egypt', N'7dc83c9f-34fa-41e4-914d-38434d4c44eb')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'd359ab63-c974-40ce-ab9b-2ccd4e358402', N'England', N'93bc7dae-f758-4c65-be13-8ef913d32696')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'ac074b87-a842-41d1-a30f-300b4b33fdbd', N'USA', N'044c8736-6e78-4473-b5b2-3b08b75a744a')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'ee20b748-61e0-451b-9b18-97790853d959', N'Nigeria', N'7dc83c9f-34fa-41e4-914d-38434d4c44eb')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'8eaa3dfb-e0a5-4315-b6a8-99a8718dc062', N'Australia', N'044c8736-6e78-4473-b5b2-3b08b75a744a')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'fb00d0c9-81e8-4a8f-a636-9a8297f2fcdc', N'Canada', N'044c8736-6e78-4473-b5b2-3b08b75a744a')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'71f945b3-cd3e-4815-aef1-b98cea2b28f5', N'SAR', N'7dc83c9f-34fa-41e4-914d-38434d4c44eb')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'0bd89436-be20-4313-94ea-be79ac6561bd', N'Mexico', N'044c8736-6e78-4473-b5b2-3b08b75a744a')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'd9e41cc2-73f6-47bd-a9ac-ce07d3795929', N'Germany', N'93bc7dae-f758-4c65-be13-8ef913d32696')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'c4f9185e-58a8-4335-bd04-d3ea72072be5', N'Bulgaria', N'93bc7dae-f758-4c65-be13-8ef913d32696')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'35a862d7-6d6e-412b-be9c-d5fafd02fbd1', N'Argentina', N'79237382-eb02-461f-b2d8-0c3813ed03fe')
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (N'd12a42e0-eff6-4949-892c-d9a2890fb4ec', N'Brazil', N'79237382-eb02-461f-b2d8-0c3813ed03fe')
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (N'6ef7ba18-1ec0-402e-91eb-8a0f80de96f2', N'Bai', N'Ganyo', N'2abbdea6-229a-4c0f-b66a-06f15da2c01b')
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (N'3f6509fe-ea3b-4dca-99e8-e1c5c9d5daa3', N'Baraq', N'Obama', N'3619c068-5326-4efd-b87d-a0cca2486e08')
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (N'da25151d-9202-406e-9a08-fd3ffa53b68e', N'Tutan', N'Camon', N'aeca03d7-a494-4f9a-8b61-924858ddfc49')
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (N'f4b07bce-70de-4b42-978f-2515ca9cb88e', N'Chicago', N'ac074b87-a842-41d1-a30f-300b4b33fdbd')
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (N'93406da6-53cc-47fb-9226-342c47669a69', N'New York', N'ac074b87-a842-41d1-a30f-300b4b33fdbd')
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (N'f2698fba-882b-4dc5-8f57-3b1721b74d4f', N'Sofia', N'c4f9185e-58a8-4335-bd04-d3ea72072be5')
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (N'17b5a4cb-8f5d-4e85-8ed1-7ab379ba8a16', N'Cairo', N'01c65963-891f-4b21-9101-04c63965ee7b')
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (N'1e7ed7be-ee77-4594-a361-8ad5908e1a09', N'Plovdiv', N'c4f9185e-58a8-4335-bd04-d3ea72072be5')
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (N'68b89c81-93b7-44f1-b5b9-ee5c56c0bcd5', N'Washington', N'ac074b87-a842-41d1-a30f-300b4b33fdbd')
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_AddressID]  DEFAULT (newid()) FOR [AddressID]
GO
ALTER TABLE [dbo].[Continent] ADD  CONSTRAINT [DF_Continent_ContinentID]  DEFAULT (newid()) FOR [ContinentID]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_CountryID]  DEFAULT (newid()) FOR [CountryID]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_PersonID]  DEFAULT (newid()) FOR [PersonID]
GO
ALTER TABLE [dbo].[Town] ADD  CONSTRAINT [DF_Town_TownID]  DEFAULT (newid()) FOR [TownID]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([TownID])
REFERENCES [dbo].[Town] ([TownID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continent] ([ContinentID])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([AddressID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Address"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 118
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Continent"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 101
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 118
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Person"
            Begin Extent = 
               Top = 102
               Left = 246
               Bottom = 231
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Town"
            Begin Extent = 
               Top = 120
               Left = 38
               Bottom = 232
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Tab' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Person_Location_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'le = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Person_Location_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Person_Location_View'
GO
