$(function () {
    var state = 0;
    $('#saveChanges').on('click', function () {
        if (state === 200) {
            $('#showdialog').click();
            console.log("work")
        }
        else {
            document.getElementById('1').click();
            document.getElementById('1').classList.add("active");
            $('#showdialog').click();
        }
    });

    $('#ModalButton').on('click', function () {
            $("#exampleModal").removeAttr("id")

        if ($("form").valid()) {
            $(".now").attr("id", "exampleModal");
            }
    });



    $("form").validate({
        rules: {
            username: {
                required: true,
                minlength: 8,
            },
            useremail: {
                required: true,
                email: true
            },
            usernumber: {
                required: true,
                maxlength: 10,
                minlength: 10
            }

        },

        messages: {
            username: { required: "Please enter name", minlength: "name should have 8 letters at least" },
            useremail: { required: "Please enter email", email: "please enter valid email" },
            usernumber: { required: "Please enter your number", maxlength: "Number should have 10 digits", minlength: "Number should have 10 digits" },
        },
    });


    $("#group1 button").click(function (e) {
        document.getElementById('1').classList.remove("active");
        $.ajax({
            type: "POST",
            url: "/Home/Temprory/",
            dataType: "text",
            data: {
                "id": $(this).attr('id'),
                "value": $(this).text(),
            },
            success: function (result) {
                alert('ok ' + result);
                state = 200;
                $(this).addClass('active')
            },
            error: function (result) {
                alert('error');
            }
        });
    });

    $("#group2 button").click(function (e) {
        $.ajax({
            type: "POST",
            url: "/Home/Temprory/",
            dataType: "text",
            data: {
                "id": $(this).attr('id'),
                "value": $(this).text(),
            },
            success: function (result) {
               // alert('ok this is 2' + result);
                function JSalert() {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Your message has created successfully',
                        showConfirmButton: false,
                        timer: 2000
                    })
                }
                  JSalert();
                
                $('form[name="Regestration"]').submit();

            },
            error: function (result) {
                alert('error');
            }
        });
    });


})