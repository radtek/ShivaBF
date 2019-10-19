//let app = angular.module('InventoryApp');

angular.module(config.app).service('Services1Section6PriceMasterCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('Services1Section6PriceMasterControllerScope')).scope();
        let tenantId = scope.Services1Section6PriceMasterCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.Services1Section6PriceMasterCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Services1Section6Price/IndexAsync',
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
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.HeadingText",
                    data: "HeadingText",
                    title: "Heading&nbsp;Text",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                 {
                     name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.Price",
                     data: "Price",
                     title: "Price",
                     render: $.fn.dataTable.render.text(),
                     width: "25%",
                     targets: 3
                 },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.AncharTagTitle",
                    data: "AncharTagTitle",
                    title: "Anchar&nbsp;Tag&nbsp;Title",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                 {
                     name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.AncharTagUrl",
                     data: "AncharTagUrl",
                     title: "Anchar&nbsp;Tag&nbsp;Url",
                     render: $.fn.dataTable.render.text(),
                     width: "25%",
                     targets: 5
                 },
                  {
                      name: "Services1Section6PriceMaster.SubSubCategoryName",
                      data: "SubSubCategoryName",
                      title: "Sub&nbsp;Sub&nbsp;CategoryName",
                      render: $.fn.dataTable.render.text(),
                      width: "25%",
                      targets: 6
                  },
                  {
                   name: "StateMaster.StateFullName",
                   data: "StateFullName",
                   title: "State&nbsp;Name",
                   render: $.fn.dataTable.render.text(),
                   width: "25%",
                   targets: 7
                 },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.DisplayIndex",
                    data: "DisplayIndex",
                    title: "Display&nbsp;Index",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
 {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                },
 {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
{
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 11
                },
{
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 12
                },

{
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.TotalViews",
                    data: "TotalViews",
                    title: "TotalViews",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 13
                },
              {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.IsActive",
                    data: "IsActive",
                    title: "Is&nbsp;Active",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 14
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:15
                },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 16
                },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 17
                },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 18
                },
                {
                    name: "Services1Section6PriceMaster_tenant_Services1Master.Services1Section6PriceMaster_tenant.Services1Section6PriceMaster.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 19
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
                    targets:20
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
                    targets: 21
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
            let scope = angular.element(document.getElementById('Services1Section6PriceMasterControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services1Section6PriceMasterControllerScope')).scope();
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


    this.LoadSection6IDByTenantAndSubSubCatID = function Section6IDByTenantAndSubSubCatID(tenantId,subsubcat_id) {
        let request = $http({
            method: "get",
            url: "/Services1Section6PriceMaster/DropdownListbyTenantAsync?Id=" + tenantId+"&subsubcat_id"+subsubcat_id
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

