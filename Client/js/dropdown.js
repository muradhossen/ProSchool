
//Get and generate class dropdown
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7203/api/classes',
        method: 'GET',
        dataType: 'json',
        success: function (data) {            
            GenerateClassDropdown(data);
        },
        error: function (xhr, status, error) {
             
            console.error(xhr.responseText);
        }
    });

        $('#dropdown').change(function () {
            var selectedValue = $(this).val();           
            applyFilter(selectedValue);
        });
});

function GenerateClassDropdown(data) {
    var dropdown = $('#dropdown');
    dropdown.empty();
     
    dropdown.append($('<option>', {
        value: '',
        text: 'Select an option'
    }));
   
    data.forEach(function (item) {
        dropdown.append($('<option>', {
            value: item.classId,  
            text: item.className  
        }));
    });
}

function clearFilter(){
    var dropdown = $('#dropdown');
    dropdown.val('');

    applyFilter('');
}
 