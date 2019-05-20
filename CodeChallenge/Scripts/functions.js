$(document).ready(function () {
    $('#txtMessage').keypress(function (e) {
        if (e.keyCode == 13)
            $('#btnSend').click();
    });
});

$(function () {
    var chat = $.connection.chatHub;
    chat.client.sendChat = function (chatText) {
        
        $("#chatBox").html(chatText);

        var box = document.getElementById("chatBox");
        box.scrollTop = box.scrollHeight;
    };

    $("#txtMessage").focus();

    $.connection.hub.start().done(function () {
        chat.server.getMessages();
        $("#btnSend").click(function () {
            var namee = $("#displayName").val();
            var messageText = $("#txtMessage").val();

            if (messageText.trim() && messageText.charAt(0) !== '/') {
                chat.server.send(namee, messageText);
            }
            else if (messageText.charAt(0) === '/') {
                chat.server.command(namee, messageText);
            }

            $("#txtMessage").val("").focus();
        });
    });
});