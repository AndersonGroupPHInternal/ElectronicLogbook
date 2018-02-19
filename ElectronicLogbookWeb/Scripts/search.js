function myFunction() {

    var input, filter, found, table, tr, td, i, j, thead;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("tableid");
    tr = table.getElementsByClassName("alert");


    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td");
        for (j = 0; j < td.length; j++) {
            if (td[j].innerHTML.toUpperCase().indexOf(filter) > -1) {
                found = true;
            }
        }
        if (found) {
            tr[i].style.display = "";
            found = false;
        } else {
            if (tr[i].id !== 'info') { tr[i].style.display = "none"; }
        }
    }
}