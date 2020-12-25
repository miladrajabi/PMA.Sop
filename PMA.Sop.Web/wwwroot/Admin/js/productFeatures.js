function AddTempFeatures() {
    var feature = {};
    feature.Title = $('#Pr_Title').val();
    feature.EnglishTitle = $('#Pr_EnglishTitle').val();
    feature.Description = $('#Pr_Description').val();
    var errors = "";
    if (feature.Title.trim().length === 0) {
        errors += "عنوان را وارد نمایید.<br>";
        $('#Pr_Title').addClass("border-danger");
    } else {
        $('#Pr_Title').removeClass("border-danger");
    }

    if (feature.Description.trim().length == 0) {
        errors += "لطفا توضیحات را وارد نمایید.<br>";
        $('#Pr_Description').addClass("border-danger");
    } else {
        $('#Pr_Description').removeClass("border-danger");
    }
    if (errors.length > 0) { //if errors detected then notify user and cancel transaction
        ShowMsn(errors);
        return false; //exit function
    }
    var existTitle = false; // < -- Main indicator
    $('#table-information > tbody  > tr').each(function() {
        var title = $(this).find('.TitleCol').text(); // get text of current row by class selector
        if (feature.Title.toLowerCase() === title.toLowerCase()) { //Compare provided and existing title
            existTitle = true;
            return false;
        }
    });


if (existTitle === false) {
        ClearMsn();
        //Create Row element with provided data
        var row = $('<tr>');
        $('<td>').html(feature.Title).addClass("TitleCol").appendTo(row);
        $('<td>').html(feature.EnglishTitle).appendTo(row);
        $('<td>').html(feature.Description).appendTo(row);
        $('<td>').html("<div class='text-center'><button class='btn btn-danger btn-sm' onclick='Delete($(this))'>حذف</button></div>").appendTo(row);

        //Append row to table's body
        $('#table-body').append(row);
        CheckSubmitBtn(); // Enable submit button
    } else {
        ShowMsn("عنوان باید یکتا باشد.");
    }
}

function ClearForm() {
    $('#PrFeatures input[type="text"]').val('');
}

//Msn label for notifications
function ShowMsn(message) {
    $('#Msn').html(message);
}

//Clear text of Msn label
function ClearMsn() {
    $('#Msn').html("");
}

//Delete selected row
function Delete(row) { // remove row from table
    row.closest('tr').remove();
    CheckSubmitBtn();
}

function CheckSubmitBtn() {
    if ($('#table-information > tbody  > tr').length > 0) { // count items in table if at least 1 item is found then enable button  
        $('#btnSubmit').removeAttr("disabled");
    } else {
        $('#btnSubmit').attr("disabled", "disabled");
    }
}