
// Controllers
app.controller('VehicleOperations', ['$scope', '$window', 'VehiclesService',
    function ($scope, $window, VehiclesService) {

        // Base Url 
        var baseUrl = '/api/Vehicles/';

        //Filter Attributes for Dropdown control
        $scope.FilterAttributes = [
            {
                'name': 'Id', 'value': 'vid'
            },
            {
                'name': 'Year', 'value': 'year'
            },
            {
                'name': 'Make', 'value': 'make'
            },
            {
                'name': 'Model', 'value': 'vmodel'
            },
        ];

        $scope.IsAdd = 1;
        $scope.IsAddEditVisible = 0;
        $scope.Id = 0;
        $scope.CurrentFilterAttribute = '';
        $scope.SelectedFilterAttribute = $scope.FilterAttributes[0].value;

        //Enable Add Vehicle section
        $scope.EnableAddVehicle = function () {
            $scope.Reset();
            $scope.IsAddEditVisible = 1;
        }

        //Enable Update Vehicle Section
        $scope.EnableEditVehicle = function (dataModel) {
            debugger
            $scope.IsAdd = 0;
            $scope.AddUpdateText = "Update";
            $scope.GetVehicleById(dataModel);

        }

        //Reset Filter attribute drop down
        $scope.ResetFilter = function () {
            debugger
            $scope.Reset();
            $scope.CurrentFilterAttribute = '';
            $scope.SelectedFilterAttribute = $scope.FilterAttributes[0].value;
            $scope.GetAllVehicles();

        }

        // Add or Update Vehicle
        $scope.AddOrUpdate = function () {
            var vehicle = {
                Id: $scope.Id,
                Year: $scope.Year,
                Make: $scope.Make,
                VModel: $scope.VModel,
                RowVersion: $scope.RowVersion,
            }

            if ($scope.IsAdd == 1) {
                debugger
                var apiRoute = baseUrl; // + 'AddVehicle/';
                var AddVehicle = VehiclesService.post(apiRoute, vehicle);
                AddVehicle.then(function (response) {
                    debugger
                    $scope.status = response.status;
                    $scope.data = response.data;
                    if (response.data != "") {
                        $window.alert($scope.Make + "-" + $scope.VModel + " Vehicle added Successfully");
                        //$scope.GetAllVehicles();
                        //$scope.Reset();

                    }
                    else {
                        $window.alert("Some error");
                    }
                    $scope.GetAllVehicles();
                    $scope.Reset();

                }, function (error) {
                    $scope.data = error.data || 'Request failed';
                    $scope.status = error.status;
                    console.log("Error: " + error);
                    $window.alert(error.data.ExceptionMessage || error.data.Message || 'Request failed');
                });
            }
            else {

                debugger
                var apiRoute = baseUrl;  // + 'Updatevehicle/';
                var UpdateVehicle = VehiclesService.put(apiRoute, vehicle);
                UpdateVehicle.then(function (response) {
                    if (response.data != "") {
                        $window.alert($scope.Make + "-" + $scope.VModel + " Vehicle updated Successfully");
                        //$scope.GetAllVehicles();
                        //$scope.Reset();

                    } else {
                        $window.alert("Request failed");
                    }

                    $scope.GetAllVehicles();
                    $scope.Reset();

                }, function (error) {
                    $scope.data = error.data || 'Request failed';
                    $scope.status = error.status;
                    console.log("Error: " + error);
                    $window.alert(error.data.ExceptionMessage || error.data.Message || 'Request failed');
                });
            }

        }

        //Get All Vehicles
        $scope.GetAllVehicles = function () {
            var apiRoute = baseUrl; //+ 'GetAllVehicles/';
            var vehicles = VehiclesService.getAll(apiRoute);
            vehicles.then(function (response) {
                debugger
                $scope.vehicles = response.data;
                $scope.Reset();
            },
            function (error) {
                $scope.data = error.data || 'Request failed';
                $scope.status = error.status;
                console.log("Error: " + error);
                $window.alert(error.data.ExceptionMessage || error.data.Message || 'Request failed');
            });


        }
        
        //Run Startup
        $scope.GetAllVehicles();

        //Get All Vehicles by filter attribute
        $scope.GetAllVehiclesByFilter = function () {
            debugger
            var filterAttribute = $scope.SelectedFilterAttribute;
            var filterAttributeValue = $scope.CurrentFilterAttribute;
            var apiRoute = baseUrl + 'Filter/'; // + filterAttribute + '/';
            var vehicles = VehiclesService.getbyFilter(apiRoute, filterAttribute, filterAttributeValue);
            vehicles.then(function (response) {
                $scope.vehicles = response.data;
                $scope.Reset();
            },
            function (error) {
                $scope.data = error.data || 'Request failed';
                $scope.status = error.status;
                console.log("Error: " + error);
                $window.alert(error.data.ExceptionMessage || error.data.Message || 'Request failed');
            });
        }

        // Get Vehicle by Id
        $scope.GetVehicleById = function (dataModel) {
            debugger
            var apiRoute = baseUrl; // + 'GetVehicleById';
            var vehicle = VehiclesService.getbyID(apiRoute, dataModel.Id);
            vehicle.then(function (response) {
                debugger
                if (response.data != "") {
                    $scope.Id = response.data.Id;
                    $scope.Year = response.data.Year;
                    $scope.Make = response.data.Make;
                    $scope.VModel = response.data.VModel;
                    $scope.RowVersion = response.data.RowVersion;
                    $scope.IsAddEditVisible = 1;
                }
            },
            function (error) {
                debugger
                $scope.data = error.data || 'Request failed';
                $scope.status = error.status;
                console.log("Error: " + error);
                $window.alert(error.data.ExceptionMessage || error.data.Message || 'Request failed');
            });
        }

        // Delete Vehicle
        $scope.DeleteVehicle = function (dataModel) {
            debugger
            var apiRoute = baseUrl + dataModel.Id; // + 'DeleteVehicle/' + dataModel.Id;
            var DeleteVehicle = VehiclesService.delete(apiRoute);
            DeleteVehicle.then(function (response) {
                if (response.data != "") {
                    $window.alert(dataModel.Make + "-" + dataModel.VModel + " Vehicle Deleted Successfully");
                    //$scope.GetAllVehicles();
                    //$scope.Reset();

                } else {
                    $window.alert("Some error");
                }
                $scope.GetAllVehicles();
                $scope.Reset();

            }, function (error) {
                $scope.data = error.data || 'Request failed';
                $scope.status = error.status;
                console.log("Error: " + error);
                $window.alert(error.data.ExceptionMessage || error.data.Message || 'Request failed');
            });
        }

        //Reset $Scope object
        $scope.Reset = function () {
            // $scope.SelectedFilterAttribute = $scope.FilterAttributes[0].value;
            $scope.IsAddEditVisible = 0;
            $scope.IsAdd = 1;
            $scope.AddUpdateText = "Add";
            $scope.Id = 0;
            $scope.Year = "";
            $scope.Make = "";
            $scope.VModel = "";
            $scope.RowVersion = null;
        }

    }]);

