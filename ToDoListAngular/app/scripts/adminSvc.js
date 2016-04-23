'use strict';
angular.module('todoApp')
.factory('adminSvc', ['$http', function ($http) {

    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        getApptList: function () {
            return $http.get(apiEndpoint + '/api/APPOINTMENTs/GetAPPOINTMENTsForToday');
        },
        putPayment: function (payment) {
            return $http.put(apiEndpoint + '/api/ACCOUNTs/PutACCOUNTPayment', payment);
        },
        getDentists: function () {
            return $http.get(apiEndpoint + '/api/DENTISTs/GetDentists');
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/DENTISTs/DeleteDENTIST' + id
            });
        }
    };
}]);