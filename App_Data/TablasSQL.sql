USE [Pedidos]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 13/08/2020 6:04:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](80) NULL,
	[customer_email] [nvarchar](120) NULL,
	[customer_mobile] [nvarchar](40) NULL,
	[status] [nvarchar](20) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[product_id] [int] NULL,
	[requestId] [nvarchar](50) NULL,
	[processUrl] [nvarchar](150) NULL,
	[fechaProcess] [datetime] NULL,
	[customer_lastname] [nvarchar](80) NULL,
	[customer_document] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 13/08/2020 6:04:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code_product] [nvarchar](50) NULL,
	[name_product] [nchar](10) NULL,
	[value_product] [float] NULL,
	[image_url_product] [nvarchar](250) NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (1, N'eee', N'betouis@hotmail.com', N'eeeee', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (2, N'fdss', N'sdfsf', N'sdsf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (5, N'JUAN MENDEZ', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:19:58.627' AS DateTime), CAST(N'2020-08-13T17:19:59.127' AS DateTime), 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (6, N'JUAN MENDEZ', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:24:47.250' AS DateTime), CAST(N'2020-08-13T17:24:47.250' AS DateTime), 2, N'337817', N'https://test.placetopay.com/redirection/session/337817/38ab2c5cdc3a6c5834d9cfeb6c67cfc6', CAST(N'2020-08-13T17:24:51.127' AS DateTime), NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (7, N'JUAN MENDEZ', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:28:49.553' AS DateTime), CAST(N'2020-08-13T17:28:49.553' AS DateTime), 2, N'337819', N'https://test.placetopay.com/redirection/session/337819/9521fae08e132459ea25f518881cf95c', CAST(N'2020-08-13T17:28:51.780' AS DateTime), NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (8, N'Edilberto', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:42:04.377' AS DateTime), CAST(N'2020-08-13T17:42:04.377' AS DateTime), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (9, N'Edilberto', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:42:35.007' AS DateTime), CAST(N'2020-08-13T17:42:35.007' AS DateTime), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (10, N'Edilberto', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:45:45.647' AS DateTime), CAST(N'2020-08-13T17:45:45.647' AS DateTime), 2, N'337827', N'https://test.placetopay.com/redirection/session/337827/3392c190a04d7bafc3823d066cdb719b', CAST(N'2020-08-13T17:46:04.827' AS DateTime), N'Mendez', N'14474049')
INSERT [dbo].[Pedido] ([id], [customer_name], [customer_email], [customer_mobile], [status], [created_at], [updated_at], [product_id], [requestId], [processUrl], [fechaProcess], [customer_lastname], [customer_document]) VALUES (11, N'Edilberto', N'betouis@hotmail.com', N'3154295765', N'CREATED', CAST(N'2020-08-13T17:51:05.553' AS DateTime), CAST(N'2020-08-13T17:51:05.553' AS DateTime), 2, N'337829', N'https://test.placetopay.com/redirection/session/337829/b22af7364c11bf3ac8919dfe119e1300', CAST(N'2020-08-13T17:51:07.243' AS DateTime), N'Mendez', N'14474049')
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([id], [code_product], [name_product], [value_product], [image_url_product]) VALUES (1, N'444', N'producto 1', 3333, N'images/producto1.png')
INSERT [dbo].[product] ([id], [code_product], [name_product], [value_product], [image_url_product]) VALUES (2, N'33', N'producto 3', 4444, N'images/producto3.png')
SET IDENTITY_INSERT [dbo].[product] OFF
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_product]
GO
