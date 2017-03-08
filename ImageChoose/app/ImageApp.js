var ImageApp = angular.module('ImageApp', ["ngRoute"]);

ImageApp.config(function ($routeProvider,$locationProvider) {
    $routeProvider.when("/Image", {
        templateUrl: 'app/ImageApp/ImageDisplay.html',
        controller: 'ImageController'
    }).otherwise({
        redirectTo:"/Image"
    })
    $locationProvider.html5Mode(true);
});