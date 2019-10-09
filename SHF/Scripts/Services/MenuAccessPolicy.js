angular.module(config.app).service('MenuAccessPolicyCRUD', function () {


    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('MenuAccessControllerScope')).scope();
        let tenantId = scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID == null ? 0 : scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID;
        let aspNetRoleId = scope.AspNetRoleSubMenuCreateOrEditViewModel.AspNetRole_ID;
        let viewBagTenantID = $('#ViewBag_TenantID').val();
        let antiForgeryToken = $('#antiForgeryToken').val();
        let src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/MenuAccessPolicy/IndexAsync',
                type: 'POST',
                dataSrc: 'data',
                data: { 'tenantId': tenantId, 'aspNetRoleId': aspNetRoleId },
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
                    name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.DisplayName",
                    data: "AspNetRoleDisplayName",
                    title: "Role&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "15%",
                    targets: 2
                },
                {
                    name: "aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Name",
                    data: "SubMenuName",
                    title: "Menu&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "15%",
                    targets: 3
                },
                {
                    name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.HasAccess",
                    data: "HasAccess",
                    title: "Has&nbsp;Access",
                    searchable: false,
                    render: function (data, type, row, meta) {
                        let lblHasAccess = "No";
                        if (data) lblHasAccess = "Yes";
                        let chkHasAccess = "";
                        if (data) chkHasAccess = "checked";
                        return '<label><input type="checkbox" value="' + data + '" class="chk-access" ' + chkHasAccess + '>&nbsp;' + lblHasAccess + '</label>';
                    },
                    width: "10%",
                    targets: 4
                },
                {
                    name: "tenant.Name",
                    data: "TenantName",
                    title: "Tenant&nbsp;Name",
                    render: $.fn.dataTable.render.text(),
                    width: "25%",
                    visible: viewBagTenantID <= 0 ? true : false,
                    targets: 5
                },
                //{ name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedBy", data: "CreatedBy", title: "Created&nbsp;By", render: $.fn.dataTable.render.text(), width: "6%", targets: 6 },
                //{
                //    name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedOn", data: "CreatedOn", title: "Created&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        let date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                //    },
                //    width: "10%",
                //    targets: 7
                //},
                //{ name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedBy", data: "UpdatedBy", title: "Modified&nbsp;By", render: $.fn.dataTable.render.text(), width: "6%", targets: 8 },
                //{
                //    name: "aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedOn", data: "UpdatedOn", title: "Modified&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        let date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                //    },
                //    width: "10%",
                //    targets: 9
                //},


            ],
            language: {
                decimal: ",",
                thousands: "."
            }
        });


        $('#grdTable tbody').off('click');
        $('#grdTable tbody').on('click', '.chk-access', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('MenuAccessControllerScope')).scope();
            scope.EditAsync(rowData.ID, rowData.HasAccess);
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

    this.HideTable = function ClearObject() {
        $('#grdTable_wrapper').hide();
    }






});

