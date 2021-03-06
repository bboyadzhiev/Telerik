USE [UniversityDB2]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses_Lecturers]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Lecturers](
	[CourseID] [uniqueidentifier] NOT NULL,
	[LecturerID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Courses_Lecturers] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[LecturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses_Students]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Students](
	[CourseID] [uniqueidentifier] NOT NULL,
	[StudentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Courses_Students] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FacultyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments_Courses]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments_Courses](
	[DepartmentID] [uniqueidentifier] NOT NULL,
	[CourseID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Departments_Courses] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments_Lecturers]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments_Lecturers](
	[LecturerID] [uniqueidentifier] NOT NULL,
	[DepartmentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Departments_Lecturers] PRIMARY KEY CLUSTERED 
(
	[LecturerID] ASC,
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculties](
	[FacultyID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lecturers]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturers](
	[LecturerID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Lecturers] PRIMARY KEY CLUSTERED 
(
	[LecturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lecturers_Titles]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturers_Titles](
	[LecturerID] [uniqueidentifier] NOT NULL,
	[TitleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Lecturers_Titles] PRIMARY KEY CLUSTERED 
(
	[LecturerID] ASC,
	[TitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [uniqueidentifier] NOT NULL,
	[FacultyNumber] [int] NOT NULL,
	[FacultyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 21.8.2014 г. 00:43:02 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Titles](
	[TitleID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[TitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Courses] ([CourseID], [Name]) VALUES (N'df3f5da8-1d9a-4f26-80dc-10fc8f664fdc', N'JavaScript OOP')
INSERT [dbo].[Courses] ([CourseID], [Name]) VALUES (N'80de4634-c48b-4605-bfdc-22c4422409e4', N'C Sharp I')
INSERT [dbo].[Courses] ([CourseID], [Name]) VALUES (N'94ed3f4b-744b-4bce-924a-3bf16190b45c', N'OOP')
INSERT [dbo].[Courses] ([CourseID], [Name]) VALUES (N'43461750-d811-40c0-8f56-5c7ac271f77d', N'C Sharp II')
INSERT [dbo].[Courses] ([CourseID], [Name]) VALUES (N'587b5229-72fc-488f-a429-8df0fc10e1ed', N'JavaScript UI & DOM')
INSERT [dbo].[Departments] ([DepartmentID], [Name], [FacultyID]) VALUES (N'0b6a90f0-fd90-4f15-8895-4efcd79fa04b', N'Algo Academy', N'7aa50365-01ca-469d-89a4-4ab995eeef6a')
INSERT [dbo].[Departments] ([DepartmentID], [Name], [FacultyID]) VALUES (N'2df18e48-6f59-48cb-a37c-623ced0a8622', N'Student Academy', N'7aa50365-01ca-469d-89a4-4ab995eeef6a')
INSERT [dbo].[Departments] ([DepartmentID], [Name], [FacultyID]) VALUES (N'e67489e1-dda0-4275-a5f9-fcc8f12f1122', N'School Academy', N'7aa50365-01ca-469d-89a4-4ab995eeef6a')
INSERT [dbo].[Departments_Lecturers] ([LecturerID], [DepartmentID]) VALUES (N'e6aeb5b0-73ae-43e7-a98e-3b155b362560', N'2df18e48-6f59-48cb-a37c-623ced0a8622')
INSERT [dbo].[Departments_Lecturers] ([LecturerID], [DepartmentID]) VALUES (N'2d2f82ad-bf33-4735-84e1-86e4d6c6e74a', N'2df18e48-6f59-48cb-a37c-623ced0a8622')
INSERT [dbo].[Departments_Lecturers] ([LecturerID], [DepartmentID]) VALUES (N'e713645e-6c63-46e2-984b-94b7a446f600', N'2df18e48-6f59-48cb-a37c-623ced0a8622')
INSERT [dbo].[Departments_Lecturers] ([LecturerID], [DepartmentID]) VALUES (N'e713645e-6c63-46e2-984b-94b7a446f600', N'e67489e1-dda0-4275-a5f9-fcc8f12f1122')
INSERT [dbo].[Departments_Lecturers] ([LecturerID], [DepartmentID]) VALUES (N'7e539c1c-f137-4307-b358-9c244b5847e3', N'2df18e48-6f59-48cb-a37c-623ced0a8622')
INSERT [dbo].[Departments_Lecturers] ([LecturerID], [DepartmentID]) VALUES (N'7e539c1c-f137-4307-b358-9c244b5847e3', N'e67489e1-dda0-4275-a5f9-fcc8f12f1122')
INSERT [dbo].[Faculties] ([FacultyID], [Name]) VALUES (N'7aa50365-01ca-469d-89a4-4ab995eeef6a', N'Teleric Academy')
INSERT [dbo].[Lecturers] ([LecturerID]) VALUES (N'e6aeb5b0-73ae-43e7-a98e-3b155b362560')
INSERT [dbo].[Lecturers] ([LecturerID]) VALUES (N'2d2f82ad-bf33-4735-84e1-86e4d6c6e74a')
INSERT [dbo].[Lecturers] ([LecturerID]) VALUES (N'e713645e-6c63-46e2-984b-94b7a446f600')
INSERT [dbo].[Lecturers] ([LecturerID]) VALUES (N'7e539c1c-f137-4307-b358-9c244b5847e3')
INSERT [dbo].[Lecturers_Titles] ([LecturerID], [TitleID]) VALUES (N'e6aeb5b0-73ae-43e7-a98e-3b155b362560', N'230f3735-ad99-44ca-8cf4-54aa14262423')
INSERT [dbo].[Lecturers_Titles] ([LecturerID], [TitleID]) VALUES (N'e6aeb5b0-73ae-43e7-a98e-3b155b362560', N'8bd360a8-87f5-4869-8c99-b3dfe58eba64')
INSERT [dbo].[Lecturers_Titles] ([LecturerID], [TitleID]) VALUES (N'2d2f82ad-bf33-4735-84e1-86e4d6c6e74a', N'a060e2ed-3ace-4dd8-a9fe-7bb5be6cdd50')
INSERT [dbo].[Lecturers_Titles] ([LecturerID], [TitleID]) VALUES (N'e713645e-6c63-46e2-984b-94b7a446f600', N'8bd360a8-87f5-4869-8c99-b3dfe58eba64')
INSERT [dbo].[Lecturers_Titles] ([LecturerID], [TitleID]) VALUES (N'7e539c1c-f137-4307-b358-9c244b5847e3', N'8bd360a8-87f5-4869-8c99-b3dfe58eba64')
INSERT [dbo].[Persons] ([PersonID], [Name]) VALUES (N'e6aeb5b0-73ae-43e7-a98e-3b155b362560', N'Doncho Minchev')
INSERT [dbo].[Persons] ([PersonID], [Name]) VALUES (N'66e2ce6a-7b14-4b0b-bf7f-3f2da674cece', N'Gosho')
INSERT [dbo].[Persons] ([PersonID], [Name]) VALUES (N'2d2f82ad-bf33-4735-84e1-86e4d6c6e74a', N'Evlogi Hristov')
INSERT [dbo].[Persons] ([PersonID], [Name]) VALUES (N'e713645e-6c63-46e2-984b-94b7a446f600', N'Nikolai Kostov')
INSERT [dbo].[Persons] ([PersonID], [Name]) VALUES (N'7e539c1c-f137-4307-b358-9c244b5847e3', N'Ivaylo Kenov')
INSERT [dbo].[Persons] ([PersonID], [Name]) VALUES (N'1035f00a-5f7f-43c0-b7fe-b83e63d43198', N'Pesho')
INSERT [dbo].[Titles] ([TitleID], [Name]) VALUES (N'230f3735-ad99-44ca-8cf4-54aa14262423', N'Prof')
INSERT [dbo].[Titles] ([TitleID], [Name]) VALUES (N'a060e2ed-3ace-4dd8-a9fe-7bb5be6cdd50', N'assistant')
INSERT [dbo].[Titles] ([TitleID], [Name]) VALUES (N'8bd360a8-87f5-4869-8c99-b3dfe58eba64', N'Ph. D')
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_CourseID]  DEFAULT (newid()) FOR [CourseID]
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Departments_DepartmentID]  DEFAULT (newid()) FOR [DepartmentID]
GO
ALTER TABLE [dbo].[Faculties] ADD  CONSTRAINT [DF_Faculties_FacultyID]  DEFAULT (newid()) FOR [FacultyID]
GO
ALTER TABLE [dbo].[Persons] ADD  CONSTRAINT [DF_Persons_PersonID]  DEFAULT (newid()) FOR [PersonID]
GO
ALTER TABLE [dbo].[Titles] ADD  CONSTRAINT [DF_Titles_TitleID]  DEFAULT (newid()) FOR [TitleID]
GO
ALTER TABLE [dbo].[Courses_Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Lecturers_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Courses_Lecturers] CHECK CONSTRAINT [FK_Courses_Lecturers_Courses]
GO
ALTER TABLE [dbo].[Courses_Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Lecturers_Lecturers] FOREIGN KEY([LecturerID])
REFERENCES [dbo].[Lecturers] ([LecturerID])
GO
ALTER TABLE [dbo].[Courses_Lecturers] CHECK CONSTRAINT [FK_Courses_Lecturers_Lecturers]
GO
ALTER TABLE [dbo].[Courses_Students]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Students_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Courses_Students] CHECK CONSTRAINT [FK_Courses_Students_Courses]
GO
ALTER TABLE [dbo].[Courses_Students]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Students_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Courses_Students] CHECK CONSTRAINT [FK_Courses_Students_Students]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([FacultyID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Departments_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Courses_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[Departments_Courses] CHECK CONSTRAINT [FK_Departments_Courses_Courses]
GO
ALTER TABLE [dbo].[Departments_Courses]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Courses_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Departments_Courses] CHECK CONSTRAINT [FK_Departments_Courses_Departments]
GO
ALTER TABLE [dbo].[Departments_Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Lecturers_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Departments_Lecturers] CHECK CONSTRAINT [FK_Departments_Lecturers_Departments]
GO
ALTER TABLE [dbo].[Departments_Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Lecturers_Lecturers] FOREIGN KEY([LecturerID])
REFERENCES [dbo].[Lecturers] ([LecturerID])
GO
ALTER TABLE [dbo].[Departments_Lecturers] CHECK CONSTRAINT [FK_Departments_Lecturers_Lecturers]
GO
ALTER TABLE [dbo].[Lecturers]  WITH CHECK ADD  CONSTRAINT [FK_Lecturers_Persons] FOREIGN KEY([LecturerID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Lecturers] CHECK CONSTRAINT [FK_Lecturers_Persons]
GO
ALTER TABLE [dbo].[Lecturers_Titles]  WITH CHECK ADD  CONSTRAINT [FK_Lecturers_Titles_Lecturers] FOREIGN KEY([LecturerID])
REFERENCES [dbo].[Lecturers] ([LecturerID])
GO
ALTER TABLE [dbo].[Lecturers_Titles] CHECK CONSTRAINT [FK_Lecturers_Titles_Lecturers]
GO
ALTER TABLE [dbo].[Lecturers_Titles]  WITH CHECK ADD  CONSTRAINT [FK_Lecturers_Titles_Titles] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Titles] ([TitleID])
GO
ALTER TABLE [dbo].[Lecturers_Titles] CHECK CONSTRAINT [FK_Lecturers_Titles_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([FacultyID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Persons] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Persons]
GO
