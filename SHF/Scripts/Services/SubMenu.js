//var app = angular.module('SHFApp');

angular.module(config.app).service('SubMenuCRUD', function ($http) {

    this.GetTableObject = function TableData() {
        var antiForgeryToken = $('#antiForgeryToken').val();  
        var src = '../../../Content/Images/';
        var oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Navigation/IndexAsync',
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
            processing: false,
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
                { name: "ID", data: "ID", title: "ID", render: $.fn.dataTable.render.text(), width: "3%", targets: 1 },
                { name: "Name", data: "Name", title: "Name", render: $.fn.dataTable.render.text(), width: "10%", targets: 2 },
                { name: "Url", data: "Url", title: "Url", render: $.fn.dataTable.render.text(), width: "20%", targets: 3 },
                {
                    name: "IconClass", data: "IconClass", title: "Icon", render: function (data, type, row, meta) {
                        return '<i title="Edit" class=' + data + '></i>&nbsp;&nbsp;&nbsp;' + data + '';
                    },
                    width: "10%",
                    targets: 4
                },
                { name: "OrderBy", data: "OrderBy", title: "Order", render: $.fn.dataTable.render.text(), width: "4%", targets: 5 },
                { name: "ParrentMenu_ID", data: "ParrentMenu_ID", title: "Parrent&nbsp;ID", render: $.fn.dataTable.render.text(), width: "4%", targets: 6 },
                //{ name: "CreatedBy", data: "CreatedBy", title: "Created&nbsp;By", render: $.fn.dataTable.render.text(), width: "6%", targets: 7 },
                //{
                //    name: "CreatedOn", data: "CreatedOn", title: "Created&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        var date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                //    },
                //    width: "10%",
                //    targets: 8
                //},
                //{ name: "UpdatedBy", data: "UpdatedBy", title: "Modified&nbsp;By", render: $.fn.dataTable.render.text(), width: "6%", targets: 9 },
                //{
                //    name: "UpdatedOn", data: "UpdatedOn", title: "Modified&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        var date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                //    },
                //    width: "10%",
                //    targets: 10
                //},
                {
                    name: null,
                    data: "ID",
                    title: "Edit",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-success btn-edit"><i title="Edit" class="fa fa-edit"></i></button>';
                    },
                    width: "2%",
                    targets: 11
                },
                {
                    name: null,
                    data: "ID",
                    title: "Delete",
                    orderable: false,
                    render: function (data, type, row, meta) {
                        return '<button type="button" class="btn btn-xs text-danger btn-delete"><i title="Delete" class="fa fa-trash"></i></button>';
                    },
                    width: "2%",
                    targets: 12
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
            var scope = angular.element(document.getElementById('SubMenuControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            var rowData = oTable.row($(this).parents('tr')).data();
            var scope = angular.element(document.getElementById('SubMenuControllerScope')).scope();
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



    this.LoadParrentMenuDropdown = function ParrentMenuDropdown() {

        var request = $http({
            method: "get",
            url: "/Get/Navigation/ParrentDropdownListAsync"
        });
        return request;
    }


});

