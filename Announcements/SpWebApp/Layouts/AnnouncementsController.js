myApp.controller('AllAnnouncementsController', ['$scope', 'AnnouncementsService', function ($scope, AnnouncementsService) {
    AnnouncementsService.GetAllAnnouncements()
        .success(function (data) {
            $scope.allAnnouncements = data;
        });


}]);