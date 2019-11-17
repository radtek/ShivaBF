//let app = angular.module('InventoryApp');

angular.module(config.app).service('Services4Section678FieldValuesCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('Services4Section678FieldValuesControllerScope')).scope();
        let tenantId = scope.Services4Section678FieldValuesCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.Services4Section678FieldValuesCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Services4Section678FieldValues/IndexAsync',
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
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.S4S678FM_Id",
                    data: "S4S678FM_Id",
                    title: "S4S678FM_Id",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                 {
                     name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.RowNumber",
                     data: "RowNumber",
                     title: "RowNumber",
                     render: $.fn.dataTable.render.text(),
                     width: "25%",
                     targets: 3
                 },
                 
                 {
                     name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayText",
                     data: "DisplayText",
                     title: "DisplayText",
                     render: $.fn.dataTable.render.text(),
                     width: "25%",
                     targets: 4
                 },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.DownloadFilePath",
                    data: "DownloadFilePath",
                    title: "DownloadFilePath",
                     render: $.fn.dataTable.render.text(),
                     width: "25%",
                     targets: 4
                 },
                 {
                   name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.DownloadFilePath",
                    data: "DownloadFilePath",
                    title: "Image Preview",
                   render: function (data, type, row, meta) {
                        return '<img src="'+data+'" style="height:150px;width:200px;"/>';
                    },
                    width: "40%",
                    targets: 4
                },
                  {
                    name: "Services4Section678FieldValues.SubSubCategoryName",
                    data: "SubSubCategoryName",
                    title: "Sub&nbsp;Sub&nbsp;CategoryName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayIndex",
                    data: "DisplayIndex",
                    title: "Display&nbsp;Index",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
 {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
 {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
{
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                },
{
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },

{
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.TotalViews",
                    data: "TotalViews",
                    title: "TotalViews",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 11
                },
              {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.IsActive",
                    data: "IsActive",
                    title: "Is&nbsp;Active",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 12
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:13
                },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 14
                },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 15
                },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 16
                },
                {
                    name: "Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 17
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
                    targets: 18
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
                    targets: 19
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
            let scope = angular.element(document.getElementById('Services4Section678FieldValuesControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services4Section678FieldValuesControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
$('#grdTable tbody').on('click', '.btn-preview', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services4Section678FieldValuesControllerScope')).scope();
            scope.Preview('services4.html?u='+rowData.ServiceUrl+'#tblSection5');
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


    this.LoadProductDropdown = function ProductDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/Product/DropdownListbyTenantAsync?Id=" + tenantId
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

