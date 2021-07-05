USE [master]
GO
/****** Object:  Database [campaigndb]    Script Date: 7/3/2021 4:29:51 PM ******/
CREATE DATABASE [campaigndb]
GO
ALTER DATABASE [campaigndb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [campaigndb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [campaigndb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [campaigndb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [campaigndb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [campaigndb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [campaigndb] SET ARITHABORT OFF 
GO
ALTER DATABASE [campaigndb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [campaigndb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [campaigndb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [campaigndb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [campaigndb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [campaigndb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [campaigndb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [campaigndb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [campaigndb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [campaigndb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [campaigndb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [campaigndb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [campaigndb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [campaigndb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [campaigndb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [campaigndb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [campaigndb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [campaigndb] SET RECOVERY FULL 
GO
ALTER DATABASE [campaigndb] SET  MULTI_USER 
GO
ALTER DATABASE [campaigndb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [campaigndb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [campaigndb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [campaigndb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [campaigndb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [campaigndb] SET QUERY_STORE = OFF
GO
USE [campaigndb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [campaigndb]
GO
/****** Object:  Table [dbo].[Ad]    Script Date: 7/3/2021 4:29:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ad](
	[id] [uniqueidentifier] NOT NULL,
	[content_id] [uniqueidentifier] NOT NULL,
	[link] [nvarchar](250) NOT NULL,
	[click_count] [int] NOT NULL,
	[campaign_id] [uniqueidentifier] NOT NULL,
	[registered_user_id] [uniqueidentifier] NOT NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blocks]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blocks](
	[id] [uniqueidentifier] NOT NULL,
	[blocked_by_id] [uniqueidentifier] NOT NULL,
	[blocking_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Blocks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campaign]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaign](
	[id] [uniqueidentifier] NOT NULL,
	[agent_id] [uniqueidentifier] NOT NULL,
	[likes_count] [int] NOT NULL,
	[dislikes_count] [int] NOT NULL,
	[exposure_count] [int] NOT NULL,
	[click_count] [int] NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[start_date] [datetime2](7) NULL,
	[end_date] [datetime2](7) NULL,
	[date_of_change] [datetime2](7) NULL,
	[min_date_of_birth] [datetime2](7) NULL,
	[max_date_of_birth] [datetime2](7) NULL,
	[gender] [nvarchar](10) NULL,
 CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CampaignUpdates]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignUpdates](
	[id] [uniqueidentifier] NOT NULL,
	[campaign_id] [uniqueidentifier] NOT NULL,
	[date_of_change] [datetime2](7) NULL,
	[min_date_of_birth] [datetime2](7) NULL,
	[max_date_of_birth] [datetime2](7) NULL,
	[gender] [nvarchar](10) NULL,
	[is_updated] [bit] NOT NULL,
 CONSTRAINT [PK_CampaignUpdates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CampaignRequest]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampaignRequest](
	[id] [uniqueidentifier] NOT NULL,
	[is_approved] [bit] NOT NULL,
	[campaign_id] [uniqueidentifier] NOT NULL,
	[verified_user_id] [uniqueidentifier] NOT NULL,
	[action] [nvarchar](50) NULL,
 CONSTRAINT [PK_CampaignRequest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExposureDates]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExposureDates](
	[id] [uniqueidentifier] NOT NULL,
	[campaign_id] [uniqueidentifier] NOT NULL,
	[exposure_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ExposureDateList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[id] [uniqueidentifier] NOT NULL,
	[followed_by_id] [uniqueidentifier] NOT NULL,
	[following_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mutes]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mutes](
	[id] [uniqueidentifier] NOT NULL,
	[muted_by_id] [uniqueidentifier] NOT NULL,
	[muting_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Mutes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegisteredUser]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegisteredUser](
	[id] [uniqueidentifier] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[date_of_birth] [datetime2](7) NOT NULL,
	[gender] [nvarchar](6) NOT NULL,
	[type] [nvarchar](20) NOT NULL,
	[category] [nvarchar](30) NULL,
	[profile_image_path] [nvarchar](250) NULL,
	[is_private] [bit] NOT NULL,
	[website_address] [nvarchar](250) NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[is_banned] [bit] NOT NULL,
 CONSTRAINT [PK_RegisteredUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeenBy]    Script Date: 7/3/2021 4:29:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeenBy](
	[id] [uniqueidentifier] NOT NULL,
	[registered_user_id] [uniqueidentifier] NOT NULL,
	[exposure_date_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SeenBy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ad]  WITH CHECK ADD  CONSTRAINT [FK_Ad_Campaign] FOREIGN KEY([campaign_id])
REFERENCES [dbo].[Campaign] ([id])
GO
ALTER TABLE [dbo].[Ad] CHECK CONSTRAINT [FK_Ad_Campaign]
GO
ALTER TABLE [dbo].[CampaignUpdates]  WITH CHECK ADD  CONSTRAINT [FK_CampaignUpdates_Campaign] FOREIGN KEY([campaign_id])
REFERENCES [dbo].[Campaign] ([id])
GO
ALTER TABLE [dbo].[CampaignUpdates] CHECK CONSTRAINT [FK_CampaignUpdates_Campaign]
GO
ALTER TABLE [dbo].[Ad]  WITH CHECK ADD  CONSTRAINT [FK_Ad_RegisteredUser] FOREIGN KEY([registered_user_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Ad] CHECK CONSTRAINT [FK_Ad_RegisteredUser]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_BlockedAgent_RegisteredUser2] FOREIGN KEY([blocking_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_BlockedAgent_RegisteredUser2]
GO
ALTER TABLE [dbo].[Blocks]  WITH CHECK ADD  CONSTRAINT [FK_Blocks_RegisteredUser1] FOREIGN KEY([blocked_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Blocks] CHECK CONSTRAINT [FK_Blocks_RegisteredUser1]
GO
ALTER TABLE [dbo].[Campaign]  WITH CHECK ADD  CONSTRAINT [FK_Campaign_Agent] FOREIGN KEY([agent_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Campaign] CHECK CONSTRAINT [FK_Campaign_Agent]
GO
ALTER TABLE [dbo].[CampaignRequest]  WITH CHECK ADD  CONSTRAINT [FK_CampaignRequest_Campaign] FOREIGN KEY([campaign_id])
REFERENCES [dbo].[Campaign] ([id])
GO
ALTER TABLE [dbo].[CampaignRequest] CHECK CONSTRAINT [FK_CampaignRequest_Campaign]
GO
ALTER TABLE [dbo].[CampaignRequest]  WITH CHECK ADD  CONSTRAINT [FK_CampaignRequest_RegisteredUser] FOREIGN KEY([verified_user_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[CampaignRequest] CHECK CONSTRAINT [FK_CampaignRequest_RegisteredUser]
GO
ALTER TABLE [dbo].[ExposureDates]  WITH CHECK ADD  CONSTRAINT [FK_ExposureDateList_Campaign] FOREIGN KEY([campaign_id])
REFERENCES [dbo].[Campaign] ([id])
GO
ALTER TABLE [dbo].[ExposureDates] CHECK CONSTRAINT [FK_ExposureDateList_Campaign]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_RegisteredUser1] FOREIGN KEY([followed_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_RegisteredUser1]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_RegisteredUser2] FOREIGN KEY([following_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_RegisteredUser2]
GO
ALTER TABLE [dbo].[Mutes]  WITH CHECK ADD  CONSTRAINT [FK_Mutes_RegisteredUser_muted_by] FOREIGN KEY([muted_by_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Mutes] CHECK CONSTRAINT [FK_Mutes_RegisteredUser_muted_by]
GO
ALTER TABLE [dbo].[Mutes]  WITH CHECK ADD  CONSTRAINT [FK_Mutes_RegisteredUser_muting] FOREIGN KEY([muting_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[Mutes] CHECK CONSTRAINT [FK_Mutes_RegisteredUser_muting]
GO
ALTER TABLE [dbo].[SeenBy]  WITH CHECK ADD  CONSTRAINT [FK_SeenBy_ExposureDates] FOREIGN KEY([exposure_date_id])
REFERENCES [dbo].[ExposureDates] ([id])
GO
ALTER TABLE [dbo].[SeenBy] CHECK CONSTRAINT [FK_SeenBy_ExposureDates]
GO
ALTER TABLE [dbo].[SeenBy]  WITH CHECK ADD  CONSTRAINT [FK_SeenBy_RegisteredUser] FOREIGN KEY([registered_user_id])
REFERENCES [dbo].[RegisteredUser] ([id])
GO
ALTER TABLE [dbo].[SeenBy] CHECK CONSTRAINT [FK_SeenBy_RegisteredUser]
GO
USE [master]
GO
ALTER DATABASE [campaigndb] SET  READ_WRITE 
GO
