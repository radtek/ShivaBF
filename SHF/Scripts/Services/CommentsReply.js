﻿//let app = angular.module('InventoryApp');

angular.module(config.app).service('CommentsReplyCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('CommentsReplyControllerScope')).scope();
        let tenantId = scope.CommentsReplyCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.CommentsReplyCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/CommentsReply/IndexAsync',
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
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },

                {
                    name: "BlogMaster.BlogTitle",
                    data: "BlogTitle",
                    title: "BlogTitle",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.BlogCommentsDetails.Comment",
                    data: "BlogComment",
                    title: "BlogComment",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
              {
                  name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Name",
                  data: "Name",
                  title: "Name",
                  render: $.fn.dataTable.render.text(),
                  width: "25%",
                  targets: 4
              },
{
    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.EmailId",
    data: "EmailId",
    title: "EmailId",
    render: $.fn.dataTable.render.text(),
    width: "25%",
    targets: 5
},
{
    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Comment",
    data: "Comment",
    title: "Comment",
    render: $.fn.dataTable.render.text(),
    width: "25%",
    targets: 5
},
                {
                    name: "Blog.BlogTitle",
                    data: "BlogTitle",
                    title: "BlogTitle",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },

                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 26
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 27
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 28
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 29
                },

                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.TotalViews",
                    data: "TotalViews",
                    title: "TotalViews",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 30
                },
              {
                  name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.IsActive",
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
                    targets: 32
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 33
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedOn",
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
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 35
                },
                {
                    name: "CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedOn",
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
            let scope = angular.element(document.getElementById('CommentsReplyControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('CommentsReplyControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
 $('#grdTable tbody').on('click', '.btn-preview', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('CommentsReplyControllerScope')).scope();
            scope.Preview('blog-details.html?u=' + rowData.ServiceUrl + '#divComment');
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
            url: "/Get/CommentsReply/DropdownListbyTenantAsync?Id=" + tenantId
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

