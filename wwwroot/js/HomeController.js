var app = angular.module('Homeapp', []);

app.controller("HomeController", ['$scope', '$http', function ($scope, $http) {
    $scope.btntext = "Save";
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..."
        $http({
            url: "/Home/RegisterUser",
            method: 'POST',
            data: //$httpParamSerializerJQLike($scope.registration), // $httpParamSerializerJQLike change post data from JSON to string
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).then(function () {
            alert('Data Submitted...!');

        }, function () {

            alert('Failed');

        });
    }
}]);
