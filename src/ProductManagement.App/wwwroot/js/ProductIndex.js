$(document).ready(function() {
    $('#btnClear').on('click',
        function() {
            swal({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, clear it!'
            }).then((result) => {
                if (result.value) {
                    clearData();
                }
            })
        });

    function clearData() {
        $.ajax({
            url: '/api/Product/ClearAll',
            type: 'POST'
        }).done(function() {
            swal({
                title: 'Deleted!',
                text: 'Your file has been deleted.',
                type: 'success'
            }).then(function() {
                location.reload();
            });
        });
    }
});