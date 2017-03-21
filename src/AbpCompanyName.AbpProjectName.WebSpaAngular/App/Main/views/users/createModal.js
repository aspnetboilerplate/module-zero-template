(function () {
    angular.module('app').controller('app.views.users.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.user',
        function ($scope, $uibModalInstance, userService) {
            var vm = this;

            vm.user = {
                isActive: true
            };

            vm.save = function () {
                userService.createUser(vm.user)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };
        }
    ]);
})();