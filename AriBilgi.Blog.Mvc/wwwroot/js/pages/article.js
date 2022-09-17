var app = angular.module('articleapp', []);

app.controller("articleController", function ($scope, $http) {

    angular.element(document).ready(function () {
        $scope.GetCategoryList();
    });

    $scope.AddArticle = function () {
        $http({
            method: "POST",
            url: "/Article/AddArticle",
            data: $scope.Article
        }).then(function (d) {
            if (d.data) {
                alert("Makale başarıyla eklendi");
            } else {
                alert("Makale eklenemedi");
            }
        });
    }


    $scope.GetCategoryList = function () {
        $http({
            method: "POST",
            url: "/Article/GetCategoryList",
        }).then(function (d) {
            $scope.CategoryList = d.data;
        });
    }



});