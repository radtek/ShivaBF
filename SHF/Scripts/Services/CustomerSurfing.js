﻿//let app = angular.module('InventoryApp');

angular.module(config.app).service('CustomerSurfingCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('CustomerSurfingControllerScope')).scope();
        let tenantId = scope.CustomerSurfingCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.CustomerSurfingCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/CustomerSurfing/IndexAsync',
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
                    name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
               {
                    name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.Session_ID",
                    data: "Session_ID",
                    title: "Session",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
               {
                    name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FirstName",
                    data: "FirstName",
                    title: "FirstName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
                {
                    name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.LastName",
                    data: "LastName",
                    title: "LastName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                  {
                   name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.DOB",
                    data: "DOB",
                    title: "DOB",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "40%",
                    targets: 5
                },
                 {
                   name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.EmailID",
                    data: "EmailID",
                    title: "EmailID",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 6
                },
               {
                   name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FullStreetAddress",
                    data: "FullStreetAddress",
                   title: "Full&nbsp;Street&nbsp;Address",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 7
                },
               {
                    name: "CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.PageUrl",
                    data: "PageUrl",
                    title: "PageUrl",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
              {
                    name: "IPInfo.ip",
                    data: "ip",
                    title: "Visited&nbsp;IP",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                },
                {
                    name: "IPInfo.is_eu",
                    data: "is_eu",
                    title: "Is&nbsp;Eu",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
                {
                    name: "IPInfo.city",
                    data: "city",
                    title: "City",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                {
                    name: "IPInfo.region",
                    data: "region",
                    title: "Region",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
                {
                    name: "IPInfo.region_code",
                    data: "region_code",
                    title: "Region&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
                {
                    name: "IPInfo.country_name",
                    data: "country_name",
                    title: "Country",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
                {
                    name: "IPInfo.country_code",
                    data: "country_code",
                    title: "Country&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
                {
                    name: "IPInfo.continent_name",
                    data: "continent_name",
                    title: "Continent&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                },
                {
                    name: "IPInfo.continent_code",
                    data: "continent_code",
                    title: "Continent&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
                {
                    name: "IPInfo.latitude",
                    data: "latitude",
                    title: "Latitude",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 11
                },
                {
                    name: "IPInfo.longitude",
                    data: "longitude",
                    title: "Longitude",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 12
                },
                {
                    name: "IPInfo.postal",
                    data: "postal",
                    title: "Postal",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 13
                },
                {
                    name: "IPInfo.calling_code",
                    data: "calling_code",
                    title: "Calling&nbsp;Code",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 14
                },
                {
                    name: "IPInfo.city",
                    data: "city",
                    title: "City",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 15
                },
                {
                    name: "IPInfo.flag",
                    data: "flag",
                    title: "Flag",
                    render: function (data, type, row, meta) {
                        return '<img src="'+data+'" />';
                    },
                    width: "25%",
                    targets: 16
                },
                {
                    name: "IPInfo.emoji_flag",
                    data: "emoji_flag",
                    title: "Emoji&nbsp;Flag",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 17
                },
                {
                    name: "CustomerInfo_tenant.tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:12
                },
                {
                    name: "Customer.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 13
                },
                {
                    name: "Customer.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 14
                },
                {
                    name: "Customer.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 15
                },
                {
                    name: "Customer.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 16
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
            let scope = angular.element(document.getElementById('CustomerSurfingControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('CustomerSurfingControllerScope')).scope();
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


    this.LoadCustomerDropdown = function CustomerDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/CustomerSurfing/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadAllCustomerSurfingByTenantIdAsync = function GetAllCustomerSurfingByTenantIdAsync(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/CustomerSurfing/GetAllCustomerSurfingByTenantIdAsync?Id=" + tenantId
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

