/// <reference path="~/Scripts/angular.js" />
/// <reference path="../../services/appSession.js" />
/// <reference path="~/Scripts/jquery-2.1.4.js" />

(function () {
    var controllerId = 'app.views.account.profile';
    angular.module('app').controller(controllerId, [
        '$scope', '$window', '$http', function ($scope, $window, $http) {
            var vm = this;
            
            $scope.accountData = null;

            $scope.getData = function () {
                vm.getById().then(function (d) {
                    $scope.accountData = d;
                });
            }

            vm.getById = function () {
                return $http.get('/api/account/profileInfo').then(function (res) {
                    return res.data;
                });
            }

            $scope.getData();
        }
    ]);
})();