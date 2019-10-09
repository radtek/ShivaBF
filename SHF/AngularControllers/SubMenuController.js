// create angular app
//var app = angular.module("SHFApp", ['ngMessages', 'ui.bootstrap']);

// create angular controller
angular.module(config.app).controller('SubMenuCtrl', ['$scope', '$http', '$window', 'SubMenuCRUD', 'CustomService',
    function ($scope, $http, $window, SubMenuCRUD, CustomService) {

        //Declaration and initialization
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;

        $scope.Entity = {};
        $scope.SubMenuCreateOrEditViewModel = {};
        $scope.SubMenuCreateOrEditViewModel.SelectedParrentMenu_ID = -1;
        $scope.SubMenuIndexViewModel = [];
        //$scope.ParrentMenuDropdownViewModel = [];
        $scope.ParrentMenuDropDownListViewModel = [];
        SubMenuCRUD.LoadTable();


        ////Delete--------------------------------------
        $scope.Delete = function (Id) {

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
                        obj.Customer_ID = Id;
                        $http({
                            method: "post",
                            url: "/Customer/Delete/",
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


        /********************************************************************************************************************************************/
        

        $scope.CreateAsync = function () {
            $scope.errors = {};
            $scope.errors.pageError = {};
            $scope.errors.formErrors = {};
            $scope.errors.pageError = null;
            $scope.errors.formErrors = null;
            $scope.Processing = false;
            $scope.SubMenuCreateOrEditViewModel = {};
           //$scope.ParrentMenuDropDownListViewModel = [];
            BindParrentMenuDropDownList();
            $('#modal-createOredit').modal('show');
        }

        function BindParrentMenuDropDownList() {

            if($scope.ParrentMenuDropDownListViewModel.length <= 0  ){

                var result = SubMenuCRUD.LoadParrentMenuDropdown();
                result.then(
                    function success(response) {
                        // Add your success stuff here
                        switch (response.data.Type) {

                            case 'Exception':
                                swal('Error', response.data.Message, 'error');
                                break;

                            case 'Response':
                                $scope.ParrentMenuDropDownListViewModel = response.data.Entity;
                                $scope.SubMenuCreateOrEditViewModel.SelectedParrentMenu_ID = -1;
                                break;

                            default:
                                swal('Error', 'Internal server error', 'error');
                                break;
                        }
                    }, function errors(response) {
                        switch (response.data.Type) {

                            case 'Exception':
                                swal('Error', response.data.Message, 'error');
                                break;
                            case 'Validation':
                                swal('Error', response.data.Message, 'error');
                                break;

                            default:
                                swal('Error', 'Internal server error', 'error');
                                break;
                        }
                        //console.clear();
                    });

            }
        }



        $scope.EditAsync = function (Id) {
            BindParrentMenuDropDownList();
            $http.get("/Get/Navigation/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    // Add your success stuff here

                    switch (response.data.Type) {

                        case 'Exception':
                            swal('Error', response.data.Message, 'error');
                            break;
                        case 'Response':
                            $scope.SubMenuCreateOrEditViewModel = {};                           
                          
                            $scope.SubMenuCreateOrEditViewModel = response.data.Entity;                            
                            $('#modal-createOredit').modal('show');
                            break;

                        case 'Validation':
                            swal('Error', response.data.Message, 'error');
                            break;

                        default:
                            swal('Error', 'Internal server error', 'error');
                            break;
                    }
                }, function errors(response) {
                    switch (response.data.Type) {

                        case 'Exception':
                            swal('Error', response.data.Message, 'error');
                            break;
                        case 'Validation':
                            swal('Error', response.data.Message, 'error');
                            break;

                        default:
                            swal('Error', 'Internal server error', 'error');
                            break;
                    }
                    console.clear();
                });
        }


        $scope.createOreditAsyncForm = function () {           
            $scope.Processing = true;
            $scope.path = "";
            if ($scope.myForm.$valid) {

                $scope.path = ($scope.SubMenuCreateOrEditViewModel.ID == undefined || $scope.SubMenuCreateOrEditViewModel.ID == null || $scope.SubMenuCreateOrEditViewModel.ID == 0) ? "/Post/Navigation/CreateAsync" : "/Post/Navigation/EditAsync";

                $http.post($scope.path, $scope.SubMenuCreateOrEditViewModel,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                    }
                ).then(
                    function success(response) {
                        $scope.SubMenuCreateOrEditViewModel = {};
                        $scope.Processing = false;
                        $('#modal-createOredit').modal('hide');
                        swal('Success!', response.data.Message, 'success');
                        SubMenuCRUD.LoadTable();
                        console.clear();
                        //console.log(response);                                     
                    }, function errors(response) {
                        handleErrors(response.data);
                        $scope.Processing = false;
                        console.clear();
                    });

                function updateErrors(errors) {
                    $scope.errors = {};
                    $scope.errors.formErrors = {};
                    $scope.errors.pageError = "";
                    if (errors) {
                        for (var i = 0; i < errors.length; i++) {
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

        }

        $('#modal-createOredit').keyup(function (e) {
            if (e.key === "Escape") {
                $scope.ShowConfirm(this.id);
            }
        })


        $scope.ShowConfirm = function (modelId) {
            CustomService.OnClose(modelId);
        }



    }]);