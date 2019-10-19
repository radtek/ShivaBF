//let app = angular.module('InventoryApp');

angular.module(config.app).service('Services1MasterCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('Services1MasterControllerScope')).scope();
        let tenantId = scope.Services1MasterCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.Services1MasterCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/ServiceType1/IndexAsync',
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
                    name: "Services1Master_tenant.Services1Master.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "Services1Master_tenant.Services1Master.BannerImagePath",
                    data: "BannerImagePath",
                    title: "BannerImagePath",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                {
                    name: "Services1Master_tenant.Services1Master.BannerOnHeading",
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
                    name: "Services1Master_tenant.Services1Master.BannerHeadingDescription",
                    data: "BannerHeadingDescription",
                    title: "BannerHeadingDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
                {
                    name: "Services1Master_tenant.Services1Master.BannerAncharTagTitle",
                    data: "BannerAncharTagTitle",
                    title: "BannerAncharTagTitle",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
                {
                    name: "Services1Master_tenant.Services1Master.BannerAncharTagUrl",
                    data: "BannerAncharTagUrl",
                    title: "BannerAncharTagUrl",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section1AfterBannerHeading",
                    data: "Section1AfterBannerHeading",
                    title: "Section1AfterBannerHeading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section1AfterBannerDescription",
                    data: "Section1AfterBannerDescription",
                    title: "Section1AfterBannerDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
                   {
                    name: "Services1Master_tenant.Services1Master.Section1AfterBannerImagePath",
                    data: "Section1AfterBannerImagePath",
                    title: "Section1AfterBannerImagePath",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                }, 
                {
                    name: "Services1Master_tenant.Services1Master.Section1AfterBannerImageOnDescription",
                    data: "Section1AfterBannerImageOnDescription",
                    title: "Section1AfterBannerImageOnDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section2Heading",
                    data: "Section2Heading",
                    title: "Section2Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 11
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section2Description",
                    data: "Section2Description",
                    title: "Section2Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 12
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section3Heading",
                    data: "Section3Heading",
                    title: "Section3Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 13
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section3Description",
                    data: "Section3Description",
                    title: "Section3Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 14
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section3TextboxMaskedText",
                    data: "Section3TextboxMaskedText",
                    title: "Section3TextboxMaskedText",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 15
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section4Heading",
                    data: "Section4Heading",
                    title: "Section4Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 16
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section5Heading",
                    data: "Section5Heading",
                    title: "Section5Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 17
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section6Heading",
                    data: "Section6Heading",
                    title: "Section6Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 18
                },
                    {
                    name: "Services1Master_tenant.Services1Master.Section6Description",
                    data: "Section6Description",
                    title: "Section6Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 19
                },
                    {
                    name: "Services1Master_tenant.Services1Master.Section7Description",
                    data: "Section7Description",
                    title: "Section7Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 20
                },
                  {
                    name: "Services1Master_tenant.Services1Master.Section8Description",
                    data: "Section8Description",
                    title: "Section8Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 21
                },
                  {
                    name: "Services1Master_tenant.Services1Master.Section96Heading",
                    data: "Section96Heading",
                    title: "Section96Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 22
                },
                 {
                    name: "Services1Master_tenant.Services1Master.Section9Description",
                    data: "Section9Description",
                    title: "Section9Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 23
                },
                {
                    name: "Services1Master_tenant.Services1Master.Section10MappingBankFlag",
                    data: "Section10MappingBankFlag",
                    title: "Section10MappingBankFlag",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 24
                },
                 {
                    name: "Services1Master_tenant.Services1Master.DisplayIndex",
                    data: "DisplayIndex",
                    title: "Display&nbsp;Index",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 25
                },
                {
                    name: "Services1Master_tenant.Services1Master.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 26
                },
                {
                    name: "Services1Master_tenant.Services1Master.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 27
                },
                {
                    name: "Services1Master_tenant.Services1Master.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 28
                },
                {
                    name: "Services1Master_tenant.Services1Master.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 29
                },

                {
                    name: "Services1Master_tenant.Services1Master.TotalViews",
                    data: "TotalViews",
                    title: "TotalViews",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 30
                },
              {
                    name: "Services1Master_tenant.Services1Master.IsActive",
                    data: "IsActive",
                    title: "Is&nbsp;Active",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 31
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:32
                },
                {
                    name: "Services1Master_tenant.Services1Master.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 33
                },
                {
                    name: "Services1Master_tenant.Services1Master.CreatedOn",
                    data: "CreatedOn",
                    title: "Created&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "11%",
                    targets: 34
                },
                {
                    name: "Services1Master_tenant.Services1Master.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 35
                },
                {
                    name: "Services1Master_tenant.Services1Master.UpdatedOn",
                    data: "UpdatedOn",
                    title: "Modified&nbsp;On",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "11%",
                    targets: 36
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
            let scope = angular.element(document.getElementById('Services1MasterControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services1MasterControllerScope')).scope();
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
            url: "/Get/Services1Master/DropdownListbyTenantAsync?Id=" + tenantId
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

