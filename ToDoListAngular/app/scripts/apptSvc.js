'use strict';
angular.module('todoApp')
.factory('apptSvc', ['$http', function ($http) {

    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        getPatients: function (accountID) {
            return $http.get(apiEndpoint + '/api/APPOINTMENTs/GetAPPOINTMENTPatients?accountID=' + accountID);
        },
        getServices: function () {
            return $http.get(apiEndpoint + '/api/APPOINTMENTs/GetAPPOINTMENTServices');
        },
        getDentists: function () {
            return $http.get(apiEndpoint + '/api/DENTISTs/GetDentists');
        },
        putAppointment: function (appointment) {
            return $http.put(apiEndpoint + '/api/APPOINTMENTs/PutAPPOINTMENT', appointment);
        },
        
        postItem: function (appointment) {
            return $http.post(apiEndpoint + '/api/APPOINTMENTs/PostAPPOINTMENT', appointment);
        },

        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/APPOINTMENTs/DeleteAPPOINTMENT?id=' + id
            });
        },
        getAppointments: function (accountID) {
            return $http.get(apiEndpoint + '/api/APPOINTMENTs/GetAPPOINTMENTsByPatient?accountID=' + accountID);
        }
    };
}]);