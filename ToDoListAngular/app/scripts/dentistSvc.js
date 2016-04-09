'use strict';
angular.module('todoApp')
.factory('dentistSvc', ['$http', function ($http) {

    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        getItems: function () {
            return $http.get(apiEndpoint + '/api/DENTISTs');
        },
        getItem: function (id) {
            return $http.get(apiEndpoint + '/api/DENTISTs/' + id);
        },
        postItem: function (item) {
            return $http.post(apiEndpoint + '/api/DENTISTs', item);
        },
        putItem: function (item) {
            return $http.put(apiEndpoint + '/api/DENTISTs/', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/DENTISTs/' + id
            });
        }
    };
}]);