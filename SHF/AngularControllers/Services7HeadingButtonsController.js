﻿angular.module(config.app).controller('Services7HeadingButtonsCtrl', ['$scope', '$http', '$window','CategoriesMasterCRUD','SubCategoriesMasterCRUD', 'Services7HeadingButtonsCRUD','Services7MasterCRUD','TenantCRUD','CustomService','CodeValueCRUD',
    function ($scope, $http, $window,CategoriesMasterCRUD,SubCategoriesMasterCRUD, Services7HeadingButtonsCRUD,Services7MasterCRUD, TenantCRUD,CustomService,CodeValueCRUD) {      
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.Services7HeadingButtonsCreateOrEditViewModel = {};
        $scope.AllTenants = [];
        $scope.AllSubSubCategories = [];
        $scope.Services7HeadingButtonsCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.Services7HeadingButtonsCreateOrEditViewModel.SelectedSubSubCat_Id = -1;
       
        $scope.Preview = function (url) {
            CustomService.PreviewOpen(url);
        }
        $scope.Guide = function () {
        $('#modal-guide').modal('show');
        } 
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.Services7HeadingButtonsCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;     

        $scope.BindGrid = function () {
            Services7HeadingButtonsCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.Services7HeadingButtonsCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.Services7HeadingButtonsCreateOrEditViewModel = {};
            $scope.Reset();
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
            $scope.BindServiceTypeDropDownList(1020);
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
                $scope.Services7HeadingButtonsCreateOrEditViewModel.SelectedTenant_ID = -1;
               // $scope.Services7HeadingButtonsCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.Services7HeadingButtonsCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
               // $scope.BindUnitOfMeasurementDropDownList($scope.Services7HeadingButtonsCreateOrEditViewModel.Tenant_ID);
            }
            $('#modal-createOredit').modal('show');
        }

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
/********************************************************************************/
        $scope.EditAsync = function (Id) {
            $scope.Clear();
            $scope.BindServiceTypeDropDownList(1020);
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
           }
            $http.get("/Get/Services7HeadingButtons/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.Services7HeadingButtonsCreateOrEditViewModel = response.data.Entity;
                           // $scope.LoadAllCategory();
                            $scope.LoadAllSubSubCategory();
                            //$scope.Services7HeadingButtonsCreateOrEditViewModel.Category_ID=$scope.Services7HeadingButtonsCreateOrEditViewModel.Category_ID;
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
                $scope.path = ($scope.Services7HeadingButtonsCreateOrEditViewModel.ID == undefined || $scope.Services7HeadingButtonsCreateOrEditViewModel.ID == null || 
          $scope.Services7HeadingButtonsCreateOrEditViewModel.ID == 0) ? "/Post/Services7HeadingButtons/CreateAsync" : "/Post/Services7HeadingButtons/EditAsync";
               $http.post($scope.path, $scope.Services7HeadingButtonsCreateOrEditViewModel,
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
                    },
                    function errors(response) {
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
              
 $scope.DeleteAsync = function (Id) {

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
                  $http.post("/Post/Services7HeadingButtons/Delete/", obj,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                    }
                ).then(function (response) {
                            switch (response.data.Type) {
                            case 'Response':
                                $('#modal-createOredit').modal('hide');
                               // CustomService.Alert(response);
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
                        })
                    }
                    else {
                        CustomService.Notify("Your record is safe!");
                    }
                });
        }
/************load Sub Category**************************************************************************************************/
$scope.LoadAllSubSubCategory = function () {
            let tenantId = $scope.Services7HeadingButtonsCreateOrEditViewModel.Tenant_ID;
            $scope.BindSubSubCategoryDropDownList(tenantId);
        }

$scope.BindSubSubCategoryDropDownList = function (tenantId) {
            let promise = Services7MasterCRUD.LoadSubSubCategoriesDropdown(tenantId)
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.AllSubSubCategories = response.data.Entity;
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
 $scope.BindServiceTypeDropDownList = function (Id) {
            $scope.AllServiceType = [];
            $scope.AllServiceType = CodeValueCRUD.LoadCodeValueByCodeId(Id);
        }         
    }]);


