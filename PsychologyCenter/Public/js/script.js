$(document).ready(function () {



    //Like//


    $('.like').click(function (e) {
        e.preventDefault();
        var id = $('.BlogID').val();
        $.ajax({
            type: 'POST',
            url: '/Home/Like',
            data: { id },
            dataType: 'json'
        }).done(function (response) {
            if (response.Status.toString() === "200") {
                var likecount = $('.LikeCount').text();
                var total = parseInt(likecount) + 1;
                $('.LikeCount').text(parseInt(total));

            }
        }).fail(function (data) {

        });
    });



    //COMMENT//


    $('.commentButton').click(function (e) {
        e.preventDefault();
        var blogId = $('.BlogID').val();
        var message = $('#message').val();
        var name = $('#name').val();
        $.ajax({
            type: 'POST',
            url: '/Home/CommentBlog',
            data: { blogId, name, message },
            dataType: 'json'
        }).done(function (response) {
            console.log(response.Status.toString());
            swal("Uğurlu!", "Rəyiniz göndərildi!", "success");

            if (response.Status.toString() === "200") {

                $('#message').val('');
                $('#name').val('');
            }
        }).fail(function (data) {
            swal("Uğursuz!", "Xəta baş verdi yenidən yoxlayın!", "error");
            $('#message').val('');
            $('#name').val('');
        });
    });



    //Mail appointmen Ajax
    //---------------------* /

    $('.appointment').click(function (e) {
        e.preventDefault();
        var email = $('#email').val();
        var name = $('#name').val();
        var number = $('#number').val();
        var date = $('#date').val();
        var message = $('#message').val();

        $.ajax({
            type: 'POST',
            url: 'Home/Message',
            data: { email, name, number, date, message },
            dataType: 'json'
        }).done(function (response) {
            console.log(response);
            swal("Uğurlu!", "Mesajınız göndərildi!", "success");
        }).fail(function (data) {
            swal("Uğursuz!", "Xəta baş verdi yenidən yoxlayın və məlumatların hamısını doldurduğunuza əmin olun!", "error");
        });
    });


    //Mail contact Ajax
    //---------------------* /

    $('.contactMessage').click(function (e) {
        e.preventDefault();
        var email1 = $('#email1').val();
        var name1 = $('#name1').val();
        var phone1 = $('#phone1').val();
        var subject1 = $('#subject1').val();
        var message1 = $('#message1').val();

        $.ajax({
            type: 'POST',
            url: 'Home/ContactMessage',
            data: { email1, name1, phone1, subject1, message1 },
            dataType: 'json'
        }).done(function (response) {
            swal("Uğurlu!", "Mesajınız göndərildi!", "success");
        }).fail(function (data) {
            swal("Uğursuz!", "Xəta baş verdi yenidən yoxlayın və məlumatların hamısını doldurduğunuza əmin olun!", "error");
        });
    });
});
