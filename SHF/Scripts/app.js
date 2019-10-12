//https://github.com/dotansimha/angularjs-dropdown-multiselect
var config = {
    app: "InventoryApp"
}

angular.module(config.app, ['ngMessages', 'ui.bootstrap', 'ngSanitize', 'remoteValidation', 'angularjs-dropdown-multiselect', 'ui.select2']);
//.config(['$routeProvider',
//    function ($routeProvider) {
//        $routeProvider.
//            when('/Configurations/Master/Tenant/Index',
//            {
//                templateUrl: 'Views/Tenant/Index.cshtml',
//                controller: 'TenantCtrl'
//            })
//            .
//            when('/page2',
//            {
//                templateUrl: 'Modules/Page2/page2.html',
//                controller: 'Page2Controller'
//            })
//            .
//            otherwise(
//            {
//                redirectTo: '/Configurations/Master/Tenant/Index'
//            });
//    }
//]);

