(function () {
    var app = angular.module("vehicleTypes", []);

    app.controller("vehicleTypesController", ['$scope', '$http', '$window', function ($scope, $http, $window) {
        $scope.data = "This will contain data";

        $scope.getVehicleType = getVehicleType;
        $scope.getVehicleTypes = getVehicleTypes;
        $scope.createVehicleType = createVehicleType;
        $scope.edit = editVehicleType;
        $scope.delete = deleteVehicleType;

        $scope.vehicleType = { ID: 0, Type: undefined, Fee: 0 };

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

        function createVehicleType() {
            $http.post("/api/vehicleTypesAPI/post", JSON.stringify($scope.vehicleType))
                .then(function (response) {
                    $scope.vehicleType.Type = undefined;
                    $scope.vehicleType.Fee = undefined;

                    $window.location.href = "/VehicleTypes/Index";
                });
        }

        function editVehicleType(id) {
            debugger;
            var data = $.param({
                id: parseInt(id),
                type: $scope.vehicleType.Type,
                fee: parseFloat($scope.vehicleType.Fee.replace(",", "."))
            });
            $http.put("/api/vehicleTypesAPI/put?" + data)
                .success(function (data, status, headers) {
                    $scope.ServerResponse = data;
                })
                .error(function (data, status, header, config) {
                    $scope.ServerResponse = htmlDecode("Data: " + data +
                        "\n\n\n\nstatus: " + status +
                        "\n\n\n\nheaders: " + header +
                        "\n\n\n\nconfig: " + config);
                })
                .then(function (response) {
                    $window.location.href = "/VehicleTypes/Index";
                })
                ;
            //{
            //        debugger;
            //        $scope.vehicleType.Type = undefined;
            //        $scope.vehicleType.Fee = undefined;

            //        $window.location.href = "/VehicleTypes/Index";
            //    });
        }

        function deleteVehicleType(id) {
            $http.delete("/api/vehicleTypesAPI/delete?id=" + id)
                .then(function (response) {
                    debugger;
                    $window.location.href = "/VehicleTypes/Index";
                });
        }
    }]);
}());