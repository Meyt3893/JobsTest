
var myapp = angular.module("myapp", ['ngRoute']);

myapp.controller("homeController", ['$scope', '$http',function ($scope, $http) {
 
   
    
    $scope.search = function (inSearch) {
        $scope.inSearch = inSearch;
        $http({
            method: "GET",
            url: "http://localhost:59836/api/Jobs/searchjobs/" + $scope.inSearch

        }).then(function Success(response) {

            $scope.jobs = JSON.parse(response.data);       

        }, function Error(response) {
                alert(response.statusText);
        });

    };

    
   

}]);