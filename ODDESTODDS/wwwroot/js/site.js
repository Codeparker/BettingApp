
//var pusher = new Pusher('8547d7df8ea09890aded', {
//    cluster: 'eu',
//    encrypted: true
//});

//var channel = pusher.subscribe('bet_channel');

//channel.bind('bet_event', function (data) {
//    reloadGroup();
//});

//$("#CreatNewGame").click(function () {
//    // get all selected users
   
//    let data = {
//        HomeTeam: $("#GroupName").val(),
//        AwayTeam: UserNames,
//        HomeOdd: 3.9,
//        AwayOdd: 6.0,
//        DrawOdd: 4.8,
//        GameStartTime: GameStartTime
//    };

//    $.ajax({
//        type: "POST",
//        url: "/api/BettingAdmin",
//        data: JSON.stringify(data),
//        success: (data) => {
//            reloadGroup();
          
//        },
//        dataType: 'json',
//        contentType: 'application/json'
//    });

//});

//function reloadGroup() {
//    $.get("/api/BettingGuest", function (data) {
//        let groups = "";
//        console.log(data);
//        data.forEach(function (group) {
//            groups += `<div class="group" data-group_id="` + group.groupId + `">` + group.groupName + `</div>`;
//        });

//        $("#groups").html(groups);
//    });
//}


