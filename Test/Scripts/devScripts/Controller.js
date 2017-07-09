app.controller('crudController', function ($scope, crudService) {

    $scope.selectedTs = {};
    $scope.selectedCat = {};

    loadTSData();
    loadTimePeriods();

    //loads time periods data
    function loadTimePeriods()
    {
        var promiseGet = crudService.getTimePeriods();
        promiseGet.then(function (pl) {
            $scope.TimePeriods = pl.data;
        
        }, function (errorPl) {
        console.log('failure loading time periods data', errorPl);
    });
    }
    //Function to load all categories
    //create a dictionary with categories being values
    //keys are string formed by the category and all
    //of its ancestor categories up until the root category,
    //separated by '-' sign
    function loadTSData() {
        var promiseGet = crudService.getCategories();
        promiseGet.then(function (pl) {
            $scope.Categories = {};
            var tempCat = {};
            for (i = 0; i < pl.data.length; i++) {
                var tdata = pl.data[i];
                tempCat[tdata.Id] = tdata;
            }
            for (i = 0; i < pl.data.length; i++) {
                var pdata = pl.data[i];
                var fullName = pdata.Name;
                var level = pdata.Level;
                var parentId = pdata.ParentId;
                for (j = level; j > 0; j--) {
                    var parentCat = tempCat[parentId];
                    fullName = parentCat.Name + "-" + fullName;
                    parentId = parentCat.ParentId;
                }
                $scope.Categories[fullName] = pdata;
            }
        }, function (errorPl) {
                console.log('failure loading TS data', errorPl);
            });
    }

    //Clear the scope models
    $scope.clear = function () {

        $scope.selectedTs = {};
        $scope.selectedCat = {};
        $scope.Categories = {};
        $scope.TimePeriods = {};
    }    

    $scope.exportData = function () {
        var spTable = $scope.selectedTs.SeriesPoints;
        var tpTable = $scope.TimePeriods;
        alasql('SELECT spTable.Date,spTable.SPValue,tpTable.Name INTO XLSX("TSReport.xlsx",{headers:true}) FROM ? AS spTable INNER JOIN ? AS tpTable ON spTable.PeriodId=tpTable.Id', [spTable, tpTable]);
       
    };

    
});
