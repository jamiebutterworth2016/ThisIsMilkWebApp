function submitSprint() {

    var sprintDescription = $('#sprintDescription').val().trim();
    var sprintStartDate = $('#sprintStartDate').val().trim();
    var sprintLengthInDays = parseInt($('#sprintLengthInDays').val().trim()) || 0;

    if (sprintDescription === "") {
        showErrorMessage('Please enter a description');
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
    $('#alert-danger').hide();
    $('#alert-success').hide();

    $('#sprintsView-Loading').show();
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
            $('#sprintsView').html(data);
            $('#alert-success').html('Successfully created sprint');
            $('#alert-success').show();
            $('#sprintsView-Loading').hide();
            $('#sprintsView').show();

            $('#sprintDescription').val('');
            $('#sprintStartDate').val('');
            $('#sprintLengthInDays').val('1');
        },
        error: () => {
            $('#alert-danger').html('Failed to create sprint. Please refresh page');
            $('#alert-danger').show();
            $('#sprintsView-Loading').hide();
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