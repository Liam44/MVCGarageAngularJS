(function () {
    var app = angular.module("garage", []);

    app.controller("garageController", ['$scope', '$http', '$window', function ($scope, $http, $window) {
        $scope.data = "This will contain data";

        $scope.getAllVehicles = getAllVehicles;
        $scope.getParkedVehicles = getParkedVehicles;

        function getAllVehicles() {
            $http.get("/api/garageAPI/getAllVehicles")
                .then(function (response) {
                    debugger;
                    $scope.data = response.data;
                });
        }

        function getParkedVehicles() {
            $http.get("/api/garageAPI/getParkedVehicles")
                .then(function (response) {
                    debugger;
                    $scope.data = response.data;
                });
        }
    }]);
}());