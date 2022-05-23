let monsters = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
  connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:53500/hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

  connection.on("MonsterCreated", (user, message) => {
    getdata();
  });

  connection.on("MonsterDeleted", (user, message) => {
    getdata();
  });

  connection.onclose(async () => {
    await start();
  });
  start();
}

async function start() {
  try {
    await connection.start();
    console.log("SignalR Connected.");
  } catch (err) {
    console.log(err);
    setTimeout(start, 5000);
  }
}

async function getdata() {
  await fetch("http://localhost:53500/monster")
    .then((x) => x.json())
    .then((y) => {
      monsters = y;
      console.log(monsters);
      display();
    });
}

function display() {
  document.getElementById("resultarea").innerHTML = "";
  monsters.forEach((t) => {
    document.getElementById("resultarea").innerHTML +=
      "<tr><td>" +
      t.monsterId +
      "</td><td>" +
      t.name +
      "</td><td>" +
      `<button class="btn btn-danger m-2" type="button" onclick="remove(${t.monsterId})">Delete</button>` +
      `<button class="btn btn-secondary m-2" type="button" onclick="update(${t.monsterId})">Update</button>` +
      "</td></tr>";
  });
}

function remove(id) {
  fetch("http://localhost:53500/monster/" + id, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
    body: null,
  })
    .then((response) => response)
    .then((data) => {
      console.log("Success:", data);
      getdata();
    })
    .catch((error) => {
      console.error("Error:", error);
    });
}

function update(id) {
  const localmonster = monsters.find((x) => x.monsterId === id);
  console.log(localmonster);
  localmonster.name = document.getElementById("name").value;
  if (localmonster.name == "") {
    alert("Adjon meg egy nevet!");
    return;
  }
  console.log(JSON.stringify(localmonster));
  fetch("http://localhost:53500/monster", {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(localmonster),
  })
    .then((response) => response)
    .then((data) => {
      console.log("Success:", data);
      getdata();
    })
    .catch((error) => {
      console.error("Error:", error);
    });
}

function create() {
  let name = document.getElementById("name").value;
  fetch("http://localhost:53500/monster", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ Name: name }),
  })
    .then((response) => response)
    .then((data) => {
      console.log("Success:", data);
      getdata();
    })
    .catch((error) => {
      console.error("Error:", error);
    });
}
