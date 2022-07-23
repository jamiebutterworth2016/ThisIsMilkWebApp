function submitSprint() {

    $('#btnCreateSprint').prop('disabled', true);
    $('#alert-danger').hide();
    $('#alert-success').hide();

    $('#sprintsView-Loading').show();
    $('#sprintsView').hide();

    //show loading card and wait 5 secs
    setTimeout(() => {
        createSprint();
    }, 5000);
}

function createSprint(data) {

    var data =
    {
        numberOfDaysInSprint: $('#numberOfDaysInSprint').val(),
        storyPoints: $('#storyPoints').val()
    };

    $.ajax({
        url: '/Sprint/CreateSprint',
        type: 'POST',
        dataType: 'html',
        data: data,
        success: (data) => {
            alert('Successfully received Data ');
            $('#btnCreateSprint').prop('disabled', false);
            $('#sprintsView').html(data);
            $('#alert-success').html('Successfully created sprint');
            $('#alert-success').show();
            $('#sprintsView-Loading').hide();
            $('#sprintsView').show();
        },
        error: () => {
            $('#alert-danger').html('Failed to create sprint. Please refresh page');
            $('#alert-danger').show();
            $('#sprintsView-Loading').hide();
            $('#sprintsView').hide();
        }
    })
}