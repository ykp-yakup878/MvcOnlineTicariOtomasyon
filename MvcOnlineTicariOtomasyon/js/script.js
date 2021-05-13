//admin open
$('.button').click(function(){
  var buttonId = $(this).attr('id');
  $('#modal-container').removeAttr('class').addClass(buttonId);
  $('body').addClass('modal-active');
});

// $('#modal-container').click(function close() {
//     $(this).addClass('out');
//     $('body').removeClass('modal-active');
//   });

//admin out
  $('#btn').click(function close() {
    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');
  });


// cari kayıt open
$('.carikayit').click(function(){
  var buttonId = $(this).attr('id');
  $('.carikayit2').removeAttr('class').addClass(buttonId);
  $('body').addClass('modal-active');
});

//cari kayıt out
  $('#btn2').click(function close() {
    $('.five').addClass('out');
    $('.five').addClass('carikayit2');
    $('body').removeClass('modal-active');
  });


  // cari giriş open
$('.carigiris').click(function(){
  var buttonId = $(this).attr('id');
  $('.carigiris1').removeAttr('class').addClass(buttonId);
  $('body').addClass('modal-active');
});


//cari giriş out
  $('#btn1').click(function close() {
    $('.two').addClass('out');
    $('.two').addClass('carigiris1');
    $('body').removeClass('modal-active');
  });
