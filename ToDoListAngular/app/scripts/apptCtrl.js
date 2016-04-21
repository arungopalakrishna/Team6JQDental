'use strict';
angular.module('todoApp')
.controller('apptCtrl', ['$rootScope', '$scope', '$location', 'apptSvc', function ($rootScope, $scope, $location, apptSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };

    $scope.serviceList = null;
    $scope.patientList = null;
    $scope.accountID = $rootScope.accountID;

    $scope.populate = function (){
        apptSvc.getServices().success(function (results) {
            $scope.serviceList = results;
            // alert($scope.serviceList[0].ServiceName);
        });

        apptSvc.getPatients($scope.accountID).success(function (results) {
            $scope.patientList = results;
           // alert($scope.patientList[0].Patient_First_Name);
        })
    };

    $scope.schedule = function () {
        alert($scope.patient.Patient_First_Name);
        event.preventDefault();
    };



}]);