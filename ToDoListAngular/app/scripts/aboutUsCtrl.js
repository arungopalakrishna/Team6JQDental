'use strict';
angular.module('todoApp')
.controller('aboutUsCtrl', ['$scope', '$location', 'dentistSvc', function ($scope, $location, dentistSvc) {
    $scope.error = "";
    $scope.loadingMessage = "Loading...";
    $scope.dentistList = null;
    $scope.editingInProgress = false;
    $scope.newTodoCaption = "";


    $scope.editInProgressTodo = {
        Description: "",
        ID: 0
    };

    $scope.populate = function () {
        dentistSvc.getItems().success(function (results) {
            $scope.dentistList = results;
            $scope.loadingMessage = "";
        }).error(function (err) {
            $scope.error = err;
            $scope.loadingMessage = "";
        })
    };

}]);