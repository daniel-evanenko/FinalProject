var myApp = angular.module('myApp', []);
myApp.controller('GreetingController', ['$scope', function ($scope) {
    $scope.greeting = 'Hola!';
    $scope.btntext = "Save";
    $scope.savedata = function () {
        $scope.btntext = "Data Submited...";
    }
}]);