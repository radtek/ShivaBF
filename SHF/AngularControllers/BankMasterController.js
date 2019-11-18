angular.module(config.app).controller('BankMasterCtrl', ['$scope', '$http', '$window', 'BankMasterCRUD', 'TenantCRUD','CustomService','BannerMasterCRUD',
    function ($scope, $http, $window, BankMasterCRUD, TenantCRUD,CustomService,BannerMasterCRUD) {      
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.BankMasterCreateOrEditViewModel = {};
        $scope.AllTenants = [];
       
        $scope.BankMasterCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.BankMasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.BankMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
        $scope.AllBannerMaster = [];
        $scope.SelectFor="";
        $scope.BindGrid = function () {
            BankMasterCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.BankMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.BankMasterCreateOrEditViewModel = {};
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
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
                $scope.BankMasterCreateOrEditViewModel.SelectedTenant_ID = -1;
                $scope.BankMasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.BankMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                $scope.BindUnitOfMeasurementDropDownList($scope.BankMasterCreateOrEditViewModel.Tenant_ID);
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

 
        $scope.BindUnitOfMeasurementDropDownList = function (tenantId) {
            let promise = UnitOfMeasurementCRUD.LoadUnitOfMeasurementDropdown(tenantId)
            promise.then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.AllUnitOfMeasurements = response.data.Entity;
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
            $http.get("/Get/Bank/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.BankMasterCreateOrEditViewModel = response.data.Entity;
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
                $scope.path = ($scope.BankMasterCreateOrEditViewModel.ID == undefined || $scope.BankMasterCreateOrEditViewModel.ID == null || $scope.BankMasterCreateOrEditViewModel.ID == 0) ? "/Post/Bank/CreateAsync" : "/Post/Bank/EditAsync";
                $http.post($scope.path, $scope.BankMasterCreateOrEditViewModel,
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
                        $http.post("/Post/Bank/Delete/", obj,
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

        $('#modal-createOredit').keyup(function (e) {
            if (e.key === "Escape") {
                $scope.ShowConfirm(this.id);
            }
        })


        $scope.ShowConfirm = function (modelId) {
            CustomService.OnClose(modelId);
        }
      /**********************************PopUp Image Handling *********************************/
        $scope.SelectBannerAsync = function (ID, BannerName) {
            $scope.BankMasterCreateOrEditViewModel[$scope.SelectFor] = BannerName;
            $('#modal-bannermaster').modal('hide');
        }


            $scope.SelectBannerasync = function (inputname) {
               $scope.SelectFor=inputname;
               $scope.AllBannerMaster = [];
                if ($scope.BankMasterCreateOrEditViewModel.Tenant_ID == undefined || $scope.BankMasterCreateOrEditViewModel.Tenant_ID <= 0 || $scope.BankMasterCreateOrEditViewModel.Tenant_ID == null) {
                    swal("Please select Tenant", "", "error");
                    return;
                }
                var result = BannerMasterCRUD.LoadAllBannerMasterByTenantIdAsync($scope.BankMasterCreateOrEditViewModel.Tenant_ID);
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


        $scope.PageLoad();
              

    }]);

