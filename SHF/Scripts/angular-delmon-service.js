

var app = angular.module('InventoryApp');

app.service('CustomService', function () {

    function getCookie(cname, key) {
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split('&');
        var value = 0;
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            var KeyValuePair = c.split('=');
            if (KeyValuePair[0] == key) {
                switch (KeyValuePair[0]) {
                    case 'DItnaneT':
                        value = KeyValuePair[1];
                        break;

                    case 'DIhcnarB':
                        value = KeyValuePair[1];
                        break;

                    default:
                        break;
                }
            }
        }

        return value;
    }

    function checkCookie() {
        var user = getCookie("nomleD");
        if (user != "") {
            alert("Welcome again " + user);
        }
        else {
            user = prompt("Please enter your name:", "");
            if (user != "" && user != null) {
                setCookie("nomleD", user, 30);
            }
        }
    }

    function GetCustomFormatDate(dateValue, format = "") {
        var newdate = new Date(parseInt(dateValue.substr(6)));
        format = format == "" ? "dd/mm/yyyy" : format;
        return newdate.format(format)
    }

    function applyDateFormat(obj, format) {

        if (!Array.isArray(obj)) {
            if (obj != null) {

                if (typeof (obj) == "object") {

                    let dat = Object.values(obj);
                    Object.keys(obj).forEach(function (key, index) {

                        if (typeof (Object.keys(obj)[index]) == "object") {

                            applyDateFormat(Object.keys(obj)[index], format);
                        }
                        if (key.toString().includes("Date") || key.toString().includes("CreatedOn") || key.toString().includes("UpdatedOn")) {

                            key = GetCustomFormatDate(obj.key, format)
                        }
                        //if (key != null && obj[index] != null && key == "CreatedOn" && obj[index].toString().includes("Date")) {
                        //     
                        //    obj[index] = GetCustomFormatDate(obj[key], format)
                        //}
                    });
                } else {
                    if (obj != null && obj.toString().includes("Date")) {

                        obj = GetCustomFormatDate(obj, format)
                    }
                }
            }
        }
        else {
            if (obj != null && Array.isArray(obj) && obj.length > 0) {
                obj.forEach(function (key, index) {
                    applyDateFormat(obj[index], format);
                });
            }
        }
    }



    this.GetTenantID = function () {
        return getCookie('nomleD', 'DItnaneT');
    }

    this.GetUserName = function () {
        return getCookie('nomleD', 'emaNeloR');
    }

    this.FormatExistingDateValue = function (obj, format = "") {
        format = format == "" ? "dd/mm/yyyy" : format;
        applyDateFormat(obj, format);
    }

    this.sleep = function (milliseconds) {
        var start = new Date().getTime();
        for (var i = 0; i < 1e7; i++) {
            if ((new Date().getTime() - start) > milliseconds) {
                break;
            }
        }
    }

    this.PrintDiv = function (divID) {
        //Get the HTML of div
        var divElements = document.getElementById(divID).innerHTML;
        //Get the HTML of whole page
        var oldPage = document.body.innerHTML;

        //Reset the page's HTML with div's HTML only
        document.body.innerHTML =
            "<html><head><title></title></head><body>" +
            divElements + "</body>";

        //Print Page
        window.print();

        //Restore orignal HTML
        document.body.innerHTML = oldPage;

    }



    this.ShowMessage = function (messageCode) {
        if (messageCode) {
            let NOTIFICATION_MESSAGES = JSON.parse(localStorage.getItem("NOTIFICATION_MESSAGES"));
            if (NOTIFICATION_MESSAGES && NOTIFICATION_MESSAGES.length > 0) {
                let MESSAGES = JSLINQ(NOTIFICATION_MESSAGES).Where(function (message) { return message.MessageCode == messageCode; });
                if (MESSAGES && MESSAGES.items && MESSAGES.items.length > 0) {
                    let MESSAGE = MESSAGES.items[0];
                    swal({ icon: MESSAGE.Icon, title: MESSAGE.Title, text: MESSAGE.MessageCode + ': ' + MESSAGE.Description });
                }
            } else {
                swal("Whooaaa! Please logout and login again...", "", "error");
            }
        }
        else {
            swal("ERR 10: Whooaaa! Message code" + messageCode + " does not exists.", "", "error");
        }
    }


    this.Alert = function (response) {
        swal(response.data.Title, response.data.Message, response.data.Icon);
    }


    this.Notify = function (MessageCode) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["error"](MessageCode);
    }

    this.OnClose = function (modelId) {
        swal({
            title: "Are you sure?",
            text: "Once close, you will not be able to recover this data!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $('#' + modelId).modal("hide");
                }
            });
    }

    this.Thread = {
        sleep: function (ms) {           
            let start = Date.now();
            while (true) {
                let clock = (Date.now() - start);
                if (clock >= ms) break;
            }

        }
    };

    this.ConvertNumberToWord = function (Total) {

        var words = new Array();
        words[0] = '';
        words[1] = 'one';
        words[2] = 'two';
        words[3] = 'three';
        words[4] = 'four';
        words[5] = 'five';
        words[6] = 'six';
        words[7] = 'seven';
        words[8] = 'eight';
        words[9] = 'nine';
        words[10] = 'ten';
        words[11] = 'eleven';
        words[12] = 'twelve';
        words[13] = 'thirteen';
        words[14] = 'fourteen';
        words[15] = 'fifteen';
        words[16] = 'sixteen';
        words[17] = 'seventeen';
        words[18] = 'eighteen';
        words[19] = 'nineteen';
        words[20] = 'twenty';
        words[30] = 'thirty';
        words[40] = 'forty';
        words[50] = 'fifty';
        words[60] = 'sixty';
        words[70] = 'seventy';
        words[80] = 'eighty';
        words[90] = 'ninety';
        amount = Total.toString();
        var atemp = amount.split(".");
        var number = atemp[0].split(",").join("");
        var n_length = number.length;
        var words_string = "";
        if (n_length <= 9) {
            var n_array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
            var received_n_array = new Array();
            for (var i = 0; i < n_length; i++) {
                received_n_array[i] = number.substr(i, 1);
            }
            for (var i = 9 - n_length, j = 0; i < 9; i++ , j++) {
                n_array[i] = received_n_array[j];
            }
            for (var i = 0, j = 1; i < 9; i++ , j++) {
                if (i == 0 || i == 2 || i == 4 || i == 7) {
                    if (n_array[i] == 1) {
                        n_array[j] = 10 + parseInt(n_array[j]);
                        n_array[i] = 0;
                    }
                }
            }
            value = "";
            for (var i = 0; i < 9; i++) {
                if (i == 0 || i == 2 || i == 4 || i == 7) {
                    value = n_array[i] * 10;
                } else {
                    value = n_array[i];
                }
                if (value != 0) {
                    words_string += words[value] + " ";
                }
                if ((i == 1 && value != 0) || (i == 0 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "crores ";
                }
                if ((i == 3 && value != 0) || (i == 2 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "lakhs ";
                }
                if ((i == 5 && value != 0) || (i == 4 && value != 0 && n_array[i + 1] == 0)) {
                    words_string += "thousand ";
                }
                //if (i == 6 && value != 0 && (n_array[i + 1] != 0 && n_array[i + 2] != 0)) {
                //    words_string += "hundred and ";
                //}
                //else if (i == 6 && value != 0) {
                //    words_string += "hundred ";
                //}
                 if (i == 6 && value != 0) {
                    words_string += "hundred ";
                }
            }
            words_string = words_string.split("  ").join(" ");
        }
        var AmountInWords =  words_string;
        // return words_string;
        return AmountInWords;
    }


    this.ConvertNumberToWordwithDecimal = function(n) {
        var nums = n.toString().split('.')
        var whole = this.ConvertNumberToWord(nums[0])
        if (nums.length == 2) {
            var fraction = this.ConvertNumberToWord(nums[1])
            if (fraction == "") {
                return 'Rupees  ' + whole;
            }
            else {
                return 'Rupees  ' + whole + 'and ' + fraction + ' paise';
            }
        } else {
            return 'Rupees  ' + whole;
        }
    }
});