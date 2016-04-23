'use strict';
angular.module('todoApp')
.controller('apptCtrl', ['$rootScope', '$scope', '$location', 'apptSvc', function ($rootScope, $scope, $location, apptSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };

    $scope.serviceList = null;
    $scope.patientList = null;
    $scope.accountID = sessionStorage.getItem('accountID');

    $scope.populate = function (){
        apptSvc.getServices().success(function (results) {
            $scope.serviceList = results;
        });

        apptSvc.getPatients($scope.accountID).success(function (results) {
            $scope.patientList = results;
        });

        apptSvc.getDentists().success(function (results) {
            $scope.dentistList = results;
        });
    };

    $scope.schedule = function () {
        
    };

    $scope.changedPatient = function (patient) {
        $scope.selectedPatientID = patient;
    }

    $scope.changedDentist = function (dentist) {
        $scope.selectedDentistID = dentist;
    }

    $scope.changedService = function (services) {
        $scope.selectedServiceList = services;
    }
}]);