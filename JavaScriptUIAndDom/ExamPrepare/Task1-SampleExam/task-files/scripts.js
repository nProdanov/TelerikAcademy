function createCalendar(selector, events) {

    solve(selector, events);
    function solve(selector, events) {
        var selectedElement = document.querySelector(selector);
        selectedElement.appendChild(createCal(events));
        selectedElement.previousElementSibling.innerHTML = 'July 2016';

        function createCal(events) {
            var calendarDiv = document.createElement('div');
            calendarDiv.className = 'calendar';

            var table = document.createElement('table');
            table.style.borderSpacing = '0';
            table.style.border = '1px solid black';
            table.addEventListener('mouseover', function (ev) {
                var target = ev.target;

                while (true) {
                    if (target === null) {
                        return;
                    } else if (target.tagName === 'TD') {
                        break;
                    }

                    target = target.parentElement;
                }

                if (target.id !== 'selected' && target.className !== 'non-active') {
                    target.firstChild.style.backgroundColor = 'orange';
                }

            }, false);

            table.addEventListener('mouseout', function (ev) {
                var target = ev.target;

                while (true) {
                    if (target === null) {
                        return;
                    } else if (target.tagName === 'TD') {
                        break;
                    }

                    target = target.parentElement;
                }

                if (target.id !== 'selected' && target.className !== 'non-active') {
                    target.firstChild.style.backgroundColor = 'lightgray';
                }

            }, false);

            table.addEventListener('click', function (ev) {
                var target = ev.target;

                while (true) {
                    if (target === null) {
                        return;
                    } else if (target.tagName === 'TD') {
                        break;
                    }

                    target = target.parentElement;
                }

                if (target.className !== 'non-active') {
                    var selected = document.getElementById('selected');
                    if (selected !== null) {
                        selected.id = '';
                        selected.style.backgroundColor = 'white';
                        selected.firstElementChild.style.backgroundColor = 'lightgray';
                    }

                    target.id = 'selected';
                    target.style.backgroundColor = 'lightgreen';
                    target.firstChild.style.backgroundColor = 'lightgreen';
                }
            }, false);

            var tr = document.createElement('tr');
            tr.style.height = '100px';
            var td = document.createElement('td');
            td.style.width = '120px';
            td.style.border = '1px solid black';
            td.style.verticalAlign = 'top';
            td.style.textAlign = 'center';

            var dayCounter = 1;
            var date = new Date(2016, 6, 1);

            var weekday = new Array(7);
            weekday[0] = "Sunday";
            weekday[1] = "Monday";
            weekday[2] = "Tuesday";
            weekday[3] = "Wednesday";
            weekday[4] = "Thursday";
            weekday[5] = "Friday";
            weekday[6] = "Saturday";

            var month = new Array(12);
            month[0] = "January";
            month[1] = "February";
            month[2] = "March";
            month[3] = "April";
            month[4] = "May";
            month[5] = "June";
            month[6] = "July";
            month[7] = "August";
            month[8] = "September";
            month[9] = "October";
            month[10] = "November";
            month[11] = "December";

            for (var rows = 0; rows < 5; rows += 1) {
                var currentRow = tr.cloneNode(true);
                for (var cols = 0; cols < 7; cols += 1) {
                    var currentCell = td.cloneNode(true);
                    if (rows === 0 && cols < 4) {
                        currentCell.className = 'non-active';
                        currentCell.style.backgroundColor = 'lightyellow';
                        currentRow.appendChild(currentCell);
                        continue;
                    } else {
                        if (dayCounter <= 31) {
                            var cellHeaderDiv = document.createElement('div');
                            cellHeaderDiv.style.display = 'inline-block';
                            cellHeaderDiv.style.backgroundColor = 'lightgray';
                            cellHeaderDiv.style.width = '100%';

                            var cellHeader = document.createElement('p');
                            cellHeader.style.fontSize = '15px';
                            cellHeader.style.margin = '0';
                            cellHeader.style.color = 'black';
                            cellHeader.innerHTML = weekday[date.getDay()] + ' ' + date.getDate() + '.' + month[date.getMonth()] + '.' + date.getFullYear();

                            var cellEventsDiv = document.createElement('div');
                            var eventContent = document.createElement('p');
                            eventContent.style.fontSize = '15px';
                            eventContent.style.margin = '0';
                            eventContent.style.color = 'black';

                            cellHeaderDiv.appendChild(cellHeader);
                            currentCell.appendChild(cellHeaderDiv);

                            for (var i = 0; i < events.length; i += 1) {
                                var currentEvent = events[i];
                                if (currentEvent.date == dayCounter) {
                                    var currCellEventsDiv = cellEventsDiv.cloneNode(true);
                                    var currEventContent = eventContent.cloneNode(true);
                                    var eventHourDate = new Date(0, 0, 0, currentEvent.hour.split(':')[0], currentEvent.hour.split(':')[1]);
                                    eventHourDate = new Date(eventHourDate.getTime() + currentEvent.duration * 60000);
                                    currEventContent.innerHTML = currentEvent.hour + '-' + eventHourDate.getHours() + ':' + eventHourDate.getMinutes() + ' ' + currentEvent.title;

                                    currCellEventsDiv.appendChild(currEventContent);
                                    currentCell.appendChild(currCellEventsDiv);
                                    events.splice(i, 1);
                                    i -= 1;
                                }
                            }

                            dayCounter += 1;
                            date.setDate(dayCounter);
                        }
                    }

                    currentRow.appendChild(currentCell);
                }

                table.appendChild(currentRow);
            }

            calendarDiv.appendChild(table);
            return calendarDiv;
        }

    }
}

module.exports = solve;