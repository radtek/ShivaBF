using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.Helper
{
    public static class busConstant
    {
        public abstract class Settings
        {
            public abstract class DataBase
            {
                public abstract class SqlServer
                {
                    public abstract class Connections
                    {
                        public abstract class TimeOut
                        {
                            public const int S100 = 100;
                            public const int S200 = 200;
                            public const int S300 = 300;
                            public const int S400 = 400;
                            public const int S500 = 500;
                            public const int S600 = 600;
                            public const int S700 = 700;
                            public const int S800 = 800;
                            public const int S900 = 900;
                            public const int S1000 = 1000;
                        }
                        public abstract class ConnectionString
                        {
                            //public const string DEFAULT = DEVELOPMENT_HOME;
                            //public const string DEFAULT = DEVELOPMENT;
                            //public const string DEFAULT = DEVELOPMENT_L;
                           // public const string DEFAULT = TESTING;
                          public const string DEFAULT = PRODUCTION;
                        }
                        private const string DEVELOPMENT_HOME = "DevelopmentHome";
                        private const string DEVELOPMENT = "DevelopmentMSSQL";
                        private const string DEVELOPMENT_L = "DevelopmentMSSQLL";
                        private const string TESTING = "TestingMSSQL";
                        private const string PRODUCTION = "ProductionMSSQL";
                    }
                }
            }


            public abstract class Cache
            {
                public abstract class Keys
                {
                    public const string CODE_TABLE = "CODE_TABLE";
                    public const string CODE_VALUE_TABLE = "CODE_VALUE_TABLE";
                    public const string MESSAGE_TABLE = "Message_TABLE";
                    public const string ASPNET_USER_ROLE_TABLE = "ASPNET_USER_ROLE_TABLE";
                    public const string ASPNET_ROLE_SUBMENU_TABLE = "ASPNET_ROLE_SUBMENU_TABLE";
                    public const string SUB_MENU_TABLE = "SUB_MENU_TABLE";
                }

                public abstract class OutputCache
                {
                    public abstract class TimeOut
                    {
                        public const int S10 = 10;
                        public const int S20 = 20;
                        public const int S30 = 30;
                        public const int S60 = 60;
                        public const int S100 = 100;
                        public const int S200 = 200;
                        public const int S300 = 0;
                        public const int S400 = 400;
                        public const int S500 = 500;
                        public const int S600 = 600;
                        public const int S700 = 700;
                        public const int S800 = 800;
                        public const int S900 = 900;
                        public const int S1000 = 1000;
                    }
                }
            }


            public abstract class Session
            {

                public abstract class Keys
                {
                    public const string ACTIVITY_BY = "Activity_By";
                    public const string ACTIVITY_DATETIME = "Activity_DateTime";
                    public const string USER = "User";
                    public const string IMPERSONATE = "Impersonate";
                }
            }


            public abstract class Cookie
            {
                public abstract class Name
                {
                    public const string DELMON_SOLUTIONS = "&nomleD";
                }
                public abstract class SubKeys
                {
                    public const string TENANT_ID = "&DItnaneT";
                    public const string BRANCH_ID = "&DIhcnarB";
                    public const string USER_ID = "&DIresU";
                    public const string ROLE_NAME = "&emaNeloR";
                }
            }


            public abstract class AspNetRoles
            {
                public const string ADMIN = "Admin";
                public const string DEVLOPMENT = "DEVLOPMENT";
                public const string SUPPORT = "SUPPORT";
                //new roles defined for by default role for each tenant
                public enum DefaultRolesForTenant {
                    [DescriptionAttribute("Purchase Executive")] PURCHASEEXECUTIVE,
                    [DescriptionAttribute("Sales Executive")] SALSEXECUTIVE,
                    [DescriptionAttribute("Accounts Executive")] ACCOUNTSEXECUTIVE
            };
                public const string PURCHASEEXECUTIVE = "Purchase Executive";
                public const string SALSEXECUTIVE = "Sales Executive";
                public const string ACCOUNTSEXECUTIVE = "Account Executive";
                
            }


            public abstract class NavigationFor
            {
                public const string TENANT = "TENANT";
                public const string DEVLOPMENT = "DEVLOPMENT";
            }

            public abstract class CMSPath
            {
                public const string TENANAT_UPLOAD_DIRECTORY = "/Media/Uploads/Tenants/";
                public const string TENANAT_THUMB_DIRECTORY = "/Media/Thumbs/Tenants/";
            }
        }

        public abstract class Messages
        {
            public abstract class Type
            {
                public const string VALIDATION = "Validation";
                public const string RESPONSE = "Response";
                public const string EXCEPTION = "Exception";

                public abstract class Validations
                {
                    public const string REQUIRED = "The {0} is required.";
                    public const string ONLY_CHARATERS = "The digits and special symbols and spaces are not allowed in {0}.";
                    public const string NO_SPACE = "The spaces between characters are not allowed in {0}.";

                    public const string LENGTH = "The length of {0} must be between {1} and {2} characters.";

                    public const string LENGTH_1_TO_2 = "Data length must be between 1 and 2 characters.";
                    public const string LENGTH_2_TO_4 = "Data length must be between 2 and 4 characters.";
                    public const string LENGTH_2_TO_50 = "Data length must be between 2 and 50 characters.";
                    public const string LENGTH_UP_TO_50 = "Data length must be less than or equal to 50 characters.";

                    public const string EMAIL = "Please enter valid email address.";
                    public const string MOBILE = "Please enter valid (10 digit) mobile number.";
                    public const string PHONE_NUMBER = "Please enter valid {0}.";
                    public const string GST_NUMBER = "Please enter valid {0}.";
                    public const string PAN_NUMBER = "Please enter valid {0}.";

                    public const string PURCHASE_ORDER_ITEMS_NOT_FOUND = "Purchase order items should not be empty.";
                    public const string SERIAL_NUMBER_NOTFOUND = "Product serial number should not be empty.";
                    public const string SERIAL_NUMBER_NOTEXISTS = "Serial number not exists.";
                    public const string SERIAL_NUMBER_EXISTS = "Serial number already inwarded.";

                    public const string ZIP_CODE = "Please enter valid {0}.";
                }
                public abstract class Responses
                {
                    public const string SAVE = "Record saved successfully.";
                    public const string DELETE = "Record deleted successfully.";
                    public const string ALREADY_EXIST = "Record Already Exist.";

                }

                public abstract class Exceptions
                {
                    public const string SOMETHING_IS_MISSING = "Something is missing.";
                    public const string SOMETHING_WENT_WRONG = "Something went wrong.";
                    public const string INTERNAL_SERVER_ERROR = "Internal Server Error.";
                    public const string BAD_REQUEST = "Bad Request.";
                    public const string NOT_FOUND = "Page Not Found.";

                    public const string IX_TaxDisplayNameAndTenantId = "Tax name is already exists.";
                    public const string IX_VendorIDProductIDTenantID = "Product and Vendor is already mapped.";
                    public const string IX_ProductIDAndUnitOfMeasurementID = "Product and UOM is already mapped.";
                    public const string IX_Message_Code = "Messgae code is already exists.";
                }
            }
            public abstract class Title
            {
                public const string SUCCESS = "Success!";
                public const string WARNING = "Warning";
                public const string ERROR = "Error";
            }
            public abstract class Icon
            {
                public const string SUCCESS = "success";
                public const string WARNING = "warning";
                public const string ERROR = "error";
            }

            public abstract class MessageCode
            {
                public const int SAVE = 1;
                public const int SKU_ALREADY_EXIST = 2;
                public const int ROLE_ALREADY_EXIST = 3;
                public const int UOM_ALREADY_EXIST = 4;
                public const int Slab_ALREADY_EXIST = 5;
                public const int Services_ALREADY_EXIST = 6;
            }
        }

        public abstract class Misc
        {
            public const int MONTHS_IN_YEAR = 12;
            public const int FISCAL_YEAR_START_MONTH = 4;
            public const int FISCAL_YEAR_START_DATE = 1;
            public const int FISCAL_YEAR_END_MONTH = 3;
            public const int FISCAL_YEAR_END_DATE = 31;

            public const string FLAG_YES = "Y";
            public const string FLAG_NO = "N";
            public const string FLAG_YES_VALUE = "YES";
            public const string FLAG_NO_VALUE = "NO";

            public const string FLAG_TRUE = "true";
            public const string FLAG_FALSE = "false";

            public const bool TRUE = true;
            public const bool FALSE = false;

            public const string SYSTEM = "SYSTEM";
            public const string USER_IMPERSONATION = "UserImpersonation";
            public const string ORIGINAL_USER_NAME = "OriginalUsername";

            public const string TENANT = "TENANT";
            public const string DEVLOPMENT = "DEVLOPMENT";
        }

        public abstract class Code
        {
            public const int PURCHASE_ORDER_STATUS = 1001;
            public const int EXPECTED_DELIVERY = 1002;
            public const int QUALITY_STATUS = 1003;
            public const int BARCODE_TYPE = 1004;
            public const int SOURCE_OF_SUPPLY = 1005;
            public const int REFERENCE_TYPE = 1006;
            public const int DELIVERY_METHOD = 1007;
            public const int SALES_ORDER_STATUS = 1008;
            public const int COUNTRY = 1009;
            public const int STATE = 1010;
            public const int CITY_OR_DISTRICT = 1011;
            public const int ADDRESS_TYPE = 1012;
            public const int CONTACT_PERSON_TYPE = 1013;
            public const int CONTACT_TYPE = 1014;
            public const int BARCODE_CATEGORY = 1015;
            public const int BARCODE_SUB_CATEGORY = 1016;
            public const int SERVICE_TYPE = 1020;

            public abstract class CodeValue
            {
                public abstract class ServiceType
                {
                    public const string SERVICE_1 = "SER1";
                    public const string SERVICE_2 = "SER2";
                    public const string SERVICE_3 = "SER3";
                    public const string SERVICE_4 = "SER4";
                    public const string SERVICE_5 = "SER5";
                    public const string SERVICE_6 = "SER6";
                    public const string SERVICE_7 = "SER7";
                    public const string SERVICE_8 = "SER8";

                }
                public abstract class BarcodeType
                {
                    public const string CODE_128_AUTO = "CODE128";
                    public const string CODE_128_A = "CODE128A";
                    public const string CODE_128_B = "CODE128B";
                    public const string CODE_128_C = "CODE128C";
                    public const string EN_13 = "EAN13";
                    public const string EAN_8 = "EAN8";
                    public const string UPC = "UPC";
                    public const string CODE_39 = "CODE39";
                    public const string ITF_14 = "ITF14";
                    public const string ITF = "ITF";
                    public const string MSI = "MSI";
                    public const string MSI_10 = "MSI10";
                    public const string MSI_11 = "MSI11";
                    public const string MSI_1010 = "MSI1010";
                    public const string MSI_1110 = "MSI1110";
                    public const string PHARMACODE = "pharmacode";


                    //public const string Code128auto = "A128";
                    //public const string Code128A = "128A";
                    //public const string Code128B = "128B";
                    //public const string Code128C = "128C";
                    //public const string EN13 = "EN13";
                    //public const string EAN8 = "EAN8";
                    //public const string UPC = "UPC";
                    //public const string CODE39 = "CD39";
                    //public const string ITF14 = "IF14";
                    //public const string ITF = "ITF";
                    //public const string MSI = "MSI";
                    //public const string MSI10 = "MI10";
                    //public const string MSI11 = "MI11";
                    //public const string MSI1010 = "MS10";
                    //public const string MSI1110 = "MS11";
                    //public const string pharmacode = "PHCD";
                }
                public abstract class PurchaseOrderStatus
                {
                    public const string INITIATED = "INTI";
                    public const string PARTIAL = "PRTL";
                    public const string COMPLETED = "COMP";
                }

                public abstract class SalesOrderStatus
                {
                    public const string INITIATED = "INTI";
                    public const string PARTIAL = "PRTL";
                    public const string COMPLETED = "COMP";
                }

                public abstract class ExpectedDelivery
                {
                    public const string DAY = "DAYS";
                    public const string MONTH = "MNTH";
                    public const string YEAR = "YEAR";
                }

                public abstract class QualityStatus
                {
                    public const string GOOD = "GOOD";
                    public const string DEFECTED = "DFCT";
                    public const string EXPIRED = "EXPR";
                }

                public abstract class ReferenceType
                {
                    public const string TELEPHONIC = "TLPH";
                    public const string EMAIL = "EMAL";
                    public const string PERSON_TO_PERSON = "PTOP";
                }

                public abstract class DeliveryMethod
                {
                    public const string COURIER = "CRUR";
                    public const string SELF = "SELF";
                }

                public abstract class SourceOfSupply
                {
                    public const string MAHARASHTRA = "MH00";
                    public const string GUJRAT = "GJ00";
                    public const string DEHLI = "DL00";
                }

                public abstract class AddressType
                {
                    public const string BILLING = "BILL";
                    public const string SHIPPING = "SHIP";
                }

                public abstract class Country
                {
                    public const string INDIA = "INDI";
                }

                public abstract class State
                {
                    public const string MAHARASHTRA = "MH00";
                    public const string GUJRAT = "GJ00";
                    public const string DEHLI = "DL00";
                }

                public abstract class CityOrDistrict
                {
                    public const string PUNE = "PUNE";
                    public const string NASHIK = "NSHK";
                    public const string MUMBAI = "MUMB";
                    public const string NAGPUR = "NGPR";
                }

                public abstract class ContactType
                {
                    public const string CUSTOMER = "CUST";
                    public const string VENDOR = "VEND";
                }
                public abstract class ContactPersonType
                {
                    public const string PRIMARY = "PRIM";
                    public const string SECONDARY = "SECO";
                }

                public abstract class BarcodeCategory
                {
                    public const string LINEAR_BARCODE = "LINE";
                    public const string QR_CODE = "QRCD";
                    public const string PFD_417 = "P417";
                    public const string DATA_MATRIX = "DTMT";
                }

                public abstract class BarcodeSubCategory
                {
                    public const string CODA_BAR = "CDBR";
                    public const string CODE_2_OF_5 = "C2O5";
                    public const string CODE_11 = "CD11";
                    public const string CODE_39 = "CD39";
                    public const string CODE_93 = "CD93";
                    public const string CODE_128 = "C128";
                    public const string EAN_8 = "EAN8";
                    public const string EAN_13 = "EN13";
                    public const string GS1_128_EAN_128 = "E128";
                    public const string INTERLEAVED_2_OF_5 = "I2O5";
                    public const string ITF_14 = "IF14";
                    public const string MSI_PLESSY = "MSIP";
                    public const string ONE_CODE = "ONCD";
                    public const string PLANET = "PLNT";
                    public const string POSTNET = "PONT";
                    public const string RM4SSC = "RM4S";
                    public const string UPC_A = "UPCA";
                    public const string UPC_E = "UPCE";
                }
            }
        }

        public abstract class SwitchCase
        {
            public abstract class BaseViewModel
            {
                public const string CREATED_BY = "CreatedBy";
                public const string CREATED_ON = "CreatedOn";
                public const string UPDATED_BY = "UpdatedBy";
                public const string UPDATED_ON = "UpdatedOn";
                public const string IS_DELETED = "IsDeleted";
                public const string IS_ACTIVE = "IsActive";
                public const string URL = "Url";
                public const string METADATA = "Metadata";
                public const string KEYWORD = "Keyword";
                public const string METADESCRIPTION = "MetaDescription";
                
            }

            public abstract class Tables
            {
                public const string SUB_MENU = "SubMenu";
                public const string ASPNET_ROLE_SUB_MENU = "AspNetRoleSubMenu";
            }

            public abstract class BarcodeType
            {
                public const string CODE_128_AUTO = "A128";
                public const string CODE_128_A = "128A";
                public const string CODE_128_B = "128B";
                public const string CODE_128_C = "128C";
                public const string EN_13 = "EN13";
                public const string EAN_8 = "EAN8";
                public const string UPC = "UPC";
                public const string CODE_39 = "CD39";
                public const string ITF_14 = "IF14";
                public const string ITF = "ITF";
                public const string MSI = "MSI";
                public const string MSI_10 = "MI10";
                public const string MSI_11 = "MI11";
                public const string MSI_1010 = "MS10";
                public const string MSI_1110 = "MS11";
                public const string PHARMACODE = "PHCD";
            }

            public abstract class BarcodeCategory
            {
                public const string LINEAR_BARCODE = "LINE";
                public const string QR_CODE = "QRCD";
                public const string PFD_417 = "P417";
                public const string DATA_MATRIX = "DTMT";

                public abstract class Linear
                {
                    public const string CODA_BAR = "CDBR";
                    public const string CODE_2_OF_5 = "C2O5";
                    public const string CODE_11 = "CD11";
                    public const string CODE_39 = "CD39";
                    public const string CODE_93 = "CD93";
                    public const string CODE_128 = "C128";
                    public const string EAN_8 = "EAN8";
                    public const string EAN_13 = "EN13";
                    public const string GS1_128_EAN_128 = "E128";
                    public const string INTERLEAVED_2_OF_5 = "I2O5";
                    public const string ITF_14 = "IF14";
                    public const string MSI_PLESSY = "MSIP";
                    public const string ONE_CODE = "ONCD";
                    public const string PLANET = "PLNT";
                    public const string POSTNET = "PONT";
                    public const string RM4SSC = "RM4S";
                    public const string UPC_A = "UPCA";
                    public const string UPC_E = "UPCE";
                }


            }

        }

        public abstract class Forms
        {
            public const string LOOK_UP = "Lookup";
            public const string MAINTENANCE = "Maintenance";
        }

        public abstract class Numbers
        {
            public abstract class Integer
            {
                public const int ZERO = 0;
                public const int ONE = 1;
                public const int TWO = 2;
                public const int THREE = 3;
                public const int FOUR = 4;
                public const int FIVE = 5;
                public const int SIX = 6;
                public const int SEVEN = 7;
                public const int EIGHT = 8;
                public const int NINE = 9;
                public const int TEN = 10;
            }

            public abstract class Decimal
            {
                public const decimal ZERO = 0.0m;
                public const decimal ONE = 1.0m;
                public const decimal TWO = 2.0m;
                public const decimal THREE = 3.0m;
                public const decimal FOUR = 4.0m;
                public const decimal FIVE = 5.0m;
                public const decimal SIX = 6.0m;
                public const decimal SEVEN = 7.0m;
                public const decimal EIGHT = 8.0m;
                public const decimal NINE = 9.0m;
                public const decimal TEN = 10.0m;
            }

        }

        public abstract class DataType
        {
            public const string LAND_LINE_NUMBER = "LAND_LINE_NUMBER";
            public const string MOBILE_NUMBER = "MOBILE_NUMBER";
            public const string GST_NUMBER = "GST_NUMBER";
            public const string PAN_NUMBER = "PAN_NUMBER";
            public const string ZIP_CODE = "ZIP_CODE";
        }

    }
}
