var app = angular.module('categoryapp', []);

app.controller("categoryController", function ($scope, $http) {

    angular.element(document).ready(function () {
       
    });

    $scope.AddCategory = function () {
        $http({
            method: "POST",
            url: "/Category/AddCategory",
            data: $scope.Category
        }).then(function (d) {
            if (d.data) {
                alert("Kategori başarıyla eklendi");
            } else {
                alert("Kategori eklenemedi");
            }
        });
    }

   


});