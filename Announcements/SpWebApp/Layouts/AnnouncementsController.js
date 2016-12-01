myApp.controller('AllAnnouncementsController', ['$scope', 'AnnouncementsService', function ($scope, AnnouncementsService) {
    AnnouncementsService.GetAllAnnouncements()
        .success(function (data) {
            $scope.allAnnouncements = data;
        });
}]);

myApp.controller('MyAnnouncementsController', ['$scope', 'AnnouncementsService', function ($scope, AnnouncementsService) {
    AnnouncementsService.GetMyAnnouncements()
        .success(function (data) {
            $scope.myAnnouncements = data;
        });
}]);

myApp.controller('FriendsAnnouncementsController', ['$scope', 'AnnouncementsService', function ($scope, AnnouncementsService) {
    AnnouncementsService.GetMyFriendsAnnouncements()
        .success(function (data) {
            $scope.friendsAnnouncements = data;
        });
}]);