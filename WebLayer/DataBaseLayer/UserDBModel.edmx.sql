
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/08/2017 16:39:55
-- Generated from EDMX file: C:\Users\Kristoffer\Source\Repos\HT2016WinterProjekt\WebLayer\DataBaseLayer\UserDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Friends_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK_Friends_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Friends_User_Name]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK_Friends_User_Name];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[FriendRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FriendRequests];
GO
IF OBJECT_ID(N'[dbo].[Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friends];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Post];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[MSreplication_options]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[MSreplication_options];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_fallback_db]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_fallback_db];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_fallback_dev]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_fallback_dev];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_fallback_usg]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_fallback_usg];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_monitor]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_monitor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Iid] int IDENTITY(1,1) NOT NULL,
    [ImageSize] int  NOT NULL,
    [FileName] nvarchar(max)  NULL,
    [ImageData] varbinary(max)  NULL
);
GO

-- Creating table 'Profile'
CREATE TABLE [dbo].[Profile] (
    [Pid] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [City] nvarchar(max)  NULL,
    [SexOrient] nvarchar(20)  NULL,
    [Searchable] nchar(10)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ImagePath] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UId] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [City] nvarchar(max)  NULL,
    [Country] nvarchar(max)  NULL,
    [Age] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ImagePath] nvarchar(100)  NULL,
    [SexOrient] nvarchar(20)  NULL
);
GO

-- Creating table 'MSreplication_options'
CREATE TABLE [dbo].[MSreplication_options] (
    [optname] nvarchar(128)  NOT NULL,
    [value] bit  NOT NULL,
    [major_version] int  NOT NULL,
    [minor_version] int  NOT NULL,
    [revision] int  NOT NULL,
    [install_failures] int  NOT NULL
);
GO

-- Creating table 'spt_fallback_db'
CREATE TABLE [dbo].[spt_fallback_db] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_dbid] smallint  NULL,
    [name] varchar(30)  NOT NULL,
    [dbid] smallint  NOT NULL,
    [status] smallint  NOT NULL,
    [version] smallint  NOT NULL
);
GO

-- Creating table 'spt_fallback_dev'
CREATE TABLE [dbo].[spt_fallback_dev] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_low] int  NULL,
    [xfallback_drive] char(2)  NULL,
    [low] int  NOT NULL,
    [high] int  NOT NULL,
    [status] smallint  NOT NULL,
    [name] varchar(30)  NOT NULL,
    [phyname] varchar(127)  NOT NULL
);
GO

-- Creating table 'spt_fallback_usg'
CREATE TABLE [dbo].[spt_fallback_usg] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_vstart] int  NULL,
    [dbid] smallint  NOT NULL,
    [segmap] int  NOT NULL,
    [lstart] int  NOT NULL,
    [sizepg] int  NOT NULL,
    [vstart] int  NOT NULL
);
GO

-- Creating table 'spt_monitor'
CREATE TABLE [dbo].[spt_monitor] (
    [lastrun] datetime  NOT NULL,
    [cpu_busy] int  NOT NULL,
    [io_busy] int  NOT NULL,
    [idle] int  NOT NULL,
    [pack_received] int  NOT NULL,
    [pack_sent] int  NOT NULL,
    [connections] int  NOT NULL,
    [pack_errors] int  NOT NULL,
    [total_read] int  NOT NULL,
    [total_write] int  NOT NULL,
    [total_errors] int  NOT NULL
);
GO

-- Creating table 'FriendRequests'
CREATE TABLE [dbo].[FriendRequests] (
    [UserID] int  NOT NULL,
    [FutureFriendId] int  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [TimeStamp] nvarchar(20)  NULL,
    [ApproveFlag] nvarchar(10)  NULL,
    [RejectFlag] nvarchar(10)  NULL,
    [BlockFlag] nvarchar(10)  NULL,
    [SpamFlag] nvarchar(10)  NULL,
    [FRId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [UserId] int  NOT NULL,
    [FriendId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FriendName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [MessageID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [PostMessage] nvarchar(100)  NULL,
    [DateSent] nchar(10)  NULL,
    [PostUserID] int  NOT NULL
);
GO

-- Creating table 'Post'
CREATE TABLE [dbo].[Post] (
    [PostId] int  NOT NULL,
    [Message] nvarchar(50)  NULL,
    [PostedBy] nvarchar(max)  NULL,
    [PostedDate] nvarchar(50)  NULL,
    [Users_UId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Iid] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Iid] ASC);
GO

-- Creating primary key on [Pid] in table 'Profile'
ALTER TABLE [dbo].[Profile]
ADD CONSTRAINT [PK_Profile]
    PRIMARY KEY CLUSTERED ([Pid] ASC);
GO

-- Creating primary key on [UId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UId] ASC);
GO

-- Creating primary key on [optname], [value], [major_version], [minor_version], [revision], [install_failures] in table 'MSreplication_options'
ALTER TABLE [dbo].[MSreplication_options]
ADD CONSTRAINT [PK_MSreplication_options]
    PRIMARY KEY CLUSTERED ([optname], [value], [major_version], [minor_version], [revision], [install_failures] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] in table 'spt_fallback_db'
ALTER TABLE [dbo].[spt_fallback_db]
ADD CONSTRAINT [PK_spt_fallback_db]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] in table 'spt_fallback_dev'
ALTER TABLE [dbo].[spt_fallback_dev]
ADD CONSTRAINT [PK_spt_fallback_dev]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] in table 'spt_fallback_usg'
ALTER TABLE [dbo].[spt_fallback_usg]
ADD CONSTRAINT [PK_spt_fallback_usg]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] ASC);
GO

-- Creating primary key on [lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] in table 'spt_monitor'
ALTER TABLE [dbo].[spt_monitor]
ADD CONSTRAINT [PK_spt_monitor]
    PRIMARY KEY CLUSTERED ([lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] ASC);
GO

-- Creating primary key on [UserID], [FRId] in table 'FriendRequests'
ALTER TABLE [dbo].[FriendRequests]
ADD CONSTRAINT [PK_FriendRequests]
    PRIMARY KEY CLUSTERED ([UserID], [FRId] ASC);
GO

-- Creating primary key on [FriendId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([FriendId] ASC);
GO

-- Creating primary key on [MessageID] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([MessageID] ASC);
GO

-- Creating primary key on [PostId] in table 'Post'
ALTER TABLE [dbo].[Post]
ADD CONSTRAINT [PK_Post]
    PRIMARY KEY CLUSTERED ([PostId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'Profile'
ALTER TABLE [dbo].[Profile]
ADD CONSTRAINT [FK_Profile_Users]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Profile_Users'
CREATE INDEX [IX_FK_Profile_Users]
ON [dbo].[Profile]
    ([UserID]);
GO

-- Creating foreign key on [FutureFriendId] in table 'FriendRequests'
ALTER TABLE [dbo].[FriendRequests]
ADD CONSTRAINT [FK_Table_Users]
    FOREIGN KEY ([FutureFriendId])
    REFERENCES [dbo].[Friends]
        ([FriendId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_Users'
CREATE INDEX [IX_FK_Table_Users]
ON [dbo].[FriendRequests]
    ([FutureFriendId]);
GO

-- Creating foreign key on [UserId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_Friends_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Friends_User'
CREATE INDEX [IX_FK_Friends_User]
ON [dbo].[Friends]
    ([UserId]);
GO

-- Creating foreign key on [Users_UId] in table 'Post'
ALTER TABLE [dbo].[Post]
ADD CONSTRAINT [FK_UsersPost]
    FOREIGN KEY ([Users_UId])
    REFERENCES [dbo].[Users]
        ([UId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersPost'
CREATE INDEX [IX_FK_UsersPost]
ON [dbo].[Post]
    ([Users_UId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------