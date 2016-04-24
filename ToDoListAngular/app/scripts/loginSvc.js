'use strict';
angular.module('todoApp')
.factory('loginSvc', ['$http', function ($http) {

    $http.defaults.useXDomain = true;
    delete $http.defaults.headers.common['X-Requested-With'];

    return {
        getAuth: function (credentials) {
            return $http.get(apiEndpoint + '/api/ACCOUNTs/GetACCOUNTAuthentication?accountID=' + credentials.accountID + "&password=" + credentials.password);
        },
        getPayment: function (id) {
            return $http.get(apiEndpoint + '/api/ACCOUNTs/GetACCOUNTInfoDetails?id=' + id);
        },
        postAccount: function (account) {
            return $http.post(apiEndpoint + '/api/ACCOUNTs/PostACCOUNT', account);
        },
        putItem: function (item) {
            return $http.put(apiEndpoint + '/api/DENTISTs/PutDENTIST', item);
        },
        deleteItem: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/DENTISTs/DeleteDENTIST' + id
            });
        },
        getAccountPatients: function (accountID) {
            return $http.get(apiEndpoint + '/api/ACCOUNTs/GetPATIENTs?accountID=' + accountID);
        },
        postPatient: function (patient) {
            return $http.post(apiEndpoint + '/api/ACCOUNTs/PostPATIENT', patient);
        },
        deletePatient: function (id) {
            return $http({
                method: 'DELETE',
                url: apiEndpoint + '/api/ACCOUNTs/DeletePATIENT?id=' + id
            });
        }
    };
}]);