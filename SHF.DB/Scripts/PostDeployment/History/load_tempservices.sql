﻿IF EXISTS (SELECT * FROM sys.objects WHERE name = 'tempservices')  
DROP Table [dbo].[tempservices]  
GO
CREATE TABLE [dbo].[tempservices](
	[SL_No_] [int] NOT NULL,
	[MAIN_CATEGORY_MENU] [nvarchar](50) NOT NULL,
	[SUB_CATEGORY_MENU] [nvarchar](50) NOT NULL,
	[SERVICE_NAME] [nvarchar](100) NOT NULL,
	[SERVICES_PAGE_TYPE] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (1, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Proprietorship Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (2, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Partnership Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (3, N'Form New Business', N'BUSINESS REGISTRATIONS', N'LLP Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (4, N'Form New Business', N'BUSINESS REGISTRATIONS', N'One Person Company Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (5, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Private Limited Company Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (6, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Public Limited Company Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (7, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Nidhi Company Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (8, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Producer Company Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (9, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Section 8 Company Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (10, N'Form New Business', N'BUSINESS REGISTRATIONS', N'Indian Subsidiary of Foreign Co.', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (11, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'Digital Signature', 4)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (12, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'MSME Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (13, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'Trade License', 3)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (14, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'Health License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (15, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'Professional Tax Registration', 3)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (16, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'FSSAI Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (17, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'Import Export Code', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (18, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'PSARA Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (19, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'RERA Registration for Projects', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (20, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'RERA Registration for Agents', 3)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (21, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'VAT Registration', 3)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (22, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'RCMC Registration', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (23, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'APEDA Registration', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (24, N'Form New Business', N'GOVERNMENT REGISTRATIONS', N'MPEDA Registration', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (25, N'Form New Business', N'NGO REGISTRATIONS', N'Trust Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (26, N'Form New Business', N'NGO REGISTRATIONS', N'Society Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (27, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in USA', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (28, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in China', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (29, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in Singapore', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (30, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in Dubai', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (31, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in Malaysia', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (32, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in UK', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (33, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in Australia', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (34, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in Hongkong', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (35, N'Form New Business', N'INTERNATIONAL INCORPORATIONS', N'Incorporation in Germany', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (36, N'Goods & Services Tax', N'REGISTRATION & RETURNS', N'GST Registration', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (37, N'Goods & Services Tax', N'REGISTRATION & RETURNS', N'Temporary GST Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (38, N'Goods & Services Tax', N'REGISTRATION & RETURNS', N'GST Registration for Foreigners', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (39, N'Goods & Services Tax', N'REGISTRATION & RETURNS', N'GST Registration Cancellation', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (40, N'Goods & Services Tax', N'REGISTRATION & RETURNS', N'GST Return Filing', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (41, N'Goods & Services Tax', N'REGISTRATION & RETURNS', N'GST Annual Return', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (42, N'Goods & Services Tax', N'OTHER GST SERVICES', N'GST E-Way Bill', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (43, N'Goods & Services Tax', N'OTHER GST SERVICES', N'GST LUT Filing', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (44, N'Goods & Services Tax', N'OTHER GST SERVICES', N'GST Refund', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (45, N'Goods & Services Tax', N'OTHER GST SERVICES', N'Input Tax Credit Recon', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (46, N'Goods & Services Tax', N'OTHER GST SERVICES', N'GST Advisory', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (47, N'Goods & Services Tax', N'OTHER GST SERVICES', N'GST Notice', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (48, N'Income Tax', N'ITR FILING', N'ITR-1 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (49, N'Income Tax', N'ITR FILING', N'ITR-2 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (50, N'Income Tax', N'ITR FILING', N'ITR-3 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (51, N'Income Tax', N'ITR FILING', N'ITR-4 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (52, N'Income Tax', N'ITR FILING', N'ITR-5 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (53, N'Income Tax', N'ITR FILING', N'ITR-6 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (54, N'Income Tax', N'ITR FILING', N'ITR-7 Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (55, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'PAN Card Application', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (56, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'PAN Card Correction', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (57, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'TAN Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (58, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'TDS Return Filing', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (59, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'Income Tax Notice', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (60, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'Section 12A Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (61, N'Income Tax', N'MANDATORY IT COMPLIANCE', N'Section 80G Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (62, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (63, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Rectification', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (64, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Opposition', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (65, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Objection', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (66, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Renewal', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (67, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Assignment', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (68, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark Watch', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (69, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark in USA', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (70, N'Intellectual Property', N'TRADEMARK SERVICES', N'Trademark in Australia', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (71, N'Intellectual Property', N'TRADEMARK SERVICES', N'International Trademark Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (72, N'Intellectual Property', N'OTHER IPR SERVICES', N'Design Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (73, N'Intellectual Property', N'OTHER IPR SERVICES', N'Copyright Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (74, N'Intellectual Property', N'OTHER IPR SERVICES', N'Patent Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (75, N'Intellectual Property', N'OTHER IPR SERVICES', N'Provisional Patent', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (76, N'Intellectual Property', N'OTHER IPR SERVICES', N'Logo Designing', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (77, N'Legal Compliance', N'COMPANY RELATED', N'Company Name Change', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (78, N'Legal Compliance', N'COMPANY RELATED', N'Change RO of Company', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (79, N'Legal Compliance', N'COMPANY RELATED', N'Add Director', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (80, N'Legal Compliance', N'COMPANY RELATED', N'Remove Director', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (81, N'Legal Compliance', N'COMPANY RELATED', N'Increase Authorised Capital', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (82, N'Legal Compliance', N'COMPANY RELATED', N'MoA Amendment', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (83, N'Legal Compliance', N'COMPANY RELATED', N'DIN e-KYC Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (84, N'Legal Compliance', N'COMPANY RELATED', N'DIN Application', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (85, N'Legal Compliance', N'COMPANY RELATED', N'DIN Cancellation', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (86, N'Legal Compliance', N'COMPANY RELATED', N'Nominee Consent Form (OPC)', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (87, N'Legal Compliance', N'COMPANY RELATED', N'ACTIVE Form Filing', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (88, N'Legal Compliance', N'COMPANY RELATED', N'MSME Return', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (89, N'Legal Compliance', N'COMPANY RELATED', N'Return of Deposits', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (90, N'Legal Compliance', N'COMPANY RELATED', N'Appointment of Managerial Personnel', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (91, N'Legal Compliance', N'COMPANY RELATED', N'Dormant Company Status Application', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (92, N'Legal Compliance', N'COMPANY RELATED', N'Active Company Status Application', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (93, N'Legal Compliance', N'COMPANY RELATED', N'Return of Dormant Company', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (94, N'Legal Compliance', N'COMPANY RELATED', N'Close a Company', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (95, N'Legal Compliance', N'BULK DSC & USB TOKENS', N'E-Mudhra DSC', 5)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (96, N'Legal Compliance', N'BULK DSC & USB TOKENS', N'Capricorn DSC', 5)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (97, N'Legal Compliance', N'BULK DSC & USB TOKENS', N'FIPS USB Tokens', 6)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (98, N'Legal Compliance', N'PAYROLL COMPLIANCE', N'EPFO Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (99, N'Legal Compliance', N'PAYROLL COMPLIANCE', N'ESI Registration', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (100, N'Legal Compliance', N'PAYROLL COMPLIANCE', N'PF Return Filing', 7)
GO
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (101, N'Legal Compliance', N'PAYROLL COMPLIANCE', N'ESI Return Filing', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (102, N'Legal Compliance', N'PAYROLL COMPLIANCE', N'Professional Tax Return Filing', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (103, N'Legal Compliance', N'CONVERSION', N'Proprietorship to OPC', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (104, N'Legal Compliance', N'CONVERSION', N'Proprietorship to Partnership', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (105, N'Legal Compliance', N'CONVERSION', N'Partnership to LLP', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (106, N'Legal Compliance', N'CONVERSION', N'Partnership to Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (107, N'Legal Compliance', N'CONVERSION', N'LLP to Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (108, N'Legal Compliance', N'CONVERSION', N'Society to Section 8 Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (109, N'Legal Compliance', N'CONVERSION', N'Trust to Section 8 Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (110, N'Legal Compliance', N'CONVERSION', N'OPC to Private Limited Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (111, N'Legal Compliance', N'CONVERSION', N'OPC to Public Limited Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (112, N'Legal Compliance', N'CONVERSION', N'Private to OPC Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (113, N'Legal Compliance', N'CONVERSION', N'Private to Public Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (114, N'Legal Compliance', N'CONVERSION', N'Public to Private Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (115, N'Legal Compliance', N'CONVERSION', N'Private Limited Company to LLP', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (116, N'Legal Compliance', N'CONVERSION', N'Public Limited Company to LLP', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (117, N'Legal Compliance', N'CONVERSION', N'Section 8 to Private Limited Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (118, N'Legal Compliance', N'CONVERSION', N'Section 8 to Public Limited Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (119, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Proprietorship', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (120, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Partnership', 7)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (121, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'LLP', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (122, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'One Person Company', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (123, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Private Limited Company', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (124, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Public Limited Company', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (125, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Indian Subsidiary of Foreign Co.', 1)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (126, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Section 8 Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (127, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Producer Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (128, N'Legal Compliance', N'ANNUAL COMPLIANCE', N'Nidhi Company', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (129, N'Legal Compliance', N'LLP RELATED', N'LLP Name Change', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (130, N'Legal Compliance', N'LLP RELATED', N'LLP RO Change', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (131, N'Legal Compliance', N'LLP RELATED', N'Add Partner to LLP', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (132, N'Legal Compliance', N'LLP RELATED', N'Change LLP Agreement', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (133, N'Legal Compliance', N'LLP RELATED', N'Resignation of Partner of LLP', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (134, N'Legal Compliance', N'LLP RELATED', N'Amend Partners details of LLP', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (135, N'Legal Compliance', N'LLP RELATED', N'Close an LLP', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (136, N'Legal Compliance', N'LEGAL COMPLIANCE', N'Sales Tax Notice', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (137, N'Legal Compliance', N'LEGAL COMPLIANCE', N'Professional Tax Notice', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (138, N'Legal Compliance', N'LEGAL COMPLIANCE', N'FEMA Related Advisory', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (139, N'Miscellaneous', N'LIQUOR LICENSE', N'Temporary One Day Function License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (140, N'Miscellaneous', N'LIQUOR LICENSE', N'One Day Permission for Foreign Liquor', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (141, N'Miscellaneous', N'LIQUOR LICENSE', N'One Year & Lifelong Permission for Foreign
Liquor', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (142, N'Miscellaneous', N'LIQUOR LICENSE', N'One Day Permission for Country Liquor', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (143, N'Miscellaneous', N'LIQUOR LICENSE', N'Wholesale License for Wine', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (144, N'Miscellaneous', N'LIQUOR LICENSE', N'Wholesale License for Country Liquor', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (145, N'Miscellaneous', N'LIQUOR LICENSE', N'Wholesale License for Foreign Liquor', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (146, N'Miscellaneous', N'LIQUOR LICENSE', N'Permit Room License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (147, N'Miscellaneous', N'LIQUOR LICENSE', N'Club License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (148, N'Miscellaneous', N'LIQUOR LICENSE', N'Beer Shop License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (149, N'Miscellaneous', N'LIQUOR LICENSE', N'Mild Liquor & Wine Bar License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (150, N'Miscellaneous', N'LIQUOR LICENSE', N'Wine Bar License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (151, N'Miscellaneous', N'LIQUOR LICENSE', N'Wine Shop License', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (152, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Name Change', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (153, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Religion Change', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (154, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Make a Will', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (155, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Age Nationality Domicile', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (156, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Senior Citizen Certificate', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (157, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Resident Certificate', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (158, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Change of Date of Birth', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (159, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Solvency Certificate', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (160, N'Miscellaneous', N'PERSONAL & PROPERTY RELATED', N'Rental Agreement Registration', 2)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (161, N'Miscellaneous', N'DIGITAL MARKETING', N'Email Marketing', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (162, N'Miscellaneous', N'DIGITAL MARKETING', N'SEO', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (163, N'Miscellaneous', N'DIGITAL MARKETING', N'Online Advertising', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (164, N'Miscellaneous', N'MANDATORY LICENSES', N'Factory License Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (165, N'Miscellaneous', N'MANDATORY LICENSES', N'Factory License Renewal', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (166, N'Miscellaneous', N'MANDATORY LICENSES', N'Registration of Principle Employer', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (167, N'Miscellaneous', N'MANDATORY LICENSES', N'Contractual Labour License Registration', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (168, N'Miscellaneous', N'MANDATORY LICENSES', N'Contractual Labour License Renewal', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (169, N'Miscellaneous', N'MANDATORY LICENSES', N'PCB Consent to Operate', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (170, N'Miscellaneous', N'MANDATORY LICENSES', N'PCB Consent to Establish', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (171, N'Miscellaneous', N'WEB OR APP RELATED', N'Website Designing', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (172, N'Miscellaneous', N'WEB OR APP RELATED', N'Website Maintenance', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (173, N'Miscellaneous', N'WEB OR APP RELATED', N'Website Redesign', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (174, N'Miscellaneous', N'WEB OR APP RELATED', N'Mobile App Development', 8)
INSERT [dbo].[tempservices] ([SL_No_], [MAIN_CATEGORY_MENU], [SUB_CATEGORY_MENU], [SERVICE_NAME], [SERVICES_PAGE_TYPE]) VALUES (175, N'Miscellaneous', N'WEB OR APP RELATED', N'Software Development', 8)
