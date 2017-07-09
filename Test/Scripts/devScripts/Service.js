app.service('crudService', function ($http) {
    

    //Get All Categories
    this.getCategories = function () {
        return $http.get("/api/timeseries/categories");
    }

    //Get All Periods
    this.getTimePeriods = function () {
        return $http.get("/api/timeseries/timeperiods");
    }
});