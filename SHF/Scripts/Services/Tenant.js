//var app = angular.module('SHFApp');

angular.module(config.app).service('TenantCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        var antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        var oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Tenant/IndexAsync',
                type: 'POST',
                dataSrc: 'data',
                headers: {
                    'RequestVerificationToken': antiForgeryToken
                }
            },

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
                        return '<text>' + parseInt(parseInt(meta.row) + 1) + '</text>';
                    },
                    searchable: false,
                    orderable: false,
                    targets: 0
                },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ID", data: "ID", title: "ID", render: $.fn.dataTable.render.text(), targets: 1 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Name", data: "Name", title: "Name", render: $.fn.dataTable.render.text(), targets: 2 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.BillingAddress", data: "BillingAddress", title: "Billing&nbsp;Address", render: $.fn.dataTable.render.text(), orderable: false, targets: 3 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ShippingAddress", data: "ShippingAddress", title: "Shipping&nbsp;Address", render: $.fn.dataTable.render.text(), orderable: false, targets: 4 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactPerson", data: "ContactPerson", title: "Contact&nbsp;Person", render: $.fn.dataTable.render.text(), targets: 5 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.ContactNumber", data: "ContactNumber", title: "Contact&nbsp;Number", render: $.fn.dataTable.render.text(), targets: 6},
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.Email", data: "Email", title: "Email", targets: 7 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.GST", data: "GST", title: "GST", targets: 8 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfLocations", data: "NoOfLocations", title: "No.Of&nbsp;Locations", render: $.fn.dataTable.render.text(), targets: 9 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.NoOfSHFItems", data: "NoOfSHFItems", title: "No.Of&nbsp;SHF&nbsp;Items", render: $.fn.dataTable.render.text(), targets: 10 },
                { name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.aspNetUser.UserName", data: "Username", title: "User&nbsp;Name", render: $.fn.dataTable.render.text(), targets: 11 },
                //{ name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedBy", data: "CreatedBy", title: "Created&nbsp;By", render: $.fn.dataTable.render.text(), targets: 12 },
                //{
                //    name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.CreatedOn", data: "CreatedOn", title: "Created&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        var date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                //    },
                //    targets: 13
                //},
                //{ name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedBy", data: "UpdatedBy", title: "Modified&nbsp;By", render: $.fn.dataTable.render.text(), targets: 14 },
                //{
                //    name: "tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict_Shipping_Country.tenant_aspNetUser_aspNetUserRole_Billing_Country_State_CityorDistrict.tenant_aspNetUser_aspNetUserRole_Billing_Country_State.tenant_aspNetUser_aspNetUserRole_Billing_Country.tenant_aspNetUser_aspNetUserRole.tenant_aspNetUser.tenant.UpdatedOn", data: "UpdatedOn", title: "Modified&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        var date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                //    },
                //    targets: 15
                //},
                {
                    name: null,
                    data: "ID",
                    title: "Edit",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-edit"><i title="Edit" class="fa fa-edit"></i></button>';
                    },
                    targets: 16
                },
                {
                    name: null,
                    data: "Username",
                    title: "Login",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-info"><a href="/Settings/Security/Account/LoginAsync?emaNresu=' + data + '&returnUrl=/" ><i title="Login" class="fa fa-sign-in"></i></a></button>';
                    },
                    targets: 17
                },
                {
                    name: null,
                    data: "ID",
                    title: "Delete",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-danger btn-delete"><i title="Delete" class="fa fa-trash"></i></button>';
                    },
                    targets: 18
                },
            ],
            language: {
                decimal: ",",
                thousands: "."
            }
        });

        $('#grdTable tbody').off('click');
        $('#grdTable tbody').on('click', '.btn-edit', function () {
            var rowData = oTable.row($(this).parents('tr')).data();
            var scope = angular.element(document.getElementById('TenantControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            var rowData = oTable.row($(this).parents('tr')).data();
            var scope = angular.element(document.getElementById('TenantControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });

    }

    this.LoadTable = function GetObject() {
        if ($.fn.dataTable.isDataTable('#grdTable')) {
            var table = $('#grdTable').DataTable();
            table.ajax.reload();
        }
        else {
            this.GetTableObject();
        }
    }



    this.LoadTenantDropdown = function TenantDropdown() {

        var request = $http({
            method: "get",
            url: "/Get/Tenant/DropdownListAsync"
        });
        return request;
    }


});

