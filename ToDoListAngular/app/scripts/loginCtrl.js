'use strict';
angular.module('todoApp')
.controller('loginCtrl', [ '$rootScope', '$scope', '$location', 'loginSvc', function ($rootScope, $scope, $location, loginSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };
    //alert($rootScope.testVar);

    $rootScope.authenticated = true;
    $rootScope.accountID = 1;

    var authenticate = function (credentials, callback) {

        var headers = credentials ? {
            authorization: "Basic "
                + btoa(credentials.username + ":" + credentials.password)
        } : {};

        $http.get('user', { headers: headers }).success(function (data) {
            if (data.name) {
                $rootScope.authenticated = true;
            } else {
                $rootScope.authenticated = false;
            }
            callback && callback();
        }).error(function () {
            $rootScope.authenticated = false;
            callback && callback();
        });

    }

    authenticate();
    $scope.credentials = {};
    $scope.login = function () {
        authenticate($scope.credentials, function () {
            if ($rootScope.authenticated) {
                $location.path("/");
                $scope.error = false;
            } else {
                $location.path("/login");
                $scope.error = true;
            }
        });
    };

}]);