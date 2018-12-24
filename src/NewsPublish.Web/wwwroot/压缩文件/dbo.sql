/*
 Navicat Premium Data Transfer

 Source Server         : 本机
 Source Server Type    : SQL Server
 Source Server Version : 10501600
 Source Host           : .:1433
 Source Catalog        : NewsPublish
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 10501600
 File Encoding         : 65001

 Date: 24/12/2018 15:39:45
*/


-- ----------------------------
-- Table structure for Banner
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Banner]') AND type IN ('U'))
	DROP TABLE [dbo].[Banner]
GO

CREATE TABLE [dbo].[Banner] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Image] varchar(200) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Url] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [AddTime] datetime  NULL,
  [Remark] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Banner] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'编号',
'SCHEMA', N'dbo',
'TABLE', N'Banner',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'Banner图片',
'SCHEMA', N'dbo',
'TABLE', N'Banner',
'COLUMN', N'Image'
GO

EXEC sp_addextendedproperty
'MS_Description', N'跳转地址',
'SCHEMA', N'dbo',
'TABLE', N'Banner',
'COLUMN', N'Url'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加时间',
'SCHEMA', N'dbo',
'TABLE', N'Banner',
'COLUMN', N'AddTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Banner',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'Banner表',
'SCHEMA', N'dbo',
'TABLE', N'Banner'
GO


-- ----------------------------
-- Records of Banner
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Banner] ON
GO

INSERT INTO [dbo].[Banner] ([Id], [Image], [Url], [AddTime], [Remark]) VALUES (N'2', N'/BannerPic/20181221162634.jpg', N'www.baidu.com', N'2018-12-21 16:26:34.020', N'1234567')
GO

INSERT INTO [dbo].[Banner] ([Id], [Image], [Url], [AddTime], [Remark]) VALUES (N'3', N'/BannerPic/20181221162808.png', N'www.baidu.com', N'2018-12-21 16:28:08.633', N'12345678')
GO

SET IDENTITY_INSERT [dbo].[Banner] OFF
GO


-- ----------------------------
-- Table structure for News
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[News]') AND type IN ('U'))
	DROP TABLE [dbo].[News]
GO

CREATE TABLE [dbo].[News] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [NewsClassifyId] int  NOT NULL,
  [Title] varchar(1000) COLLATE Chinese_PRC_CI_AS  NULL,
  [Image] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL,
  [Contents] text COLLATE Chinese_PRC_CI_AS  NULL,
  [PublishDate] datetime  NULL,
  [Remark] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[News] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'编号',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻类别编号',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'NewsClassifyId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻标题',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'Title'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻图片',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'Image'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻内容',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'Contents'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发布日期',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'PublishDate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'News',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻表',
'SCHEMA', N'dbo',
'TABLE', N'News'
GO


-- ----------------------------
-- Records of News
-- ----------------------------
SET IDENTITY_INSERT [dbo].[News] ON
GO

INSERT INTO [dbo].[News] ([Id], [NewsClassifyId], [Title], [Image], [Contents], [PublishDate], [Remark]) VALUES (N'1', N'2', N'123456', N'/NewsPic/20181224143534.jpg', N'888888', N'2018-12-24 14:35:34.813', NULL)
GO

INSERT INTO [dbo].[News] ([Id], [NewsClassifyId], [Title], [Image], [Contents], [PublishDate], [Remark]) VALUES (N'2', N'1', N'wewe', N'/NewsPic/20181224143801.png', N'tttttttttttttt', N'2018-12-24 14:38:01.913', NULL)
GO

SET IDENTITY_INSERT [dbo].[News] OFF
GO


-- ----------------------------
-- Table structure for NewsClassify
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsClassify]') AND type IN ('U'))
	DROP TABLE [dbo].[NewsClassify]
GO

CREATE TABLE [dbo].[NewsClassify] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Name] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sort] int  NULL,
  [Remark] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[NewsClassify] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'编号',
'SCHEMA', N'dbo',
'TABLE', N'NewsClassify',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'类别名称',
'SCHEMA', N'dbo',
'TABLE', N'NewsClassify',
'COLUMN', N'Name'
GO

EXEC sp_addextendedproperty
'MS_Description', N'排序编号(从大到小排列)',
'SCHEMA', N'dbo',
'TABLE', N'NewsClassify',
'COLUMN', N'Sort'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'NewsClassify',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻类别表',
'SCHEMA', N'dbo',
'TABLE', N'NewsClassify'
GO


-- ----------------------------
-- Records of NewsClassify
-- ----------------------------
SET IDENTITY_INSERT [dbo].[NewsClassify] ON
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'1', N'时政要闻', N'7', N'时政备注')
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'2', N'军事', N'3', N'军事新闻备注')
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'3', N'房产', N'0', NULL)
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'4', N'体育', N'1', NULL)
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'5', N'经济', N'2', NULL)
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'6', N'国际新闻', N'4', NULL)
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'7', N'404', N'5', NULL)
GO

INSERT INTO [dbo].[NewsClassify] ([Id], [Name], [Sort], [Remark]) VALUES (N'8', N'国内新闻', N'6', NULL)
GO

SET IDENTITY_INSERT [dbo].[NewsClassify] OFF
GO


-- ----------------------------
-- Table structure for NewsComment
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsComment]') AND type IN ('U'))
	DROP TABLE [dbo].[NewsComment]
GO

CREATE TABLE [dbo].[NewsComment] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [NewsId] int  NOT NULL,
  [Contents] varchar(2000) COLLATE Chinese_PRC_CI_AS  NULL,
  [AddTime] datetime  NULL,
  [Remark] varchar(200) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[NewsComment] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'编号',
'SCHEMA', N'dbo',
'TABLE', N'NewsComment',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻编号',
'SCHEMA', N'dbo',
'TABLE', N'NewsComment',
'COLUMN', N'NewsId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'评论内容',
'SCHEMA', N'dbo',
'TABLE', N'NewsComment',
'COLUMN', N'Contents'
GO

EXEC sp_addextendedproperty
'MS_Description', N'评论时间',
'SCHEMA', N'dbo',
'TABLE', N'NewsComment',
'COLUMN', N'AddTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'NewsComment',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'新闻评论表',
'SCHEMA', N'dbo',
'TABLE', N'NewsComment'
GO


-- ----------------------------
-- Records of NewsComment
-- ----------------------------
SET IDENTITY_INSERT [dbo].[NewsComment] ON
GO

INSERT INTO [dbo].[NewsComment] ([Id], [NewsId], [Contents], [AddTime], [Remark]) VALUES (N'1', N'1', N'评论内容', N'2018-12-24 14:45:56.000', N'评论备注')
GO

INSERT INTO [dbo].[NewsComment] ([Id], [NewsId], [Contents], [AddTime], [Remark]) VALUES (N'2', N'1', N'评论内容2', N'2018-12-24 14:45:56.000', N'评论备注2')
GO

INSERT INTO [dbo].[NewsComment] ([Id], [NewsId], [Contents], [AddTime], [Remark]) VALUES (N'3', N'1', N'评论内容3', N'2018-12-24 14:45:56.000', N'评论备注3')
GO

SET IDENTITY_INSERT [dbo].[NewsComment] OFF
GO


-- ----------------------------
-- Primary Key structure for table Banner
-- ----------------------------
ALTER TABLE [dbo].[Banner] ADD CONSTRAINT [PK_BANNER] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table News
-- ----------------------------
ALTER TABLE [dbo].[News] ADD CONSTRAINT [PK_NEWS] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table NewsClassify
-- ----------------------------
ALTER TABLE [dbo].[NewsClassify] ADD CONSTRAINT [PK_NEWSCLASSIFY] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table NewsComment
-- ----------------------------
ALTER TABLE [dbo].[NewsComment] ADD CONSTRAINT [PK_NEWSCOMMENT] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table News
-- ----------------------------
ALTER TABLE [dbo].[News] ADD CONSTRAINT [FK_NewsClassify_News] FOREIGN KEY ([NewsClassifyId]) REFERENCES [dbo].[NewsClassify] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table NewsComment
-- ----------------------------
ALTER TABLE [dbo].[NewsComment] ADD CONSTRAINT [FK_News_NewsComment] FOREIGN KEY ([NewsId]) REFERENCES [dbo].[News] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

