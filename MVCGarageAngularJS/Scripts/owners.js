(function () {
    var app = angular.module("owners", []);

    app.controller("ownersController", ['$scope', '$http', function ($scope, $http) {
        $scope.data = "This will contain data";

        owner = {
            ID: 0,
            Fname: "",
            Lname: "",
            Gender: "",
            LicenseNumber: ""
        }

        $scope.getOwner = getOwner;
        $scope.getOwners = getOwners;
        $scope.sendData = sendData;
        $scope.owner = owner;

        function getOwners() {
            $http.get("/api/ownersAPI/get")
        }


    }]);
})();