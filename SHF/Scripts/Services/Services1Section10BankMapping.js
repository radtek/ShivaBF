//let app = angular.module('InventoryApp');
angular.module(config.app).service('Services1Section10BankMappingCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('Services1Section10BankMappingControllerScope')).scope();
        let tenantId = scope.Services1Section10BankMappingCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.Services1Section10BankMappingCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Services1Section10BankMapping/IndexAsync',
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
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
{
                    name: "SubSubCategoryMaster.SubSubCategoryName",
                    data: "SubSubCategory_Name",
                    title: "Sub&nbsp;Sub&nbsp;Category",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 2
                },
                {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.BankMaster.BankMaster_Id",
                    data: "BankMaster_Id",
                    title: "BankMaster_Id",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
{
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.BankMaster.Description",
                    data: "Description",
                    title: "Description",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },

               
 {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Url",
                    data: "Url",
                    title: "Url",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 5
                },
 {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Metadata",
                    data: "Metadata",
                    title: "Metadata",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 6
                },
{
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.MetaDescription",
                    data: "MetaDescription",
                    title: "MetaDescription",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 7
                },
{
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Keyword",
                    data: "Keyword",
                    title: "Keyword",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 8
                },

              {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.IsActive",
                    data: "IsActive",
                    title: "IsActive",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 10
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:11
                },
                {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 12
                },
                {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedOn",
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
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 14
                },
                {
                    name: "Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedOn",
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
                    name: "Services1Master.Url",
                    data: "ServiceUrl",
                    title: "ServiceUrl",
                    width: "11%",
                    targets: 17
                },
 {
                    name: "Services1Master.Url",
                    data: "ServiceUrl",
                    title: "ServiceUrl",
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
            let scope = angular.element(document.getElementById('Services1Section10BankMappingControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services1Section10BankMappingControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
 $('#grdTable tbody').on('click', '.btn-preview', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('Services1Section10BankMappingControllerScope')).scope();
            scope.Preview('Views/services1.html?u='+rowData.ServiceUrl+'#divService1Section10BankMapping');
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


});

