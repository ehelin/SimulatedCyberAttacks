CREATE TABLE [BucketList].[Bucket].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NULL,
	[Salt] [nvarchar](max) NULL,
	[PassWord] [nvarchar](max) NULL,
	[Email] [nvarchar](255) NULL,
	[Token] [nvarchar](1000) NULL,
	[Created] [datetime] NULL,
	[CreatedBy] [nvarchar](255) NULL,
	[Modified] [datetime] NULL,
	[ModifiedBy] [nvarchar](255) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [BucketList].[Bucket].[BucketListItem](
	[BucketListItemId] [int] IDENTITY(1,1) NOT NULL,
	[ListItemName] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Category] [nvarchar](255) NULL,
	[Achieved] [bit] NULL,
	[CategorySortOrder] [int] NULL,
 CONSTRAINT [PK_BucketListItems] PRIMARY KEY CLUSTERED 
(
	[BucketListItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [BucketList].[Bucket].[BucketListUser](
	[BucketListUserId] [int] IDENTITY(1,1) NOT NULL,
	[BucketListItemId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_BucketListUser] PRIMARY KEY CLUSTERED 
(
	[BucketListUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


