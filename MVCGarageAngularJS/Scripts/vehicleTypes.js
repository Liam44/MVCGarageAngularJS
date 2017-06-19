(function () {
    var app = angular.module("vehicleTypes", []);

    app.controller("vehicleTypesController", ['$scope', '$http', function ($scope, $http) {
        $scope.data = "This will contain data";

        $scope.getData = getData;
        $scope.sendData = sendData;

        function getData() {
            $http.get("/api/vehicleTypesAPI/get")
            .then(function (response) {
                $scope.data = response.data
            });
        }

        $scope.vehicleType = { ID: 0, Type: "", Fee: 0 };

        function sendData() {
            $http.post("/api/vehicleTypesAPI/post", JSON.stringify($scope.vehicleType))
            .then(function (response) {
                var tmp = angular.copy($scope.vehicleType);
                $scope.data.push(tmp);
                $scope.vehicleType.Type = undefined;
                $scope.vehicleType.Fee = undefined;
            });
        }
    }]);
}());