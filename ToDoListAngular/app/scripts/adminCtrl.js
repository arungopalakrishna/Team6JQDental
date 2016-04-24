'use strict';
angular.module('todoApp')
.controller('adminCtrl', ['$rootScope', '$scope', '$location', 'adminSvc', function ($rootScope, $scope, $location, adminSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };
    $scope.todayDate = new Date().toLocaleDateString();

    adminSvc.getApptList().success(function (results) {
        $scope.apptList = results;
    });

    adminSvc.getDentists().success(function (results) {
        $scope.dentistList = results;
    });

    $scope.update = function (payment) {
        $scope.payment = angular.copy(payment);
    };

    $scope.processPay = function () {
        adminSvc.putPayment($scope.payment).success(function (results) {
            if (results.includes('good')) {
            } else {

            }
    
        });
    }

}]);