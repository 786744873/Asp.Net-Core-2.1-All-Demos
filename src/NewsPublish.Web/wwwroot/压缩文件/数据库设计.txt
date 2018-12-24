if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('News') and o.name = 'FK_NewsClassify_News')
alter table News
   drop constraint FK_NewsClassify_News
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NewsComment') and o.name = 'FK_News_NewsComment')
alter table NewsComment
   drop constraint FK_News_NewsComment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Banner')
            and   type = 'U')
   drop table Banner
go

if exists (select 1
            from  sysobjects
           where  id = object_id('News')
            and   type = 'U')
   drop table News
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NewsClassify')
            and   type = 'U')
   drop table NewsClassify
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NewsComment')
            and   type = 'U')
   drop table NewsComment
go

/*==============================================================*/
/* Table: Banner                                                */
/*==============================================================*/
create table Banner (
   Id                   int                  identity,
   Image                varchar(200)         not null,
   Url                  varchar(100)         null,
   AddTime              datetime             null,
   Remark               varchar(200)         null,
   constraint PK_BANNER primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Banner表',
   'user', @CurrentUser, 'table', 'Banner'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'Banner', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Banner图片',
   'user', @CurrentUser, 'table', 'Banner', 'column', 'Image'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '跳转地址',
   'user', @CurrentUser, 'table', 'Banner', 'column', 'Url'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'Banner', 'column', 'AddTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Banner', 'column', 'Remark'
go

/*==============================================================*/
/* Table: News                                                  */
/*==============================================================*/
create table News (
   Id                   int                  identity,
   NewsClassifyId           int                  not null,
   Title                varchar(1000)        null,
   Image                varchar(200)         null,
   Contents              text                 null,
   PublishDate          datetime             null,
   Remark               varchar(200)         null,
   constraint PK_NEWS primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻表',
   'user', @CurrentUser, 'table', 'News'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'News', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻类别编号',
   'user', @CurrentUser, 'table', 'News', 'column', 'NewsClassifyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻标题',
   'user', @CurrentUser, 'table', 'News', 'column', 'Title'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻图片',
   'user', @CurrentUser, 'table', 'News', 'column', 'Image'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻内容',
   'user', @CurrentUser, 'table', 'News', 'column', 'Contents'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布日期',
   'user', @CurrentUser, 'table', 'News', 'column', 'PublishDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'News', 'column', 'Remark'
go

/*==============================================================*/
/* Table: NewsClassify                                          */
/*==============================================================*/
create table NewsClassify (
   Id                   int                  identity,
   Name                 varchar(100)         null,
   Sort                 int                  null,
   Remark               varchar(200)         null,
   constraint PK_NEWSCLASSIFY primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻类别表',
   'user', @CurrentUser, 'table', 'NewsClassify'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'NewsClassify', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类别名称',
   'user', @CurrentUser, 'table', 'NewsClassify', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序编号(从大到小排列)',
   'user', @CurrentUser, 'table', 'NewsClassify', 'column', 'Sort'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'NewsClassify', 'column', 'Remark'
go

/*==============================================================*/
/* Table: NewsComment                                           */
/*==============================================================*/
create table NewsComment (
   Id                   int                  identity,
   NewsId               int                  not null,
   Contents              varchar(2000)        null,
   AddTime              datetime             null,
   Remark               varchar(200)         null,
   constraint PK_NEWSCOMMENT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻评论表',
   'user', @CurrentUser, 'table', 'NewsComment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编号',
   'user', @CurrentUser, 'table', 'NewsComment', 'column', 'Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '新闻编号',
   'user', @CurrentUser, 'table', 'NewsComment', 'column', 'NewsId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '评论内容',
   'user', @CurrentUser, 'table', 'NewsComment', 'column', 'Contents'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '评论时间',
   'user', @CurrentUser, 'table', 'NewsComment', 'column', 'AddTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'NewsComment', 'column', 'Remark'
go

alter table News
   add constraint FK_NewsClassify_News foreign key (NewsClassifyId)
      references NewsClassify (Id)
go

alter table NewsComment
   add constraint FK_News_NewsComment foreign key (NewsId)
      references News (Id)
go

