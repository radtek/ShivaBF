
angular.module(config.app).service('MessageCRUD', function ($http) {
    this.GetTableObject = function TableData() {
        let scope = angular.element(document.getElementById('MessageControllerScope')).scope();
        let antiForgeryToken = $('#antiForgeryToken').val();
        var src = '../../../Content/Images/';
        let oTable = $('#grdTable').DataTable({
            serverSide: true,
            ajax: {
                url: '/Post/Message/IndexAsync',
                type: 'POST',
                dataSrc: 'data',
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
                        return '<text>' + parseInt(parseInt(meta.row) + 1) + '</text>';
                    },
                    searchable: false,
                    orderable: false,
                    width: "3%",
                    targets: 0
                },
                {
                    name: "ID",
                    data: "ID",
                    title: "ID",
                    render: $.fn.dataTable.render.text(),
                    width: "3%",
                    targets: 1
                },
                {
                    name: "Description",
                    data: "Description",
                    title: "Description",
                    render: $.fn.dataTable.render.text(),
                    width: "10%",
                    targets: 2
                },
                {
                    name: "Title",
                    data: "Title",
                    title: "Title",
                    render: $.fn.dataTable.render.text(),
                    width: "6%",
                    targets: 3
                },
                {
                    name: "Type",
                    data: "Type",
                    title: "Type",
                    render: $.fn.dataTable.render.text(),
                    width: "10%",
                    targets: 4
                },
                {
                    name: "Icon",
                    data: "Icon",
                    title: "Icon",
                    render: $.fn.dataTable.render.text(),
                    width: "10%",
                    targets: 5
                },
                //{
                //    name: "CreatedBy",
                //    data: "CreatedBy",
                //    title: "Created&nbsp;By",
                //    render: $.fn.dataTable.render.text(),
                //    width: "6%",
                //    targets: 6
                //},
                //{
                //    name: "CreatedOn", data: "CreatedOn", title: "Created&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        let date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');

                //    },
                //    width: "11%",
                //    targets: 7
                //},
                //{
                //    name: "UpdatedBy",
                //    data: "UpdatedBy",
                //    title: "Modified&nbsp;By",
                //    render: $.fn.dataTable.render.text(),
                //    width: "6%",
                //    targets: 8
                //},
                //{
                //    name: "UpdatedOn", data: "UpdatedOn", title: "Modified&nbsp;On",
                //    render: function (data, type, row, meta) {
                //        let date = new Date(parseInt(data.replace('/Date(', '')));
                //        return moment(date).format('DD-MM-YYYY hh:mm:ss a');
                //    },
                //    width: "11%",
                //    targets: 9
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
                    targets: 10
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
                    targets: 11
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
            let scope = angular.element(document.getElementById('MessageControllerScope')).scope();
            scope.EditAsync(rowData.ID);
        });

        $('#grdTable tbody').on('click', '.btn-delete', function () {
            let rowData = oTable.row($(this).parents('tr')).data();
            let scope = angular.element(document.getElementById('MessageControllerScope')).scope();
            scope.DeleteAsync(rowData.ID);
        });
    }

    this.LoadTable = function GetObject() {
        if ($.fn.dataTable.isDataTable('#grdTable')) {
            let table = $('#grdTable').DataTable();
            table.ajax.reload();
        }
        else {
            this.GetTableObject();
        }
    }



});

