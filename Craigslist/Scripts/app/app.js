console.log("app loaded");
const app = angular.module("main", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.when("/listings"),{
        templateUrl: "/Scripts/app/views/listings.html",
        controller: "allListingsController"
    }
})
