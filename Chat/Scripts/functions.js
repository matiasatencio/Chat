$(document).ready(function(){
    $('#txtMessage').keypress(function(e){
      if(e.keyCode==13)
      $('#btnSend').click();
    });
});

$(function () {
            var chat = $.connection.chatHub;

            chat.client.sendChat = function (name, message) {
                var divName = $("<div />").text(name).html();
                var divMessage = $("<div />").text(message).html();

                $("#chatBox").append("<strong>" + divName + "</strong>: " + divMessage + "<br />");
                
                var box = document.getElementById("chatBox");
                box.scrollTop = box.scrollHeight;
            };

            var namee = prompt("Name: ", "");
            $("#displayName").val(namee);

            $("#txtMessage").focus();

            $.connection.hub.start().done(function () {
                $("#btnSend").click(function () {
                    var namee = $("#displayName").val();
                    var messageText = $("#txtMessage").val();
                    if(messageText.trim()) {
                        chat.server.send(namee, messageText);
                        $("#txtMessage").val("").focus();
                    }
                });
            });
        });