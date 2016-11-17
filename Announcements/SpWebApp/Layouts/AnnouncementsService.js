myApp.factory('AnnouncementsService', ['$http', function ($http) {
    return {
        GetAllAnnouncements: function () {
            return $http.get("api/Announcements")
                .success(function (data) {
                    return data
                })
                .error(function (data) {
                    return data
                });
        }
    }
}])