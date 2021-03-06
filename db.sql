USE [master]
GO
/****** Object:  Database [CarTestingCard]    Script Date: 05/02/2015 02:29:30 ******/
CREATE DATABASE [CarTestingCard] ON  PRIMARY 
( NAME = N'CarTestingCard', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CarTestingCard.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CarTestingCard_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CarTestingCard_1.ldf' , SIZE = 9216KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CarTestingCard] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarTestingCard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarTestingCard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarTestingCard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarTestingCard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarTestingCard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarTestingCard] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarTestingCard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarTestingCard] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CarTestingCard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarTestingCard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarTestingCard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarTestingCard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarTestingCard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarTestingCard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarTestingCard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarTestingCard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarTestingCard] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarTestingCard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarTestingCard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarTestingCard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarTestingCard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarTestingCard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarTestingCard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarTestingCard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarTestingCard] SET RECOVERY FULL 
GO
ALTER DATABASE [CarTestingCard] SET  MULTI_USER 
GO
ALTER DATABASE [CarTestingCard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarTestingCard] SET DB_CHAINING OFF 
GO
USE [CarTestingCard]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Brand]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Visible] [bit] NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChangeRequestReason]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeRequestReason](
	[ChangeRequestReasonID] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ChangeRequestReason] PRIMARY KEY CLUSTERED 
(
	[ChangeRequestReasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Code]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[CodeID] [int] NOT NULL,
	[CodeTypeID] [int] NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Suffix] [nvarchar](50) NULL,
	[Seed] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[IncrementStep] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED 
(
	[CodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CodeType]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodeType](
	[CodeTypeID] [int] NOT NULL,
	[TItle] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_CodeType] PRIMARY KEY CLUSTERED 
(
	[CodeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](200) NULL,
	[ContactPersonID] [int] NULL,
	[Phone] [nvarchar](50) NULL,
	[AccreditationScope] [nvarchar](4000) NULL,
	[AccreditationNumber] [nvarchar](50) NULL,
	[AccreditationExpireDate] [datetime] NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[IDNo] [char](9) NULL,
	[CompanyLogoFileID] [int] NULL,
	[AccreditationLogoFileID] [int] NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyChangeRequest](
	[CompanyChangeRequestID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[CompanyName] [nvarchar](200) NULL,
	[ContactPersonID] [int] NULL,
	[Phone] [nvarchar](50) NULL,
	[AccreditationScope] [nvarchar](4000) NULL,
	[AccreditationNumber] [nvarchar](50) NULL,
	[AccreditationExpireDate] [datetime] NULL,
	[ResponsiblePersonID] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[QualityManagerConfirmStatusID] [int] NULL,
	[QualityManagerConfirmDate] [datetime] NULL,
	[QualityManagerPersonID] [int] NULL,
	[AdministratorConfirmStatusID] [int] NULL,
	[AdministratorConfirmDate] [datetime] NULL,
	[AdministratorPersonID] [int] NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_CompanyChangeRequest] PRIMARY KEY CLUSTERED 
(
	[CompanyChangeRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyHistory]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyHistory](
	[CompanyHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CompanyHistoryName] [nvarchar](200) NULL,
	[ContactPersonID] [int] NULL,
	[Phone] [nvarchar](50) NULL,
	[AccreditationScope] [nvarchar](4000) NULL,
	[AccreditationNumber] [nvarchar](50) NULL,
	[AccreditationExpireDate] [datetime] NULL,
	[ResponsiblePersonID] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_CompanyHistory] PRIMARY KEY CLUSTERED 
(
	[CompanyHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyStatistic]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyStatistic](
	[CompanyID] [int] NOT NULL,
	[ScheduleChangeRequestCnt] [int] NULL,
	[FilledCardCnt] [int] NULL,
	[TestingCardChangeRequestCnt] [int] NULL,
	[TestingCardDailyAvg] [decimal](18, 2) NULL,
	[UserOnlineTime] [int] NULL,
	[ValidCardCnt] [int] NULL,
	[InvalidCardCnt] [int] NULL,
	[FirstTestingCnt] [int] NULL,
	[SecondaryTestingCnt] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CompanyStatistic] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConfirmStatus]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfirmStatus](
	[ConfirmStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ConfirmStatusName] [nvarchar](200) NULL,
 CONSTRAINT [PK_ConfirmStatus] PRIMARY KEY CLUSTERED 
(
	[ConfirmStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ErrorCodes]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorCodes](
	[error_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](512) NULL,
 CONSTRAINT [PK__ErrorCod__DA71E16C06CD04F7] PRIMARY KEY CLUSTERED 
(
	[error_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[File]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](500) NULL,
	[FilePath] [nvarchar](2000) NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Model]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[ModelID] [int] IDENTITY(1,1) NOT NULL,
	[BrandID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Visible] [bit] NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Object]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[ObjectID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Object] PRIMARY KEY CLUSTERED 
(
	[ObjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ObjectPermission]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObjectPermission](
	[AccountTypeID] [int] NOT NULL,
	[ObjectID] [int] NOT NULL,
	[Permission] [int] NOT NULL,
 CONSTRAINT [PK_ObjectPermission] PRIMARY KEY CLUSTERED 
(
	[AccountTypeID] ASC,
	[ObjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[IDNo] [nvarchar](50) NOT NULL,
	[SystemIDNo] [nvarchar](50) NULL,
	[CompanyID] [int] NULL,
	[AccountTypeID] [int] NOT NULL,
	[FileID] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Person_1] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonChangeRequest](
	[PersonChangeRequestID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[IDNo] [nvarchar](50) NOT NULL,
	[SystemIDNo] [nvarchar](50) NULL,
	[CompanyID] [int] NOT NULL,
	[AccountTypeID] [int] NOT NULL,
	[FileID] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[QualityManagerConfirmStatusID] [int] NULL,
	[AdministratorConfirmStatusID] [int] NULL,
	[QualityManagerPersonID] [int] NULL,
	[QualityManagerConfirmDate] [datetime] NULL,
	[AdministratorConfirmDate] [datetime] NULL,
	[AdministratorPersonID] [int] NULL,
 CONSTRAINT [PK_PersonChangeRequest_1] PRIMARY KEY CLUSTERED 
(
	[PersonChangeRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonDay]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonDay](
	[PersonID] [int] NOT NULL,
	[AttendanceDate] [date] NOT NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[BreakStartTime] [time](0) NULL,
	[BreakEndTime] [time](0) NULL,
	[IsLeave] [bit] NULL,
 CONSTRAINT [PK_PersonDay] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[AttendanceDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonHistory]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonHistory](
	[PersonHierarchyID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[IDNo] [nvarchar](50) NOT NULL,
	[SystemIDNo] [nvarchar](50) NULL,
	[CompanyID] [int] NOT NULL,
	[AccountTypeID] [int] NOT NULL,
	[FileID] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonHistory] PRIMARY KEY CLUSTERED 
(
	[PersonHierarchyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonLeave]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLeave](
	[PersonID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[ResponsiblePersonID] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonLeave_1] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonLeaveChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLeaveChangeRequest](
	[PersonLeaveChangeRequestID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[ResponsiblePersonID] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[QualityManagerConfirmStatusID] [int] NULL,
	[QualityManagerConfirmDate] [datetime] NULL,
	[QualityManagerPersonID] [int] NULL,
	[AdministratorConfirmStatusID] [int] NULL,
	[AdministratorConfirmDate] [datetime] NULL,
	[AdministratorPersonID] [int] NULL,
 CONSTRAINT [PK_PersonLeaveChangeRequest_1] PRIMARY KEY CLUSTERED 
(
	[PersonLeaveChangeRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonLeaveHistory]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLeaveHistory](
	[PersonLeaveHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[ResponsiblePersonID] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonLeaveHistory_1] PRIMARY KEY CLUSTERED 
(
	[PersonLeaveHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonSchedule]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSchedule](
	[PersonID] [int] NOT NULL,
	[WeekDayNumber] [int] NOT NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[BreakStartTime] [time](0) NULL,
	[BreakEndTime] [time](0) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonSchedule] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[WeekDayNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonScheduleChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonScheduleChangeRequest](
	[PersonScheduleChangeRequestID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[ResponsiblePersonID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[QualityManagerConfirmStatusID] [int] NULL,
	[QualityManagerConfirmDate] [datetime] NULL,
	[QualityManagerPersonID] [int] NULL,
	[AdministratorConfirmStatusID] [int] NULL,
	[AdministratorConfirmDate] [datetime] NULL,
	[AdministratorPersonID] [int] NULL,
 CONSTRAINT [PK_PersonScheduleChangeRequest] PRIMARY KEY CLUSTERED 
(
	[PersonScheduleChangeRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonScheduleChangeRequestDetail]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonScheduleChangeRequestDetail](
	[PersonScheduleChangeRequestID] [int] NOT NULL,
	[WeekDayNumber] [int] NOT NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[BreakStartTime] [time](0) NULL,
	[BreakEndTime] [time](0) NULL,
 CONSTRAINT [PK_PersonScheduleChangeRequestDetails] PRIMARY KEY CLUSTERED 
(
	[PersonScheduleChangeRequestID] ASC,
	[WeekDayNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonScheduleHistory]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonScheduleHistory](
	[PersonScheduleHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[WeekDayNumber] [int] NOT NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[BreakStartTime] [time](0) NULL,
	[BreakEndTime] [time](0) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_PersonScheduleHistory] PRIMARY KEY CLUSTERED 
(
	[PersonScheduleHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonSession]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSession](
	[PersonID] [int] NOT NULL,
	[SessionNumber] [int] NOT NULL,
	[SessionID] [uniqueidentifier] NOT NULL,
	[SessionStart] [datetime] NOT NULL,
	[SessionEnd] [datetime] NULL,
	[LastSeenOn] [datetime] NULL,
	[Duration]  AS (datediff(minute,[SessionStart],isnull([SessionEnd],[LastSeenOn]))),
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonSession] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[SessionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonStatistic]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonStatistic](
	[PersonID] [int] NOT NULL,
	[ScheduleChangeRequestCnt] [int] NULL,
	[FilledCardCnt] [int] NULL,
	[TestingCardChangeRequestCnt] [int] NULL,
	[TestingCardDailyAvg] [decimal](18, 2) NULL,
	[UserOnlineTime] [int] NULL,
	[ValidCardCnt] [int] NULL,
	[InvalidCardCnt] [int] NULL,
	[FirstTestingCnt] [int] NULL,
	[SecondaryTestingCnt] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonStatistic_1] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCard]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCard](
	[TestingCardID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[TestingCardNumber] [nvarchar](50) NULL,
	[VIN] [nvarchar](50) NULL,
	[CarBrand] [nvarchar](200) NULL,
	[CarModel] [nvarchar](200) NULL,
	[CarNumber] [nvarchar](50) NULL,
	[CarSerialNo] [nvarchar](50) NULL,
	[Odometer] [decimal](8, 2) NULL,
	[OwnerName] [nvarchar](200) NULL,
	[OwnerIDNo] [nvarchar](50) NULL,
	[IsValid] [bit] NULL,
	[IsFirstTesting] [bit] NULL,
	[FirnishNumber] [nvarchar](50) NULL,
	[FirnishDate] [date] NULL,
	[Comment] [nvarchar](2000) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NULL,
 CONSTRAINT [PK_TestingCard] PRIMARY KEY CLUSTERED 
(
	[TestingCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardChangeRequest](
	[TestingCardChangeRequestID] [int] IDENTITY(1,1) NOT NULL,
	[ReasonID] [int] NULL,
	[ReasonDescription] [nvarchar](2000) NULL,
	[TestingCardID] [int] NULL,
	[Number] [nvarchar](50) NULL,
	[TestingCardNumber] [nvarchar](50) NULL,
	[VIN] [nvarchar](50) NULL,
	[CarBrand] [nvarchar](200) NULL,
	[CarModel] [nvarchar](200) NULL,
	[CarNumber] [nvarchar](50) NULL,
	[CarSerialNo] [nvarchar](50) NULL,
	[Odometer] [decimal](8, 2) NULL,
	[OwnerName] [nvarchar](200) NULL,
	[OwnerIDNo] [nvarchar](50) NULL,
	[IsValid] [bit] NULL,
	[IsFirstTesting] [bit] NULL,
	[FirnishNumber] [nvarchar](50) NULL,
	[FirnishDate] [date] NULL,
	[Comment] [nvarchar](2000) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
	[QualityManagerConfirmStatusID] [int] NULL,
	[QualityManagerConfirmDate] [datetime] NULL,
	[QualityManagerPersonID] [int] NULL,
	[AdministratorConfirmStatusID] [int] NULL,
	[AdministratorConfirmDate] [datetime] NULL,
	[AdministratorPersonID] [int] NULL,
 CONSTRAINT [PK_TestingCardChangeRequest] PRIMARY KEY CLUSTERED 
(
	[TestingCardChangeRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardDetail]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardDetail](
	[TestingCardID] [int] NOT NULL,
	[TestingSubStepID] [int] NOT NULL,
	[IsInvalid] [bit] NOT NULL,
	[IsChecked] [bit] NOT NULL,
 CONSTRAINT [PK_TestingCardDetail] PRIMARY KEY CLUSTERED 
(
	[TestingCardID] ASC,
	[TestingSubStepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardDetailChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardDetailChangeRequest](
	[TestingCardChangeRequestID] [int] NOT NULL,
	[TestingCardID] [int] NULL,
	[TestingSubStepID] [int] NOT NULL,
	[IsInvalid] [bit] NOT NULL,
	[IsChecked] [bit] NOT NULL,
 CONSTRAINT [PK_TestingCardDetailChangeRequest_1] PRIMARY KEY CLUSTERED 
(
	[TestingCardChangeRequestID] ASC,
	[TestingSubStepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardDetailHistory]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardDetailHistory](
	[TestingCardHistoryID] [int] NOT NULL,
	[TestingCardID] [int] NOT NULL,
	[TestingSubStepID] [int] NOT NULL,
	[IsInvalid] [bit] NOT NULL,
	[IsChecked] [bit] NOT NULL,
 CONSTRAINT [PK_TestingCardDetailHistory_1] PRIMARY KEY CLUSTERED 
(
	[TestingCardHistoryID] ASC,
	[TestingSubStepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardFile]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardFile](
	[TestingCardID] [int] NOT NULL,
	[FileID] [int] NOT NULL,
 CONSTRAINT [PK_TestingCardFile] PRIMARY KEY CLUSTERED 
(
	[TestingCardID] ASC,
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardFileChangeRequest]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardFileChangeRequest](
	[TestingCardChangeRequestID] [int] NOT NULL,
	[TestingCardID] [int] NOT NULL,
	[FileID] [int] NOT NULL,
 CONSTRAINT [PK_TestingCardFileChangeRequest] PRIMARY KEY CLUSTERED 
(
	[TestingCardChangeRequestID] ASC,
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingCardHistory]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingCardHistory](
	[TestingCardHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[TestingCardID] [int] NOT NULL,
	[Number] [nvarchar](50) NULL,
	[TestingCardNumber] [nvarchar](50) NULL,
	[VIN] [nvarchar](50) NULL,
	[CarBrand] [nvarchar](200) NULL,
	[CarModel] [nvarchar](200) NULL,
	[CarNumber] [nvarchar](50) NULL,
	[CarSerialNo] [nvarchar](50) NULL,
	[Odometer] [decimal](8, 2) NULL,
	[OwnerName] [nvarchar](200) NULL,
	[OwnerIDNo] [nvarchar](50) NULL,
	[IsValid] [bit] NULL,
	[IsFirstTesting] [bit] NULL,
	[FirnishNumber] [nvarchar](50) NULL,
	[FirnishDate] [date] NULL,
	[Comment] [nvarchar](2000) NULL,
	[ResponsiblePersonID] [int] NULL,
	[EffectiveDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_TestingCardHistory] PRIMARY KEY CLUSTERED 
(
	[TestingCardHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingStep]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingStep](
	[TestingStepID] [int] NOT NULL,
	[TestingStepName] [nvarchar](200) NULL,
	[OrderNumber] [int] NULL,
 CONSTRAINT [PK_TestingStep] PRIMARY KEY CLUSTERED 
(
	[TestingStepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestingSubStep]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingSubStep](
	[TestingSubStepID] [int] NOT NULL,
	[TestingSubStepName] [nvarchar](200) NULL,
	[TestingStepID] [int] NULL,
	[OrderNumber] [int] NULL,
 CONSTRAINT [PK_TestingSubStep] PRIMARY KEY CLUSTERED 
(
	[TestingSubStepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [LOG].[INTERNAL_LOG]    Script Date: 05/02/2015 02:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [LOG].[INTERNAL_LOG](
	[ERROR_NUMBER] [bigint] NULL,
	[ERROR_SEVERITY] [bigint] NULL,
	[ERROR_STATE] [bigint] NULL,
	[ERROR_OBJECT_NAME] [varchar](64) NULL,
	[ERROR_LINE] [bigint] NULL,
	[ERROR_MESSAGE] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Brand] ADD  CONSTRAINT [DF_Brand_Visible]  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Model] ADD  CONSTRAINT [DF_Model_Visible]  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_UpdateDate]  DEFAULT (getdate()) FOR [EffectiveDate]
GO
ALTER TABLE [dbo].[PersonChangeRequest] ADD  CONSTRAINT [DF_PersonChangeRequest_UpdateDate]  DEFAULT (getdate()) FOR [EffectiveDate]
GO
ALTER TABLE [dbo].[PersonHistory] ADD  CONSTRAINT [DF_PersonHistory_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[TestingCardDetail] ADD  CONSTRAINT [DF_TestingCardDetail_IsValid]  DEFAULT ((0)) FOR [IsInvalid]
GO
ALTER TABLE [dbo].[TestingCardDetail] ADD  CONSTRAINT [DF_TestingCardDetail_IsChecked]  DEFAULT ((0)) FOR [IsChecked]
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest] ADD  CONSTRAINT [DF_TestingCardDetailChangeRequest_IsValid]  DEFAULT ((0)) FOR [IsInvalid]
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest] ADD  CONSTRAINT [DF_TestingCardDetailChangeRequest_IsChecked]  DEFAULT ((0)) FOR [IsChecked]
GO
ALTER TABLE [dbo].[TestingCardDetailHistory] ADD  CONSTRAINT [DF_TestingCardDetailHistory_IsValid]  DEFAULT ((0)) FOR [IsInvalid]
GO
ALTER TABLE [dbo].[TestingCardDetailHistory] ADD  CONSTRAINT [DF_TestingCardDetailHistory_IsChecked]  DEFAULT ((0)) FOR [IsChecked]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_File_AccreditationLogo] FOREIGN KEY([AccreditationLogoFileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_File_AccreditationLogo]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_File_CompanyLogo] FOREIGN KEY([CompanyLogoFileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_File_CompanyLogo]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Person] FOREIGN KEY([ContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Person]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Person1]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_Company]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_ConfirmStatus] FOREIGN KEY([QualityManagerConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_ConfirmStatus]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_ConfirmStatus1] FOREIGN KEY([AdministratorConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_ConfirmStatus1]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_Person] FOREIGN KEY([ContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_Person]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_Person1]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_Person2] FOREIGN KEY([AdministratorPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_Person2]
GO
ALTER TABLE [dbo].[CompanyChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_CompanyChangeRequest_Person3] FOREIGN KEY([QualityManagerPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyChangeRequest] CHECK CONSTRAINT [FK_CompanyChangeRequest_Person3]
GO
ALTER TABLE [dbo].[CompanyHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyHistory_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[CompanyHistory] CHECK CONSTRAINT [FK_CompanyHistory_Company]
GO
ALTER TABLE [dbo].[CompanyHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyHistory_Person] FOREIGN KEY([ContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyHistory] CHECK CONSTRAINT [FK_CompanyHistory_Person]
GO
ALTER TABLE [dbo].[CompanyHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_CompanyHistory_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyHistory] CHECK CONSTRAINT [FK_CompanyHistory_Person1]
GO
ALTER TABLE [dbo].[CompanyHistory]  WITH CHECK ADD  CONSTRAINT [FK_CompanyHistory_Person2] FOREIGN KEY([ContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyHistory] CHECK CONSTRAINT [FK_CompanyHistory_Person2]
GO
ALTER TABLE [dbo].[CompanyHistory]  WITH CHECK ADD  CONSTRAINT [FK_CompanyHistory_Person3] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[CompanyHistory] CHECK CONSTRAINT [FK_CompanyHistory_Person3]
GO
ALTER TABLE [dbo].[CompanyStatistic]  WITH CHECK ADD  CONSTRAINT [FK_CompanyStatistic_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[CompanyStatistic] CHECK CONSTRAINT [FK_CompanyStatistic_Company]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Brand]
GO
ALTER TABLE [dbo].[ObjectPermission]  WITH CHECK ADD  CONSTRAINT [FK_ObjectPermission_AccountType] FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[ObjectPermission] CHECK CONSTRAINT [FK_ObjectPermission_AccountType]
GO
ALTER TABLE [dbo].[ObjectPermission]  WITH CHECK ADD  CONSTRAINT [FK_ObjectPermission_Object] FOREIGN KEY([ObjectID])
REFERENCES [dbo].[Object] ([ObjectID])
GO
ALTER TABLE [dbo].[ObjectPermission] CHECK CONSTRAINT [FK_ObjectPermission_Object]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_AccountType] FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_AccountType]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Company]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_File]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Person]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_AccountType] FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_AccountType]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_AdminConfirmStatus] FOREIGN KEY([AdministratorConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_AdminConfirmStatus]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_AdminPerson] FOREIGN KEY([AdministratorPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_AdminPerson]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_Company]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_File]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_Person]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_QualityManagerConfirmStatus] FOREIGN KEY([QualityManagerConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_QualityManagerConfirmStatus]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonChangeRequest_QualityManagerPerson] FOREIGN KEY([QualityManagerPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_QualityManagerPerson]
GO
ALTER TABLE [dbo].[PersonChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_PersonChangeRequest_ResponsiblePerson] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonChangeRequest] CHECK CONSTRAINT [FK_PersonChangeRequest_ResponsiblePerson]
GO
ALTER TABLE [dbo].[PersonDay]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonDay_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonDay] CHECK CONSTRAINT [FK_PersonDay_Person]
GO
ALTER TABLE [dbo].[PersonHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonHistory_AccountType] FOREIGN KEY([AccountTypeID])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[PersonHistory] CHECK CONSTRAINT [FK_PersonHistory_AccountType]
GO
ALTER TABLE [dbo].[PersonHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonHistory_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[PersonHistory] CHECK CONSTRAINT [FK_PersonHistory_Company]
GO
ALTER TABLE [dbo].[PersonHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonHistory_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[PersonHistory] CHECK CONSTRAINT [FK_PersonHistory_File]
GO
ALTER TABLE [dbo].[PersonHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonHistory_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonHistory] CHECK CONSTRAINT [FK_PersonHistory_Person]
GO
ALTER TABLE [dbo].[PersonHistory]  WITH CHECK ADD  CONSTRAINT [FK_PersonHistory_Person1] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonHistory] CHECK CONSTRAINT [FK_PersonHistory_Person1]
GO
ALTER TABLE [dbo].[PersonLeave]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeave_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeave] CHECK CONSTRAINT [FK_PersonLeave_Person]
GO
ALTER TABLE [dbo].[PersonLeave]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeave_Person1] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeave] CHECK CONSTRAINT [FK_PersonLeave_Person1]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_ConfirmStatus] FOREIGN KEY([QualityManagerConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_ConfirmStatus]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_ConfirmStatus1] FOREIGN KEY([AdministratorConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_ConfirmStatus1]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_Person]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_Person1] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_Person1]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_Person2] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_Person2]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_Person3] FOREIGN KEY([AdministratorPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_Person3]
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_PersonLeaveChangeRequest_Person4] FOREIGN KEY([QualityManagerPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveChangeRequest] CHECK CONSTRAINT [FK_PersonLeaveChangeRequest_Person4]
GO
ALTER TABLE [dbo].[PersonLeaveHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveHistory_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveHistory] CHECK CONSTRAINT [FK_PersonLeaveHistory_Person]
GO
ALTER TABLE [dbo].[PersonLeaveHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonLeaveHistory_Person1] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonLeaveHistory] CHECK CONSTRAINT [FK_PersonLeaveHistory_Person1]
GO
ALTER TABLE [dbo].[PersonSchedule]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonSchedule_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonSchedule] CHECK CONSTRAINT [FK_PersonSchedule_Person]
GO
ALTER TABLE [dbo].[PersonSchedule]  WITH CHECK ADD  CONSTRAINT [FK_PersonSchedule_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonSchedule] CHECK CONSTRAINT [FK_PersonSchedule_Person1]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequest_AdminConfirmStatus] FOREIGN KEY([AdministratorConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest] CHECK CONSTRAINT [FK_PersonScheduleChangeRequest_AdminConfirmStatus]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequest_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest] CHECK CONSTRAINT [FK_PersonScheduleChangeRequest_Person]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequest_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest] CHECK CONSTRAINT [FK_PersonScheduleChangeRequest_Person1]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequest_Person2] FOREIGN KEY([AdministratorPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest] CHECK CONSTRAINT [FK_PersonScheduleChangeRequest_Person2]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequest_Person3] FOREIGN KEY([QualityManagerPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest] CHECK CONSTRAINT [FK_PersonScheduleChangeRequest_Person3]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequest_QualityManagerConfirmStatus] FOREIGN KEY([QualityManagerConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequest] CHECK CONSTRAINT [FK_PersonScheduleChangeRequest_QualityManagerConfirmStatus]
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequestDetail]  WITH CHECK ADD  CONSTRAINT [FK_PersonScheduleChangeRequestDetails_PersonScheduleChangeRequest] FOREIGN KEY([PersonScheduleChangeRequestID])
REFERENCES [dbo].[PersonScheduleChangeRequest] ([PersonScheduleChangeRequestID])
GO
ALTER TABLE [dbo].[PersonScheduleChangeRequestDetail] CHECK CONSTRAINT [FK_PersonScheduleChangeRequestDetails_PersonScheduleChangeRequest]
GO
ALTER TABLE [dbo].[PersonScheduleHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonScheduleHistory_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonScheduleHistory] CHECK CONSTRAINT [FK_PersonScheduleHistory_Person]
GO
ALTER TABLE [dbo].[PersonScheduleHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonScheduleHistory_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonScheduleHistory] CHECK CONSTRAINT [FK_PersonScheduleHistory_Person1]
GO
ALTER TABLE [dbo].[PersonSession]  WITH CHECK ADD  CONSTRAINT [FK_PersonSession_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonSession] CHECK CONSTRAINT [FK_PersonSession_Person]
GO
ALTER TABLE [dbo].[PersonStatistic]  WITH CHECK ADD  CONSTRAINT [FK_PersonStatistic_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonStatistic] CHECK CONSTRAINT [FK_PersonStatistic_Person]
GO
ALTER TABLE [dbo].[TestingCard]  WITH CHECK ADD  CONSTRAINT [FK_TestingCard_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TestingCard] CHECK CONSTRAINT [FK_TestingCard_Person]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_ChangeRequestReason] FOREIGN KEY([ReasonID])
REFERENCES [dbo].[ChangeRequestReason] ([ChangeRequestReasonID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_ChangeRequestReason]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_ConfirmStatus] FOREIGN KEY([QualityManagerConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_ConfirmStatus]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_ConfirmStatus1] FOREIGN KEY([AdministratorConfirmStatusID])
REFERENCES [dbo].[ConfirmStatus] ([ConfirmStatusID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_ConfirmStatus1]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_Person] FOREIGN KEY([QualityManagerPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_Person]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_Person1] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_Person1]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_Person3] FOREIGN KEY([AdministratorPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_Person3]
GO
ALTER TABLE [dbo].[TestingCardChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardChangeRequest_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardChangeRequest] CHECK CONSTRAINT [FK_TestingCardChangeRequest_TestingCard]
GO
ALTER TABLE [dbo].[TestingCardDetail]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardDetail_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardDetail] CHECK CONSTRAINT [FK_TestingCardDetail_TestingCard]
GO
ALTER TABLE [dbo].[TestingCardDetail]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardDetail_TestingSubStep] FOREIGN KEY([TestingSubStepID])
REFERENCES [dbo].[TestingSubStep] ([TestingSubStepID])
GO
ALTER TABLE [dbo].[TestingCardDetail] CHECK CONSTRAINT [FK_TestingCardDetail_TestingSubStep]
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardDetailChangeRequest_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest] CHECK CONSTRAINT [FK_TestingCardDetailChangeRequest_TestingCard]
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardDetailChangeRequest_TestingCardChangeRequest] FOREIGN KEY([TestingCardChangeRequestID])
REFERENCES [dbo].[TestingCardChangeRequest] ([TestingCardChangeRequestID])
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest] CHECK CONSTRAINT [FK_TestingCardDetailChangeRequest_TestingCardChangeRequest]
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardDetailChangeRequest_TestingSubStep] FOREIGN KEY([TestingSubStepID])
REFERENCES [dbo].[TestingSubStep] ([TestingSubStepID])
GO
ALTER TABLE [dbo].[TestingCardDetailChangeRequest] CHECK CONSTRAINT [FK_TestingCardDetailChangeRequest_TestingSubStep]
GO
ALTER TABLE [dbo].[TestingCardDetailHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardDetailHistory_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardDetailHistory] CHECK CONSTRAINT [FK_TestingCardDetailHistory_TestingCard]
GO
ALTER TABLE [dbo].[TestingCardDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_TestingCardDetailHistory_TestingCardHistory] FOREIGN KEY([TestingCardHistoryID])
REFERENCES [dbo].[TestingCardHistory] ([TestingCardHistoryID])
GO
ALTER TABLE [dbo].[TestingCardDetailHistory] CHECK CONSTRAINT [FK_TestingCardDetailHistory_TestingCardHistory]
GO
ALTER TABLE [dbo].[TestingCardDetailHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardDetailHistory_TestingSubStep] FOREIGN KEY([TestingSubStepID])
REFERENCES [dbo].[TestingSubStep] ([TestingSubStepID])
GO
ALTER TABLE [dbo].[TestingCardDetailHistory] CHECK CONSTRAINT [FK_TestingCardDetailHistory_TestingSubStep]
GO
ALTER TABLE [dbo].[TestingCardFile]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardFile_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[TestingCardFile] CHECK CONSTRAINT [FK_TestingCardFile_File]
GO
ALTER TABLE [dbo].[TestingCardFile]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardFile_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardFile] CHECK CONSTRAINT [FK_TestingCardFile_TestingCard]
GO
ALTER TABLE [dbo].[TestingCardFileChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardFileChangeRequest_File] FOREIGN KEY([FileID])
REFERENCES [dbo].[File] ([FileID])
GO
ALTER TABLE [dbo].[TestingCardFileChangeRequest] CHECK CONSTRAINT [FK_TestingCardFileChangeRequest_File]
GO
ALTER TABLE [dbo].[TestingCardFileChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardFileChangeRequest_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardFileChangeRequest] CHECK CONSTRAINT [FK_TestingCardFileChangeRequest_TestingCard]
GO
ALTER TABLE [dbo].[TestingCardFileChangeRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardFileChangeRequest_TestingCardChangeRequest] FOREIGN KEY([TestingCardChangeRequestID])
REFERENCES [dbo].[TestingCardChangeRequest] ([TestingCardChangeRequestID])
GO
ALTER TABLE [dbo].[TestingCardFileChangeRequest] CHECK CONSTRAINT [FK_TestingCardFileChangeRequest_TestingCardChangeRequest]
GO
ALTER TABLE [dbo].[TestingCardHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardHistory_Person] FOREIGN KEY([ResponsiblePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TestingCardHistory] CHECK CONSTRAINT [FK_TestingCardHistory_Person]
GO
ALTER TABLE [dbo].[TestingCardHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_TestingCardHistory_TestingCard] FOREIGN KEY([TestingCardID])
REFERENCES [dbo].[TestingCard] ([TestingCardID])
GO
ALTER TABLE [dbo].[TestingCardHistory] CHECK CONSTRAINT [FK_TestingCardHistory_TestingCard]
GO
ALTER TABLE [dbo].[TestingSubStep]  WITH CHECK ADD  CONSTRAINT [FK_TestingSubStep_TestingStep] FOREIGN KEY([TestingStepID])
REFERENCES [dbo].[TestingStep] ([TestingStepID])
GO
ALTER TABLE [dbo].[TestingSubStep] CHECK CONSTRAINT [FK_TestingSubStep_TestingStep]
GO
USE [master]
GO
ALTER DATABASE [CarTestingCard] SET  READ_WRITE 
GO
