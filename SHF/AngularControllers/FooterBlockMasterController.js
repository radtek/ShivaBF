angular.module(config.app).controller('FooterBlockMasterCtrl', ['$scope', '$http', '$window', 'FooterBlockMasterCRUD', 'TenantCRUD','CustomService',
    function ($scope, $http, $window, FooterBlockMasterCRUD, TenantCRUD,CustomService) {      
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.FooterBlockMasterCreateOrEditViewModel = {};
        $scope.AllTenants = [];
       
        $scope.FooterBlockMasterCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.FooterBlockMasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.FooterBlockMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;

       $scope.Preview = function (url) {
          CustomService.PreviewOpen(url);
            }
       $scope.Guide = function () {
            $('#modal-guide').modal('show');
        }
        $scope.BindGrid = function () {
            FooterBlockMasterCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.FooterBlockMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.FooterBlockMasterCreateOrEditViewModel = {};
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
                $scope.FooterBlockMasterCreateOrEditViewModel.SelectedTenant_ID = -1;
                $scope.FooterBlockMasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.FooterBlockMasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                $scope.BindUnitOfMeasurementDropDownList($scope.FooterBlockMasterCreateOrEditViewModel.Tenant_ID);
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
            $http.get("/Get/FooterBlockMaster/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.FooterBlockMasterCreateOrEditViewModel = response.data.Entity;
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
                $scope.path = ($scope.FooterBlockMasterCreateOrEditViewModel.ID == undefined || $scope.FooterBlockMasterCreateOrEditViewModel.ID == null || $scope.FooterBlockMasterCreateOrEditViewModel.ID == 0) ? "/Post/FooterBlockMaster/CreateAsync" : "/Post/FooterBlockMaster/EditAsync";
                $http.post($scope.path, $scope.FooterBlockMasterCreateOrEditViewModel,
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
        $scope.FileUploadAsync = function () {
            $scope.fileList = [];
            $scope.curFile;
            $scope.ImageProperty = {
                file: ''
            }
            $('#modal-fileupload').modal('show');
        }

        $scope.FileUploadAsyncPost = function ()
        {
debugger;
            var val = $scope.FileUpload($scope.fileList, "/Post/TenantCommonUploadFile/FileUpload", $scope.FooterBlockMasterCreateOrEditViewModel.Tenant_ID);
            if (val !== "Error" && val !== "") {
                $scope.FooterBlockMasterCreateOrEditViewModel.IconPath = val;
                $('#modal-fileupload').modal('hide');
            }
            else {
                $scope.FooterBlockMasterCreateOrEditViewModel.IconPath ="";
            }
            $scope.fileList = [];
            $scope.curFile;
            $scope.ImageProperty = {
                file: ''
            }
            
        }

        /***************************************for file Upload****************************/

       
        $scope.setFile = function (element) {
            $scope.fileList = [];

            var files = element.files;
            for (var i = 0; i < files.length; i++) {
                $scope.ImageProperty.file = files[i];
                $scope.fileList.push($scope.ImageProperty);
                $scope.ImageProperty = {};
            }
        }

       $scope.FileUpload = function (fileList, url, tenantId) {
             CustomService.FnUploadFile(fileList, url, tenantId).then(function (value) {
           alert(value);
        });
        }

        /**************************end File Upload************************/

        $scope.PageLoad();
              

    }]);

