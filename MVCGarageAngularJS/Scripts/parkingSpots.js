(function () {
    var app = angular.module("parkingSpots", []);

    app.controller("parkingSpotsController", ['$scope', '$http', '$window', function ($scope, $http, $window) {
        $scope.data = "This will contain data";

        $scope.getParkingSpots= getParkingSpots;
        $scope.getParkingSpot = getParkingSpot;
        $scope.createParkingSpot = createParkingSpot;
        $scope.edit = editParkingSpot;
        $scope.delete = deleteParkingSpot;

        $scope.parkingSpot = { ID: 0, Label: undefined };

        function getParkingSpots() {
            $http.get("/api/parkingSpotsAPI/get")
                .then(function (response) {
                    $scope.data = response.data;
                });
        }

        function getParkingSpot(id) {
            $http.get("/api/parkingSpotsAPI/get?id=" + id)
                .then(function (response) {
                    $scope.parkingSpot = response.data;
                });
        }

        function createParkingSpot() {
            $http.post("/api/parkingSpotsAPI/post", JSON.stringify($scope.parkingSpot))
                .then(function (response) {
                    $scope.parkingSpot.Label = undefined;

                    $window.location.href = "/ParkingSpots/Index";
                });
        }

        function editParkingSpot(id) {
            debugger;
            var data = $.param({
                id: parseInt(id),
                label: $scope.parkingSpot.Label
            });
            $http.put("/api/parkingSpotsAPI/put?" + data)
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
                    $window.location.href = "/ParkingSpots/Index";
                });
            //{
            //        debugger;
            //        $scope.parkingSpot.Type = undefined;
            //        $scope.parkingSpot.Fee = undefined;

            //        $window.location.href = "/ParkingSpot/Index";
            //    });
        }

        function deleteParkingSpot(id) {
            $http.delete("/api/parkingSpotsAPI/delete?id=" + id)
                .then(function (response) {
                    $window.location.href = "/ParkingSpots/Index";
                });
        }
    }]);
}());