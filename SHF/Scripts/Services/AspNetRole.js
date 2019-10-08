//let app = angular.module('SHFApp');

angular.module(config.app).service('AspNetRoleCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('AspNetRoleControllerScope')).scope();       
        let tenantId = scope.AspNetRoleCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.AspNetRoleCreateOrEditViewModel.Tenant_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        let src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Roles/IndexAsync',
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
                    name: "aspnetRole.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "aspnetRole.DisplayName",
                    data: "DisplayName",
                    title: "Role&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    targets: 2
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets: 3
                },
                //{ name: "aspnetRole.CreatedBy", data: "CreatedBy", title: "Created&nbsp;By", render: $.fn.dataTable.render.text(), width: "6%", targets: 4 },
                //{
                //    name: "aspnetRole.CreatedOn", data: "CreatedOn", title: "Created&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        let date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                //    },
                //    width: "10%",
                //    targets: 5
                //},
                //{ name: "aspnetRole.UpdatedBy", data: "UpdatedBy", title: "Modified&nbsp;By", render: $.fn.dataTable.render.text(), width: "6%", targets: 6 },
                //{
                //    name: "aspnetRole.UpdatedOn", data: "UpdatedOn", title: "Modified&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        let date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                //    },
                //    width: "10%",
                //    targets: 7
                //},
                {
                    name: null,
                    data: "ID",
                    title: "&nbsp;Edit&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-edit"><i title="Edit" class="fa fa-edit"></i></button>';
                    },
                    width: "2%",
                    targets: 8
                },
                //{
                //    name: null,
                //    data: "ID",
                //    title: "&nbsp;Access&nbsp;&nbsp;&nbsp;",
                //    orderable: false,
                //    render: function (data, type, row, meta) {
                //        return '<button type="button" class="text-danger btn-access"><i title="Access" class="fa fa-sitemap"></i></button>';
                //    },
                //    width: "2%",
                //    targets: 9
                //},
                {
                    name: null,
                    data: "ID",
                    title: "&nbsp;Delete&nbsp;&nbsp;&nbsp;",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-danger btn-delete"><i title="Delete" class="fa fa-trash"></i></button>';
                    },
                    width: "2%",
                    targets: 9
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
            let scope = angular.element(document.getElementById('AspNetRoleControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        //$('#grdTable tbody').on('click', '.btn-access', function () {
        //    let rowData = oTable.row($(this).parents('tr')).data();
        //    let scope = angular.element(document.getElementById('AspNetRoleControllerScope')).scope();
        //    scope.AccessAsync(rowData.ID);
        //});


        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('AspNetRoleControllerScope')).scope();
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

    this.GetRolesByTenantId = function RolesByTenantId(tenantId) {
        let request = $http({
            method: "get",
            url: "/Get/Roles/DropdownListbyTenantAsync?Id=" + tenantId
        });
        return request;
    }

    this.GetRolesByUserId = function RolesByUserId(userId) {
        let request = $http({
            method: "get",
            url: "/Get/Roles/AssignedRolesOfUserAsync?Id=" + userId
        });
        return request;
    }   

});

