var connection = new signalR.HubConnectionBuilder().withUrl('http://localhost:5183/SignalRBookingHub').build();
document.getElementById("sendButton").disabled = false;
connection.on("ReceiveMessage", function (user, message) {
    var currentdate = new Date();
    var datetime = currentdate.getHours() + ":" + currentdate.getMinutes() + ":" + currentdate.getSeconds();
    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML += ` ${datetime} : ${message}`;
    document.getElementById("messageList").appendChild(li);
    
});
    
 connection.start().then(function () {
     document.getElementById("sendButton").disabled = false;
 }).catch(function (err) {
     return console.error(err.toString());
 });
 
    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });