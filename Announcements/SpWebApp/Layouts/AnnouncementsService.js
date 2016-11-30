myApp.factory('AnnouncementsService', ['$http', function ($http) {
    return {
        GetAllAnnouncements: function (token) {
            //return $http.get("/api/Announcements")
            return $http({
                url: "/AnnouncementsMVC",
                method: "GET"
            })
                .success(function (data) {
                    return data
                })
                .error(function (data) {
                    return data
                });
        },
        GetMyAnnouncements: function () {
            return $http({
                url: "/AnnouncementsMVC",
                method: "GET",
                params: { what: "my" }
            })
                .success(function (data) {
                    return data
                })
                .error(function (data) {
                    return data
                });
        },
        GetMyFriendsAnnouncements: function () {
            return $http({
                url: "/AnnouncementsMVC",
                method: "GET",
                params: { what: "friends" }
            })
                .success(function (data) {
                    return data
                })
                .error(function (data) {
                    return data
                });
        }
    }
}])