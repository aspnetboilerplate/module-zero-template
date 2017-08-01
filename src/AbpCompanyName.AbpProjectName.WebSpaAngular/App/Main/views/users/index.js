(function() {
    angular.module('app').controller('app.views.users.index', [
        '$scope', '$uibModal', 'abp.services.app.user',
        function ($scope, $uibModal, userService) {
            var vm = this;

            vm.users = [];

            function getUsers() {
                userService.getAll({}).then(function (result) {
                    vm.users = result.data.items;
                });
            }

            vm.openUserCreationModal = function() {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/users/createModal.cshtml',
                    controller: 'app.views.users.createModal as vm',
                    backdrop: 'static'
                });
                
                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getUsers();
                });
            };

            vm.openUserEditModal = function (user) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/users/editModal.cshtml',
                    controller: 'app.views.users.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return user.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getUsers();
                });
            };

            getUsers();
        }
    ]);
})();