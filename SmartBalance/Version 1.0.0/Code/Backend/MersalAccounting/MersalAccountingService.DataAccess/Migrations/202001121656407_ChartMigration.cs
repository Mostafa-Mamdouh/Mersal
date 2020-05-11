namespace MersalAccountingService.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChartMigration : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("dbo.SP_GetFinancialMovementsChart"
        // These are stored procedure parameters
        ,
        // Here is the stored procedure body
        @"
        IF OBJECT_ID('#temptable', 'U') IS NOT NULL
	DROP TABLE #temptable;

create table #temptable(
    MovementName nvarchar(50),
	January float,
	February float,
	March float ,
	April float ,
	May float,
	June float,
	July float,
	August float,
	September float,
	October float,
	November float,
    December float,
)

insert into #temptable (MovementName) values ('Payment Movement')
insert into #temptable (MovementName) values ('Bank Movement')
insert into #temptable (MovementName) values ('purchase Invoice')
insert into #temptable (MovementName) values ('Purchase Rebate')
insert into #temptable (MovementName) values ('Donation')



 declare @i int;
 declare @month int;
 declare @monthName nvarchar(50);

 set @i=1;
SET @month = 12;


    WHILE (@i <= 12)
    BEGIN
	if(@i=1)
	 set @monthName='January'
	 else if (@i=2)
	 set @monthName='February'
	  else if (@i=3)
	 set @monthName='March'
	   else if (@i=4)
	 set @monthName='April'
	   else if (@i=5)
	 set @monthName='May'
	   else if (@i=6)
	 set @monthName='June'
	 	   else if (@i=7)
	 set @monthName='July'
	   else if (@i=8)
	 set @monthName='August'
	   else if (@i=9)
	    set @monthName='September'
	   else if (@i=10)
	 set @monthName='October'
	   else if (@i=11)
	 set @monthName='November'
	   else if (@i=12)
	 set @monthName='December'


	 -- Donation
    declare @DonationQuery nvarchar(max);
	set @DonationQuery=N'update #temptable set '+ @monthName+'=
    isnull((select count(d.Id)   from [dbo].[Donations] d where d.ParentKeyDonationId is null 
    and (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''Donation'''
	execute SP_executesql  @DonationQuery 



	 -- bankMovement
    declare @BankMovementQuery nvarchar(max);
	set @BankMovementQuery=N'update #temptable set '+ @monthName+'=
    isnull((select count(d.Id)   from [dbo].[BankMovements] d where d.ParentKeyBankMovementId is null 
    and (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''Bank Movement'''
	execute SP_executesql  @BankMovementQuery 


	 -- purchaseInvoice
    declare @purchaseInvoiceQuery nvarchar(max);
	set @purchaseInvoiceQuery=N'update #temptable set '+ @monthName+'=
    isnull((select count(d.Id)   from [dbo].[PurchaseInvoices] d where
    (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''purchase Invoice'''
	execute SP_executesql  @purchaseInvoiceQuery 



	 -- PurchaseRebate
    declare @PurchaseRebateQuery nvarchar(max);
	set @PurchaseRebateQuery=N'update #temptable set '+ @monthName+'=
    isnull((select count(d.Id)   from [dbo].[PurchaseRebates] d where 
    (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''Purchase Rebate'''
	execute SP_executesql  @PurchaseRebateQuery 


		 -- PaymentMovement
    declare @PaymentMovementQuery nvarchar(max);
    set @PaymentMovementQuery=N'update #temptable set '+ @monthName+'=
    isnull((select count(d.Id)   from [dbo].[PaymentMovments] d where d.ParentKeyPaymentMovmentId is null 
    and (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''Payment Movement'''
	execute SP_executesql  @PaymentMovementQuery 


    SET @i = @i + 1
    END
	select * from #temptable

        ");
            CreateStoredProcedure("dbo.SP_GetPaymentAndReceiptChart"
// These are stored procedure parameters
,
// Here is the stored procedure body
@"IF OBJECT_ID('#temptable', 'U') IS NOT NULL
	DROP TABLE #temptable;

create table #temptable(
    MovementName nvarchar(50),
	January float,
	February float,
	March float ,
	April float ,
	May float,
	June float,
	July float,
	August float,
	September float,
	October float,
	November float,
    December float,
)

insert into #temptable (MovementName) values ('Payment Movement')
insert into #temptable (MovementName) values ('Donation')



 declare @i int;
 declare @month int;
 declare @monthName nvarchar(50);

 set @i=1;
SET @month = 12;


    WHILE (@i <= 12)
    BEGIN
	if(@i=1)
	 set @monthName='January'
	 else if (@i=2)
	 set @monthName='February'
	  else if (@i=3)
	 set @monthName='March'
	   else if (@i=4)
	 set @monthName='April'
	   else if (@i=5)
	 set @monthName='May'
	   else if (@i=6)
	 set @monthName='June'
	 	   else if (@i=7)
	 set @monthName='July'
	   else if (@i=8)
	 set @monthName='August'
	   else if (@i=9)
	    set @monthName='September'
	   else if (@i=10)
	 set @monthName='October'
	   else if (@i=11)
	 set @monthName='November'
	   else if (@i=12)
	 set @monthName='December'


	 -- Donation
    declare @DonationQuery nvarchar(max);
	set @DonationQuery=N'update #temptable set '+ @monthName+'=
    isnull((select sum(d.Amount)   from [dbo].[Donations] d where d.ParentKeyDonationId is null 
    and (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''Donation'''
	execute SP_executesql  @DonationQuery 





		 -- PaymentMovement
    declare @PaymentMovementQuery nvarchar(max);
    set @PaymentMovementQuery=N'update #temptable set '+ @monthName+'=
    isnull((select sum(d.Amount)   from [dbo].[PaymentMovments] d where d.ParentKeyPaymentMovmentId is null 
    and (SELECT YEAR(CURRENT_TIMESTAMP))=(SELECT YEAR(d.CreationDate)) and (SELECT MONTH(CURRENT_TIMESTAMP))= '+ CAST(@i AS NVARCHAR(10))+'),0)
	where MovementName=''Payment Movement'''
	execute SP_executesql  @PaymentMovementQuery 


    SET @i = @i + 1
    END
	select * from #temptable

        ");


        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.SP_GetFinancialMovementsChart");
            DropStoredProcedure("dbo.SP_GetPaymentAndReceiptChart");

        }
    }
}
