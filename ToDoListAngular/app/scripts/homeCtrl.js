//
// Use the following code for running without authentication.
//
'use strict';
angular.module('todoApp')
.controller('homeCtrl', ['$rootScope','$scope',  '$location', function ($rootScope, $scope,  $location) {
    $scope.isActive = function (viewLocation) {        
        return viewLocation === $location.path();
    };


    if (sessionStorage.getItem('authenticated') == 'true') {
        $rootScope.authenticated = true;
       
    } else {
        $rootScope.authenticated = false;
        $rootScope.username = "";
        $rootScope.accountID = "";
    }

    $scope.logout = function () {
        alert("logged out")
        $rootScope.authenticated = false;
        $rootScope.username = "";
        $rootScope.accountID = "";
        sessionStorage.removeItem('authenticated');
        sessionStorage.removeItem('accountID');
    }

}]);


//
// Use the following code for running with authentication.
//
//'use strict';
//angular.module('todoApp')
//.controller('homeCtrl', ['$scope', 'adalAuthenticationService','$location', function ($scope, adalService, $location) {
//    $scope.login = function () {
//        adalService.login();
//    };
//    $scope.logout = function () {
//        adalService.logOut();
//    };
//    $scope.isActive = function (viewLocation) {        
//        return viewLocation === $location.path();
//    };
//}]);
