let nombre = [];

nombre.push(["Pepito Limon", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Juanita Pérez", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Ana García", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Carlos Sánchez", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Luisa Martínez", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Pedro González", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["María Rodríguez", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Javier Fernández", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Elena López", moment(new Date()).format("DD-MM-YYYY")]);
nombre.push(["Sergio Ramírez", moment(new Date()).format("DD-MM-YYYY")]);

let tagUl = document.createElement("ul");

for (let i = 0; i < nombre.length; i++) {
    let tagLi = document.createElement("li");
    tagLi.textContent = `${nombre[i][0]} - Fecha de Registro: ${nombre[i][1]}`;
    tagUl.appendChild(tagLi);
}

document.body.appendChild(tagUl);