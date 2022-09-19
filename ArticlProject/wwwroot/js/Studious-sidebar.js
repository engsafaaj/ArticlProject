$(document).ready(function () {
    $("#sidebar").niceScroll({
        cursorcolor: 'rgba(0,0,0,.3)',
        cursorwidth: 0,
        cursorborder: 'none'
    });
    
    $('#sidebar a').on('click', function(){
        setTimeout( function() {
                $("#sidebar").getNiceScroll().resize();
        }, 500);
    });

    $('#close-sidebar, .overlay').on('click', function () {
        $('#sidebar').removeClass('active');
        $('.overlay').fadeOut();
    });

    $('.open-sidebar').on('click', function () {
        $('#sidebar').addClass('active');
        $('.overlay').fadeIn();
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
});