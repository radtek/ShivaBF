//let app = angular.module('InventoryApp');

angular.module(config.app).service('CustomerServiceOrderCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('CustomerServiceOrderControllerScope')).scope();
        let tenantId = scope.CustomerServiceOrderCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.CustomerServiceOrderCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/CustomerServiceOrder/IndexAsync',
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
                    name: "customerServiceOrder.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
               
                {
                    name: "customerServiceOrder.FirstName",
                    data: "FirstName",
                    title: "FirstName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 3
                },
                {
                    name: "customerServiceOrder.LastName",
                    data: "LastName",
                    title: "LastName",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 4
                },
                
                 {
                   name: "customerServiceOrder.EmailID",
                    data: "EmailID",
                    title: "EmailID",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 6
                },
               {
                   name: "customerServiceOrder.FullStreetAddress",
                    data: "FullStreetAddress",
                    title: "FullStreetAddress",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 7
                },
               {
                   name: "customerServiceOrder.Telephone",
                    data: "Telephone",
                    title: "Telephone",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 8
                },
               {
                   name: "customerServiceOrder.Fax",
                    data: "Fax",
                    title: "Fax",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 9
                },
                {
                    name: "customerServiceOrder.Service_Id",
                    data: "Service_Id",
                    title: "Service_Id",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10
                },
                {
                    name: "customerServiceOrder.ServiceName",
                    data: "ServiceName",
                    title: "ServiceName",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10
                },
                {
                    name: "customerServiceOrder.Plan_Id",
                    data: "Plan_Id",
                    title: "Plan_Id",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10
                },
                {
                    name: "customerServiceOrder.PlanName",
                    data: "PlanName",
                    title: "PlanName",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10
                },
                {
                    name: "customerServiceOrder.Amount",
                    data: "Amount",
                    title: "Amount",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10

                },
                {
                    name: "customerServiceOrder.PaymentMethod",
                    data: "PaymentMethod",
                    title: "PaymentMethod",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10

                },
                {
                    name: "customerServiceOrder.DatePurchased",
                    data: "DatePurchased",
                    title: "DatePurchased",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "40%",
                    targets: 10

                },
                {
                    name: "customerServiceOrder.OrdersStatus",
                    data: "OrdersStatus",
                    title: "OrdersStatus",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10

                },
                {
                    name: "customerServiceOrder.OrdersDateFinished",
                    data: "OrdersDateFinished",
                    title: "OrdersDateFinished",
                    render: function (data, type, row, meta) {
                        let date = new Date(parseInt(data.replace('/Date(', '')));
                        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                    },
                    width: "40%",
                    targets: 10

                },
                {
                    name: "customerServiceOrder.Comments",
                    data: "Comments",
                    title: "Comments",
                    render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 10

                },
                {
                   name: "customerServiceOrder.IsActive",
                    data: "IsActive",
                    title: "IsActive",
                   render: $.fn.dataTable.render.text(),
                    width: "40%",
                    targets: 11
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets:12
                },
                {
                    name: "customerServiceOrder.CreatedBy",
                    data: "CreatedBy",
                    title: "Created&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 13
                },
                {
                    name: "customerServiceOrder.CreatedOn",
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
                    name: "customerServiceOrder.UpdatedBy",
                    data: "UpdatedBy",
                    title: "Modified&nbsp;By",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 15
                },
                {
                    name: "customerServiceOrder.UpdatedOn",
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
                    title: "&nbsp;Edit&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-edit"><i title="Edit" class="fa fa-edit"></i></button>';
                    },
                    width: "2%",
                    targets: 9
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
            let scope = angular.element(document.getElementById('customerServiceOrderServiceOrderControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('customerServiceOrderServiceOrderControllerScope')).scope();
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


    this.LoadcustomerServiceOrderDropdown = function customerServiceOrderDropdown(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/customerServiceOrderServiceOrder/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.LoadAllcustomerServiceOrderServiceOrderByTenantIdAsync = function GetAllcustomerServiceOrderServiceOrderByTenantIdAsync(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/customerServiceOrderServiceOrder/GetAllcustomerServiceOrderServiceOrderByTenantIdAsync?Id=" + tenantId
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

