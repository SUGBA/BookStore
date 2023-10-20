function zero_first_format(value) {
    if (value < 10) {
        value = '0' + value;
    }
    return value;
}

function clockTimer() {
    var date = new Date();

    var time = [date.getHours(), date.getMinutes(), date.getSeconds()]; // |[0] = Hours| |[1] = Minutes| |[2] = Seconds|
    var dayOfWeek = ["Суббота", "Понедельник", "Вторник", "Среда", "Четверг", "Пятинца", "Воскресенье"]
    var days = date.getDay();

    time[0] = zero_first_format(time[0]);
    time[1] = zero_first_format(time[1]);
    time[2] = zero_first_format(time[2]);

    var current_time = [time[0], time[1], time[2]].join(':');
    var clock = document.getElementById("clock");
    var day = document.getElementById("dayOfWeek");

    clock.innerHTML = current_time;
    day.innerHTML = dayOfWeek[days];

    setTimeout("clockTimer()", 1000);
}

function date_time() {
    var current_datetime = new Date();
    var day = zero_first_format(current_datetime.getDate());
    var month = zero_first_format(current_datetime.getMonth() + 1);
    var year = current_datetime.getFullYear();

    return day + "." + month + "." + year;
}

setInterval(function () {
    document.getElementById('current_date_time_block').innerHTML = date_time();
}, 1000);