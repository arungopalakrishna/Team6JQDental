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
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/APPOINTMENTs/PostAPPONTMENT', item);
        },
        putItem: function (item) {
            return $http.put(apiEndpoint + '/api/APPOINTMENTs/PutDENTIST', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/APPOINTMENTs/DeleteDENTIST' + id
            });
        }
    };
}]);