$( "#toggle" ).click(function() {
  $(".menu").toggleClass("closed");
  $(this).toggleClass("closed");
  $(".content").toggleClass("closed");
  $("#wrapper").toggleClass("closed")
});