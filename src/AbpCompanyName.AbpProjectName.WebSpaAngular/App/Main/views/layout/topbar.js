(function () {
    var controllerId = 'app.views.layout.topbar';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;
            vm.languages = [];
            vm.currentLanguage = {};

            function init() {
                vm.languages = abp.localization.languages;
                vm.currentLanguage = abp.localization.currentLanguage;
            }

            vm.changeLanguage = function (languageName) {
                abp.utils.setCookieValue(
                    "Abp.Localization.CultureName",
                    languageName,
                    new Date(new Date().getTime() + 5 * 365 * 86400000), //5 year
                    abp.appPath
                );

                location.reload();
            }

            init();

        }
    ]);
})();