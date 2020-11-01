// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// CALENDAR

$(document).ready(function () {

    var selectedEvent = null;

    drawCalendar();

    function drawCalendar() {
        var calendarEl = document.getElementById('calendar');
        var calendar = new FullCalendar.Calendar(calendarEl, {
            themeSystem: 'default',
            initialView: 'timeGridWeek',
            eventBackgroundColor: '#3ad29f',
            //initialDate: new Date(),
            locale: 'pl',
            headerToolbar: {
                start: 'today prev,next',
                end: 'timeGridWeek,timeGridDay'
            },
            slotDuration: '00:30:00',
            slotMinTime: "07:00:00",
            slotMaxTime: "23:00:00",
            weekends: false,
            events: { url: "/home/GetAllEvents" },
            eventClick: function (info, jsEvent, view) {
                selectedEvent = info.event;
                $('#eventModal #eventTitle').text(selectedEvent.title);
                var $desc = $('<div/>');
                $desc.append($('<p/>').html('<b>EventID: </b>' + selectedEvent.id));
                $desc.append($('<p/>').html('<b>Start: </b>' + moment(selectedEvent.start).format('DD.MM.YYYY HH:mm')));
                if (selectedEvent.end != null)
                    $desc.append($('<p/>').html('<b>Koniec: </b>' + moment(selectedEvent.end).format('DD.MM.YYYY HH:mm')));
                $desc.append($('<p/>').html('<b>Opis: </b>' + selectedEvent.extendedProps.description));
                $('#eventModal #pDetails').empty().html($desc);
                $('#eventModal').modal();
            },
            selectable: true,
            unselectAuto: true,
            select: function (info, start, end, allDay) {
                selectedEvent = {
                    id: 0,
                    title: '',
                    description: '',
                    start: info.start,
                    end: info.end,
                    allDay: info.allDay,
                    color: '',
                    orderID: ''
                };
                openAddEditForm();
                calendar.unselect();
            },
            editable: true,
            eventDurationEditable: true,
            eventDrop: function (info) {
                var data = {
                    EventID: info.event.id,
                    Title: info.event.title,
                    Start: moment(info.event.start).format('DD.MM.YYYY HH:mm'),
                    End: info.event.end != null ? moment(info.event.end).format('DD.MM.YYYY HH:mm') : null,
                    AllDay: info.event.allDay,
                    Description: info.event.description,
                    BackgroundColor: info.event.color,
                    OrderID: info.event.orderID
                };
                SaveEvent(data);
            },
            eventResize: function (info) {
                var data = {
                    EventID: info.event.id,
                    Title: info.event.title,
                    Start: moment(info.event.start).format('DD.MM.YYYY HH:mm'),
                    End: info.event.end != null ? moment(info.event.end).format('DD.MM.YYYY HH:mm') : null,
                    AllDay: info.event.allDay,
                    Description: info.event.description,
                    BackgroundColor: info.event.color,
                    OrderID: info.event.orderID
                };
                SaveEvent(data);
            }
        });
        calendar.render();
    }

    function openAddEditForm() {

        if (selectedEvent != null) {

            $('#txtStart, #txtEnd').datetimepicker('destroy');

            $('#hdEventID').val(selectedEvent.id);
            $('#txtTitle').val(selectedEvent.title);
            $('#txtStart').val(moment(selectedEvent.start).format('DD.MM.YYYY HH:mm'));
            $('#chkIsFullDay').prop("checked", selectedEvent.allDay || false);
            $('#chkIsFullDay').change();
            $('#txtEnd').val(selectedEvent.end != null ? moment(selectedEvent.end).format('DD.MM.YYYY HH:mm') : '');
            $('#txtDescription').val(selectedEvent.description);
            $('#ddThemeColor').val(selectedEvent.color);
            $('#selectedOrder').val(selectedEvent.orderID);

            $('#txtStart, #txtEnd').datetimepicker({
                contentWindow: window,
                step: 30,
                minTime: '7:00',
                maxTime: '22:30',
                format: 'd.m.Y H:i'
            });
        }
        $('#eventModal').modal('hide');
        $('#eventModalSave').modal();
    }

    $('#btnSave').click(function () {
        //Validation
        //if ($('#txtTitle').val().trim() == "") {
        //    alert('Title required');
        //    return;
        //}
        //if ($('#txtStart').val().trim() == "") {
        //    alert('Start required');
        //    return;
        //}

        //if ($('#chkIsFullDay').is(':checked') == false && $('#txtEnd').val().trim() == "") {
        //    alert('End required');
        //    return;
        //}

        var data = {
            EventID: $('#hdEventID').val(),
            Title: $('#txtTitle').val().trim(),
            Start: $('#txtStart').val().trim(),
            End: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val().trim(),
            AllDay: $('#chkIsFullDay').is(':checked') ? true : false,
            Description: $('#txtDescription').val().trim(),
            BackgroundColor: $('#ddThemeColor').val(),
            OrderID: $('#selectedOrder').val(),
        }
        //call function for submit data on the server
        SaveEvent(data);
    })

    function SaveEvent(data) {
        $.ajax({
            type: "POST",
            url: '@Url.Action("SaveEvent", "Home")',
            data: data,
            dataType: "json",
            success: function (data) {
                //REFRESH CALENDAR
                drawCalendar();
                $('#eventModalSave').modal('hide');
            },
            error: function () {
                alert('Failed to refresh calendar after save');
            }
        })
    }

    $('#btnEdit').click(function () {
        openAddEditForm();
    })

    $('#btnDelete').click(function () {
        if (selectedEvent != null && confirm('Are you sure?')) {
            $.ajax({
                type: "POST",
                url: '@Url.Action("DeleteEvent", "Home")',
                data: { EventID: selectedEvent.id },
                dataType: "json",
                success: function () {
                    //REFRESH CALENDAR
                    drawCalendar();
                    $('#eventModal').modal('hide');

                },
                error: function () {
                    alert('Failed to refresh calendar after delete');
                }
            })
        }
    })

    $('#chkIsFullDay').change(function () {
        if ($(this).is(':checked')) {
            $('#divEndDate').hide();
        }
        else {
            $('#divEndDate').show();
        }
    });
})

// SELECT2

$('.select2').select2(
    {
        theme: 'bootstrap4',
    });

$('.myselect').select2(
    {
        width: 'resolve',
        height: 'resolve',
        allowClear: true,
        placeholder: {
            id: '0', // the value of the option
            text: 'Wybierz...'
        },
        sorter: function (data) {
            return data.sort(function (a, b) {
                return a.text < b.text ? -1 : a.text > b.text ? 1 : 0;
            })
        }
    });

$('.select2-multi').select2(
    {
        multiple: true,
        theme: 'bootstrap4',
    });

//DATETIMEPICKERS

$.datetimepicker.setLocale('pl');

$('#startDate').datetimepicker({
    contentWindow: window,
    timepicker: false,
    step: 30,
    minTime: '7:00',
    maxTime: '23:30',
    format: 'd.m.Y',
    defaultDate: new Date()
});

$('#PrintDate').datetimepicker({
    contentWindow: window,
    step: 5,
    format: 'd.m.Y H:i',
    defaultDate: new Date()
});

$('#endDate').datetimepicker({
    contentWindow: window,
    timepicker: false,
    step: 30,
    minTime: '7:00',
    maxTime: '23:30',
    format: 'd.m.Y',
    defaultDate: new Date()
});

$('#toDoDate').datetimepicker({
    contentWindow: window,
    format: 'd.m.Y H:i',
    defaultDate: new Date()
});





$('#dataTable-1').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_",
            "search": "Szukaj:",
            "zeroRecords": "Brak rekordów w tabeli",
            "info": "Wyświetlono _START_ do _END_ z łącznie _TOTAL_ pozycji",
            "infoEmpty": "Brak rekordów w tabeli",
            "infoFiltered": "(sfiltrowano z łącznie _MAX_ pozycji)",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        },
        "lengthMenu": [
            [10, 50, 100, -1],
            [10, 50, 100, "Wszystkie"]
        ],
        "dom": "frtilp",
        //"scrollX": true,
    });

$('#dataTable-2').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_",
            "search": "Szukaj:",
            "zeroRecords": "Brak rekordów w tabeli",
            "info": "Wyświetlono _START_ do _END_ z łącznie _TOTAL_ pozycji",
            "infoEmpty": "Brak rekordów w tabeli",
            "infoFiltered": "(sfiltrowano z łącznie _MAX_ pozycji)",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        },
        "lengthMenu": [
            [10, 50, 100, -1],
            [10, 50, 100, "Wszystkie"]
        ],
        "dom": "frtilp",
        //"scrollX": true,
    });

$('#dataTable-orders').DataTable(
    {
        "language": {
            "lengthMenu": "Pokaż _MENU_",
            "search": "Szukaj:",
            "zeroRecords": "Brak rekordów w tabeli",
            "info": "Wyświetlono _START_ do _END_ z łącznie _TOTAL_ pozycji",
            "infoEmpty": "Brak rekordów w tabeli",
            "infoFiltered": "(sfiltrowano z łącznie _MAX_ pozycji)",
            "paginate": {
                "first": "Pierwsza",
                "last": "Ostatnia",
                "next": "Następna",
                "previous": "Poprzednia"
            }
        },
        "lengthMenu": [
            [10, 50, 100, -1],
            [10, 50, 100, "Wszystkie"]
        ],
        "dom": "frtilp",
        //"scrollX": true
    });














$('.drgpicker').daterangepicker(
    {
        singleDatePicker: true,
        timePicker: false,
        showDropdowns: true,
        locale:
        {
            format: 'MM/DD/YYYY'
        }
    });
$('.time-input').timepicker(
    {
        'scrollDefault': 'now',
        'zindex': '9999' /* fix modal open */
    });
/** date range picker */
if ($('.datetimes').length) {
    $('.datetimes').daterangepicker(
        {
            timePicker: true,
            startDate: moment().startOf('hour'),
            endDate: moment().startOf('hour').add(32, 'hour'),
            locale:
            {
                format: 'M/DD hh:mm A'
            }
        });
}
var start = moment().subtract(29, 'days');
var end = moment();

function cb(start, end) {
    $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
}
$('#reportrange').daterangepicker(
    {
        startDate: start,
        endDate: end,
        ranges:
        {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        }
    }, cb);
cb(start, end);
$('.input-placeholder').mask("00/00/0000",
    {
        placeholder: "__/__/____"
    });
$('.input-zip').mask('00000-000',
    {
        placeholder: "____-___"
    });
$('.input-money').mask("#.##0,00",
    {
        reverse: true
    });
$('.input-phoneus').mask('(000) 000-0000');
$('.input-mixed').mask('AAA 000-S0S');
$('.input-ip').mask('0ZZ.0ZZ.0ZZ.0ZZ',
    {
        translation:
        {
            'Z':
            {
                pattern: /[0-9]/,
                optional: true
            }
        },
        placeholder: "___.___.___.___"
    });
// editor
var editor = document.getElementById('editor');
if (editor) {
    var toolbarOptions = [
        [
            {
                'font': []
            }],
        [
            {
                'header': [1, 2, 3, 4, 5, 6, false]
            }],
        ['bold', 'italic', 'underline', 'strike'],
        ['blockquote', 'code-block'],
        [
            {
                'header': 1
            },
            {
                'header': 2
            }],
        [
            {
                'list': 'ordered'
            },
            {
                'list': 'bullet'
            }],
        [
            {
                'script': 'sub'
            },
            {
                'script': 'super'
            }],
        [
            {
                'indent': '-1'
            },
            {
                'indent': '+1'
            }], // outdent/indent
        [
            {
                'direction': 'rtl'
            }], // text direction
        [
            {
                'color': []
            },
            {
                'background': []
            }], // dropdown with defaults from theme
        [
            {
                'align': []
            }],
        ['clean'] // remove formatting button
    ];
    var quill = new Quill(editor,
        {
            modules:
            {
                toolbar: toolbarOptions
            },
            theme: 'snow'
        });
}
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();