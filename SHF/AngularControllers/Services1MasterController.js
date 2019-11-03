angular.module(config.app).controller('Services1MasterCtrl', ['$scope', '$http', '$window','SubSubCategoriesMasterCRUD', 'Services1MasterCRUD', 'TenantCRUD','CustomService','CodeValueCRUD',
    function ($scope, $http, $window,SubSubCategoriesMasterCRUD, Services1MasterCRUD, TenantCRUD,CustomService,CodeValueCRUD) {      
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;
        $scope.Entity = {};
        $scope.Services1MasterCreateOrEditViewModel = {};
        $scope.AllTenants = [];
        $scope.AllSubSubCategories = [];
        $scope.Services1MasterCreateOrEditViewModel.SelectedTenant_ID = -1;
        $scope.Services1MasterCreateOrEditViewModel.SelectedSubSubCat_Id = -1;
        $scope.fileList = [];
        $scope.curFile;
        $scope.ImageProperty = {
            file: ''
        }
        $scope.fileList2 = [];
        $scope.curFile2;
        $scope.ImageProperty2 = {
            file2: ''
        }
        $scope.Cookie_Tenant_ID = parseInt(CustomService.GetTenantID());
        $scope.Services1MasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;     

        $scope.BindGrid = function () {
            Services1MasterCRUD.LoadTable();
        }      

        $scope.PageLoad = function () {
            $scope.Services1MasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
            $scope.BindGrid();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }


        $scope.Clear = function () {
            $scope.Services1MasterCreateOrEditViewModel = {};
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
                $scope.Services1MasterCreateOrEditViewModel.SelectedTenant_ID = -1;
               // $scope.Services1MasterCreateOrEditViewModel.SelectedUnitOfMesurment = -1;
            } else {
                $scope.Services1MasterCreateOrEditViewModel.Tenant_ID = $scope.Cookie_Tenant_ID;
               // $scope.BindUnitOfMeasurementDropDownList($scope.Services1MasterCreateOrEditViewModel.Tenant_ID);
            }
            $('#modal-createOredit').modal('show');
        }
$scope.Preview = function (url) {
    CustomService.PreviewOpen(url);
}
$scope.Guide = function () {
$('#modal-guide').modal('show');
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
            $http.get("/Get/Services1Master/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    switch (response.data.Type) {
                        case 'Exception':
                            CustomService.Notify(response.data.Message);
                            console.log(response);
                            break;
                        case 'Response':
                            $scope.Services1MasterCreateOrEditViewModel = response.data.Entity;
                           // $scope.LoadAllCategory();
                            $scope.LoadAllSubSubCategory();
                            //$scope.Services1MasterCreateOrEditViewModel.Category_ID=$scope.Services1MasterCreateOrEditViewModel.Category_ID;
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
                $scope.path = ($scope.Services1MasterCreateOrEditViewModel.ID == undefined || $scope.Services1MasterCreateOrEditViewModel.ID == null || 
          $scope.Services1MasterCreateOrEditViewModel.ID == 0) ? "/Post/Services1Master/CreateAsync" : "/Post/Services1Master/EditAsync";
               $http.post($scope.path, $scope.Services1MasterCreateOrEditViewModel,
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
                  $http.post("/Post/Services1Master/Delete/", obj,
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
            let tenantId = $scope.Services1MasterCreateOrEditViewModel.Tenant_ID;
debugger;
            $scope.BindSubSubCategoryDropDownList(tenantId);
        }

$scope.BindSubSubCategoryDropDownList = function (tenantId) {
            let promise = Services1MasterCRUD.LoadSubSubCategoriesDropdown(tenantId)
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
     var tenantId = $scope.Services1MasterCreateOrEditViewModel.Tenant_ID;
     var reqObj = new XMLHttpRequest();
     reqObj.upload.addEventListener("progress", uploadProgress, false)
     reqObj.addEventListener("load", uploadComplete, false)
     reqObj.addEventListener("error", uploadFailed, false)
     reqObj.addEventListener("abort", uploadCanceled, false)
     reqObj.open("POST", "/Post/Services1/FileUpload", true);
     reqObj.setRequestHeader("Content-Type", "multipart/form-data");
     reqObj.setRequestHeader('X-File-Name', name);
     reqObj.setRequestHeader('X-File-Type', type);
     reqObj.setRequestHeader('X-File-Size', size);
     reqObj.setRequestHeader('tenantId', tenantId);
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
         $scope.Services1MasterCreateOrEditViewModel.BannerImagePath = name;
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


        /***************************************for file Upload 2****************************/


 $scope.setFile2 = function (element) {
     $scope.fileList2 = [];

     var files2 = element.files;
     for (var i = 0; i < files2.length; i++) {
         $scope.ImageProperty2.file2 = files2[i];

         $scope.fileList2.push($scope.ImageProperty2);
         $scope.ImageProperty2 = {};
         $scope.$apply();
     }
 }
 $scope.UploadFile2 = function () {
     for (var i = 0; i < $scope.fileList2.length; i++) {
         $scope.UploadFileIndividual2($scope.fileList2[i].file,
                                     $scope.fileList2[i].file.name,
                                     $scope.fileList2[i].file.type,
                                     $scope.fileList2[i].file.size,
                                     i);
     }
 }
 $scope.UploadFileIndividual2 = function (fileToUpload, name, type, size, index) {
     var tenantId = $scope.Services1MasterCreateOrEditViewModel.Tenant_ID;
     var reqObj = new XMLHttpRequest();
     reqObj.upload.addEventListener("progress", uploadProgress, false)
     reqObj.addEventListener("load", uploadComplete, false)
     reqObj.addEventListener("error", uploadFailed, false)
     reqObj.addEventListener("abort", uploadCanceled, false)
     reqObj.open("POST", "/Post/Services1/FileUpload", true);
     reqObj.setRequestHeader("Content-Type", "multipart/form-data");
     reqObj.setRequestHeader('X-File-Name', name);
     reqObj.setRequestHeader('X-File-Type', type);
     reqObj.setRequestHeader('X-File-Size', size);
     reqObj.setRequestHeader('tenantId', tenantId);
     reqObj.send(fileToUpload);
     function uploadProgress(evt) {
         if (evt.lengthComputable) {
             var uploadProgressCount = Math.round(evt.loaded * 100 / evt.total);
             document.getElementById('P2' + index).innerHTML = uploadProgressCount;
             if (uploadProgressCount == 100) {
                 document.getElementById('P2' + index).innerHTML =
                '<i class="fa fa-refresh fa-spin" style="color:green;"></i>';
             }
         }
     }
     function uploadComplete(evt) {
         document.getElementById('P2' + index).innerHTML = '<span style="color:Green;font-weight:bold;font-style: oblique">Saved..</span>';
         $scope.NoOfFileSaved++;
         $scope.Services1MasterCreateOrEditViewModel.BannerImagePath = name;
         $scope.$apply();
     }
     function uploadFailed(evt) {
         document.getElementById('P2' + index).innerHTML = '<span style="color:Red;font-weight:bold;font-style: oblique">Upload Failed..</span>';
     }
     function uploadCanceled(evt) {
         document.getElementById('P2' + index).innerHTML = '<span style="color:Red;font-weight:bold;font-style: oblique">Canceled..</span>';
     }
 }


        /**************************end File Upload************************/


    }]);


