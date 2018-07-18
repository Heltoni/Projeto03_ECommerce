function funcao01() {
    alert("Chamando uma função callback");
}

var btn1 = document.getElementById("btn1");
btn1.addEventListener("click", funcao01);


//aqui definimos uma função anônima
//este é o jeito mais comum de ser utilizado
var btn2 = document.getElementById("btn2");
btn2.addEventListener("click", function () {
    alert("Chamando uma função anônima");
});

var btn3 = document.getElementById("btn3");
//aqui temos o mesmo principio da expressão lambda porém no JS é chamado de arrow function
btn3.addEventListener("click", () => { alert("Arrow Function") });

