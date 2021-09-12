var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    $scope.Print = function () {
        window.print()
    }

});