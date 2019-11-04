SET IDENTITY_INSERT [dbo].[Tbl_Tenant] ON 

INSERT [dbo].[Tbl_Tenant] ([ID], [Name], [Storage_Directory], [Billing_Address_Attention], [Billing_Address_Street_1], [Billing_Address_Street_2], [BillingAddressCountry_ID], [Billing_Address_Country_Value], [BillingAddressState_ID], [Billing_Address_State_Value], [BillingAddressCityOrDistrict_ID], [Billing_Address_CityOrDistrict_Value], [Billing_Address_Zip_Code], [Billing_Address_Phone], [Billing_Address_Fax], [Shipping_Address_Attention], [Shipping_Address_Street_1], [Shipping_Address_Street_2], [ShippingAddressCountry_ID], [Shipping_Address_Country_Value], [ShippingAddressState_ID], [Shipping_Address_State_Value], [ShippingAddressCityOrDistrict_ID], [Shipping_Address_CityOrDistrict_Value], [Shipping_Address_Zip_Code], [Shipping_Address_Phone], [Shipping_Address_Fax], [Contact_Person], [Contact_Number], [Email], [GST], [No_Of_Locations], [No_Of_SHF_Items], [Is_Active], [Update_Seq], [Created_By], [Created_On], [Modified_By], [Modified_On], [Is_Deleted]) VALUES (1, N'ShivaBF', NULL, N'sdj', N'asd', N'ds.,fksd', 1009, N'INDI', 1010, N'MH00', 1011, N'PUNE', N'412307', N'23252221', N'2212552152115522', N'sdj', N'asd', N'ds.,fksd', 1009, N'INDI', 1010, N'MH00', 1011, N'PUNE', N'412307', N'23252221', N'2212552152115522', N'Mukund Jha', N'9521784521', N'shiva@ymail.com', N'11EAWPK9956B1Z1', 11, 20, 1, 0, N'delmon', CAST(N'2019-10-30T20:23:37.273' AS DateTime), N'delmon', CAST(N'2019-10-30T20:23:37.273' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Tbl_Tenant] OFF


declare @Tenant_ID bigint
 SELECT @Tenant_ID=T.Id FROM dbo.Tbl_Tenant T WITH(NOLOCK) WHERE T.[Name]='ShivaBF';
 update [dbo].[Tbl_CategoriesMaster]
set Tenant_ID=@Tenant_ID

update [dbo].[Tbl_SubCategoriesMaster]
set Tenant_ID=@Tenant_ID

update [dbo].[Tbl_SubSubCategoriesMaster]
set Tenant_ID=@Tenant_ID