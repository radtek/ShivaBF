
//let app = angular.module("SHFApp", ['ngMessages','ui.bootstrap']);


// create angular controller
angular.module(config.app).controller('MenuAccessPolicyCtrl', ['$scope', '$http', '$window', 'MenuAccessPolicyCRUD', 'AspNetRoleCRUD', 'TenantCRUD', 'CodeValueCRUD', 'CustomService',
    function ($scope, $http, $window, MenuAccessPolicyCRUD, AspNetRoleCRUD, TenantCRUD, CodeValueCRUD, CustomService) {

        //Declaration and initialization
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;

        $scope.AllTenants = [];
        $scope.AllAspNetRoles = [];

        $scope.AspNetRoleSubMenuCreateOrEditViewModel = {};
        $scope.AspNetRoleSubMenuCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.AspNetRoleSubMenuCreateOrEditViewModel.SelectedAspNetRole_ID = -1;

        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());



        $scope.BindGrid = function () {
            MenuAccessPolicyCRUD.LoadTable();
        }

        $scope.PageLoad = function () {          
            if ($scope.Cookie_Tenant_ID <= CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO) {
                $scope.BindTenantDropDownList();
            } else {
                $scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                $scope.BindAspNetRoleDropDownList($scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID);
            }
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }

        $scope.Close = function () {
            if ($scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID > CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO) {
                $scope.AspNetRoleSubMenuCreateOrEditViewModel = {};
                if ($scope.Cookie_Tenant_ID <= CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO) {
                    $scope.BindTenantDropDownList();
                } else {
                    $scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                }
                $scope.BindGrid();
            }
        }

        $scope.BindTenantDropDownList = function () {
            if ($scope.AllTenants.length <= CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO) {
                let promise = TenantCRUD.LoadTenantDropdown();
                promise.then(
                    function success(response) {
                        switch (response.data.Type) {
                            case 'Exception':
                                CustomService.Notify(response.data.Message);
                                console.log(response);
                                break;
                            case 'Response':
                                $scope.AllTenants = [];
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

        $scope.BindAspNetRoleDropDownList = function (tenantId) {
            tenantId = tenantId == null ? CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO : tenantId;
            $scope.AllAspNetRoles = [];
            let promise = AspNetRoleCRUD.GetRolesByTenantId(tenantId);
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.AllAspNetRoles = response.data.Entity;
                            $scope.AspNetRoleSubMenuCreateOrEditViewModel.SelectedAspNetRole_ID = -1;
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















        ////Delete--------------------------------------

        /********************************************************************************************************************************************/






        $scope.LoadAspNetRoles = function () {
            if ($scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID > CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO) {
                $scope.BindAspNetRoleDropDownList($scope.AspNetRoleSubMenuCreateOrEditViewModel.Tenant_ID);
                $scope.BindGrid();
            }
            else {
                $scope.AllAspNetRoles = [];
                $scope.AspNetRoleSubMenuCreateOrEditViewModel.SelectedAspNetRole_ID = -1;
                $scope.BindGrid();
                //MenuAccessPolicyCRUD.HideTable();
                //CustomService.Notify('Please select tenant');
                //console.log('Please select tenant');                
            }
        }


        $scope.LoadMenuAccessPolicy = function () {          
            if ($scope.AspNetRoleSubMenuCreateOrEditViewModel.AspNetRole_ID > CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO) {               
                    $scope.BindGrid();               
            }
            else {
                $scope.BindGrid();
                //MenuAccessPolicyCRUD.HideTable();
                //CustomService.Notify('Please select role'); 
                //console.log('Please select role');              
            }
        }


        $scope.createOreditAsyncForm = function () {
            $scope.Processing = true;
            $scope.path = "";
            $('#modal-createOredit').modal('show');
            if ($scope.myForm2.$valid) {
                $scope.path = "/Post/MenuAccessPolicy/UpdatePolicyAsync";
                $http.post($scope.path, $scope.AspNetRoleSubMenuCreateOrEditViewModel,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryTokenForUpdate }
                    }
                ).then(
                    function success(response) {
                        $scope.Processing = false;
                        $('#modal-createOredit').modal('hide');
                        switch (response.data.Type) {
                            case 'Response':                              
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
                        $scope.Processing = false;
                        $('#modal-createOredit').modal('hide');
                        CustomService.Notify(response.data.Message);                      
                        handleErrors(response.data);
                        console.log(response);
                    });

                function updateErrors(errors) {
                    $scope.errors = {};
                    $scope.errors.formErrors = {};
                    $scope.errors.pageError = "";
                    if (errors) {
                        for (let i = CodeValueCRUD.CODE_VALUE.Numerics.Integer.ZERO; i < errors.length; i++) {
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


        $scope.EditAsync = function (Id, Hasaccess) {
            $('#modal-createOredit').modal('show');
            $scope.AspNetRoleSubMenuCreateOrEditViewModel.ID = Id;
            $scope.AspNetRoleSubMenuCreateOrEditViewModel.HasAccess = Hasaccess;
            $http.post("/Post/MenuAccessPolicy/EditAsync", $scope.AspNetRoleSubMenuCreateOrEditViewModel,
                {
                    headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                }
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            CustomService.Alert(response);
                            //$scope.PageLoad();
                            $scope.LoadMenuAccessPolicy();
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
            $('#modal-createOredit').modal('hide');
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

