angular.module(config.app).controller('MessageCtrl', ['$scope', '$http', '$window', 'MessageCRUD', 'CustomService',
    function ($scope, $http, $window, MessageCRUD, CustomService) {

        $scope.AllIcon = [{ ID: 'warning', Name: 'Warning' }, { ID: 'success', Name: 'Success' }, { ID: 'error', Name: 'Error' }];

        $scope.BindGrid = function () {
            MessageCRUD.LoadTable();
        }

        $scope.PageLoad = function () {           
            //CustomService.ShowMessage(1003);
           $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
            $scope.path = "";
            $scope.errors = {};
            $scope.errors.pageError = {};
            $scope.errors.formErrors = {};
            $scope.errors.pageError = null;
            $scope.errors.formErrors = null;
            $scope.Processing = false;
        }

        $scope.EditAsync = function (Id) {
            $scope.Reset();
            $scope.MessageCreateOrEditViewModel = {};

            $http.get("/Get/Message/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {

                        case 'Exception':
                            console.log(response);
                            swal(response.data.Title, response.data.Message, response.data.Icon);
                            break;

                        case 'Response':
                            console.clear();
                            $scope.MessageCreateOrEditViewModel = response.data.Entity;
                            $('#modal-createOredit').modal('show');
                            break;

                        case 'Validation':
                            console.log(response);
                            swal(response.data.Title, response.data.Message, response.data.Icon);
                            break;

                        default:
                            console.log(response);
                            swal('Error', 'Internal server error', 'error');
                            break;
                    }
                }, function errors(response) {
                    switch (response.data.Type) {

                        case 'Exception':
                            console.log(response);
                            swal(response.data.Title, response.data.Message, response.data.Icon);
                            break;

                        case 'Validation':
                            console.log(response);
                            swal(response.data.Title, response.data.Message, response.data.Icon);
                            break;

                        default:
                            console.log(response);
                            swal('Error', 'Internal server error', 'error');
                            break;
                    }
                    console.clear();
                });
        }

        $scope.createOreditAsyncForm = function () {
            $scope.Processing = true;
            if ($scope.myForm.$valid) {
                $scope.path = ($scope.MessageCreateOrEditViewModel.ID == undefined || $scope.MessageCreateOrEditViewModel.ID == null || $scope.MessageCreateOrEditViewModel.ID == 0) ? "/Post/Message/CreateAsync" : "/Post/Message/EditAsync";
                $http.post($scope.path, $scope.MessageCreateOrEditViewModel,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                    }
                ).then(
                    function success(response) {
                        $('#modal-createOredit').modal('hide');
                        swal(response.data.Title, response.data.Message, response.data.Icon);
                        $scope.BindGrid();
                        console.clear();
                    }, function errors(response) {
                        handleErrors(response.data);
                        console.clear();
                    });

                function updateErrors(errors) {
                    $scope.errors = {};
                    $scope.errors.formErrors = {};
                    $scope.errors.pageError = "";
                    if (errors) {
                        for (let i = 0; i < errors.length; i++) {
                            $scope.errors.formErrors[errors[i].Key] = errors[i].Message;
                        }
                    }
                }

                var handleErrors = function (data) {
                    if (data.ValidationSummary) {
                        $scope.ValidationSummary = {};
                        $scope.ValidationSummary = data.ValidationSummary;
                    }
                    if (data.Errors) {
                        updateErrors(data.Errors);
                    } else if (data.Message) {
                        $scope.errors = {};
                        $scope.errors.pageError = data.Message;
                    } else if (data) {
                        $scope.errors = {};
                        $scope.errors.pageError = data;
                    } else {
                        $scope.errors = {};
                        $scope.errors.pageError = "An unexpected error has occurred, please try again later.";
                    }
                };

            }
            $scope.Processing = false;
        }


        $scope.CreateAsync = function () {
            $scope.MessageCreateOrEditViewModel = {};
            $scope.SelectedIcon_ID = -1;
            $scope.Reset();
            $('#modal-createOredit').modal('show');
        }

        ////Delete--------------------------------------
        $scope.DeleteAsync = function (Id) {
            debugger
            swal({
                title: "Are you sure?",
                text: "Once deleted, you will not be able to recover this record!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var obj = {};
                        obj.Id = Id;
                        $http({
                            method: "post",
                            url: "/Message/DeleteAsync/",
                            data: obj
                        }).then(function (response) {
                            swal(response.data, { icon: "success", });
                            GetAll();
                        })
                    }
                    else {
                        swal("Your record is safe!");
                    }
                });
        }


        $('#modal-createOredit').keyup(function (e) {
            if (e.key === "Escape") {
                $scope.ShowConfirm(this.id);
            }
        })

        $scope.ShowConfirm = function (modelId) {
            CustomService.OnClose(modelId);
        }


        $scope.PageLoad();


    }]);