angular.module(config.app).service('CodeValueCRUD', function ($http) {

    this.CODE = {
        PurchaseOrderStatus: 1001,
        ExpectedDelivery: 1002,
        QualityStatus: 1003,
        BarcodeType: 1004,
        SourceOfSupply: 1005,
        ReferenceType: 1006,
        DeliveryMethod: 1007,
        SalesOrderStatus: 1008,
        Country: 1009,
        State: 1010,
        CityOrDistrict: 1011,
        AddressType: 1012,
        ContactPersonType: 1013,
        ContactType: 1014,
        BarcodeCategory: 1015,
        BarcodeSubCategory: 1016,
ServiceType: 1020
    }

    this.CODE_VALUE = {
ServiceType: {
SERVICE_1:"SER1",
SERVICE_2:"SER2",
SERVICE_3:"SER3",
SERVICE_4:"SER4",
SERVICE_5:"SER5",
SERVICE_6:"SER6",
SERVICE_7:"SER7",
SERVICE_8:"SER8",
},
        BarcodeType: {
            Code128auto: "A128",
            Code128A: "128A",
            Code128B: "128B",
            Code128C: "128C",
            EN13: "EN13",
            EAN8: "EAN8",
            UPC: "UPC",
            CODE39: "CD39",
            ITF14: "IF14",
            ITF: "ITF",
            MSI: "MSI",
            MSI10: "MI10",
            MSI11: "MI11",
            MSI1010: "MS10",
            MSI1110: "MS11",
            pharmacode: "PHCD",
        },

        PurchaseOrderStatus: {
            INITIATED: "INTI",
            PARTIAL: "PRTL",
            COMPLETED: "COMP",
        },

        SalesOrderStatus: {
            INITIATED: "INTI",
            PARTIAL: "PRTL",
            COMPLETED: "COMP",
        },

        ExpectedDelivery: {
            DAY: "DAYS",
            MONTH: "MNTH",
            YEAR: "YEAR",
        },

        QualityStatus: {
            GOOD: "GOOD",
            DEFECTED: "DFCT",
            EXPIRED: "EXPR",
        },

        ReferenceType: {
            TELEPHONIC: "TLPH",
            EMAIL: "EMAL",
            PERSONTOPERSON: "PTOP",
        },

        DeliveryMethod: {
            COURIER: "CRUR",
            SELF: "SELF",
        },

        SourceOfSupply: {
            MAHARASHTRA: "MH00",
            GUJRAT: "GJ00",
            DEHLI: "DL00",
        },

        AddressType: {
            BILLING: "BILL",
            SHIPPING: "SHIP",
        },

        Country: {
            INDIA: "INDI",
        },

        State: {
            MAHARASHTRA: "MH00",
            GUJRAT: "GJ00",
            DEHLI: "DL00",
        },

        CityOrDistrict: {
            PUNE: "PUNE",
            NASHIK: "NSHK",
            MUMBAI: "MUMB",
            NAGPUR: "NGPR",
        },

        ContactType: {
            Customer: "CUST",
            Vendor: "VEND",
        },

        ContactPersonType: {
            PRIMARY: "PRIM",
            SECONDARY: "SECO",
        },

        BarcodeCategory: {
            LINEAR_BARCODE: "LINE",
            QR_CODE: "QRCD",
            PFD_417: "P417",
            DATA_MATRIX: "DTMT",
        },

        BarcodeSubCategory: {
            CODA_BAR: "CDBR",
            CODE_2_OF_5: "C2O5",
            CODE_11: "CD11",
            CODE_39: "CD39",
            CODE_93: "CD93",
            CODE_128: "C128",
            EAN_8: "EAN8",
            EAN_13: "EN13",
            GS1_128_EAN_128: "E128",
            INTERLEAVED_2_OF_5: "I2O5",
            ITF_14: "IF14",
            MSI_PLESSY: "MSIP",
            ONE_CODE: "ONCD",
            PLANET: "PLNT",
            POSTNET: "PONT",
            RM4SSC: "RM4S",
            UPC_A: "UPCA",
            UPC_E: "UPCE",
        },

        Numerics: {

            Integer: {
                ZERO: 0,
                ONE: 1,
                TWO: 2,
                THREE: 3,
                FOUR: 4,
                FIVE: 5,
                SIX: 6,
                SEVEN: 7,
                EIGHT: 8,
                NINE: 9,
                TEN: 10
            },

            Decimal: {
                ONE: 1.00,
                TWO: 2.00,
                THREE: 3.00,
                FOUR: 4.00,
                FIVE: 5.00,
                SIX: 6.00,
                SEVEN: 7.00,
                EIGHT: 8.00,
                NINE: 9.00,
                ZERO: 0.00
            }
        }
    };


    this.LoadCodeValueDropDownByCodeId = function CodeValueDropDownByCodeId(codeId) {
        let request = $http({
            method: "get",
            url: "/Get/CodeValue/CodeValueByCodeAsync?Id=" + codeId
        });
        return request;
    }

    this.LoadCodeValueByCodeId = function CodeValueByCodeId(codeId) {
        if (codeId) {
            let CODE_VALUES = JSON.parse(localStorage.getItem("CODE_VALUES"));
            if (CODE_VALUES && CODE_VALUES.length > 0) {
                let CODEVALUES = JSLINQ(CODE_VALUES).Where(function (codeValues) { return codeValues.Code_ID == codeId; });
                if (CODEVALUES && CODEVALUES.items && CODEVALUES.items.length > 0) {
                    return CODEVALUES.items;
                }
            } else {
                swal("Whooaaa! Please logout and login again...", "", "error");
            }
        }
        else {
            swal("ERR 10: Whooaaa! Code value for codeId" + codeId + " does not exists.", "", "error");
        }
    }


});
