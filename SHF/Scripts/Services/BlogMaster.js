//let app = angular.module('InventoryApp');

angular.module(config.app).service('BlogMasterCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('BlogMasterControllerScope')).scope();
        let tenantId = scope.BlogMasterCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.BlogMasterCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/BlogMaster/IndexAsync',
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
                    name: "BlogMaster.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "BlogMaster.BannerImagePath",
                    data: "BannerImagePath",
                    title: "BannerImagePath",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                {
                    name: "BlogMaster.BannerImagePath",
                    data: "BannerImagePath",
                    title: "Image Preview",
                   render: function (data, type, row, meta) {
                        return '<img src="'+data+'" style="height:150px;width:200px;"/>';
                    },
                    width: "40%",
                    targets: 2
                },
                {
                    name: "BlogMaster.BannerDescription1",
                    data: "BannerDescription1",
                    title: "BannerDescription1",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
               
                {
                    name: "BlogMaster.BannerDescription2",
                    data: "BannerDescription2",
                    title: "BannerDescription2",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
                {
                    name: "BlogMaster.BlogTitle",
                    data: "BlogTitle",
                    title: "BlogTitle",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
                {
                    name: "BlogMaster.Section1ImagePath",
                    data: "Section1ImagePath",
                    title: "Section1ImagePath",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
 {
                    name: "BlogMaster.Section1ImagePath",
                    data: "Section1ImagePath",
                    title: "Image Preview",
                   render: function (data, type, row, meta) {
                        return '<img src="'+data+'" style="height:150px;width:200px;"/>';
                    },
                    width: "40%",
                    targets: 6
                },
                {
                    name: "BlogMaster.Section2Heading",
                    data: "Section2Heading",
                    title: "Section2Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
                {
                    name: "BlogMaster.Section2Description",
                    data: "Section2Description",
                    title: "Section2Description",
 render: function (data, type, row, meta) {
                       return $("<span/>").html(data).text(); 
                    },
                    //render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },
                   {
                       name: "BlogMaster.Section3Heading",
                       data: "Section3Heading",
                       title: "Section3Heading",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 9
                }, 
                {
                    name: "BlogMaster.Section3Description",
                    data: "Section3Description",
                    title: "Section3Description",
 render: function (data, type, row, meta) {
                       return $("<span/>").html(data).text(); 
                    },
                   // render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
               
                {
                    name: "BlogMaster.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 26
                },
                {
                    name: "BlogMaster.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 27
                },
                {
                    name: "BlogMaster.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 28
                },
                {
                    name: "BlogMaster.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 29
                },

                {
                    name: "BlogMaster.TotalViews",
                    data: "TotalViews",
                    title: "TotalViews",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 30
                },
              {
                    name: "BlogMaster.IsActive",
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
                    name: "BlogMaster.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 33
                },
                {
                    name: "BlogMaster.CreatedOn",
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
                    name: "BlogMaster.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 35
                },
                {
                    name: "BlogMaster.UpdatedOn",
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
            let scope = angular.element(document.getElementById('BlogMasterControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('BlogMasterControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
       $('#grdTable tbody').on('click', '.btn-preview', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('BlogMasterControllerScope')).scope();
            scope.Preview('blog-details.html?u='+rowData.Url);
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

    this.LoadBlogTitleDropdown = function BlogTitleDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/BlogMaster/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }
this.GetBlogsUrl = function blogsUrl(Id) {
        let request = $http({
            method: "get",
            url: "/Get/BlogMaster/GetBlogsUrl?Id=" + Id
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

