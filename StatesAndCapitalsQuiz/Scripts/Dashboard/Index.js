var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    $scope.questions;

    $scope.ChangeVal = function () {
        let questions = document.getElementById("questions").getElementsByTagName('li');

        for (let i = 0; i < questions.length; i++) {
            $scope.responses.push({
                id: questions[i].getElementsByTagName('input')[0].id,
                question: questions[i].getElementsByTagName('input')[0].name,
                assert: questions[i].getElementsByTagName('input')[0].value
            })
        }
    }

    $scope.GetStates = function () {
        var actionUrl = 'https://localhost:44339/Dashboard/getStates';
        $http.get(actionUrl)
            .then(function (result) {
                $scope.questions = result.data;
            })
    }

    $scope.SendResponses = function () {
        let request = [];
        let questions = document.getElementById("questions").getElementsByTagName('li');

        for (let i = 0; i < questions.length; i++) {
            request.push({
                state: questions[i].getElementsByTagName('input')[0].id,
                capital: questions[i].getElementsByTagName('input')[0].value
            })
        }

        var req = {
            method: 'POST',
            url: 'https://localhost:44339/Dashboard/SendResponses',
            headers: {},
            data: { request: request, TotalQuestions: questions.length }
        }

        $http(req).then(response => {
            if (response.data.result) {
                alert("Result have been saved, Grad: " + response.data.data);
                $scope.GetStates();
            };
        });


    }
});
