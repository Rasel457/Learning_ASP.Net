app.controller("posts",function($scope,$http){
    $scope.fname = "Rasel";
    $http.get("https://jsonplaceholder.typicode.com/posts").
    then(function(response){
        $scope.posts=response.data;
    })
});