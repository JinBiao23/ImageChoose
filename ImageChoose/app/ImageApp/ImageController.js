ImageApp.controller("ImageController", function ImageController($scope, $http) {
    $scope.GetRandomPicture = function () {
        var url = '/Home/GetPicture';
        var promise = $http.get(url);
        promise.then(function (result) {
            $scope.image = result.data.ImageArray;
            $scope.SetImageName = result.data.ImageName;
            $("#imageName").val(result.data.ImageName);
            console.log("promise done here")
        });
        console.log("promise passed here")
    };  
    $scope.likedImages = {
        imgs: []
    } 
    function SetImagePerference(perference) {
        var url = '/Home/SetImagePreference?imageName=' + $("#imageName").val() + '&userName=' + $("#userName").val() + '&likeImage=' + perference;
        var promise = $http.get(url);
        promise.then(function (result) {
            $scope.SetImageName = result.data.ImageName;
            $scope.SetUserName = result.data.UserName;
            $scope.ImagePerference = (result.data.LikeIt ? "like" : "not like");
            $("#alertDiv").removeClass("hidden");
            console.log("promise done here")
        });
    } 
    $scope.LikeImage = function () {
        SetImagePerference(true)
        //var url = '/Home/SetImagePreference?imageName=' + $("#imageName").val() + '&userName=' + $("#userName").val() + '&likeImage=true';
        //var promise = $http.get(url);
        //promise.then(function (result) { 
        //    $scope.SetImageName = result.data.ImageName;
        //    $scope.SetUserName = result.data.UserName;
        //    $scope.ImagePerference = (result.data.LikeIt ? "like" : "not like");
        //    $("#alertDiv").removeClass("hidden");
        //    console.log("promise done here")
        //});
        console.log("promise passed here")
    };
    $scope.UnlikeImage = function () {
        SetImagePerference(false);
        //var url = '/Home/SetImagePreference?imageName=' + $("#imageName").val() + '&userName=' + $("#userName").val() + '&likeImage=false';
        //var promise = $http.get(url);
        //promise.then(function (result) {
        //    $scope.SetImageName = result.data.ImageName;
        //    $scope.SetUserName = result.data.UserName;
        //    $scope.ImagePerference = (result.data.LikeIt ? "like" : "not like");
        //    $("#alertDiv").removeClass("hidden");
        //    console.log("promise done here")
        //});
        console.log("promise passed here")
    };

    function GetPreferencedImages(preference) {
        var url = '/Home/GetPreferencedImages?userName=' + $("#userName").val() + '&likedImage=' + preference;
        var promise = $http.get(url);
        promise.then(function (result) {
            $scope.preferencedImages = result.data;
            $.each(result.data, function (i, item) {
                var image = {
                    imageName : item.ImageName,
                    imageContent: item.ImageArray
                }
                $scope.likedImages.imgs.push(image);
            });
            //console.log("promise done here")
        });
    }

    $scope.GetLikedImages = function () {
        $scope.likedImages = {
            imgs: []
        }
        GetPreferencedImages(true);
    }
    $scope.GetUnLikedImages = function () {
        $scope.likedImages = {
            imgs: []
        }
        GetPreferencedImages(false);
    }
})