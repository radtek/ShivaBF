//var app = angular.module('SHFApp');

angular.module(config.app).service('AspNetUserCRUD', function () {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('AspNetUserControllerScope')).scope();
        let tenantId = scope.RegisterOrEditViewModel.Tenant_ID == null ? 0 : scope.RegisterOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        var antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        var oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Users/IndexAsync',
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
                    targets: 0
                },
                {
                    name: "aspnetUser.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    targets: 1
                },
                {
                    name: "aspnetUser.UserName",
                    data: "UserName",
                    title: "User&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    targets: 2
                },
                {
                    name: "aspnetUser.FirstName",
                    data: "FirstName",
                    title: "First&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    targets: 3
                },
                {
                    name: "aspnetUser.LastName",
                    data: "LastName",
                    title: "Last&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    targets: 4
                },
                {
                    name: "aspnetUser.Email",
                    data: "Email",
                    title: "Email",
                    render: $.fn.dataTable.render.text(),
                    targets: 5
                },
                {
                    name: "aspnetUser.EmailConfirmed",
                    data: "EmailConfirmed",
                    title: "Email&nbsp;Confirmed",
                    render: function (data, type, row, meta) {
                        var text = data ? 'Yes' : 'No';
                        return text.toString();
                    },
                    targets: 6
                },
                {
                    name: "aspnetUser.PhoneNumber",
                    data: "PhoneNumber",
                    title: "Phone&nbsp;Number",
                    render: $.fn.dataTable.render.text(),
                    targets: 7
                },
                {
                    name: "aspnetUser.PhoneNumberConfirmed",
                    data: "PhoneNumberConfirmed", title: "Phone&nbsp;Number&nbsp;Confirmed",
                    render: function (data, type, row, meta) {
                        var text = data ? 'Yes' : 'No';
                        return text.toString();
                    },
                    targets: 8
                },
                {
                    name: "aspnetUser.AccessFailedCount",
                    data: "AccessFailedCount",
                    title: "Access&nbsp;Failed&nbsp;Count",
                    render: $.fn.dataTable.render.text(),
                    targets: 9
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets: 10
                },
                //{ name: "aspnetUser.CreatedBy", data: "CreatedBy", title: "Created&nbsp;By", render: $.fn.dataTable.render.text(), targets: 11 },
                //{
                //    name: "aspnetUser.CreatedOn", data: "CreatedOn", title: "Created&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        var date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                //    },

                //    targets: 12
                //},
                //{ name: "aspnetUser.UpdatedBy", data: "UpdatedBy", title: "Modified&nbsp;By", render: $.fn.dataTable.render.text(), targets: 13 },
                //{
                //    name: "aspnetUser.UpdatedOn", data: "UpdatedOn", title: "Modified&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        var date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                //    },

                //    targets: 14
                //},
                {
                    name: null,
                    data: "ID",
                    title: "&nbsp;Edit&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-edit"><i title="Edit" class="fa fa-edit"></i></button>';
                    },

                    targets: 15
                },
                {
                    name: null,
                    data: "UserName",
                    title: "Login",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-info"><a href="/Settings/Security/Account/LoginAsync?emaNresu=' + data + '&returnUrl=/" ><i title="Login" class="fa fa-sign-in"></i></a></button>';
                    },
                    visible: viewBagTenantID <= 0 ? true : false,
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
            var rowData = oTable.row($(this).parents('tr')).data();
            var scope = angular.element(document.getElementById('AspNetUserControllerScope')).scope();
            scope.EditAsync(rowData.ID, rowData.Tenant_ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            var rowData = oTable.row($(this).parents('tr')).data();
            var scope = angular.element(document.getElementById('AspNetUserControllerScope')).scope();
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






});

