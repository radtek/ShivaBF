angular.module(config.app).controller('Services8MasterCtrl', ['$scope', '$http', '$window', 'SubSubCategoriesMasterCRUD', 'Services8MasterCRUD', 'TenantCRUD', 'CustomService', 'CodeValueCRUD', 'BannerMasterCRUD',
    function ($scope, $http, $window, SubSubCategoriesMasterCRUD, Services8MasterCRUD, TenantCRUD, CustomService, CodeValueCRUD, BannerMasterCRUD) {
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.Services8MasterCreateOrEditViewModel = {};
        $scope.AllTenants = [];
        $scope.AllSubSubCategories = [];
        $scope.AllBannerMaster = [];
        $scope.SelectFor = "";
        $scope.Services8MasterCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.Services8MasterCreateOrEditViewModel.SelectedSubSubCat_Id = -1;


        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.Services8MasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;

        $scope.BindGrid = function () {
            Services8MasterCRUD.LoadTable();
        }

        $scope.PageLoad = function () {
            $scope.Services8MasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.Services8MasterCreateOrEditViewModel = {};
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
CKEDITOR.instances["Section1Description"].setData('');
            $scope.BindServiceTypeDropDownList(1020);
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
                $scope.Services8MasterCreateOrEditViewModel.SelectedTenant_ID = -1;
                // $scope.Services8MasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.Services8MasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                // $scope.BindUnitOfMeasurementDropDownList($scope.Services8MasterCreateOrEditViewModel.Tenant_ID);
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
            $http.get("/Get/Services8Master/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.Services8MasterCreateOrEditViewModel = response.data.Entity;
                           CKEDITOR.instances["Section1Description"].setData($scope.Services8MasterCreateOrEditViewModel.Section1Description);
                            $scope.LoadAllSubSubCategory();
                            //$scope.Services8MasterCreateOrEditViewModel.Category_ID=$scope.Services8MasterCreateOrEditViewModel.Category_ID;
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
var objEditorSection1 = CKEDITOR.instances["Section1Description"];
$scope.Services8MasterCreateOrEditViewModel.Section1Description= objEditorSection1.getData();
            if ($scope.myForm.$valid) {
                $scope.path = ($scope.Services8MasterCreateOrEditViewModel.ID == undefined || $scope.Services8MasterCreateOrEditViewModel.ID == null ||
          $scope.Services8MasterCreateOrEditViewModel.ID == 0) ? "/Post/Services8Master/CreateAsync" : "/Post/Services8Master/EditAsync";
                $http.post($scope.path, $scope.Services8MasterCreateOrEditViewModel,
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
                        $http.post("/Post/Services8Master/Delete/", obj,
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
        /************load Sub Sub Category**************************************************************************************************/
        $scope.LoadAllSubSubCategory = function () {
            let tenantId = $scope.Services8MasterCreateOrEditViewModel.Tenant_ID;
            debugger;
            $scope.BindSubSubCategoryDropDownList(tenantId);
        }

        $scope.BindSubSubCategoryDropDownList = function (tenantId) {
            let promise = Services8MasterCRUD.LoadSubSubCategoriesDropdown(tenantId)
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

        /****************************************************************************Load LoadSubSubCateUrl*************************************************************************************/
        $scope.LoadSubSubCateUrl = function (Id) {
            let promise = SubSubCategoriesMasterCRUD.GetSubSubCategoriesUrl(Id)
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.Services8MasterCreateOrEditViewModel.Url = response.data.Entity.Url;
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
        /**********************************PopUp Image Handling *********************************/
        $scope.SelectBannerAsync = function (ID, BannerName) {
            $scope.Services8MasterCreateOrEditViewModel[$scope.SelectFor] = BannerName;
            $('#modal-bannermaster').modal('hide');
        }


        $scope.SelectBannerasync = function (inputname) {
            $scope.SelectFor = inputname;
            $scope.AllBannerMaster = [];
            if ($scope.Services8MasterCreateOrEditViewModel.Tenant_ID == undefined || $scope.Services8MasterCreateOrEditViewModel.Tenant_ID <= 0 || $scope.Services8MasterCreateOrEditViewModel.Tenant_ID == null) {
                swal("Please select Tenant", "", "error");
                return;
            }
            var result = BannerMasterCRUD.LoadAllBannerMasterByTenantIdAsync($scope.Services8MasterCreateOrEditViewModel.Tenant_ID);
            result.then(
                function success(response) {
                    switch (response.data.Type) {

                        case 'Exception':
                            swal('Error', response.data.Message, 'error');
                            break;

                        case 'Response':
                            $scope.AllBannerMaster = response.data.Entity;
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

            $('#modal-bannermaster').modal('show');
        }
    }]);


