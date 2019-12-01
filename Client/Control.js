
var myapp = angular.module("myapp", ['ngRoute']);

myapp.controller("homeController", ['$scope', '$http',function ($scope, $http) {
 
    $scope.hidethis = true;
    $scope.complete = function (input) {
        $scope.hidethis = false;
  
        $http({
            method: "GET",
            url: "http://localhost:59836/api/Jobs/autocomp/" + input

        }).then(function Success(response) {

            $scope.complist = JSON.parse(response.data);
            console.log(response.data);

        }, function Error(response) {
    
        });

    }
    $scope.fillTextbox = function (string) {
        $scope.inSearch = string;
        $scope.hidethis = true;
    }  
 
    $scope.search = function (inSearch) {
        $scope.inSearch = inSearch;
        $scope.hidethis = true;
        $http({
            method: "GET",
            url: "http://localhost:59836/api/Jobs/searchjobs/" + $scope.inSearch

        }).then(function Success(response) {

            $scope.jobs = JSON.parse(response.data);       
            console.log(response.data);

        }, function Error(response) {
                alert(response.statusText);
        });

    };


    
   

}]);
