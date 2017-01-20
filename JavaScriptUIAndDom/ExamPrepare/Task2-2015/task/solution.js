function solve() {
    $.fn.datepicker = function () {
        var MONTHS = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var DAYS_OF_WEEK = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];
        var dateCurrent = new Date();
        var workingDate = dateCurrent;

        var inputValueStr = '';
        var $input = $(this);
        $input.addClass('datepicker')
            .on('click', function (ev) {
                ev.stopPropagation();
                if ($picker.hasClass('picker-visible')) {
                    $picker.removeClass('picker-visible');
                }
                else {
                    $picker.addClass('picker-visible');
                }
            });

        // $(document).on('click', function(){
        //     var $target = $(this);
        //     if($target.tagName !== 'div' && $target.tagName !== 'input'){
        //         $picker.removeClass('picker-visible');
        //     }
        // });

        var $datepickerWrapper = $('<div />');
        $datepickerWrapper.addClass('datepicker-wrapper');
        $input.parent().append($datepickerWrapper);
        $datepickerWrapper.append($input);

        var $picker = $('<div />')
            .addClass('picker');

        // Controls
        var $controls = $('<div />')
            .addClass('controls');
        var $prevMonthBtn = $('<button />')
            .html('<')
            .addClass('btn')
            .on('click', function () {
                workingDate.setMonth(workingDate.getMonth() - 1);
                $currentMonth.html(getFullCurrentMonthString(workingDate));
                $tbody.html('');
                fillTheBody($tbody, workingDate);
            });
        var $nextMonthBtn = $('<button />')
            .html('>')
            .addClass('btn')
            .on('click', function () {
                workingDate.setMonth(workingDate.getMonth() + 1);
                $currentMonth.html(getFullCurrentMonthString(workingDate));
                $tbody.html('');
                fillTheBody($tbody, workingDate);
            });
        var currMonthString = getFullCurrentMonthString(workingDate);
        var $currentMonth = $('<div />')
            .addClass('current-month')
            .html(currMonthString);

        $controls.append($prevMonthBtn);
        $controls.append($currentMonth);
        $controls.append($nextMonthBtn);

        // Calendar
        var $calendar = $('<table />')
            .addClass('calendar')
            .on('click', 'td', function () {
                debugger;
                var $target = $(this);
                var targetDate = parseInt($target.html());
                var targetMonth = workingDate.getMonth() + 1;
                var targetYear = workingDate.getFullYear();
                if ($target.hasClass('current-month')) {
                    inputValueStr = '';
                    inputValueStr += targetDate;
                    inputValueStr += '/';
                    inputValueStr += targetMonth;
                    inputValueStr += '/';
                    inputValueStr += targetYear;
                    $input.attr('value', inputValueStr);
                    $picker.removeClass('picker-visible');
                }
                else {
                    return;
                }
            });
        var $thead = $('<thead />');
        var $tbody = $('<tbody />');
        setDaysOfThead($thead);
        fillTheBody($tbody, workingDate);
        $calendar.append($thead);
        $calendar.append($tbody);

        //current date
        var currDateAsString = dateCurrent.getDate() + ' ' + getMonthAsString(dateCurrent) + ' ' + dateCurrent.getFullYear();
        var $currentDate = $('<div />')
            .addClass('current-date');
        var $currDateLink = $('<a />')
            .addClass('current-date-link')
            .html(currDateAsString)
            .on('mouseover', function () {
                var $this = $(this);
                $this.css('cursor', 'pointer');
            })
            .on('click', function(){
                var targetDate = dateCurrent.getDate();
                var targetMonth = dateCurrent.getMonth() + 1;
                var targetYear = dateCurrent.getFullYear();
                inputValueStr = '';
                    inputValueStr += targetDate;
                    inputValueStr += '/';
                    inputValueStr += targetMonth;
                    inputValueStr += '/';
                    inputValueStr += targetYear;
                    $input.attr('value', inputValueStr);
                    $picker.removeClass('picker-visible');
            });

        $currentDate.append($currDateLink);

        $picker.append($controls);
        $picker.append($calendar);
        $picker.append($currentDate);
        $datepickerWrapper.append($picker);

        function getMonthAsString(date) {
            return MONTHS[date.getMonth()];
        }

        function getDayOfWeekAsString(dayNumber) {
            return DAYS_OF_WEEK[dayNumber];
        }

        function getFullCurrentMonthString(date) {
            var fullString = '';
            fullString += getMonthAsString(date);
            fullString += ' ';
            fullString += date.getFullYear();
            return fullString;
        }

        function fillTheBody($tbody, workingDate) {
            var row,
                col,
                $td = $('<td />'),
                $currTD,
                $tr = $('<tr />'),
                $currTr,
                workingYear = workingDate.getFullYear(),
                workingMonth = workingDate.getMonth(),
                lastDayOfPRevMonthAsDate,
                lastDayOfPrevMonthAsDayOfWeek,
                lastDayOfCurrentMonthAsDate,
                lastDateOfCurrentMont,
                isPrevMonth = true,
                isNextMonth = false,
                currentDateCounter;

            lastDayOfPRevMonthAsDate = new Date(workingYear, workingMonth, 0);
            lastDayOfPrevMonthAsDayOfWeek = lastDayOfPRevMonthAsDate.getDay();
            lastDateOfPrevMonth = lastDayOfPRevMonthAsDate.getDate();

            lastDayOfCurrentMonthAsDate = new Date(workingYear, workingMonth + 1, 0);
            lastDateOfCurrentMont = lastDayOfCurrentMonthAsDate.getDate();

            currentDateCounter = lastDateOfPrevMonth - lastDayOfPrevMonthAsDayOfWeek;
            for (row = 0; row < 6; row += 1) {
                $currTr = $tr.clone(true);
                for (col = 0; col < 7; col += 1) {
                    $currTD = $td.clone(true);

                    if (isPrevMonth) {
                        $currTD.addClass('another-month');
                        if (currentDateCounter < lastDateOfPrevMonth) {
                            $currTD.html(currentDateCounter);
                            currentDateCounter += 1;
                        }
                        else if (currentDateCounter === lastDateOfPrevMonth) {
                            $currTD.html(currentDateCounter);
                            isPrevMonth = false;
                            currentDateCounter = 1;
                        }
                    }
                    else if (isNextMonth) {
                        $currTD.addClass('another-month');
                        $currTD.html(currentDateCounter);
                        currentDateCounter += 1;
                    }
                    else {
                        $currTD.addClass('current-month');
                        $currTD.html(currentDateCounter);
                        if (currentDateCounter === lastDateOfCurrentMont) {
                            currentDateCounter = 1;
                            isNextMonth = true;
                        }
                        else {
                            currentDateCounter += 1;

                        }
                    }


                    $currTr.append($currTD);
                }
                $tbody.append($currTr);
            }
        }

        function setDaysOfThead($thead) {
            var i,
                $th = $('<th />'),
                $currTh,
                $row = $('<tr />');
            for (i = 0; i < 7; i += 1) {
                $currTh = $th.clone(true);
                $currTh.html(getDayOfWeekAsString(i));
                $row.append($currTh);
            }

            $thead.append($row);
        }

        return $input;
    };
};

if (typeof module !== 'undefined') {
    module.exports = solve;
}