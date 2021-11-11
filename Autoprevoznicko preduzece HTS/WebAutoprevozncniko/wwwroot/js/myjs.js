$(document).ready(function () {

    $("#zona").change(function () {

        var url = '/Pretraga/getPutniciByZona';

        $.getJSON(url, { id: $("#zona").val() }, function (data) {

            var items = '';

            //$("#grad").empty();

            $("#tb").empty();

            $.each(data, function (i, row) {



                dodajUTabelu(row);

            })



        })

    })

    function dodajUTabelu(row) {

        var tabela = document.getElementById("tb");

        tabela.classList.add('table');

        var tr = document.createElement("tr");

        tabela.appendChild(tr);

        var td1 = document.createElement("td");

        var td2 = document.createElement("td");

        var td3 = document.createElement("td");



        td1.innerHTML = row.id;

        td2.innerHTML = row.ime;

        td3.innerHTML = row.prezime;




        tr.appendChild(td1);

        tr.appendChild(td2);

        tr.appendChild(td3);



    };

})












$(document).ready(function () {

    $("#vozac").change(function () {

        var url = '/Pretraga/getVozacibyKorisnickoIme';

        $.getJSON(url, { id: $("#vozac").val() }, function (data) {

            var items = '';

            //$("#grad").empty(); 

            $("#tb").empty();

            $.each(data, function (i, row) {



                dodajUTabelu2(row);

            })



        })

    })

    function dodajUTabelu2(row) {

        var tabela = document.getElementById("tb");

        tabela.classList.add('table');

        var tr = document.createElement("tr");

        tabela.appendChild(tr);

        var td1 = document.createElement("td");

        var td2 = document.createElement("td");

        var td3 = document.createElement("td");

        var td4 = document.createElement("td");

        var td5 = document.createElement("td");

        var td6 = document.createElement("td");



        td1.innerHTML = row.id;

        td2.innerHTML = row.ime;

        td3.innerHTML = row.prezime;

        td4.innerHTML = row.datumRodjenja;

        td5.innerHTML = row.email;

        td6.innerHTML = row.vozackaKategorija;



        tr.appendChild(td1);

        tr.appendChild(td2);

        tr.appendChild(td3);

        tr.appendChild(td4);

        tr.appendChild(td5);

        tr.appendChild(td6);
    };

})






