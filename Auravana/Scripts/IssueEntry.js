(function () {
    var app = angular.module('issueEntry', []);

    app.controller('issueCtrl', function ($scope) {
        $scope.selectedItems = [];

        var resolutionRequested = {
            optionsName: "Resolution Requested",
            items: [
				{ name: "Evacuate", color: "red" },
				{ name: "Get the fire hose", color: "orange" },
				{ name: "Run for the hills", color: "blue" }
            ]
        }

        var incidentType = {
            optionsName: "Incident Type",
            items: [
				{ name: "I shat myself", color: "red", children: resolutionRequested },
				{ name: "I've fallen", color: "green" }
            ]
        }

        var visibilityCategory = {
            optionsName: "Visibility Category",
            items: [
				{ name: "Incident", color: "red", children: incidentType },
				{ name: "Breakdown / Failure", color: "orange" },
				{ name: "Bug / Defect", color: "orange" },
				{ name: "Help DeskRequest", color: "blue" },
				{ name: "New Feature / Enhancement", color: "green" },
				{ name: "New Object / Service", color: "green" },
				{ name: "None", color: "purple" }
            ]
        };

        $scope.currentOptions = visibilityCategory;

        $scope.selectOption = function (options, item) {
            $scope.selectedItems.push({ options: options, choice: item });
            $scope.currentOptions = item.children || visibilityCategory;
        };

        $scope.removeSelection = function (item, index) {
            $scope.selectedItems = $scope.selectedItems.slice(0, index);
            $scope.currentOptions = item.options;
        };
    });
})();