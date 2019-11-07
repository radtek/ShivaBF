angular.module(config.app).controller('HomePageSection2Ctrl', ['$scope', '$http', '$window','SubSubCategoriesMasterCRUD', 'HomePageSection2CRUD', 'TenantCRUD','CustomService','CodeValueCRUD','BannerMasterCRUD',
    function ($scope, $http, $window, SubSubCategoriesMasterCRUD, HomePageSection2CRUD, TenantCRUD, CustomService, CodeValueCRUD, BannerMasterCRUD) {
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.HomePageSection2CreateOrEditViewModel = {};
        $scope.AllTenants = [];
        $scope.AllSubSubCategories = [];
        $scope.HomePageSection2CreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.HomePageSection2CreateOrEditViewModel.SelectedSubSubCat_Id = -1;
        $scope.AllBannerMaster = [];
        $scope.SelectFor = "";
       
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.HomePageSection2CreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;     

       $scope.fileList = [];
        $scope.curFile;
        $scope.ImageProperty = {
            file: ''
        }

        $scope.Preview = function (url) {
          CustomService.PreviewOpen(url);
            }
        $scope.Guide = function () {
            $('#modal-guide').modal('show');
        }
        $scope.BindGrid = function () {
            HomePageSection2CRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.HomePageSection2CreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.HomePageSection2CreateOrEditViewModel = {};
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
                $scope.HomePageSection2CreateOrEditViewModel.SelectedTenant_ID = -1;
               // $scope.HomePageSection2CreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.HomePageSection2CreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
               // $scope.BindUnitOfMeasurementDropDownList($scope.HomePageSection2CreateOrEditViewModel.Tenant_ID);
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
            $http.get("/Get/HomePageSection2/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.HomePageSection2CreateOrEditViewModel = response.data.Entity;
                           // $scope.LoadAllCategory();
                            $scope.LoadAllSubSubCategory();
                            //$scope.HomePageSection2CreateOrEditViewModel.Category_ID=$scope.HomePageSection2CreateOrEditViewModel.Category_ID;
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
                $scope.path = ($scope.HomePageSection2CreateOrEditViewModel.ID == undefined || $scope.HomePageSection2CreateOrEditViewModel.ID == null || 
          $scope.HomePageSection2CreateOrEditViewModel.ID == 0) ? "/Post/HomePageSection2/CreateAsync" : "/Post/HomePageSection2/EditAsync";
               $http.post($scope.path, $scope.HomePageSection2CreateOrEditViewModel,
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
                  $http.post("/Post/HomePageSection2/Delete/", obj,
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
            let tenantId = $scope.HomePageSection2CreateOrEditViewModel.Tenant_ID;
debugger;
            $scope.BindSubSubCategoryDropDownList(tenantId);
        }

$scope.BindSubSubCategoryDropDownList = function (tenantId) {
            let promise = HomePageSection2CRUD.LoadSubSubCategoriesDropdown(tenantId)
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
     $scope.HomePageSection2CreateOrEditViewModel[$scope.SelectFor] = BannerName;
     $('#modal-bannermaster').modal('hide');
 }


 $scope.SelectBannerasync = function (inputname) {
     $scope.SelectFor = inputname;
     $scope.AllBannerMaster = [];
     if ($scope.HomePageSection2CreateOrEditViewModel.Tenant_ID == undefined || $scope.HomePageSection2CreateOrEditViewModel.Tenant_ID <= 0 || $scope.HomePageSection2CreateOrEditViewModel.Tenant_ID == null) {
         swal("Please select Tenant", "", "error");
         return;
     }
     var result = BannerMasterCRUD.LoadAllBannerMasterByTenantIdAsync($scope.HomePageSection2CreateOrEditViewModel.Tenant_ID);
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
                            $scope.HomePageSection2CreateOrEditViewModel.Url = response.data.Entity.Url;
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


