var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    $scope.questions;
    $scope.quantity = 10;
    $scope.q = 10;

    // Method to get list of states to display on screen.
    $scope.GetStates = function () {

        $scope.q = document.getElementById("quantity").value;
        if ($scope.q > 0) {
            $scope.quantity = $scope.q;
        } else {
            if ($scope.q < 1) {
                alert("Quantity must be greater than 0.");
                return;
            }
        }
        var req = {
            method: 'POST',
            url: 'https://localhost:44339/Dashboard/getStates',
            headers: {},
            data: { q: $scope.quantity }
        }
        $http(req).then(result => {
            $scope.questions = result.data;
        });
    }

    // Method to send response to controller and validate questions and return Correct answers.
    $scope.SendResponses = function () {
        let request = [];
        let questions = document.getElementById("questions").getElementsByTagName('li');

        for (let i = 0; i < questions.length; i++) {
            request.push({
                state: questions[i].getElementsByTagName('input')[0].id,
                capital: questions[i].getElementsByTagName('input')[0].value
            })
        }

        for (let i = 0; i < questions.length; i++) {
            capital: questions[i].getElementsByTagName('input')[0].value = "";
        }

        var req = {
            method: 'POST',
            url: 'https://localhost:44339/Dashboard/SendResponses',
            headers: {},
            data: { request: request, TotalQuestions: questions.length }
        }

        $http(req).then(response => {
            if (response.data.result) {
                alert("Result have been saved, Grad: " + response.data.data + "/" + questions.length + ".");
                $scope.GetStates();
            };
        });


    }
});
