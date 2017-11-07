//Add,Edit,Get and Delete Vehicle
app.service('VehiclesService', function ($http) {

    var urlGet = '';

    // http POST
    this.post = function (apiRouteUri, apiData) {
        var request = $http({
            method: "post",
            url: apiRouteUri,
            data: apiData
        });
        return request;
    }

    // http PUT
    this.put = function (apiRouteUri, apiData) {
        var request = $http({
            method: "put",
            url: apiRouteUri,
            data: apiData
        });
        return request;
    }

    // http DELETE
    this.delete = function (apiRouteUri) {
        var request = $http({
            method: "delete",
            url: apiRouteUri
        });
        return request;
    }

    // http GET
    this.getAll = function (apiRouteUri) {

        urlGet = apiRouteUri;
        return $http.get(urlGet);
    }

    // http GET by ID
    this.getbyID = function (apiRouteUri, VehicleId) {

        urlGet = apiRouteUri + VehicleId;
        return $http.get(urlGet);
    }

    // http GET by filter attributes
    this.getbyFilter = function (apiRouteUri, filterAttribute, filterAttributeValue) {
        debugger
        urlGet = apiRouteUri + filterAttribute + '/' + filterAttributeValue;
        return $http.get(urlGet);
    }


});
