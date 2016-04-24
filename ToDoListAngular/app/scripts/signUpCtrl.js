'use strict';
angular.module('todoApp')
.controller('signUpCtrl', ['$rootScope', '$scope', '$location', 'loginSvc', function ($rootScope, $scope, $location, loginSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };

    $scope.account = {};
    $scope.update = function (account) {
        $scope.account = angular.copy(account);
    };

    $scope.signUp = function () {
        loginSvc.postAccount($scope.account).success(function (results) {
            if (results.includes('good')) {
                $location.path('/#Home');
            } else {

            }
        });
    };

}]);