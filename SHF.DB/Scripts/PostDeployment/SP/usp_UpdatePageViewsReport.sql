IF EXISTS (SELECT * FROM sys.objects WHERE name = 'usp_UpdatePageViewsReport')  
DROP PROCEDURE dbo.usp_UpdatePageViewsReport  
GO
CREATE PROCEDURE  [dbo].[usp_UpdatePageViewsReport]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from	
	SET NOCOUNT ON;

	--insert into Tbl_PageViewsReport 
	select a.[Url],a.TotalViews,a.Tenant_ID into #tempresult from(
	select [Url],TotalViews,Tenant_ID from Tbl_Services1Master s1 
	union 
    select [Url],TotalViews,Tenant_ID from Tbl_Services2Master s2
	union 
    select [Url],TotalViews,Tenant_ID from Tbl_Services3Master s3
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_Services4Master s4
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_Services5Master s5
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_Services6Master s6
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_Services7Master s7
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_Services8Master s8
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_BlogMaster b
	union 
	select [Url],TotalViews,Tenant_ID from Tbl_HomePageSection2 h
	) a

	update Tbl_PageViewsReport set [Url]=tr.[Url],[Count]=tr.TotalViews,Tenant_ID=tr.Tenant_ID
	from #tempresult tr inner join Tbl_PageViewsReport pv 
	on tr.[Url]=pv.[Url];


	insert into Tbl_PageViewsReport
	select tr.[Url],tr.TotalViews,tr.Tenant_ID,'System',getdate(),'System',getdate(),1 from #tempresult tr left join Tbl_PageViewsReport pv 
	on tr.[Url]=pv.[Url]
	Where pv.[Url] is null;

	drop table #tempresult;

END
GO