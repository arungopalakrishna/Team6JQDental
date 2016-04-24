'use strict';
angular.module('todoApp')
.controller('myAcctCtrl', ['$rootScope', '$scope', '$location', 'loginSvc', function ($rootScope, $scope, $location, loginSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };
}]);