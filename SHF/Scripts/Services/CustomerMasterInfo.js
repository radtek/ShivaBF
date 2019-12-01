//let app = angular.module('InventoryApp');

angular.module(config.app).service('CustomerMasterInfoCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('CustomerMasterInfoControllerScope')).scope();
        let tenantId = scope.CustomerMasterInfoCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.CustomerMasterInfoCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/CustomerInfo/IndexAsync',
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
                    name: "Customer.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
               {
                    name: "Customer.FirstName",
                    data: "FirstName",
                    title: "FirstName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
                {
                    name: "Customer.LastName",
                    data: "LastName",
                    title: "LastName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                  {
                   name: "Customer.DOB",
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
                   name: "Customer.EmailID",
                    data: "EmailID",
                    title: "EmailID",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 6
                },
               {
                   name: "Customer.FullStreetAddress",
                    data: "FullStreetAddress",
                   title: "Full&nbsp;Street&nbsp;Address",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 7
                },
               {
                   name: "CustomerInfo_tenant.CustomerInfo.InfoDateOfLastLogon",
                   data: "InfoDateOfLastLogon",
                   title: "Date&nbsp;Of&nbsp;Last&nbsp;Logon",
                   render: function (data, type, row, meta) {
                       let date = new Date(parseInt(data.replace('/Date(', '')));
                       return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                   },
                    width: "40%",
                    targets: 8
                },
               {
                   name: "CustomerInfo_tenant.CustomerInfo.InfoNumberOfLogons",
                   data: "InfoNumberOfLogons",
                   title: "Number&nbsp;Of&nbsp;Logons",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 9
                },
                {
                    name: "CustomerInfo_tenant.CustomerInfo.InfoDateAccountCreated",
                    data: "InfoDateAccountCreated",
                    title: "Date&nbsp;Account&nbsp;Created",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "40%",
                    targets: 10
                },
                {
                    name: "CustomerInfo_tenant.CustomerInfo.InfoDateAccountLastModified",
                    data: "InfoDateAccountLastModified",
                    title: "Date&nbsp;Account&nbsp;Last&nbsp;Modified",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                    },
                    width: "40%",
                    targets: 11
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
            let scope = angular.element(document.getElementById('CustomerMasterInfoControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('CustomerMasterInfoControllerScope')).scope();
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
            url: "/Get/CustomerMasterInfo/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadAllCustomerMasterInfoByTenantIdAsync = function GetAllCustomerMasterInfoByTenantIdAsync(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/CustomerMasterInfo/GetAllCustomerMasterInfoByTenantIdAsync?Id=" + tenantId
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

