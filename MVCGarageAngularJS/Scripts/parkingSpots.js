(function () {
    var app = angular.module("parkingSpots", []);

    app.controller("parkingSpotsController", ['$scope', '$http', '$window', function ($scope, $http, $window) {
        $scope.data = "This will contain data";

        $scope.getParkingSpots = getParkingSpots;
        $scope.getParkingSpot = getParkingSpot;
        $scope.createParkingSpot = createParkingSpot;
        $scope.edit = editParkingSpot;
        $scope.delete = deleteParkingSpot;
        $scope.selectAParkingSpot = selectAParkingSpot;

        $scope.getAvailableParkingSpots = getAvailableParkingSpots;

        $scope.parkingSpot = { ID: 0, Label: undefined };

        function getParkingSpots() {
            $http.get("/api/parkingSpotsAPI/getparkingspots")
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
                .then(function (response) {
                    $window.location.href = "/ParkingSpots/Index";
                });
        }

        function deleteParkingSpot(id) {
            $http.delete("/api/parkingSpotsAPI/delete?id=" + id)
                .then(function (response) {
                    $window.location.href = "/ParkingSpots/Index";
                });
        }

        function getAvailableParkingSpots(vehicleId, checkIn) {
            $http.get("/api/parkingSpotsAPI/getAvailableParkingSpots?vehicleId=" + vehicleId + "&checkIn=" + (checkIn == 0 ? true : false))
                .then(function (response) {
                    $scope.parkingSpots = response.data.ParkingSpots;
                    $scope.selectedVehicle = response.data.SelectedVehicle;
                });
        }

        $scope.selectedParkingSpotID = 0;

        function selectAParkingSpot() {
            $http.post("/api/parkingSpotsAPI/selectAParkingSpot?vehicleId=" + parseInt($scope.selectedVehicle.ID) + "&parkingSpotId=" + parseInt($scope.selectedParkingSpotID))
                .then(function (response) {
                    $window.location.href = "/ParkingSpots/Index";
                })
                .catch(function (error) {
                    $scope.error = error.statusText;
                });
        }
    }]);
}());