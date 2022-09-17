var app = angular.module('homeapp', []);

app.controller("homeController", function ($scope, $http) {

    angular.element(document).ready(function () {
        $scope.GetUserList();
        $scope.GetCategoryList();
        $scope.GetArticleList();
    });

    $scope.GetUserList = function () {
        $http({
            method: "POST",
            url: "/Home/GetUserList",

        }).then(function (d) {
            $scope.UserList = d.data;
        });
    }

    $scope.GetCategoryList = function () {
        $http({
            method: "POST",
            url: "/Home/GetCategoryList",
        }).then(function (d) {
            $scope.CategoryList = d.data;
        });
    }

    $scope.GetArticleList = function () {
        $http({
            method: "POST",
            url: "/Home/GetArticleList",
        }).then(function (d) {
            $scope.ArticleList = d.data;
        });
    }
})