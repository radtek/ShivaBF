﻿//let app = angular.module('InventoryApp');

angular.module(config.app).service('FooterLinksCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('FooterLinksControllerScope')).scope();
        let tenantId = scope.FooterLinksCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.FooterLinksCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/FooterLinks/IndexAsync',
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
                    name: "FooterLinks_tenant.FooterLinks.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "FooterBlockMaster.Heading",
                    data: "Heading",
                    title: "Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
 {
                    name: "FooterLinks_tenant.FooterLinks.AncharTagTitle",
                    data: "AncharTagTitle",
                    title: "AncharTagTitle",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
 {
                    name: "FooterLinks_tenant.FooterLinks.AncharTagUrl",
                    data: "AncharTagUrl",
                    title: "AncharTagUrl",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },

 {
     name: "FooterLinks_tenant.FooterLinks.Url",
     data: "Url",
     title: "Url",
     render: $.fn.dataTable.render.text(),
     width: "25%",
     targets: 5
 },
 {
     name: "FooterLinks_tenant.FooterLinks.Metadata",
     data: "Metadata",
     title: "Metadata",
     render: $.fn.dataTable.render.text(),
     width: "25%",
     targets: 6
 },
{
    name: "FooterLinks_tenant.FooterLinks.MetaDescription",
    data: "MetaDescription",
    title: "MetaDescription",
    render: $.fn.dataTable.render.text(),
    width: "25%",
    targets: 7
},
{
    name: "FooterLinks_tenant.FooterLinks.Keyword",
    data: "Keyword",
    title: "Keyword",
    render: $.fn.dataTable.render.text(),
    width: "25%",
    targets: 8
},

{
    name: "FooterLinks_tenant.FooterLinks.TotalViews",
    data: "TotalViews",
    title: "TotalViews",
    render: $.fn.dataTable.render.text(),
    width: "25%",
    targets: 9
},
              {
                  name: "FooterLinks_tenant.FooterLinks.IsActive",
                  data: "IsActive",
                  title: "IsActive",
                  render: $.fn.dataTable.render.text(),
                  width: "25%",
                  targets: 10
              },
                {
                    name: "FooterLinks_tenant.FooterLinks.Tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets: 11
                },
                {
                    name: "FooterLinks_tenant.FooterLinks.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 12
                },
                {
                    name: "FooterLinks_tenant.FooterLinks.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 13
                },
                {
                    name: "FooterLinks_tenant.FooterLinks.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 14
                },
                {
                    name: "FooterLinks_tenant.FooterLinks.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 15
                },
{
                    name: null,
                    data: "Preview",
                    title: "&nbsp;Preview&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-preview"><i title="Preview" class="fa fa-eye"></i></button>';
                    },
                    width: "2%",
                    targets: 37
                },
                {
                    name: null,
                    data: "ID",
                    title: "&nbsp;Edit&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-edit"><i title="Edit" class="fa fa-edit"></i></button>';
                    },
                    width: "2%",
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
                    targets: 17
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
            let scope = angular.element(document.getElementById('FooterLinksControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('FooterLinksControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
$('#grdTable tbody').on('click', '.btn-preview', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('FooterLinksControllerScope')).scope();
            scope.Preview('index.html#divFooterLinks');
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


    this.LoadBankDropdown = function BankDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/FooterLinks/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadPurchaseProductDropdown = function PurchaseProductDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/Product/PurchaseDropdownListbyTenantAsync?Id=" + tenantId
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

