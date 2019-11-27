﻿angular.module(config.app).controller('PageViewsReportCtrl', ['$scope', '$http', '$window', 'PageViewsReportCRUD', 'TenantCRUD','CustomService',
    function ($scope, $http, $window, PageViewsReportCRUD, TenantCRUD,CustomService) {      
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.PageViewsReportCreateOrEditViewModel = {};
        $scope.AllTenants = [];
        
       
        $scope.PageViewsReportCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.PageViewsReportCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.PageViewsReportCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;

        $scope.fileList = [];
        $scope.curFile;
        $scope.ImageProperty = {
            file: ''
        }

        $scope.BindGrid = function () {
            PageViewsReportCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.PageViewsReportCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.PageViewsReportCreateOrEditViewModel = {};
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
                $scope.PageViewsReportCreateOrEditViewModel.SelectedTenant_ID = -1;
                $scope.PageViewsReportCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.PageViewsReportCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
                $scope.BindUnitOfMeasurementDropDownList($scope.PageViewsReportCreateOrEditViewModel.Tenant_ID);
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

 
        $scope.EditAsync = function (Id) {
            $scope.Clear();
            if ($scope.Cookie_Tenant_ID <= 0) {
                $scope.BindTenantDropDownList();
            }
            $http.get("/Get/PageViewsReport/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.PageViewsReportCreateOrEditViewModel = response.data.Entity;
                            $('#modal-createOredit').modal('show');
                            $scope.ImageProperty = {};
                            $scope.$apply();
                            $scope.fileList = [];
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
            $scope.UploadFile();
            if ($scope.myForm.$valid) {
                $scope.path = ($scope.PageViewsReportCreateOrEditViewModel.ID == undefined || $scope.PageViewsReportCreateOrEditViewModel.ID == null || $scope.PageViewsReportCreateOrEditViewModel.ID == 0) ? "/Post/PageViewsReport/CreateAsync" : "/Post/PageViewsReport/EditAsync";
                $http.post($scope.path, $scope.PageViewsReportCreateOrEditViewModel,
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
              
        /***************************************for file Upload 1****************************/


        $scope.setFile = function (element) {
            $scope.fileList = [];

            var files = element.files;
            for (var i = 0; i < files.length; i++) {
                $scope.ImageProperty.file = files[i];

                $scope.fileList.push($scope.ImageProperty);
                $scope.ImageProperty = {};
                $scope.$apply();
            }
        }
        $scope.UploadFile = function () {
            for (var i = 0; i < $scope.fileList.length; i++) {
                $scope.UploadFileIndividual($scope.fileList[i].file,
                                            $scope.fileList[i].file.name,
                                            $scope.fileList[i].file.type,
                                            $scope.fileList[i].file.size,
                                            i);
            }
        }
        $scope.UploadFileIndividual = function (fileToUpload, name, type, size, index) {
            var tenantId = $scope.PageViewsReportCreateOrEditViewModel.Tenant_ID;
            var reqObj = new XMLHttpRequest();
            reqObj.upload.addEventListener("progress", uploadProgress, false)
            reqObj.addEventListener("load", uploadComplete, false)
            reqObj.addEventListener("error", uploadFailed, false)
            reqObj.addEventListener("abort", uploadCanceled, false)
            reqObj.open("POST", "/POST/PageViewsReport/FileUpload", true);
            reqObj.setRequestHeader("Content-Type", "multipart/form-data");
            reqObj.setRequestHeader('X-File-Name', name);
            reqObj.setRequestHeader('X-File-Type', type);
            reqObj.setRequestHeader('X-File-Size', size);
            reqObj.setRequestHeader('tenantId', tenantId);
           $scope.PageViewsReportCreateOrEditViewModel.PageViewsReportPath=name;
            reqObj.send(fileToUpload);
            function uploadProgress(evt) {
                if (evt.lengthComputable) {
                    var uploadProgressCount = Math.round(evt.loaded * 100 / evt.total);
                    document.getElementById('P' + index).innerHTML = uploadProgressCount;
                    if (uploadProgressCount == 100) {
                        document.getElementById('P' + index).innerHTML =
                       '<i class="fa fa-refresh fa-spin" style="color:green;"></i>';
                    }
                }
            }
            function uploadComplete(evt) {
                document.getElementById('P' + index).innerHTML = '<span style="color:Green;font-weight:bold;font-style: oblique">Saved..</span>';
                $scope.NoOfFileSaved++;
                $scope.PageViewsReportCreateOrEditViewModel.PageViewsReportPath = name;
                $scope.$apply();
            }
            function uploadFailed(evt) {
                document.getElementById('P' + index).innerHTML = '<span style="color:Red;font-weight:bold;font-style: oblique">Upload Failed..</span>';
            }
            function uploadCanceled(evt) {
                document.getElementById('P' + index).innerHTML = '<span style="color:Red;font-weight:bold;font-style: oblique">Canceled..</span>';
            }
        }


        /**************************end File Upload************************/
    }]);
