(function () {
    var app = angular.module("vehicleTypes", []);

    app.controller("vehicleTypesController", ['$scope', '$http', function ($scope, $http) {
        $scope.data = "This will contain data";

        $scope.getVehicleType = getVehicleType;
        $scope.getVehicleTypes = getVehicleTypes;
        $scope.sendData = sendData;

        $scope.vehicleType = { ID: 0, Type: "", Fee: 0 };

        function getVehicleTypes() {
            $http.get("/api/vehicleTypesAPI/get")
            .then(function (response) {
                $scope.data = response.data;
            });
        }

        function getVehicleType(id) {
            $http.get("/api/vehicleTypesAPI/get?id=" + id)
            .then(function (response) {
                $scope.vehicleType = response.data;
            });
        }

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