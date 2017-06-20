(function () {
    var app = angular.module("vehicles", []);

    app.controller("vehicleController", ['$scope', '$http', '$window', function ($scope, $http, $window) {
        $scope.data = "This will contain data";

        $scope.getVehicle = getVehicle;
        $scope.getVehicles = getVehicles;
        $scope.getOwner = getOwner;
        $scope.getOwners = getOwners;
        $scope.getVehicleTypes = getVehicleTypes;
        $scope.createVehicle = createVehicle;
        $scope.editVehicle = editVehicle;
        $scope.deleteVehicle = deleteVehicle;

        vehicleType = {
            ID: 0,
            Type: undefined,
            Fee: 0
        }

        owner = {
            ID: 0,
            Fname: "",
            Lname: "",
            Gender: "",
            LicenseNumber: ""
        }

        $scope.vehicle = { ID: 0, RegistrationPlate: "", Owner: undefined, VehicleType: undefined, };
        $scope.owner = owner;
        $scope.vehicleType = vehicleType;

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
                });
        }

        function getOwner(id) {
            $http.get("api/ownersAPI/get?id=" + id)
            .then(function (response) {
                $scope.owner = response.data;
                debugger;
            });
        }

        function getVehicleTypes() {
            $http.get("/api/vehicleTypesAPI/get")
                .then(function (response) {
                    $scope.vehicleTypes = response.data;
                    debugger;
                });
        }
        function createVehicle() {
            $scope.vehicle.VehicleTypeID = $scope.selectedVehicleType;
            $scope.vehicle.OwnerID = $scope.selectedOwner;
            $scope.vehicle.RegistrationPlate = $scope.vehicleRegistrationPlate;
            $http.post("/api/vehiclesAPI/post", JSON.stringify($scope.vehicle))
            .then(function (response) {
                $window.location.href = "/Vehicles/Index";
            });
        }

        function editVehicle(id) {
            var data = $.param({
                id: parseInt(id),
                ownerID: parseInt($scope.vehicle.OwnerID),
                vehicleTypeID: parseInt($scope.vehicle.VehicleTypeID),
                regNum: $scope.vehicle.RegistrationPlate
            });
            $http.put("/api/vehiclesAPI/put?" + data)
                .then(function (response) {
                    $window.location.href = "/Vehicles/Index";
                });
        }

        function deleteVehicle(id) {
            $http.delete("/api/vehicleAPI/delete?id=" + id)
                .then(function (response) {
                    $window.location.href = "/Vehicles/Index";
                })
        }
    }]);
}());