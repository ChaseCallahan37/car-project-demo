const url = "http://localhost:5041/api/car";

const render = () => {
  getCars();
};

const getCars = function () {
  fetch(url)
    .then(function (response) {
      return response.json();
    })
    .then(function (data) {
      makeCarTable(data);
    });
};

const makeCarTable = (cars) => {
  let table = document.getElementById("car-table");

  table.innerHTML = "";

  table.appendChild(makeHeader());
  table.appendChild(makeBody(cars));
};

const makeHeader = () => {
  const header = document.createElement("thead");

  const th1 = document.createElement("th");
  th1.innerHTML = "Make";
  header.appendChild(th1);

  const th2 = document.createElement("th");
  th2.innerHTML = "Model";
  header.appendChild(th2);

  const th3 = document.createElement("th");
  th3.innerHTML = "Year";
  header.appendChild(th3);

  return header;
};

const makeBody = (cars) => {
  let tbody = document.createElement("tbody");

  cars.forEach((c) => {
    let tr = document.createElement("tr");

    let td1 = document.createElement("td");
    td1.innerHTML = c.make;
    tr.appendChild(td1);

    let td2 = document.createElement("td");
    td2.innerHTML = c.model;
    tr.appendChild(td2);

    let td3 = document.createElement("td");
    td3.innerHTML = c.year;
    tr.appendChild(td3);

    let editBtn = document.createElement("button");
    tr.appendChild(editBtn);
    editBtn.innerHTML = "Edit";
    editBtn.addEventListener("click", () => {
      let makeInput = document.getElementById("make-input");
      makeInput.value = c.make;

      let modelInput = document.getElementById("model-input");
      modelInput.value = c.model;

      let yearInput = document.getElementById("year-input");
      yearInput.value = c.year;

      let form = document.getElementById("car-form");
      form.onsubmit = editCar;
      form.key = c.id;
    });

    let deleteBtn = document.createElement("button");
    tr.appendChild(deleteBtn);
    deleteBtn.innerHTML = "Delete";
    deleteBtn.addEventListener("click", () => {
      deleteCar(c.id);
    });

    tbody.appendChild(tr);
  });
  return tbody;
};

const createCar = async (event) => {
  event.preventDefault();
  const target = event.target;
  const car = {
    make: target.make.value,
    model: target.model.value,
    year: target.year.value,
  };
  await fetch(url, {
    method: "POST",
    headers: {
      accept: "*/*",
      "content-type": "application/json",
    },
    body: JSON.stringify(car),
  });
  render();
  target.make.value = "";
  target.model.value = "";
  target.year.value = "";
};

const editCar = async (event) => {
  event.preventDefault();
  const target = event.target;
  const car = {
    id: target.key,
    make: target.make.value,
    model: target.model.value,
    year: target.year.value,
  };
  await fetch(`${url}/${target.key}`, {
    method: "PUT",
    headers: {
      accept: "*/*",
      "content-type": "application/json",
    },
    body: JSON.stringify(car),
  });
  render();
  target.make.value = "";
  target.model.value = "";
  target.year.value = "";
};

const deleteCar = async (id) => {
  await fetch(`${url}/${id}`, {
    method: "DELETE",
    headers: {
      accept: "*/*",
      "content-type": "application/json",
    },
  });
  render();
};

render();
