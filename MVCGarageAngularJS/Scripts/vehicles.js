(function () {
    var app = angular.module("vehicles", []);

    app.controller("vehicleController", ['$scope', '$http', function ($scope, $http) {
        $scope.data = "This will contain data";

        $scope.getVehicle = getVehicle;
        $scope.getVehicles = getVehicles;
        $scope.sendData = sendData;

        $scope.vehicle = { ID: 0,  RegistrationPlate: ""};

        function getVehicles() {
            $http.get("/api/vehiclesAPI/get")
            .then(function (response) {
                $scope.data = response.data;
                debugger;
            });
        }

        function getVehicle(id) {
            $http.get("/api/vehiclesAPI/get?id=" + id)
            .then(function (response) {
                $scope.vehicleType = response.data;
            });
        }

        function sendData() {
            $http.post("/api/vehiclesAPI/post", JSON.stringify($scope.vehicleType))
            .then(function (response) {
                var tmp = angular.copy($scope.vehicleType);
                $scope.data.push(tmp);
                $scope.vehicle.Owner = undefined;
                $scope.vehicle.VehicleType = undefined;
                $scope.vehicle.CheckIns = undefined;

            });
        }
    }]);
}());