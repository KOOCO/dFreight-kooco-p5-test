-- 添加運價中心要，但運價資料表沒有的欄位
USE IFREIGHTDL;
GO

ALTER TABLE BSFRTCENTERTD ADD
ETA nvarchar(50) NULL,
FREE_TIME nvarchar(50) NULL;
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'預計到達時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERTD', @level2type=N'COLUMN',@level2name=N'ETA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'免費倉儲時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERTD', @level2type=N'COLUMN',@level2name=N'FREE_TIME'
GO


USE IFREIGHTLOG;
GO

-- LOG 也要添加

ALTER TABLE BSFRTCENTERTD_LOG ADD
ETA nvarchar(50) NULL,
FREE_TIME nvarchar(50) NULL;
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'預計到達時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERTD_LOG', @level2type=N'COLUMN',@level2name=N'ETA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'免費倉儲時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BSFRTCENTERTD_LOG', @level2type=N'COLUMN',@level2name=N'FREE_TIME'
GO

-- 然後觸發器也要加上那些欄位

USE [IFREIGHTDL]
GO

/****** Object:  Trigger [dbo].[TR_UPDATE_BSFRTCENTERTD]    Script Date: 2023/5/11 下午 03:42:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--USE IFREIGHTDL;
ALTER  TRIGGER [dbo].[TR_UPDATE_BSFRTCENTERTD] ON [dbo].[BSFRTCENTERTD]

AFTER UPDATE, DELETE

AS 
BEGIN
        -- 定義Cursor打開
        DECLARE UpdateBSFRTCENTERTDCursor Cursor FOR --宣告名稱 UpdateBSFRTCENTERTDCursor
        -- 此區段就可以撰寫資料集
        SELECT GROUP_ID, CMP, STN, JOB_NO FROM deleted
        -- Cursor打開
        Open UpdateBSFRTCENTERTDCursor 
        -- 定義變數
        DECLARE @GROUP_ID NVARCHAR(5);
        DECLARE @CMP NVARCHAR(5);
        DECLARE @STN NVARCHAR(5);
        DECLARE @JOB_NO NVARCHAR(40);

        -- 開始迴圈跑 Cursor Start
        Fetch NEXT FROM UpdateBSFRTCENTERTDCursor INTO @GROUP_ID, @CMP, @STN, @JOB_NO -- 當前行的資料給予變數
        While (@@FETCH_STATUS <> -1)
            BEGIN
                INSERT INTO [IFREIGHTLOG].[dbo].[BSFRTCENTERTD_LOG]
                SELECT 
                    [GROUP_ID]
                   ,[CMP]
                   ,[STN]
                   ,[JOB_NO]
                   ,[F_JOB_NO]
                   ,[F_RLS_NO]
                   ,[DEP]
                   ,[SALES_DEP_ID]
                   ,[AGENT_CD]
                   ,[F_CARRIER]
                   ,[VSL]
                   ,[F_TYPE]
                   ,[POR_CD]
                   ,[POL_CD]
                   ,[POD_CD]
                   ,[SVC_MODE_TERM]
                   ,[F_CHARGE_CD]
                   ,[F_CURRENCY]
                   ,[CHG_UNIT]
                   ,[MIN_CHG]
                   ,[PRICE_ST]
                   ,[BASIC_PRICE]
                   ,[CHG_UNIT1]
                   ,[CHG_FLAG1]
                   ,[RATE1]
                   ,[CHG_UNIT2]
                   ,[CHG_FLAG2]
                   ,[RATE2]
                   ,[CHG_UNIT3]
                   ,[CHG_FLAG3]
                   ,[RATE3]
                   ,[CHG_UNIT4]
                   ,[CHG_FLAG4]
                   ,[RATE4]
                   ,[CHG_UNIT5]
                   ,[CHG_FLAG5]
                   ,[RATE5]
                   ,[CHG_UNIT6]
                   ,[CHG_FLAG6]
                   ,[RATE6]
                   ,[ACC_FLAG]
                   ,[VIA]
                   ,[CLOSING]
                   ,[ETD]
                   ,[TRUCK_ORGN]
                   ,[TRUCK_DEST]
                   ,[DEST2_CD]
                   ,[DEST3_CD]
                   ,[DEST4_CD]
                   ,[PC]
                   ,[F_TRANSIT]
                   ,[TRANSIT_TYPE]
                   ,[F_CMDT]
                   ,[L]
                   ,[W]
                   ,[H]
                   ,[PKG]
                   ,[PKG_UNIT]
                   ,[VW]
                   ,[VW_UNIT]
                   ,[CREATE_BY]
                   ,[CREATE_DATE]
                   ,[MODIFY_BY]
                   ,[MODIFY_DATE]
                   ,[F_RMK]
                   ,[POR_CNTY]
                   ,[POL_CNTY]
                   ,[POD_CNTY]
                   ,[DEST2_CNTY]
                   ,[DEST3_CNTY]
                   ,[DEST4_CNTY]
                   ,[POR_NM]
                   ,[POL_NM]
                   ,[POD_NM]
                   ,[DEST2_NM]
                   ,[DEST3_NM]
                   ,[DEST4_NM]
                   ,[PRICE_ST2]
                   ,[PRICE_ST3]
                   ,[PRICE_ST4]
                   ,[PRICE_ST5]
                   ,[PRICE_ST6]
                   ,[SEQ]
                   ,[VAT_FLAG]
                   ,[TAX_RATE]
                   ,[GUI_FLG]
                   ,[DEST_CD]
                   ,[DEST_CNTY]
                   ,[DEST_NM]
                   , ISNULL(MODIFY_DATE, CREATE_DATE), ISNULL(MODIFY_BY, CREATE_BY)
                   ,[ETA]
                   ,[FREE_TIME]
                FROM deleted
                WHERE GROUP_ID = @GROUP_ID AND CMP = @CMP AND STN= @STN AND JOB_NO = @JOB_NO
                Fetch NEXT FROM UpdateBSFRTCENTERTDCursor INTO @GROUP_ID, @CMP, @STN, @JOB_NO -- 開始執行下一筆
            END
        -- Cursor End

        -- 關閉並釋放 Cursor
        CLOSE UpdateBSFRTCENTERTDCursor
        DEALLOCATE UpdateBSFRTCENTERTDCursor
END
GO


