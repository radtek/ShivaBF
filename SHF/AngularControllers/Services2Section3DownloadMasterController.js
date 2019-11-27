angular.module(config.app).controller('Services2Section3DownloadMasterCtrl', ['$scope', '$http', '$window', 'CategoriesMasterCRUD', 'SubCategoriesMasterCRUD', 'Services2Section3DownloadMasterCRUD', 'Services2MasterCRUD', 'TenantCRUD', 'CustomService', 'CodeValueCRUD', 'BannerMasterCRUD',
    function ($scope, $http, $window, CategoriesMasterCRUD, SubCategoriesMasterCRUD, Services2Section3DownloadMasterCRUD, Services2MasterCRUD, TenantCRUD, CustomService, CodeValueCRUD, BannerMasterCRUD) {
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.Services2Section3DownloadMasterCreateOrEditViewModel = {};
        $scope.AllTenants = [];
        $scope.AllSubSubCategories = [];
        $scope.Services2Section3DownloadMasterCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.Services2Section3DownloadMasterCreateOrEditViewModel.SelectedSubSubCat_Id = -1;
        $scope.AllBannerMaster = [];
        $scope.SelectFor = "";
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;     
        $scope.Preview = function (url) {
          CustomService.PreviewOpen(url);
            }
       $scope.Guide = function () {
            $('#modal-guide').modal('show');
        }
        $scope.BindGrid = function () {
            Services2Section3DownloadMasterCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.Services2Section3DownloadMasterCreateOrEditViewModel = {};
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
                $scope.Services2Section3DownloadMasterCreateOrEditViewModel.SelectedTenant_ID = -1;
               // $scope.Services2Section3DownloadMasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
               // $scope.BindUnitOfMeasurementDropDownList($scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID);
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
            $http.get("/Get/Services2Section3DownloadMaster/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.Services2Section3DownloadMasterCreateOrEditViewModel = response.data.Entity;
                           // $scope.LoadAllCategory();
                            $scope.LoadAllSubSubCategory();
                            //$scope.Services2Section3DownloadMasterCreateOrEditViewModel.Category_ID=$scope.Services2Section3DownloadMasterCreateOrEditViewModel.Category_ID;
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
                $scope.path = ($scope.Services2Section3DownloadMasterCreateOrEditViewModel.ID == undefined || $scope.Services2Section3DownloadMasterCreateOrEditViewModel.ID == null || 
          $scope.Services2Section3DownloadMasterCreateOrEditViewModel.ID == 0) ? "/Post/Services2Section3DownloadMaster/CreateAsync" : "/Post/Services2Section3DownloadMaster/EditAsync";
               $http.post($scope.path, $scope.Services2Section3DownloadMasterCreateOrEditViewModel,
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
                  $http.post("/Post/Services2Section3DownloadMaster/Delete/", obj,
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
            let tenantId = $scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID;
            $scope.BindSubSubCategoryDropDownList(tenantId);
        }

$scope.BindSubSubCategoryDropDownList = function (tenantId) {
            let promise = Services2MasterCRUD.LoadSubSubCategoriesDropdown(tenantId)
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


        /**********************************PopUp Image Handling *********************************/
 $scope.SelectBannerAsync = function (ID, BannerName) {
     $scope.Services2Section3DownloadMasterCreateOrEditViewModel[$scope.SelectFor] = BannerName;
     $('#modal-bannermaster').modal('hide');
 }


 $scope.SelectBannerasync = function (inputname) {
     $scope.SelectFor = inputname;
     $scope.AllBannerMaster = [];
     if ($scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID == undefined || $scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID <= 0 || $scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID == null) {
         swal("Please select Tenant", "", "error");
         return;
     }
     var result = BannerMasterCRUD.LoadAllBannerMasterByTenantIdAsync($scope.Services2Section3DownloadMasterCreateOrEditViewModel.Tenant_ID);
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


