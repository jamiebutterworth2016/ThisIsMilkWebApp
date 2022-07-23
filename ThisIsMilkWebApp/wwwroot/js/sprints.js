function submitSprint() {
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
        success: function (data) {
            alert('Successfully received Data ');
            $("#sprintsView").html(data);
        },
        error: function (data) {
            alert('Failed to receive the Data');
        }
    })
}