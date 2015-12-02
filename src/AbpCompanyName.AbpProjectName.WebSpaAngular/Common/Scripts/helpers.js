var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('AbpProjectName');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);