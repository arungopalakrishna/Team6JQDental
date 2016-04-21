'use strict';
angular.module('todoApp')
.factory('loginSvc', ['$http', function ($http) {

    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        getItems: function () {
            return $http.get(apiEndpoint + '/api/DENTISTs/GetDENTISTs');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/DENTISTs/GetDENTIST' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/DENTISTs/PostDENTIST', item);
        },
        putItem: function (item) {
            return $http.put(apiEndpoint + '/api/DENTISTs/PutDENTIST', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/DENTISTs/DeleteDENTIST' + id
            });
        }
    };
}]);