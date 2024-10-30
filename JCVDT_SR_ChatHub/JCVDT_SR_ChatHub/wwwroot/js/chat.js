const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

// Start the connection
async function start() {
    try{
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

// Hadle receiving messages
connection.on("ReceiveMessage", function(user, message) {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(li);
});

// Handle send button clck
document.getElementById("sendButton").addEventListener("click", async (event) => {
    const user = docuent.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;

    try {
        await connection.invoke("sendMessage", user, message);
        document.getElementById("messageInput").value = "";
    } catch (err) {
        console.error(err);
    }
});

// Start the connection
start();