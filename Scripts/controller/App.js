var app = angular.module('app', []);

app.controller('CrowdCorrectController', ['$scope', '$http', function ($scope, $http) {
    $scope.count = 0;
    $http({
        method: 'GET',
        url: '/api/CrowdCorrectTasks?nextSuggestion=false'
    }).then(function (success) {
        $scope.tweet = success.data;
    }, function (error) {

    });
    $scope.init = function () {
        $scope.count = 1;
    };

    $scope.Submit = function () {
        $scope.count = $scope.count + 1;
    };

}]);