﻿angular.module(config.app).controller('BlogCommentsDetailsCtrl', ['$scope', '$http', '$window','SubSubCategoriesMasterCRUD', 'BlogCommentsDetailsCRUD','BlogMasterCRUD', 'TenantCRUD','CustomService','CodeValueCRUD',
    function ($scope, $http, $window,SubSubCategoriesMasterCRUD, BlogCommentsDetailsCRUD,BlogMasterCRUD, TenantCRUD,CustomService,CodeValueCRUD) {      
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.BlogCommentsDetailsCreateOrEditViewModel = {};
        $scope.AllTenants = [];
        $scope.AllBlogTitle = [];
        $scope.BlogCommentsDetailsCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.BlogCommentsDetailsCreateOrEditViewModel.SelectedBlog_Id = -1;
        $scope.BlogCommentsDetailsCreateOrEditViewModel.SelectedRelatedBlog_Id = -1;

       
       
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.BlogCommentsDetailsCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;     

        $scope.BindGrid = function () {
            BlogCommentsDetailsCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.BlogCommentsDetailsCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.BlogCommentsDetailsCreateOrEditViewModel = {};
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
                $scope.BlogCommentsDetailsCreateOrEditViewModel.SelectedTenant_ID = -1;
               // $scope.BlogCommentsDetailsCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.BlogCommentsDetailsCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
               // $scope.BindUnitOfMeasurementDropDownList($scope.BlogCommentsDetailsCreateOrEditViewModel.Tenant_ID);
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
            $http.get("/Get/BlogCommentsDetails/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.BlogCommentsDetailsCreateOrEditViewModel = response.data.Entity;
                           // $scope.LoadAllCategory();
                           // $scope.LoadAllSubSubCategory();
                            //$scope.BlogCommentsDetailsCreateOrEditViewModel.Category_ID=$scope.BlogCommentsDetailsCreateOrEditViewModel.Category_ID;
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
                $scope.path = ($scope.BlogCommentsDetailsCreateOrEditViewModel.ID == undefined || $scope.BlogCommentsDetailsCreateOrEditViewModel.ID == null || 
          $scope.BlogCommentsDetailsCreateOrEditViewModel.ID == 0) ? "/Post/BlogCommentsDetails/CreateAsync" : "/Post/BlogCommentsDetails/EditAsync";
               $http.post($scope.path, $scope.BlogCommentsDetailsCreateOrEditViewModel,
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
                  $http.post("/Post/BlogCommentsDetails/Delete/", obj,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                    }
                ).then(function (response) {
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
                        })
                    }
                    else {
                        CustomService.Notify("Your record is safe!");
                    }
                });
        }
/************load AllBlogTitle**************************************************************************************************/
$scope.LoadAllBlogTitle = function () {
            let tenantId = $scope.BlogCommentsDetailsCreateOrEditViewModel.Tenant_ID;
debugger;
            $scope.BindAllBlogTitleDropDownList(tenantId);
        }

$scope.BindAllBlogTitleDropDownList = function (tenantId) {
            let promise = BlogMasterCRUD.LoadBlogTitleDropdown(tenantId)
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.AllBlogTitle = response.data.Entity;
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

$scope.LoadAllRelatedBlogTitle = function () {
            let tenantId = $scope.BlogCommentsDetailsCreateOrEditViewModel.Tenant_ID;
debugger;
            $scope.BindAllRelatedBlogTitleDropDownList(tenantId);
        }

$scope.BindAllRelatedBlogTitleDropDownList = function (tenantId) {
            let promise = BlogMasterCRUD.LoadBlogTitleDropdown(tenantId)
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.AllRelatedBlogTitle = response.data.Entity;
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

  /****************************************************************************Load LoadSubSubCateUrl*************************************************************************************/
        $scope.LoadBlogUrl = function (Id) {
            let promise = BlogMasterCRUD.GetBlogUrl(Id)
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.BlogCommentsDetailsCreateOrEditViewModel.Url = response.data.Entity.Url;
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
    }]);


