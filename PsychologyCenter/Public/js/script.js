$(document).ready(function () {

    $(".load-more-blog a").click(function (ev) {
        ev.preventDefault();

        var data = { page: Number($(this).parent().data("page")) };

        
        // Load With Json
        var url = "/blog/getblogpartjs?page=" + data.page;
        

        var currentUrl = new URL(window.location.href);

        if (currentUrl.searchParams.get("category") !== null) {
            url += "&categoryid=" + currentUrl.searchParams.get("category");
        }

        $.getJSON(url, function (response) {

            $.each(response.data, function (key, value) {
                $(".load-more-blog").before(addBlog(value));
            });

            if (!response.NextPage) {
                $(".load-more-blog").remove();
            } else {
                $(".load-more-blog").data("page", data.page + 1);
            }
        });

    });

    function addBlog(blog) {
        var html = ` <div class="blog-post">
                    <div class="blog-post-single">
                        <figure title="${blog.Title}">
                            <img src="${blog.Photo}" alt="${blog.Title}">
                        </figure>
                        <ul class="blog-meta list-style">
                            <li><a href="${blog.Url}"><img src="${blog.Author.Photo}" alt="${blog.Author.Fullname}">${blog.Author.Fullname}</a></li>
                            <li><a href="${blog.Url}">${blog.Date}</a></li>
                        </ul>
                        <h3><a href="${blog.Url}">${blog.Title}</a></h3>
                        <p>${blog.Desc}</p>
                        <a href="${blog.Url}">Continue Reading</a>
                    </div>
                </div>`;
        return html;
    }
});




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
            dataType:'json'
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
