CREATE TABLE [dbo].[Tags] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR (50) NOT NULL
);


CREATE TABLE [dbo].[Tweets] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Text]      NVARCHAR (MAX) NULL,
);

CREATE TABLE [dbo].[Keywords] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [TweetId]  INT            NOT NULL FOREIGN KEY REFERENCES Tweets(Id),
	[IsRelatedToHealth] BIT NOT NULL,
    [Keyword]  NVARCHAR (MAX) NOT NULL
);

CREATE TABLE [dbo].[Users] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [UserId] NVARCHAR (128) NOT NULL
);


CREATE TABLE [dbo].[UserKeywordTags] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [KeywordId] INT NOT NULL FOREIGN KEY REFERENCES Keywords(Id),
    [TagId]     INT NOT NULL FOREIGN KEY REFERENCES Tags(Id),
    [UserId]    INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
);


