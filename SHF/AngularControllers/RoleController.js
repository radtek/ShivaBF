
angular.module(config.app).controller('AspNetRoleCtrl', ['$scope', '$http', '$window', 'AspNetRoleCRUD', 'TenantCRUD', 'CustomService',
    function ($scope, $http, $window, AspNetRoleCRUD, TenantCRUD, CustomService) {

        //Declaration and initialization
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.AspNetRoleCreateOrEditViewModel = {};
        $scope.TenantIndexViewModels = [];
        $scope.Tenant_ID = 0;
        $scope.AspNetRoleCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.TenantNameDropDownViewModels = [];
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());


        $scope.BindGrid = function () {
            AspNetRoleCRUD.LoadTable();
        }

        $scope.PageLoad = function () {
            $scope.AspNetRoleCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }      

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }

        $scope.Clear = function () {
            $scope.AspNetRoleCreateOrEditViewModel = {};
            $scope.Reset();
        }

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
                        let obj = {};
                        obj.Tenant_ID = Id;
                        $http({
                            method: "post",
                            url: "/Tenant/Delete/",
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
            $scope.Clear();
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
                $scope.AspNetRoleCreateOrEditViewModel.SelectedTenant_ID = -1;
            } else {
                $scope.AspNetRoleCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            }
            $('#modal-createOredit').modal('show');
        }

        $scope.BindTenantDropDownList = function () {
            let promise = TenantCRUD.LoadTenantDropdown();
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.TenantNameDropDownViewModels = response.data.Entity;
                            console.clear();
                            break;
                        default:
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                    }
                }, function errors(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Validation':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        default:
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                    }
                });
        }

        $scope.EditAsync = function (Id) {
            $scope.Clear();
            if ($scope.Cookie_Tenant_ID <= 0) {             
                $scope.BindTenantDropDownList();
            }
            $http.get("/Get/Roles/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.AspNetRoleCreateOrEditViewModel = response.data.Entity;                          
                            $('#modal-createOredit').modal('show');
                            console.clear();
                            break;
                        case 'Validation':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        default:
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                    }
                }, function errors(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Validation':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        default:
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                    }
                });
        }

        $scope.createOreditAsyncForm = function () {
            $scope.Processing = true;
            $scope.path = "";          
            if ($scope.myForm.$valid) {
                $scope.path = ($scope.AspNetRoleCreateOrEditViewModel.ID == undefined || $scope.AspNetRoleCreateOrEditViewModel.ID == null || $scope.AspNetRoleCreateOrEditViewModel.ID == 0) ? "/Post/Roles/CreateAsync" : "/Post/Roles/EditAsync";
                $http.post($scope.path, $scope.AspNetRoleCreateOrEditViewModel,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                    }
                ).then(
                    function success(response) {
                        $scope.Processing = false;
                        switch (response.data.Type) {
                            case 'Response':
                                $('#modal-createOredit').modal('hide');
                                CustomService.Alert(response);
                                $scope.PageLoad();
                                console.clear();
                                break;
                            case 'Exception':
                                CustomService.Notify(response.data.Message);
                                console.log(response);
                                break;
                            case 'Validation':
                                CustomService.Notify(response.data.Message);
                                console.log(response);
                                break;
                            default:
                                CustomService.Notify(response.data.Message);
                                console.log(response);
                                break;
                        }                      

                    }, function errors(response) {
                        console.log(response);
                        $scope.Processing = false;
                        handleErrors(response.data);
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

                let handleErrors = function (data) {
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



        $scope.PageLoad();

    }]);

