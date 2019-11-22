//let app = angular.module('InventoryApp');

angular.module(config.app).service('IPInfoCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('IPInfoControllerScope')).scope();
        let tenantId = scope.IPInfoCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.IPInfoCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/IPInfo/IndexAsync',
                type: 'POST',
                dataSrc: 'data',
                data: { 'tenantId': tenantId },
                headers: {
                    'RequestVerificationToken': antiForgeryToken
                }
            },
            //width: "100%",
            //scrollY: 500,
            //autoWidth: true,
            scrollX: true,
            //scrollCollapse: true,
            //responsive: true,
            //deferRender: true,
            //scroller: true,
            processing: true,
            pagingType: "full_numbers",
            order: [1, "desc"],
            lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
            colReorder: true,
            columns: [
                {
                    title: "#",
                    render: function (data, type, row, meta) {
                        return '<text>' + parseInt(parseInt(meta.row) + 1); + '</text>';
                    },
                    searchable: false,
                    orderable: false,
                    width: "3%",
                    targets: 0
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.ip",
                    data: "ip",
                    title: "Visited&nbsp;IP",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.is_eu",
                    data: "is_eu",
                    title: "Is&nbsp;Eu",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.city",
                    data: "city",
                    title: "City",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region",
                    data: "region",
                    title: "Region",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.region_code",
                    data: "region_code",
                    title: "Region&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_name",
                    data: "country_name",
                    title: "Country",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.country_code",
                    data: "country_code",
                    title: "Country&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_name",
                    data: "continent_name",
                    title: "Continent&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.continent_code",
                    data: "continent_code",
                    title: "Continent&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.latitude",
                    data: "latitude",
                    title: "Latitude",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 11
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.longitude",
                    data: "longitude",
                    title: "Longitude",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 12
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.postal",
                    data: "postal",
                    title: "Postal",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 13
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.calling_code",
                    data: "calling_code",
                    title: "Calling&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 14
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.city",
                    data: "city",
                    title: "City",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 15
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.flag",
                    data: "flag",
                    title: "Flag",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 16
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_flag",
                    data: "emoji_flag",
                    title: "Emoji&nbsp;Flag",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 17
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.emoji_unicode",
                    data: "emoji_unicode",
                    title: "Emoji&nbsp;Unicode",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 18
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.asn",
                    data: "Asn_asn",
                    title: "Asn",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 19
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.Asn_name",
                    data: "Asn_name",
                    title: "Asn&Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 19
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.domain",
                    data: "Asn_domain",
                    title: "Asn_domain",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 20
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.route",
                    data: "Asn_route",
                    title: "Asn_route",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 21
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.Asns.type",
                    data: "Asn_type",
                    title: "Asn_type",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 22
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.name",
                    data: "Carrier_name",
                    title: "Carrier_name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 23
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mcc",
                    data: "Carrier_mcc",
                    title: "Carrier_mcc",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 24
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.Carriers.mnc",
                    data: "Carrier_mnc",
                    title: "Carrier_mnc",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 25
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.name",
                    data: "Language_name",
                    title: "Language_name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 26
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.native",
                    data: "Language_native",
                    title: "Language_native",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 27
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.name",
                    data: "Currency_name",
                    title: "Currency_name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 28
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.code",
                    data: "Currency_code",
                    title: "Currency_code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 29
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.symbol",
                    data: "Currency_symbol",
                    title: "Currency_symbol",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 30
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.native",
                    data: "Currency_native",
                    title: "Currency_native",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 31
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.Currencies.plural",
                    data: "Currency_plural",
                    title: "Currency_plural",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 32
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.name",
                    data: "TimeZone_name",
                    title: "TimeZone_name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 33
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.abbr",
                    data: "TimeZone_abbr",
                    title: "TimeZone_abbr",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 34
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.offset",
                    data: "TimeZone_offset",
                    title: "TimeZone_offset",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 35
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.is_dst",
                    data: "TimeZone_is_dst",
                    title: "TimeZone_is_dst",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 36
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.TimeZone.current_time",
                    data: "TimeZone_current_time",
                    title: "TimeZone_current_time",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 37
                },
                {
                    name: "Threat.is_tor",
                    data: "Threat_is_tor",
                    title: "Threat_is_tor",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 38
                },
                {
                    name: "Threat.is_proxy",
                    data: "Threat_is_proxy",
                    title: "Threat_is_proxy",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 39
                },
                {
                    name: "Threat.is_anonymous",
                    data: "Threat_is_anonymous",
                    title: "Threat_is_anonymous",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 40
                },
                 {
                     name: "Threat.is_known_attacker",
                     data: "Threat_is_known_attacker",
                     title: "Threat_is_known_attacker",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 41
                },
                {
                    name: "Threat.is_known_abuser",
                    data: "Threat_is_known_abuser",
                    title: "Threat_is_known_abuser",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 42
                },
                {
                    name: "Threat.is_threat",
                    data: "Threat_is_threat",
                    title: "Threat_is_threat",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 43
                },
                {
                    name: "Threat.is_bogon",
                    data: "Threat_is_bogon",
                    title: "Threat_is_bogon",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 44
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets: 4
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 5
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 6
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 7
                },
                {
                    name: "IPInfo_tenant_Asns_Carriers_Language_Currencies_TimeZone.IPInfo_tenant_Asns_Carriers_Language_Currencies.IPInfo_tenant_Asns_Carriers_Language.IPInfo_tenant_Asns_Carriers.IPInfo_tenant_Asns.IPInfo_tenant.IPInfo.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 8
                },
                {
                    name: null,
                    data: "ID",
                    title: "&nbsp;Delete&nbsp;&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-danger btn-delete"><i title="Delete" class="fa fa-trash"></i></button>';
                    },
                    width: "2%",
                    targets: 10
                }
            ],

            language: {
                decimal: ",",
                thousands: "."
            }


        });

        $('#grdTable tbody').off('click');
        $('#grdTable tbody').on('click', '.btn-edit', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('IPInfoControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('IPInfoControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
    }

    this.LoadTable = function GetObject() {
        if ($.fn.dataTable.isDataTable('#grdTable')) {
            let table = $('#grdTable').DataTable();
            table.destroy();
            this.GetTableObject();
        }
        else {
            this.GetTableObject();
        }
    }


    this.LoadIPInfoDropdown = function IPInfoDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/IPInfo/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadAllIPInfoByTenantIdAsync = function GetAllIPInfoByTenantIdAsync(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/IPInfo/GetAllIPInfoByTenantIdAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadPurchaseProductDropdownByVendor = function PurchaseProductDropdownByVendor(vendorId) {
        let request = $http({
            method: "get",
            url: "/Get/Product/PurchaseDropdownListbyVendorAsync?Id=" + vendorId
        });
        return request;
    }

    this.LoadSaleableProductDropdownByTenant = function SaleableProductDropdownByTenantId(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/Sales/SaleableProductDropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadAllProductDropdownByVendorId = function AllProductDropdownByVendorId(vendorId) {
        let request = $http({
            method: "get",
            url: "/Get/Purchase/AllProductDropdownListByVendorAsync?Id=" + vendorId
        });
        return request;
    }

});

