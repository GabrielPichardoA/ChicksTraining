var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {

    // Method to print screen.
    $scope.Print = function () {
        window.print()
    }

});