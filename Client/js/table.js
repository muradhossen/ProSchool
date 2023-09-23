

// $.ajax({
//     url: 'https://localhost:7203/api/students',
//     method: 'GET',
//     dataType: 'json', 
//     success: function (data) {
       
//         var $studentTableBody = $('#studentTable tbody');

//         $.each(data, function (index, item) {
//             var $row = $('<tr>');
//             $row.append($('<td>').text(item.sl));
//             $row.append($('<td>').text(item.studentId));
//             $row.append($('<td>').text(item.studentName));
//             $row.append($('<td>').text(item.classId));
//             $studentTableBody.append($row);
//         });

//         // $('#studentTable').DataTable();
//     },
//     error: function (xhr, status, error) {
//         // Handle any errors that occur during the request
//         console.error(xhr.responseText);
//     }
// });

// $(document).ready(function () {
//     $('#studentTable').DataTable({
//         ajax: {
//             url: 'https://localhost:7203/api/students', 
//             dataSrc: ''
//         },
//         columns: [
//             { data: 'studentId' },
//             { data: 'studentName' },
//             { data: 'classId' },
//             { data: 'sl' }
//         ],
//         language : {
//             "loadingRecords": "Please wait - loading..."
//          },
 
//     });
// });
 

//table
$(document).ready(function () {
    getStudens();
});
 

function getStudens() {
    $.ajax({
        url: 'https://localhost:7203/api/students/all',
        method: 'GET',
        dataType: 'json',
        success: function (data, status, xhr) {
            // Access response headers
            var paginationHeader = JSON.parse(xhr.getResponseHeader('pagination'));
             
            // Initialize DataTables with the received data
            $('#studentTable').DataTable({
                data: data,
                dataSrc: '' ,
                columns: [
                    // { data: 'sl' },
                    { data: 'studentId' },
                    { data: 'studentName' },
                    { data: 'classId' },
                    {data : 'className'}                    
                ],
                language : {
                            "loadingRecords": "Please wait - loading..."
                            },
                pageLength: 5,
                lengthMenu: [5, 10, 25, 50],
                // processing: true,
                // serverSide: true
            });
        },
        error: function (xhr, status, error) {
             
            console.error(xhr.responseText);
        }
    });
}


function applyFilter(filterCriteria) {

    var table = $('#studentTable').DataTable();

    table.column(2)
    .search(filterCriteria)
    .draw();
}

function destroyStudentTable(){
var table = $('#studentTable').DataTable();
table.destroy();
}



