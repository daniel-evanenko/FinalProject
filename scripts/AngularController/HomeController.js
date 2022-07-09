var app = angular.module('Homeapp', ['ngRoute', 'ngResource']);

app.controller("HomeController", ['$scope', '$http', function ($scope, $http) {
    $scope.btntext = "Save"
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..."
        $http({
            url: "/Home/RegisterUser",
            method: 'POST',
            data: $httpParamSerializerJQLike($scope.registration), // $httpParamSerializerJQLike change post data from JSON to string
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








/*var app = angular.module("Homeapp", []);
app.controller("HomeController", ['$scope', '$http', function ($scope, $http) {
    $scope.btntext = "Save"
    $scope.savedata = function () {
        $scope.btntext ="Please Wait..."
        $http({
            method: 'POST',
            url: '/Home/RegisterUser',
            data: $scope.register
        }).success(function () {
            $scope.register = null;
            alert('Data saved');
        }).error(function () {
            alert('faild');

        });
    }
}]);




var app = null;
var open1 = null;
var oldReady = null;


function do_xhr_sync() {
    (function (open, send) {

        // Closure/state var's
        var xhrOpenRequestUrl;  // captured in open override/monkey patch
        var xhrSendResponseUrl; // captured in send override/monkey patch
        var responseData;       // captured in send override/monkey patch

        //...overrides of the XHR open and send methods are now encapsulated within a closure

        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            xhrOpenRequestUrl = url;     // update request url, closure variable
            async = false;
            arguments[2] = false;
            //alert("open1");
            open.apply(this, arguments); // reset/reapply original open method
        };

        XMLHttpRequest.prototype.send = function (data) {

            //...what ever code you need, i.e. capture response, etc.
            if (this.readyState == 4 && this.status >= 200 && this.status < 300) {
                xhrSendResponseUrl = this.responseURL;
                responseData = this.data;  // now you have the data, JSON or whatever, hehehe!
            }
            send.apply(this, arguments); // reset/reapply original send method
        }

    })(XMLHttpRequest.prototype.open, XMLHttpRequest.prototype.send);

}

/*
 $scope.click_func=function (e1)
                {
                    alert("e1="+e1);
                    alert($(e1.target).html());
                    alert($(e1.target).id);
                    alert("click1");
                };

                $("#gallery_container_div1").attr("ng-click","click_func($event)");
                $compile($("#gallery_container_div1").get(0))($scope); *


function body_on_load() {
    alert("ok1");

    //do_xhr_sync();


    app = angular.module('Homeapp', []);
    alert("ok2");
    app.config(["$routeProvider", "$httpProvider", function ($routeProvider, $httpProvider) {
        // $httpProvider.useApplyAsync(true);
    }]);

    app.controller('HomeController', function ($scope, $http, $httpParamSerializerJQLike) {
        alert("11");
        $scope.doWork = function ($event) {
            //alert("dowork");
            var element = angular.element($event.target);
            //alert(element.attr("name"));
        };

        $scope.signup = function () {
            alert("register1");
            $scope.btntext = "Please wait...!";

            alert("ok1");

            //deferred.promise;
            $http({
                url: "/Home/time_span1",
                method: 'POST',
                data: $httpParamSerializerJQLike($scope.registration), // $httpParamSerializerJQLike change post data from JSON to string
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            }).then(function () {
                alert('Data Submitted...!');

            }, function () {

                alert('Failed');

            });

            $scope.btntext = "data arrive";
            alert("resgister2");
        }

        angular.bootstrap(document, ['Homeapp']);
    }
    )
}
*/