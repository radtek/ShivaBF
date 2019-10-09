// create angular app
//var app = angular.module("SHFApp", ['ngMessages', 'ui.bootstrap']);

// create angular controller
angular.module(config.app).controller('TenantCtrl', ['$scope', '$http', '$window', 'TenantCRUD', 'CodeValueCRUD', 'CustomService',
    function ($scope, $http, $window, TenantCRUD, CodeValueCRUD, CustomService) {

        //Declaration and initialization
        $scope.path = "";
        $scope.errors = {};
        $scope.errors.pageError = {};
        $scope.errors.formErrors = {};
        $scope.errors.pageError = null;
        $scope.errors.formErrors = null;
        $scope.Processing = false;

        $scope.Entity = {};
        $scope.TenantCreateOrEditViewModel = {};
        $scope.TenantIndexViewModels = [];
        $scope.AllBillingCountry = [];
        $scope.AllShippingCountry = [];
        $scope.AllBillingState = [];
        $scope.AllShippingState = [];
        $scope.AllBillingCity = [];
        $scope.AllShippingCity = [];
        $scope.PageLoad = function () {
            $scope.BindGrid();
        }

        $scope.BindGrid = function () {
            TenantCRUD.LoadTable();
        }

        $scope.Reset = function () {
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched()
        }



        ////Delete--------------------------------------
        $scope.Delete = function (Id) {

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
                        obj.Tenant_ID = Id;
                        $http({
                            method: "post",
                            url: "/Tenant/Delete/",
                            data: obj
                        }).then(function (response) {
                            swal(response.data, { icon: "success", });
                            GetAll();
                        })
                    }
                    else {
                        swal("Your record is safe!");
                    }
                });
        }


        /********************************************************************************************************************************************/

        $scope.CreateAsync = function () {
            $scope.errors = {};
            $scope.errors.pageError = {};
            $scope.errors.formErrors = {};
            $scope.errors.pageError = null;
            $scope.errors.formErrors = null;
            $scope.TenantCreateOrEditViewModel = {};
            $scope.Reset();
            $scope.Processing = false;
            $scope.TenantCreateOrEditViewModel.BillingAddressCityOrDistrict_ID = 1011;
            $scope.TenantCreateOrEditViewModel.ShippingAddressCityOrDistrict_ID = 1011;
            $scope.TenantCreateOrEditViewModel.BillingAddressState_ID = 1010;
            $scope.TenantCreateOrEditViewModel.ShippingAddressState_ID = 1010;
            $scope.TenantCreateOrEditViewModel.BillingAddressCountry_ID = 1009;
            $scope.TenantCreateOrEditViewModel.ShippingAddressCountry_ID = 1009;
            $scope.BindBillingCountryTypeDropDownList($scope.TenantCreateOrEditViewModel.BillingAddressCountry_ID);
            $scope.BindShippingCountryTypeDropDownList($scope.TenantCreateOrEditViewModel.ShippingAddressCountry_ID);

            $('#modal-createOredit').modal('show');
        }

        $scope.EditAsync = function (Id) {
            $http.get("/Get/Tenant/EditAsync?Id=" + Id
            ).then(
                function success(response) {
                    // Add your success stuff here

                    switch (response.data.Type) {

                        case 'Exception':
                            swal('Error', response.data.Message, 'error');
                            break;

                        case 'Response':
                            $scope.TenantCreateOrEditViewModel = {};
                            //$scope.TenantCreateOrEditViewModel = JSON.stringify(response.data.Entity);
                            $scope.TenantCreateOrEditViewModel = response.data.Entity;
                            $scope.BindBillingCountryTypeDropDownList($scope.TenantCreateOrEditViewModel.BillingAddressCountry_ID);
                            $scope.BindShippingCountryTypeDropDownList($scope.TenantCreateOrEditViewModel.ShippingAddressCountry_ID);
                            $scope.LoadBillingStates();
                            $scope.LoadCityOrDistrictBilling();
                            $scope.LoadShippingStates();
                            $scope.LoadCityOrDistrictShipping();
                            $('#modal-createOredit').modal('show');
                            break;

                        case 'Validation':
                            swal('Error', response.data.Message, 'error');
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
                    console.clear();
                });
        }


        $scope.createOreditAsyncForm = function () {
            $scope.path = "";
            $scope.Processing = true;

            // check to make sure the form is completely valid
            if ($scope.myForm.$valid) {

                $scope.path = ($scope.TenantCreateOrEditViewModel.ID == undefined || $scope.TenantCreateOrEditViewModel.ID == null || $scope.TenantCreateOrEditViewModel.ID == 0) ? "/Post/Tenant/CreateAsync" : "/Post/Tenant/EditAsync";

                $http.post($scope.path, $scope.TenantCreateOrEditViewModel,
                    {
                        headers: { 'RequestVerificationToken': $scope.antiForgeryToken }
                    }
                ).then(
                    function success(response) {
                        // Add your success stuff here 
                        switch (response.data.Type) {
                            case 'Exception':
                                console.log(response);
                                swal(response.data.Title, response.data.Message, response.data.Icon);
                                break;

                            case 'Response':
                                console.clear();
                                $scope.TenantCreateOrEditViewModel = {};
                                $scope.Processing = false;
                                $('#modal-createOredit').modal('hide');
                                swal(response.data.Title, response.data.Message, response.data.Icon);
                                $scope.BindGrid();
                                break;

                            case 'Validation':
                                console.log(response);
                                swal(response.data.Title, response.data.Message, response.data.Icon);
                                break;

                            default:
                                console.log(response);
                                swal('Error', 'Internal server error', 'error');
                                break;
                        }


                        // console.clear();
                        //console.log(response);               
                        //window.location.href=response.ReturnUrl;
                    }, function errors(response) {
                        //https://benjii.me/2014/10/handling-validation-errors-with-angularjs-and-asp-net-mvc/

                        $scope.Processing = false;
                        handleErrors(response.data);
                        console.clear();
                    });

                function updateErrors(errors) {
                    $scope.errors = {};
                    $scope.errors.formErrors = {};
                    $scope.errors.pageError = "";
                    if (errors) {
                        for (var i = 0; i < errors.length; i++) {
                            $scope.errors.formErrors[errors[i].Key] = errors[i].Message;
                        }
                    }
                }

                var handleErrors = function (data) {
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


        $scope.BindBillingCountryTypeDropDownList = function (Id) {
            $scope.AllBillingCountry = CodeValueCRUD.LoadCodeValueByCodeId(Id);
        }
        $scope.LoadBillingStates = function () {
            let Id = $scope.TenantCreateOrEditViewModel.BillingAddressState_ID;
            let ParrentValue = $scope.TenantCreateOrEditViewModel.BillingAddressCountryValue;
            let result = CodeValueCRUD.LoadCodeValueByCodeId(Id);
            result = JSLINQ(result).Where(function (codeValues) { return codeValues.Data1Type == ParrentValue; });
            $scope.AllBillingState = result.items;

        }
        $scope.LoadCityOrDistrictBilling = function () {
            let Id = $scope.TenantCreateOrEditViewModel.BillingAddressCityOrDistrict_ID;
            let ParrentValue = $scope.TenantCreateOrEditViewModel.BillingAddressStateValue;
            let result = CodeValueCRUD.LoadCodeValueByCodeId(Id);
            result = JSLINQ(result).Where(function (codeValues) { return codeValues.Data1Type == ParrentValue; });
            $scope.AllBillingCity = result.items;
        }


        $scope.BindShippingCountryTypeDropDownList = function (Id) {
            $scope.AllShippingCountry = CodeValueCRUD.LoadCodeValueByCodeId(Id);
        }
        $scope.LoadShippingStates = function () {
            let Id = $scope.TenantCreateOrEditViewModel.ShippingAddressState_ID;
            let ParrentValue = $scope.TenantCreateOrEditViewModel.ShippingAddressCountryValue;
            let result = CodeValueCRUD.LoadCodeValueByCodeId(Id);
            result = JSLINQ(result).Where(function (codeValues) { return codeValues.Data1Type == ParrentValue; });
            $scope.AllShippingState = result.items;

        }
        $scope.LoadCityOrDistrictShipping = function () {
            let Id = $scope.TenantCreateOrEditViewModel.ShippingAddressCityOrDistrict_ID;
            let ParrentValue = $scope.TenantCreateOrEditViewModel.ShippingAddressStateValue;
            let result = CodeValueCRUD.LoadCodeValueByCodeId(Id);
            result = JSLINQ(result).Where(function (codeValues) { return codeValues.Data1Type == ParrentValue; });
            $scope.AllShippingCity = result.items;
        }


        $scope.CopyBillingDetails = function () {

            $scope.AllShippingState = $scope.AllBillingState;
            $scope.AllShippingCity = $scope.AllBillingCity;
            $scope.TenantCreateOrEditViewModel.ShippingAddressAttention = $scope.TenantCreateOrEditViewModel.BillingAddressAttention;
            $scope.TenantCreateOrEditViewModel.ShippingAddressCountryValue = $scope.TenantCreateOrEditViewModel.BillingAddressCountryValue;
            $scope.TenantCreateOrEditViewModel.ShippingAddressStreet1 = $scope.TenantCreateOrEditViewModel.BillingAddressStreet1;
            $scope.TenantCreateOrEditViewModel.ShippingAddressStreet2 = $scope.TenantCreateOrEditViewModel.BillingAddressStreet2;
            $scope.TenantCreateOrEditViewModel.ShippingAddressStateValue = $scope.TenantCreateOrEditViewModel.BillingAddressStateValue;
            $scope.TenantCreateOrEditViewModel.ShippingAddressCityOrDistrictValue = $scope.TenantCreateOrEditViewModel.BillingAddressCityOrDistrictValue;
            $scope.TenantCreateOrEditViewModel.ShippingAddressPhone = $scope.TenantCreateOrEditViewModel.BillingAddressPhone;
            $scope.TenantCreateOrEditViewModel.ShippingAddressFax = $scope.TenantCreateOrEditViewModel.BillingAddressFax;
            $scope.TenantCreateOrEditViewModel.ShippingAddressZipCode = $scope.TenantCreateOrEditViewModel.BillingAddressZipCode;


        }


        $('#modal-createOredit').keyup(function(e) {
            if (e.key === "Escape")  {
                $scope.ShowConfirm(this.id);
            }
        })


        $scope.ShowConfirm = function (modelId) {
            CustomService.OnClose(modelId);
        }


        $scope.PageLoad();

    }]);