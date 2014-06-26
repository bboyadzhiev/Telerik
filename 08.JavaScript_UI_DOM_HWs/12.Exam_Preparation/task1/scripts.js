function createCalendar(selector, events) {
    var container = document.querySelector(selector);
    var dayBox = document.createElement('div');
    var dayBoxTitle = document.createElement('strong');
    var dayBoxContent = document.createElement('div');

    var selectedBoxInfo = document.createElement('p');

    var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    var daysInMonth = 30;

    const DAYBOX_WIDTH = 130;
    const DAYS_PER_ROW = 7;

    const SELECTED_COLOR = 'white';
    const HOVER_COLOR = 'gray';
    const NORMAL_COLOR = 'lightgray';

    dayBoxContent.style.width = DAYBOX_WIDTH + 'px';
    dayBoxContent.style.height = DAYBOX_WIDTH + 'px';

    dayBoxContent.style.border = "1px solid black";
    dayBoxContent.style.background = 'white';
    dayBoxTitle.style.border = "1px solid black";
    dayBoxTitle.style.display = "block";

    container.style.width = DAYBOX_WIDTH * DAYS_PER_ROW + 4 * DAYS_PER_ROW + 'px';
    container.style.display = "block";

    selectedBoxInfo.innerHTML = '<p>Select day in calendar</p>'

    container.appendChild(selectedBoxInfo);


    dayBox.style.display = "inline-block";
    dayBox.style.background = NORMAL_COLOR;


    dayBoxTitle.className = "day-title";
    dayBoxContent.className = "day-content";
    dayBoxContent.innerHTML = "&nbsp;";
    dayBox.appendChild(dayBoxTitle);
    dayBox.appendChild(dayBoxContent);

    function createCalendarBoxes(daysInMonth, daysOfWeek) {
        var dayBoxes = [];

        for (var i = 1; i <= daysInMonth; i++) {
            var currentDay = daysOfWeek[i % daysOfWeek.length];
            dayBoxTitle.innerHTML = currentDay + ' ' + i + ' June 2014';
            dayBoxes.push(dayBox.cloneNode(true));
        }
        return dayBoxes;
    }

    var calendarBoxes = createCalendarBoxes(daysInMonth, daysOfWeek);
    var selectedBox = null;

    function addMonthEvents(calendarBoxes, events) {
        for (var i = 0; i < events.length; i++) {
            var date = events[i].date;
            var eventDay = calendarBoxes[date-1].querySelector(".day-content");
            eventDay.innerHTML = '<div>' + events[i].hour + ' ' + events[i].title + '</div>';
        }
    }

    addMonthEvents(calendarBoxes, events);

    function onBoxClick(ev) {
        if (selectedBox != null) {
            selectedBox.style.background = NORMAL_COLOR;
        }
        this.style.background = SELECTED_COLOR;
        selectedBox = this;
        //selectedBoxInfo.innerHTML = this.querySelector('.day-title').innerHTML + ' : ' + this.querySelector('.day-content').innerHTML;
        selectedBoxInfo.innerHTML = this.querySelector('.day-title').innerHTML + ' : ';
        var dayContent = this.querySelector('.day-content').innerHTML;
        if (dayContent !== '&nbsp;') {
            selectedBoxInfo.innerHTML += dayContent;
        } else {
            selectedBoxInfo.innerHTML += 'no events';
        }
    }

    function onBoxMouseOver(ev) {
        if (this !== selectedBox) {
            this.style.background = HOVER_COLOR;
        }
        else {
            this.style.background = SELECTED_COLOR;
        }
    }

    function onBoxMouseOut(ev) {
        if (this !== selectedBox) {
            this.style.background = NORMAL_COLOR;
        } else {
            this.style.background = SELECTED_COLOR;
        }
    }

    for (var i = 0; i < daysInMonth; i++) {
        container.appendChild(calendarBoxes[i]);
        calendarBoxes[i].addEventListener('click', onBoxClick);
        calendarBoxes[i].addEventListener('mouseover', onBoxMouseOver);
        calendarBoxes[i].addEventListener('mouseout', onBoxMouseOut);
    }

}