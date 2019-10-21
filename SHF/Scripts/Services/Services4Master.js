//let app = angular.module('InventoryApp');

angular.module(config.app).service('Services4MasterCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('Services4MasterControllerScope')).scope();
        let tenantId = scope.Services4MasterCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.Services4MasterCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/ServiceType4/IndexAsync',
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
                    name: "Services4Master_tenant.Services4Master.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "Services4Master_tenant.Services4Master.BannerImagePath",
                    data: "BannerImagePath",
                    title: "BannerImagePath",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                {
                    name: "Services4Master_tenant.Services4Master.BannerOnHeading",
                    data: "BannerOnHeading",
                    title: "BannerOnHeading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
                {
                    name: "SubSubCategoriesMaster.SubSubCategoryName",
                    data: "SubSubCategoryName",
                    title: "SubSubCategoryName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                {
                    name: "Services4Master_tenant.Services4Master.BannerHeadingDescription",
                    data: "BannerHeadingDescription",
                    title: "BannerHeadingDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
              
               {
                    name: "Services4Master_tenant.Services4Master.Section1Description",
                    data: "Section1Description",
                    title: "Section1Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
               
                {
                    name: "Services4Master_tenant.Services4Master.Section2PriceingHeading",
                    data: "Section2PriceingHeading",
                    title: "Section2PriceingHeading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
                {
                    name: "Services4Master_tenant.Services4Master.Section2PriceingDescription",
                    data: "Section2PriceingDescription",
                    title: "Section2PriceingDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
                 {
                     name: "Services4Master_tenant.Services4Master.Section3PriceingHeading",
                     data: "Section3PriceingHeading",
                     title: "Section3PriceingHeading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
                 {
                     name: "Services4Master_tenant.Services4Master.Section3PriceingDescription",
                     data: "Section3PriceingDescription",
                     title: "Section3PriceingDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
 
                   {
                       name: "Services4Master_tenant.Services4Master.Section4PriceingHeading",
                       data: "Section4PriceingHeading",
                       title: "Section4PriceingHeading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                }, 
                {
                    name: "Services4Master_tenant.Services4Master.Section4PriceingDescription",
                    data: "Section4PriceingDescription",
                    title: "Section4PriceingDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
                 {
                     name: "Services4Master_tenant.Services4Master.Section5PriceingHeading",
                     data: "Section5PriceingHeading",
                     title: "Section5PriceingHeading",
                     render: $.fn.dataTable.render.text(),
                     width: "25%",
                     targets: 10
                 },
                  {
                      name: "Services4Master_tenant.Services4Master.Section6PriceingHeading",
                      data: "Section6PriceingHeading",
                      title: "Section6PriceingHeading",
                      render: $.fn.dataTable.render.text(),
                      width: "25%",
                      targets: 10
                  },
                   {
                       name: "Services4Master_tenant.Services4Master.Section7PriceingHeading",
                       data: "Section7PriceingHeading",
                       title: "Section7PriceingHeading",
                       render: $.fn.dataTable.render.text(),
                       width: "25%",
                       targets: 10
                   },
               
                 {
                    name: "Services4Master_tenant.Services4Master.DisplayIndex",
                    data: "DisplayIndex",
                    title: "Display&nbsp;Index",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 11
                },
                {
                    name: "Services4Master_tenant.Services4Master.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 12
                },
                {
                    name: "Services4Master_tenant.Services4Master.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 13
                },
                {
                    name: "Services4Master_tenant.Services4Master.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 14
                },
                {
                    name: "Services4Master_tenant.Services4Master.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 15
                },

                {
                    name: "Services4Master_tenant.Services4Master.TotalViews",
                    data: "TotalViews",
                    title: "TotalViews",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 16
                },
              {
                    name: "Services4Master_tenant.Services4Master.IsActive",
                    data: "IsActive",
                    title: "Is&nbsp;Active",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 17
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:18
                },
                {
                    name: "Services4Master_tenant.Services4Master.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 19
                },
                {
                    name: "Services4Master_tenant.Services4Master.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 20
                },
                {
                    name: "Services4Master_tenant.Services4Master.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 21
                },
                {
                    name: "Services4Master_tenant.Services4Master.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 22
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
                    targets: 37
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
                    targets: 38
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
            let scope = angular.element(document.getElementById('Services4MasterControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services4MasterControllerScope')).scope();
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

 this.LoadSubSubCategoriesDropdown = function SubSubCategoriesDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/Services4Master/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
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

