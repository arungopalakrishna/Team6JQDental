'use strict';
angular.module('todoApp')
.controller('loginCtrl', ['$rootScope', '$scope',  '$location', 'loginSvc', function ($rootScope, $scope,  $location, loginSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();

    };

    $scope.credentials = {};
    $scope.update = function (credentials) {
        $scope.credentials = angular.copy(credentials);
    };

    $scope.init = function () {
        authenticate();
    }

    var authenticate = function (credentials) {

        if (sessionStorage.getItem('authenticated') == 'true') {
            $location.path('/#Home');
        } else {
            loginSvc.getAuth($scope.credentials).success(function (results) {
                if (results.includes('good')) {
                    $rootScope.authenticated = true;
                    $rootScope.accountID = $scope.credentials.accountID;
                    sessionStorage.setItem('authenticated', 'true');
                    sessionStorage.setItem('accountID', $rootScope.accountID);
                    $location.path('/#Home');
                } else {

                }
            });
        }
    }


    $scope.login = function () {
        authenticate();
    };

}]);