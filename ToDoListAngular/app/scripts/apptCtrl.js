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
        });

        apptSvc.getPatients($scope.accountID).success(function (results) {
            $scope.patientList = results;
        });

        apptSvc.getDentists().success(function (results) {
            $scope.dentistList = results;
        });

       


       // $scope.serviceList = [{ "ServiceID": 1, "ServiceName": "Regular check up" }, { "ServiceID": 2, "ServiceName": "Root Canal" }, { "ServiceID": 3, "ServiceName": "Clean Up" }]
       // $scope.patientList = [{ "Patient_First_Name": "Mark", "Patient_ID": 12 }, { "Patient_First_Name": "Steve", "Patient_ID": 13 }];
       // $scope.dentistList = [{ "DentistID": 1, "FirstName": "Dr. Dan" }, { "DentistID": 2, "FirstName": "Dr. Whelan" }];
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