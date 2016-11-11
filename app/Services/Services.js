(function () {
    angular.module("app.services", [])
        .factory("factoryToWorkingWithDB", function ($http) {

            var getAllMoviesFromDB_path = "../api/movie/getAll";
            var getMovieFromDBByTitle_path = "../api/movie/searchByTitle";
            var addNewMovie_path = "../api/movie/add";
            var removeMovieFromDBByTitle_path = "../api/movie/delete";


            return {
                getAllMovies: function () {
                    return $http({
                        method: 'GET',
                        url: getAllMoviesFromDB_path
                    }).success(function (response) {
                        console.log(response);
                        console.log(response.movies);
                        return response;
                    }).error(function () {
                        console.log("Error: loading all movie from server")
                    })
                },

                getMovieByTitle: function (title) {
                    return $http({
                        method: 'GET',
                        url: getMovieFromDBByTitle_path,
                        data: title
                    }).success(function (response) {
                        console.log(response);
                        return response;
                    }).error(function () {
                        console.log("Error: loading movie by title");
                    })
                },

                deleteMovieByTitle: function (title) {
                    $http({
                        method: 'POST',
                        url: removeMovieFromDBByTitle_path,
                        data: title
                    }).success(function () {
                        console.log("product " + title.title + " was deleted from DB");
                    }).error(function () {
                        console.log("Error: deleting product " + title);
                    })
                },

                addNewFilm: function (film) {
                    $http({
                        method: 'POST',
                        url: addNewMovie_path,
                        data: film
                    }).success(function () {
                        console.log("product " + film + " was added succesfully")
                    }).error(function () {
                        console.log("Eror: add of " + film + " in DB")
                    })
                }
            }
        })

    .config(function ($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $window) {
            return {
                request: function (config) {
                    config.header =  { 'MovieApp' : '12345' };
                    return config;
                },
                responseError: function (response) {
                    if (response.status === 401 || response.status === 404) {
                        $window.alert("Error: " + response.status);
                    }
                    return $q.reject(response);
                }
            }
        })
    })


 })();