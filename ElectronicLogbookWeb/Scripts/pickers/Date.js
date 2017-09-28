$scope.add = function () {
    $scope.model.Visitor.Date = moment($scope.model.Visitor.Date).format("MM-DD-YYYY");
}

