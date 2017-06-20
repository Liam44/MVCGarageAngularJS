(function () {
    var app = angular.module("vehicles", []);

    app.controller("vehicleController", ['$scope', '$http', function ($scope, $http) {
        $scope.data = "This will contain data";

        $scope.getVehicle = getVehicle;
        $scope.getVehicles = getVehicles;
        $scope.getOwner = getOwner;
        $scope.getOwners = getOwners;
        $scope.sendData = sendData;

        owner = {
            ID: 0,
            Fname: "",
            Lname: "",
            Gender: "",
            LicenseNumber: ""
        }

        $scope.vehicle = { ID: 0, RegistrationPlate: "" };
        $scope.owner = owner;  

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
                $scope.vehicle = response.data;
            });
        }

        function getOwners() {
            $http.get("/api/ownersAPI/get")
                .then(function (response) {
                    $scope.ownerData = response.data;
                    debugger;
                });
        }

        function getOwner(id) {
            $http.get("api/ownersAPI/get?id=" + id)
            .then(function (response) {
                $scope.owner = response.data;
                debugger;
            });
        }

        function sendData() {
            $http.post("/api/vehiclesAPI/post", JSON.stringify($scope.vehicle))
            .then(function (response) {
                
            });
        }
    }]);
}());