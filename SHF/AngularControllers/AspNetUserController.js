
//let app = angular.module("SHFApp", ['ngMessages','ui.bootstrap']);


// create angular controller
angular.module(config.app).controller('AspNetUserCtrl', ['$scope', '$http', 'AspNetUserCRUD', 'AspNetRoleCRUD', 'TenantCRUD', 'CustomService',
    function ($scope, $http, AspNetUserCRUD, AspNetRoleCRUD, TenantCRUD, CustomService) {

        //Declaration and initialization
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;

        $scope.AllTenants = [];
        $scope.MyRoles = [];
        $scope.MySelectedRoles = [];
        $scope.RegisterOrEditViewModel = {};
        $scope.RegisterOrEditViewModel.AssignedRoles = [];
        $scope.RegisterOrEditViewModel.SelectedTenant_ID = -1;
        $scope.RegisterOrEditViewModel.AspNetRolesViewModel = [];
        $scope.Tenant_ID = 0;
        $scope.AspNetUserIndexViewModel = [];
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());

        $scope.dropdownSetting = {
            scrollable: true,
            scrollableHeight: '200px'
        }

        $scope.BindGrid = function () {
            AspNetUserCRUD.LoadTable();
        }

        $scope.PageLoad = function () {
            $scope.RegisterOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.RegisterOrEditViewModel = {};
            $scope.Reset();
        }








        ////Delete--------------------------------------

        /********************************************************************************************************************************************/

        $scope.BindTenantDropDownList = function () {
            if ($scope.AllTenants.length <= 0) {
                let result = TenantCRUD.LoadTenantDropdown();
                result.then(
                    function success(response) {
                        switch (response.data.Type) {
                            case 'Exception':
                                CustomService.Notify(response.data.Message);
                                console.log(response);
                                break;
                            case 'Response':
                                $scope.AllTenants = response.data.Entity;
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
        }

        $scope.BindRolesDropdownList = function (tenantId) {
            let promise = AspNetRoleCRUD.GetRolesByTenantId(tenantId);
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.MyRoles = [];
                            $scope.MySelectedRoles = [];
                            angular.forEach(response.data.Entity, function (value, index) {
                                $scope.MyRoles.push({ id: value.ID, label: value.Name });
                            });
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

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }

        $scope.CreateAsync = function () {
            // $scope.RegisterViewModel = {};  
            $scope.errors = {};
            $scope.errors.pageError = {};
            $scope.errors.formErrors = {};
            $scope.errors.pageError = null;
            $scope.errors.formErrors = null;
            $scope.Processing = false;
            $scope.Clear();
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
                $scope.RegisterOrEditViewModel.SelectedTenant_ID = -1;
            } else {
                $scope.RegisterOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                $scope.BindRolesDropdownList($scope.RegisterOrEditViewModel.Tenant_ID);
            }
            $('#modal-createOredit').modal('show');
        }
        
        $scope.EditAsync = function (Id, Tenant_ID) {
            $scope.Clear();
            $scope.BindRolesDropdownList(Tenant_ID);
            CustomService.Thread.sleep(1000);
            $http.get("/Get/Users/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.RegisterOrEditViewModel = response.data.Entity[0];
                            angular.forEach(response.data.Entity[1], function (value, index) {
                                for (let i = 0; i < $scope.MyRoles.length; i++) {
                                    if ($scope.MyRoles[i].id == value.ID) {
                                        $scope.MySelectedRoles.push($scope.MyRoles[i]);
                                    }
                                }
                            });
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
                $scope.RegisterOrEditViewModel.AssignedRoles = [];
                angular.forEach($scope.MySelectedRoles, function (value, index) {
                    $scope.RegisterOrEditViewModel.AssignedRoles.push(value.id);
                });
                $scope.path = ($scope.RegisterOrEditViewModel.ID == undefined || $scope.RegisterOrEditViewModel.ID == null || $scope.RegisterOrEditViewModel.ID == 0) ? "/Post/Users/CreateAsync" : "/Post/Users/EditAsync";
                $http.post($scope.path, $scope.RegisterOrEditViewModel,
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

