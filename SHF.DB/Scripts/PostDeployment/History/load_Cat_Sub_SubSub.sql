  INSERT INTO [dbo].[Tbl_CategoriesMaster]
           ([CategoryName]
           ,[DisplayIndex]
           ,[DisplayOnHome]
           ,[IsActive]
           ,[TotalViews]
           ,[Url]
           ,[Metadata]
           ,[Keyword]
           ,[MetaDescription]
           ,[Created_By]
           ,[Created_On]
           ,[Modified_By]
           ,[Modified_On]
           ,[Is_Deleted])
   
   select distinct MAIN_CATEGORY_MENU as MAIN_CATEGORY_MENU,Main_Category_Display_Index,1,1,10,
   '/'+lower(replace(replace(dbo.udf_TitleCase(MAIN_CATEGORY_MENU),' ','_'),'&','')),
   dbo.udf_TitleCase(MAIN_CATEGORY_MENU),dbo.udf_TitleCase(MAIN_CATEGORY_MENU),dbo.udf_TitleCase(MAIN_CATEGORY_MENU),'dbo',GETDATE(),'dbo',getdate(),
   0   FROM [dbo].[tempservices];
   
     insert into [dbo].[Tbl_SubCategoriesMaster]
      ([SubCategoryName]
	  ,[Cat_Id]
      ,[DisplayIndex]
      ,[DisplayOnHome]
      ,[IsActive]
      ,[TotalViews]
      ,[Url]
      ,[Metadata]
      ,[Keyword]
      ,[MetaDescription]
       ,[Created_By]
      ,[Created_On]
      ,[Modified_By]
      ,[Modified_On]
      ,[Is_Deleted])
    select distinct t.sub_category_menu,c.ID,t.Sub_Category_Display_Index,1,1,10,'/'+lower(replace(replace(dbo.udf_TitleCase(t.sub_category_menu),' ','_'),'&','')),
   dbo.udf_TitleCase(t.sub_category_menu),dbo.udf_TitleCase(t.sub_category_menu),dbo.udf_TitleCase(t.sub_category_menu),'dbo',GETDATE(),'dbo',getdate(),
   0  from Tbl_CategoriesMaster c join tempservices t on c.CategoryName=t.MAIN_CATEGORY_MENU;
   
   
  insert into [dbo].[Tbl_SubSubCategoriesMaster](
      [SubSubCategoryName]
	  ,[Cat_Id]
      ,[SubCat_Id]
      ,[DisplayIndex]
      ,[DisplayOnHome]
      ,[IsActive]
      ,[ServiceType_ID]
      ,[ServiceTypeValue]
      ,[TotalViews]
      ,[Url]
      ,[Metadata]
      ,[Keyword]
      ,[MetaDescription]
      ,[Created_By]
      ,[Created_On]
      ,[Modified_By]
      ,[Modified_On]
      ,[Is_Deleted])
	  select distinct t.service_name,c.ID,s.ID,t.SERVICE_NAME_Display_Index,1,1,'1020',case 
           when t.services_page_type='1' then 'SER1'
		    when t.services_page_type='2' then 'SER2'
			 when t.services_page_type='3' then 'SER3'
			  when t.services_page_type='4' then 'SER4'
			   when t.services_page_type='5' then 'SER5'
			    when t.services_page_type='6' then 'SER6'
				 when t.services_page_type='7' then 'SER7'
				  when t.services_page_type='8' then 'SER8'
          else ''
		  end as ServiceTypeValue,
	  10,'/'+lower(replace(replace(dbo.udf_TitleCase(t.service_name),' ','_'),'&','')),
   dbo.udf_TitleCase(t.service_name),dbo.udf_TitleCase(t.service_name),dbo.udf_TitleCase(t.service_name),'dbo',GETDATE(),'dbo',getdate(),
   0  from Tbl_CategoriesMaster c join tempservices t on c.CategoryName=t.MAIN_CATEGORY_MENU
   join Tbl_SubCategoriesMaster s on s.SubCategoryName=t.sub_category_menu;