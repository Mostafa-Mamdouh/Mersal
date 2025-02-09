
--  [AccountChart-Categories]
--  1 = حساب رئيسي 

--  [AccountChart-Groups]
--  1 = أصول
--  4 = خصوم
--  7 = مصروفات
-- 10 = إيرادات

--  [AccountTypes]
--  1 = رئيسي
--  4 = حساب فرعي

USE [MersalAccounting]

SET IDENTITY_INSERT [dbo].[AccountCharts] ON 

/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'1', N'1', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(2, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'أصول', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(3, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'أصول', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1)
/*------- End xxx -------*/
/*------------*/
/*----*/


/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(4, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 2 --[AccountLevel]
, N'1', N'11', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, 1  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(5, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'الاصول الغير متداولة', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(6, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'الاصول الغير متداولة', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 4)
/*------- End xxx -------*/
/*------------*/
/*----*/


/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(7, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 3 --[AccountLevel]
, N'01', N'1101', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, 4  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(8, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'أصول ثابتة', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 7)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(9, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'أصول ثابتة', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 7)
/*------- End xxx -------*/
/*------------*/
/*----*/


/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(10, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 4 --[AccountLevel]
, N'1', N'11011', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, 7  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(11, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى مشروعات تحت التنفيذ', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 10)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(12, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى مشروعات تحت التنفيذ', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 10)
/*------- End xxx -------*/
/*------------*/
/*----*/



/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(13, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'1', N'110111', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, 10  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(14, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مشروعات تحت التنفيذ', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 13)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(15, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مشروعات تحت التنفيذ', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 13)
/*------- End xxx -------*/
/*------------*/
/*----*/



/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(16, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 6 --[AccountLevel]
, N'01', N'11011101', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 1 --[IsFinalNode]
, 13  --[ParentAccountChartId]
, 4 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(17, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مشروعات تحت التنفيذ - مستشفى مرسال', N'1/2', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 16)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(18, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مشروعات تحت التنفيذ - مستشفى مرسال', N'1/2', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 16)
/*------- End xxx -------*/
/*------------*/
/*----*/



/*----*/ --done
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(19, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 4 --[AccountLevel]
, N'2', N'11012', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, 7  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(20, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى نظم و برامج', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 19)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(21, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى نظم و برامج', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 19)
/*------- End xxx -------*/
/*------------*/
/*----*/





























/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(22, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'1', N'110121', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, 10  --[ParentAccountChartId]
, 4 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(23, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'نظم و برامج', N'1/1', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 22)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(24, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'نظم و برامج', N'1/1', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 22)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(25, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'code', N'110122', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(26, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مجمع إهلاك نظم و برامج', N'1/1', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 25)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(27, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مجمع إهلاك نظم و برامج', N'1/1', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 25)
/*------- End xxx -------*/
/*------------*/
/*----*/







/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(28, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 4 --[AccountLevel]
, N'code', N'11013', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(29, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى تحسينات فى أماكن مؤجرة', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 28)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(30, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى تحسينات فى أماكن مؤجرة', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 28)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(31, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'code', N'110131', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 4 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(32, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'تحسينات فى أماكن مؤجرة', N'1/2', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 31)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(33, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'تحسينات فى أماكن مؤجرة', N'1/2', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 31)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(34, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'code', N'110132', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 4 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(35, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مجمع إهلاك تحسينات فى أماكن مؤجرة', N'1/2', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 34)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(36, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مجمع إهلاك تحسينات فى أماكن مؤجرة', N'1/2', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 34)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(37, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 4 --[AccountLevel]
, N'code', N'11014', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(38, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى أجهزة كهربائية', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 37)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(39, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'صافى أجهزة كهربائية', N'مجمع', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 37)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(40, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'code', N'110141', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 4 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(41, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'أجهزة كهربائية', N'1/3', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 40)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(42, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'أجهزة كهربائية', N'1/3', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 40)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(43, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 5 --[AccountLevel]
, N'code', N'110142', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 4 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(44, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مجمع إهلاك أجهزة كهربائية', N'1/3', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 43)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(45, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'مجمع إهلاك أجهزة كهربائية', N'1/3', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 43)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(46, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(47, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 46)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(48, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 46)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(49, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(50, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 49)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(51, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 49)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(52, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(53, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 52)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(54, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 52)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(55, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(56, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 55)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(57, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 55)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(58, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(59, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 58)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(60, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 58)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(61, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(62, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 61)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(63, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 61)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(64, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(65, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 64)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(66, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 64)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(67, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(68, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 67)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(69, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 67)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(70, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(71, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 70)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(72, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 70)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(73, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(74, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 73)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(75, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 73)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(76, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(77, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 76)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(78, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 76)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(79, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(80, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 79)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(81, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 79)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(82, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(83, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 82)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(84, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 82)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(85, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(86, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 85)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(87, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 85)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(88, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(89, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 88)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(90, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 88)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(91, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(92, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 91)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(93, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 91)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(94, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(95, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 94)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(96, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 94)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(97, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(98, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 97)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(99, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 97)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(100, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(101, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 100)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(102, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 100)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(103, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(104, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 103)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(105, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 103)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(106, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(107, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 106)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(108, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 106)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(109, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(110, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 109)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(111, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 109)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(112, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(113, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 112)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(114, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 112)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(115, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(116, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 115)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(117, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 115)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(118, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(119, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 118)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(120, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 118)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(121, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(122, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 121)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(123, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 121)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(124, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(125, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 124)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(126, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 124)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(127, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(128, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 127)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(129, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 127)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(130, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(131, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 130)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(132, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 130)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(133, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(134, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 133)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(135, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 133)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(136, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(137, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 136)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(138, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 136)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(139, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(140, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 139)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(141, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 139)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(142, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(143, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 142)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(144, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 142)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(145, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(146, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 145)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(147, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 145)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(148, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(149, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 148)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(150, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 148)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(151, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(152, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 151)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(153, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 151)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(154, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(155, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 154)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(156, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 154)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(157, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(158, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 157)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(159, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 157)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(160, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(161, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 160)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(162, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 160)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(163, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(164, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 163)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(165, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 163)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(166, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(167, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 166)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(168, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 166)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(169, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(170, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 169)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(171, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 169)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(172, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(173, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 172)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(174, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 172)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(175, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(176, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 175)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(177, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 175)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(178, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(179, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 178)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(180, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 178)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(181, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(182, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 181)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(183, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 181)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(184, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(185, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 184)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(186, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 184)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(187, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(188, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 187)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(189, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 187)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(190, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(191, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 190)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(192, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 190)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(193, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(194, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 193)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(195, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 193)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(196, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(197, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 196)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(198, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 196)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(199, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(200, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 199)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(201, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 199)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(202, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(203, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 202)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(204, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 202)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(205, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(206, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 205)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(207, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 205)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(208, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(209, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 208)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(210, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 208)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(211, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(212, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 211)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(213, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 211)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(214, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(215, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 214)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(216, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 214)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(217, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(218, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 217)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(219, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 217)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(220, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(221, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 220)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(222, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 220)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(223, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(224, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 223)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(225, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 223)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(226, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(227, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 226)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(228, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 226)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(229, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(230, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 229)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(231, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 229)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(232, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(233, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 232)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(234, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 232)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(235, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(236, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 235)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(237, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 235)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(238, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(239, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 238)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(240, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 238)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(241, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(242, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 241)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(243, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 241)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(244, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(245, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 244)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(246, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 244)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(247, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(248, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 247)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(249, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 247)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(250, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(251, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 250)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(252, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 250)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(253, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(254, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 253)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(255, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 253)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(256, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(257, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 256)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(258, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 256)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(259, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(260, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 259)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(261, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 259)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(262, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(263, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 262)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(264, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 262)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(265, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(266, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 265)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(267, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 265)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(268, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(269, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 268)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(270, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 268)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(271, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(272, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 271)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(273, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 271)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(274, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(275, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 274)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(276, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 274)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(277, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(278, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 277)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(279, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 277)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(280, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(281, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 280)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(282, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 280)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(283, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(284, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 283)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(285, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 283)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(286, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(287, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 286)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(288, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 286)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(289, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(290, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 289)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(291, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 289)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(292, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(293, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 292)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(294, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 292)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(295, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(296, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 295)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(297, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 295)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(298, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(299, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 298)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(300, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 298)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(301, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(302, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 301)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(303, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 301)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(304, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(305, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 304)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(306, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 304)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(307, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(308, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 307)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(309, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 307)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(310, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(311, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 310)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(312, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 310)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(313, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(314, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 313)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(315, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 313)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(316, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(317, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 316)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(318, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 316)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(319, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(320, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 319)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(321, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 319)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(322, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(323, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 322)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(324, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 322)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(325, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(326, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 325)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(327, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 325)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(328, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(329, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 328)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(330, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 328)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(331, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(332, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 331)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(333, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 331)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(334, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(335, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 334)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(336, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 334)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(337, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(338, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 337)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(339, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 337)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(340, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(341, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 340)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(342, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 340)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(343, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(344, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 343)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(345, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 343)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(346, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(347, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 346)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(348, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 346)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(349, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(350, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 349)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(351, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 349)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(352, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(353, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 352)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(354, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 352)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(355, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(356, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 355)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(357, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 355)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(358, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(359, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 358)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(360, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 358)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(361, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(362, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 361)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(363, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 361)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(364, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(365, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 364)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(366, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 364)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(367, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(368, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 367)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(369, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 367)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(370, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(371, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 370)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(372, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 370)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(373, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(374, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 373)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(375, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 373)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(376, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(377, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 376)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(378, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 376)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(379, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(380, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 379)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(381, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 379)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(382, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(383, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 382)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(384, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 382)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(385, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(386, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 385)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(387, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 385)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(388, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(389, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 388)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(390, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 388)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(391, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(392, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 391)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(393, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 391)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(394, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(395, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 394)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(396, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 394)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(397, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(398, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 397)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(399, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 397)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(400, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(401, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 400)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(402, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 400)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(403, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(404, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 403)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(405, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 403)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(406, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(407, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 406)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(408, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 406)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(409, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(410, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 409)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(411, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 409)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(412, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(413, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 412)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(414, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 412)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(415, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(416, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 415)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(417, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 415)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(418, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(419, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 418)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(420, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 418)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(421, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(422, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 421)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(423, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 421)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(424, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(425, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 424)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(426, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 424)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(427, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(428, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 427)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(429, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 427)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(430, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(431, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 430)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(432, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 430)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(433, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(434, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 433)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(435, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 433)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(436, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(437, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 436)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(438, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 436)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(439, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(440, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 439)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(441, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 439)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(442, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(443, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 442)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(444, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 442)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(445, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(446, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 445)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(447, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 445)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(448, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(449, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 448)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(450, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 448)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(451, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(452, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 451)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(453, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 451)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(454, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(455, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 454)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(456, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 454)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(457, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(458, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 457)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(459, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 457)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(460, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(461, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 460)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(462, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 460)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(463, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(464, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 463)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(465, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 463)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(466, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(467, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 466)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(468, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 466)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(469, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(470, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 469)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(471, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 469)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(472, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(473, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 472)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(474, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 472)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(475, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(476, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 475)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(477, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 475)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(478, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(479, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 478)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(480, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 478)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(481, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(482, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 481)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(483, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 481)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(484, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(485, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 484)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(486, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 484)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(487, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(488, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 487)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(489, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 487)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(490, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(491, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 490)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(492, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 490)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(493, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(494, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 493)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(495, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 493)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(496, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(497, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 496)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(498, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 496)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(499, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(500, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 499)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(501, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 499)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(502, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(503, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 502)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(504, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 502)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(505, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(506, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 505)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(507, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 505)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(508, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(509, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 508)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(510, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 508)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(511, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(512, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 511)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(513, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 511)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(514, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(515, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 514)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(516, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 514)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(517, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(518, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 517)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(519, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 517)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(520, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(521, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 520)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(522, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 520)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(523, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(524, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 523)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(525, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 523)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(526, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(527, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 526)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(528, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 526)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(529, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(530, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 529)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(531, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 529)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(532, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(533, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 532)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(534, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 532)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(535, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(536, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 535)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(537, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 535)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(538, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(539, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 538)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(540, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 538)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(541, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(542, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 541)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(543, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 541)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(544, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(545, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 544)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(546, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 544)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(547, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(548, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 547)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(549, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 547)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(550, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(551, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 550)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(552, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 550)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(553, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(554, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 553)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(555, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 553)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(556, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(557, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 556)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(558, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 556)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(559, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(560, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 559)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(561, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 559)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(562, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(563, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 562)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(564, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 562)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(565, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(566, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 565)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(567, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 565)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(568, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(569, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 568)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(570, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 568)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(571, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(572, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 571)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(573, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 571)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(574, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(575, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 574)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(576, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 574)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(577, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(578, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 577)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(579, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 577)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(580, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(581, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 580)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(582, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 580)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(583, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(584, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 583)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(585, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 583)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(586, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(587, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 586)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(588, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 586)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(589, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(590, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 589)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(591, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 589)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(592, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(593, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 592)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(594, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 592)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(595, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(596, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 595)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(597, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 595)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(598, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(599, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 598)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(600, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 598)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(601, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(602, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 601)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(603, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 601)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(604, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(605, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 604)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(606, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 604)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(607, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(608, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 607)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(609, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 607)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(610, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(611, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 610)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(612, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 610)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(613, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(614, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 613)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(615, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 613)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(616, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(617, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 616)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(618, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 616)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(619, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(620, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 619)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(621, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 619)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(622, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(623, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 622)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(624, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 622)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(625, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(626, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 625)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(627, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 625)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(628, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(629, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 628)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(630, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 628)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(631, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(632, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 631)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(633, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 631)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(634, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(635, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 634)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(636, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 634)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(637, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(638, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 637)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(639, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 637)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(640, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(641, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 640)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(642, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 640)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(643, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(644, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 643)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(645, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 643)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(646, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(647, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 646)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(648, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 646)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(649, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(650, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 649)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(651, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 649)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(652, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(653, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 652)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(654, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 652)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(655, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(656, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 655)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(657, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 655)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(658, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(659, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 658)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(660, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 658)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(661, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(662, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 661)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(663, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 661)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(664, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(665, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 664)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(666, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 664)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(667, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(668, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 667)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(669, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 667)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(670, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(671, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 670)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(672, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 670)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(673, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(674, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 673)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(675, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 673)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(676, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(677, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 676)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(678, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 676)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(679, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(680, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 679)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(681, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 679)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(682, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(683, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 682)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(684, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 682)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(685, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(686, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 685)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(687, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 685)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(688, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(689, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 688)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(690, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 688)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(691, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(692, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 691)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(693, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 691)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(694, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(695, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 694)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(696, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 694)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(697, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(698, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 697)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(699, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 697)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(700, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(701, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 700)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(702, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 700)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(703, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(704, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 703)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(705, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 703)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(706, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(707, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 706)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(708, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 706)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(709, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(710, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 709)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(711, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 709)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(712, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(713, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 712)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(714, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 712)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(715, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(716, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 715)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(717, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 715)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(718, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(719, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 718)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(720, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 718)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(721, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(722, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 721)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(723, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 721)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(724, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(725, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 724)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(726, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 724)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(727, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(728, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 727)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(729, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 727)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(730, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(731, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 730)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(732, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 730)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(733, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(734, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 733)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(735, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 733)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(736, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(737, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 736)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(738, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 736)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(739, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(740, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 739)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(741, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 739)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(742, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(743, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 742)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(744, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 742)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(745, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(746, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 745)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(747, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 745)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(748, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(749, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 748)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(750, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 748)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(751, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(752, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 751)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(753, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 751)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(754, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(755, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 754)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(756, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 754)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(757, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(758, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 757)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(759, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 757)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(760, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(761, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 760)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(762, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 760)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(763, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(764, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 763)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(765, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 763)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(766, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(767, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 766)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(768, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 766)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(769, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(770, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 769)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(771, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 769)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(772, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(773, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 772)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(774, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 772)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(775, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(776, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 775)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(777, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 775)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(778, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(779, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 778)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(780, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 778)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(781, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(782, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 781)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(783, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 781)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(784, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(785, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 784)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(786, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 784)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(787, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(788, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 787)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(789, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 787)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(790, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(791, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 790)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(792, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 790)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(793, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(794, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 793)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(795, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 793)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(796, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(797, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 796)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(798, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 796)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(799, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(800, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 799)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(801, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 799)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(802, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(803, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 802)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(804, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 802)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(805, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(806, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 805)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(807, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 805)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(808, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(809, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 808)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(810, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 808)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(811, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(812, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 811)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(813, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 811)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(814, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(815, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 814)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(816, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 814)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(817, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(818, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 817)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(819, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 817)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(820, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(821, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 820)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(822, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 820)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(823, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(824, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 823)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(825, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 823)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(826, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(827, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 826)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(828, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 826)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(829, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(830, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 829)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(831, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 829)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(832, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(833, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 832)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(834, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 832)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(835, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(836, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 835)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(837, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 835)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(838, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(839, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 838)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(840, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 838)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(841, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(842, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 841)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(843, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 841)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(844, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(845, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 844)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(846, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 844)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(847, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(848, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 847)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(849, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 847)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(850, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(851, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 850)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(852, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 850)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(853, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(854, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 853)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(855, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 853)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(856, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(857, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 856)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(858, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 856)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(859, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(860, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 859)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(861, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 859)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(862, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(863, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 862)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(864, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 862)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(865, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(866, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 865)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(867, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 865)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(868, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(869, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 868)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(870, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 868)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(871, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(872, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 871)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(873, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 871)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(874, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(875, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 874)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(876, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 874)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(877, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(878, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 877)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(879, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 877)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(880, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(881, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 880)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(882, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 880)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(883, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(884, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 883)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(885, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 883)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(886, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(887, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 886)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(888, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 886)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(889, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(890, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 889)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(891, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 889)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(892, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(893, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 892)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(894, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 892)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(895, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(896, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 895)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(897, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 895)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(898, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(899, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 898)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(900, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 898)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(901, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(902, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 901)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(903, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 901)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(904, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(905, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 904)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(906, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 904)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(907, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(908, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 907)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(909, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 907)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(910, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(911, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 910)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(912, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 910)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(913, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(914, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 913)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(915, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 913)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(916, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(917, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 916)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(918, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 916)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(919, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(920, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 919)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(921, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 919)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(922, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(923, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 922)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(924, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 922)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(925, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(926, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 925)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(927, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 925)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(928, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(929, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 928)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(930, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 928)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(931, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(932, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 931)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(933, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 931)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(934, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(935, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 934)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(936, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 934)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(937, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(938, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 937)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(939, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 937)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(940, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(941, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 940)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(942, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 940)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(943, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(944, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 943)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(945, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 943)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(946, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(947, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 946)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(948, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 946)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(949, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(950, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 949)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(951, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 949)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(952, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(953, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 952)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(954, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 952)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(955, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(956, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 955)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(957, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 955)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(958, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(959, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 958)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(960, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 958)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(961, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(962, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 961)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(963, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 961)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(964, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(965, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 964)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(966, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 964)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(967, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(968, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 967)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(969, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 967)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(970, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(971, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 970)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(972, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 970)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(973, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(974, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 973)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(975, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 973)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(976, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(977, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 976)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(978, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 976)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(979, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(980, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 979)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(981, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 979)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(982, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(983, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 982)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(984, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 982)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(985, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(986, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 985)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(987, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 985)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(988, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(989, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 988)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(990, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 988)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(991, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(992, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 991)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(993, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 991)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(994, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(995, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 994)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(996, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 994)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(997, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(998, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 997)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(999, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 997)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1000, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1001, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1000)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1002, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1000)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1003, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1004, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1003)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1005, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1003)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1006, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1007, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1006)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1008, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1006)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1009, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1010, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1009)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1011, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1009)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1012, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1013, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1012)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1014, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1012)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1015, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1016, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1015)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1017, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1015)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1018, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1019, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1018)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1020, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1018)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1021, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1022, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1021)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1023, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1021)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1024, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1025, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1024)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1026, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1024)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1027, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1028, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1027)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1029, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1027)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1030, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1031, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1030)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1032, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1030)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1033, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1034, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1033)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1035, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1033)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1036, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1037, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1036)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1038, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1036)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1039, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1040, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1039)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1041, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1039)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1042, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1043, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1042)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1044, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1042)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1045, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1046, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1045)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1047, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1045)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1048, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1049, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1048)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1050, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1048)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1051, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1052, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1051)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1053, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1051)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1054, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1055, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1054)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1056, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1054)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1057, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1058, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1057)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1059, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1057)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1060, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1061, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1060)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1062, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1060)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1063, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1064, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1063)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1065, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1063)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1066, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1067, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1066)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1068, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1066)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1069, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1070, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1069)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1071, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1069)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1072, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1073, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1072)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1074, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1072)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1075, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1076, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1075)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1077, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1075)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1078, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1079, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1078)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1080, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1078)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1081, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1082, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1081)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1083, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1081)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1084, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1085, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1084)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1086, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1084)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1087, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1088, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1087)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1089, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1087)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1090, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1091, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1090)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1092, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1090)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1093, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1094, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1093)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1095, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1093)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1096, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1097, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1096)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1098, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1096)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1099, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1100, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1099)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1101, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1099)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1102, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1103, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1102)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1104, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1102)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1105, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1106, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1105)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1107, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1105)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1108, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1109, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1108)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1110, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1108)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1111, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1112, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1111)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1113, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1111)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1114, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1115, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1114)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1116, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1114)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1117, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1118, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1117)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1119, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1117)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1120, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1121, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1120)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1122, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1120)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1123, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1124, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1123)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1125, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1123)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1126, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1127, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1126)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1128, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1126)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1129, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1130, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1129)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1131, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1129)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1132, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1133, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1132)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1134, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1132)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1135, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1136, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1135)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1137, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1135)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1138, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1139, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1138)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1140, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1138)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1141, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1142, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1141)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1143, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1141)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1144, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1145, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1144)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1146, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1144)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1147, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1148, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1147)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1149, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1147)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1150, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1151, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1150)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1152, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1150)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1153, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1154, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1153)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1155, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1153)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1156, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1157, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1156)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1158, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1156)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1159, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1160, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1159)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1161, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1159)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1162, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1163, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1162)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1164, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1162)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1165, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1166, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1165)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1167, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1165)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1168, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1169, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1168)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1170, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1168)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1171, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1172, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1171)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1173, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1171)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1174, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1175, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1174)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1176, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1174)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1177, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1178, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1177)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1179, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1177)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1180, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1181, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1180)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1182, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1180)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1183, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1184, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1183)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1185, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1183)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1186, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1187, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1186)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1188, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1186)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1189, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1190, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1189)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1191, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1189)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1192, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1193, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1192)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1194, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1192)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1195, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1196, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1195)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1197, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1195)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1198, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1199, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1198)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1200, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1198)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1201, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1202, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1201)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1203, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1201)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1204, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1205, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1204)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1206, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1204)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1207, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1208, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1207)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1209, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1207)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1210, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1211, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1210)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1212, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1210)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1213, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1214, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1213)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1215, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1213)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1216, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1217, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1216)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1218, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1216)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1219, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1220, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1219)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1221, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1219)
/*------- End xxx -------*/
/*------------*/
/*----*/

/*----*/
/*------------*/
/*------- Start xxx -------*/
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1222, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, NULL, NULL, 1 --[AccountLevel]
, N'code', N'fullcode', CAST(N'2019-06-23T11:21:45.860' AS DateTime), 
CAST(0.00 AS Decimal(18, 2)), 0 --[IsDebt]
, 0 --[IsFinalNode]
, NULL  --[ParentAccountChartId]
, 1 --[AccountTypeId]
, 1 --[AccountChartGroupId]
, 1 --[AccountChartCategoryId]
, NULL, NULL)

-- english
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1223, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'name', N'description', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1222)

-- arabic
INSERT [dbo].[AccountCharts] 
([Id], [CreationDate], [FirstModificationDate], [LastModificationDate], [Name], [Description], [AccountLevel], [Code], [FullCode], [Date], [OpeningCredit], 
[IsDebt], [IsFinalNode], [ParentAccountChartId], [AccountTypeId], [AccountChartGroupId], [AccountChartCategoryId], [Language], [ParentKeyAccountChartId]) 
VALUES 
(1224, CAST(N'2019-06-23T11:21:45.860' AS DateTime), NULL, NULL, N'اسم', N'وصف', 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1222)
/*------- End xxx -------*/
/*------------*/
/*----*/
