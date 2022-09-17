var app = angular.module('userapp', []);

app.controller("userController", function ($scope, $http) {

    angular.element(document).ready(function () {
        $scope.GetUserRoleList();
    });

    $scope.AddUser = function () {
        $http({
            method: "POST",
            url: "/User/AddUser",
            data: $scope.User
        }).then(function (d) {
            if (d.data) {
                alert("Kullanıcı başarıyla eklendi");
            } else {
                alert("Kullanıcı eklenemedi");
            }
        });
    }

    $scope.GetUserRoleList = function () {
        $http({
            method: "POST",
            url: "/User/GetUserRoleList",
        }).then(function (d) {
            $scope.UserRoleList = d.data;
        });
    }


});