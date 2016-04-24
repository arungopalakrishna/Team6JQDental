'use strict';
angular.module('todoApp')
.controller('apptCtrl', ['$rootScope', '$scope', '$location', 'apptSvc', function ($rootScope, $scope, $location, apptSvc) {
    $scope.isActive = function (viewLocation) {
        return viewLocation === $location.path();
    };

    $scope.appointment = {};

    $scope.serviceList = null;
    $scope.patientList = null;
    $scope.accountID = sessionStorage.getItem('accountID');

    $scope.populate = function () {
        $scope.accountID = sessionStorage.getItem('accountID');
        apptSvc.getServices().success(function (results) {
            $scope.serviceList = results;
        });

        apptSvc.getPatients($scope.accountID).success(function (results) {
            $scope.patientList = results;
        });

        apptSvc.getDentists().success(function (results) {
            $scope.dentistList = results;
        });

        apptSvc.getAppointments($scope.accountID).success(function (results) {
            $scope.appointmentList = results;
        });
    };

    $scope.update = function (appointment) {
        $scope.appointment.Appointment_Date = appointment.Appointment_Date;
        $scope.appointment.Appointment_Time = appointment.Appointment_Date;
    };

    $scope.schedule = function () {
        $scope.appointment.Appointment_Time = $scope.appointment.Appointment_Date;
        apptSvc.putAppointment($scope.appointment).success(function (results) {
            apptSvc.getAppointments($scope.accountID).success(function (results) {
                $scope.appointmentList = results;
                $scope.sheduleSuccess = "Succesfully Scheduled";
            })
        })
    };

    $scope.changedPatient = function (patient) {
        $scope.appointment.Patient_ID = patient;
    }

    $scope.changedDentist = function (dentist) {
        $scope.appointment.Dentist_ID = dentist;
    }

    $scope.changedService = function (services) {
        $scope.appointment.ScheduledServiceIDs = services;
    }

    $scope.removeAppointment = function (id) {
        apptSvc.deleteItem(id).success(function () {
            apptSvc.getAppointments($scope.accountID).success(function (results) {
                $scope.appointmentList = results;
            })
        });
    };

    $scope.saveAppointment = function (appointment) {
        apptSvc.postItem(appointment).success(function () {
            apptSvc.getAppointments($scope.accountID).success(function (results) {
                $scope.appointmentList = results;
            })
        });
    };
}]);