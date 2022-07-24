function submitSprint() {

    var sprintDescription = $('#sprintDescription').val().trim();
    var sprintStartDate = $('#sprintStartDate').val().trim();
    var sprintLengthInDays = parseInt($('#sprintLengthInDays').val().trim()) || 0;

    var regexConst = new RegExp('^[a-zA-Z0-9_ ]{1,24}$');
    var sprintDescriptionIsValid = regexConst.test(sprintDescription);

    if (!sprintDescriptionIsValid) {
        showErrorMessage('Please enter a description - alphanumeric, 24 characters max');
        return;
    }

    if (sprintStartDate === "") {
        showErrorMessage('Please select a date in dd/MM/yyyy format');
        return;
    }

    if (sprintLengthInDays < 1 || sprintLengthInDays > 5) {
        showErrorMessage('Please select a sprint length from 1 to 5 days');
        return;
    }

    var data =
    {
        sprintDescription: sprintDescription,
        sprintStartDate: sprintStartDate,
        sprintLengthInDays: sprintLengthInDays
    };

    $('#btnCreateSprint').prop('disabled', true);

    $('#btnCreateSprintSpinner').show();
    $('#alert-danger').hide();
    $('#alert-success').hide();

    $('#sprintsView').hide();

    //show loading card and wait
    setTimeout(() => {
        createSprint(data);
    }, 3000);
}

function createSprint(data) {

    $.ajax({
        url: '/Sprint/CreateSprint',
        type: 'POST',
        dataType: 'html',
        data: data,
        success: (data) => {
            $('#btnCreateSprint').prop('disabled', false);
            $('#btnCreateSprintSpinner').hide();

            $('#sprintsView').html(data);
            $('#alert-success').html('Successfully created sprint');
            $('#alert-success').show();
            $('#sprintsView').show();

            $('#sprintDescription').val('');
            $('#sprintStartDate').val('');
            $('#sprintLengthInDays').val('1');
        },
        error: () => {
            $('#btnCreateSprintSpinner').hide();

            $('#alert-danger').html('Failed to create sprint. Please refresh page');
            $('#alert-danger').show();
            $('#sprintsView').hide();
        }
    })
}

function showSuccessMessage(message) {
    $('#alert-danger').hide();
    $('#alert-success').html(message);
    $('#alert-success').show();
}

function showErrorMessage(message) {
    $('#alert-success').hide();
    $('#alert-danger').html(message);
    $('#alert-danger').show();
}

$('#sprintLengthInDays').change(() => {
    if ($('#sprintLengthInDays').val() === "") {
        $('#sprintLengthInDays').val('1');
    }
});