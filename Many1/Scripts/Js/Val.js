function validate() {

    var minstart = document.forms["form"]["DateStart"].value;
    var maxstart = document.forms["form"]["DateEnd"].value;
    var today = new Date();

    x = minstart.split("-");
    dmin = x[0] * 10000 + x[1] * 100 + x[2] * 1;

    y = maxstart.split("-");
    dmax = y[0] * 10000 + y[1] * 100 + y[2] * 1;

    z1 = today.getDate();
    z2 = today.getMonth();
    z3 = today.getFullYear();
    d0 = z3 * 10000 + (z2 + 1) * 100 + z1 * 1;


    //Проверяем minstart
    if (minstart.length == 0) {
        alert("Ошибка:Начальная дата не введена");
        return false;
    }
    if (dmin < d0) {
        alert("Ошибка:Начальная дата меньше сегодняшней");
        return false;
    }



    //Проверяем maxstart
    if (maxstart.length == 0) {
        alert("Ошибка:Конечная дата не введена");
        return false;
    }
    if (dmax < dmin) {
        alert("Ошибка:Конечная дата меньше начальной");
        return false;
    }


}