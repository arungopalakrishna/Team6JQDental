'use strict';
angular.module('todoApp')
.controller('myAcctCtrl', ['$rootScope', '$scope', '$location', 'loginSvc', function ($rootScope, $scope, $location, loginSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };

    $scope.accountInfo = {};
    var id = sessionStorage.getItem('accountID');
    $scope.populate = function () {
        loginSvc.getPayment(id).success(function (results) {
            $scope.accountInfo.FirstName = results.FirstName;
            $scope.accountInfo.Account_Balance = results.Account_Balance;
            $scope.accountInfo.Last_Payment = results.Last_Payment;
            $scope.accountInfo.Remaining_Balance = results.Remaining_Balance;
        });

        loginSvc.getAccountPatients($scope.accountID).success(function (results) {
            $scope.patientsList = results;
        });
    }

    $scope.patientsList = null;
    $scope.accountID = sessionStorage.getItem('accountID');

    $scope.savePatient = function (patient) {
        loginSvc.postPatient(patient).success(function () {
            $scope.populate();
        });
    };
    $scope.removePatient = function (id) {
        loginSvc.deletePatient(id).success(function () {
            $scope.populate();
        });
    };

}]);