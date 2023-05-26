USE [IFREIGHTDL]
GO

/****** Object:  Table [dbo].[BSFRTCENTERT_EXCEL_TEMP]    Script Date: 2023/4/11 上午 10:35:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BSFRTCENTERT_EXCEL_TEMP](
	[EXCEL_TEMP_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[GROUP_ID] [nvarchar](10) NOT NULL,
	[CMP] [nvarchar](3) NOT NULL,
	[STN] [nvarchar](3) NOT NULL,
	[AGENT] [nvarchar](200) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[EFFECTIVE_DATE] [datetime2](0) NULL,
	[VALID_TILL] [datetime2](0) NULL,
	[CARRIER] [nvarchar](50) NULL,
	[ORIGIN] [nvarchar](200) NULL,
	[POD] [nvarchar](200) NULL,
	[DESTINATION] [nvarchar](200) NULL,
	[MODEL] [nvarchar](200) NULL,
	[CURRENCY] [nvarchar](3) NULL,
	[IC_20GP] [nvarchar](10) NULL,
	[IC_40GP] [nvarchar](10) NULL,
	[IC_40HQ] [nvarchar](10) NULL,
	[TRASIT_TIME] [nvarchar](100) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[ETC] [nvarchar](50) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[ETD] [nvarchar](50) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[ETA] [nvarchar](50) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[FREE_TIME] [nvarchar](50) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[REMARK] [nvarchar](MAX) NULL, -- 與 Excel 轉 Excel 小程式不同的欄位
	[UPLOADER_ID] [nvarchar](20) NOT NULL,
	[UPLOADER_TIME] [datetime2](0) NULL,
	[IS_DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_BSFRTCENTERT_EXCEL_TEMP] PRIMARY KEY CLUSTERED 
(
	[EXCEL_TEMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BSFRTCENTERT_EXCEL_TEMP] ADD  CONSTRAINT [DF_BSFRTCENTERT_EXCEL_TEMP_IS_DELETED]  DEFAULT ((0)) FOR [IS_DELETED]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流水號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'EXCEL_TEMP_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'集團' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'GROUP_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'CMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'站別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'STN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'資料來源/運價取得/代理人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'AGENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合約生效日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'EFFECTIVE_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合約到期日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'VALID_TILL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'船/航空公司代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'CARRIER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'起運地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'ORIGIN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目的港' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'POD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最終交貨地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'DESTINATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'MODEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'幣別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'CURRENCY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'20''GP的價錢' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'IC_20GP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40''GP的價錢' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'IC_40GP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40''HQ的價錢' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'IC_40HQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航程天數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'TRASIT_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'截關日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'ETC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'預計開航時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'ETD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'預計到達時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'ETA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'免費倉儲時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'FREE_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'備註' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'REMARK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上傳人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'UPLOADER_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上傳時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'UPLOADER_TIME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否刪除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERT_EXCEL_TEMP', @level2type=N'COLUMN',@level2name=N'IS_DELETED'
GO

CREATE NONCLUSTERED INDEX [IX_BSFRTCENTERT_EXCEL_TEMP_UPLOADER_ID]
ON [dbo].[BSFRTCENTERT_EXCEL_TEMP] ([UPLOADER_ID])
INCLUDE ([GROUP_ID], [CMP], [STN], [AGENT], [EFFECTIVE_DATE], [VALID_TILL], [CARRIER], [ORIGIN], [POD], [DESTINATION], [MODEL], [CURRENCY], [IC_20GP], [IC_40GP], [IC_40HQ], [TRASIT_TIME], [ETC], [ETD], [ETA], [FREE_TIME], [REMARK], [UPLOADER_TIME], [IS_DELETED])
