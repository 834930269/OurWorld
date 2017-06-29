function changeType1() {
      var a = document.getElementById('a1');
      a.setAttribute('class', 'active');
      var a2 = document.getElementById('a2');
      a2.setAttribute('class', '');
      var tq = document.getElementById('rule');
      tq.setAttribute('class', 'navs-slider-bar');
      $('#Login').css('display', 'none');
      $('#Register').css('display', '');
}
function changeType2() {
    var a = document.getElementById('a2');
    a.setAttribute('class', 'active');
    var a2 = document.getElementById('a1');
    a2.setAttribute('class', '');
    var tq = document.getElementById('rule');
    tq.setAttribute('class', 'navs-slider-bar2');
    $('#Login').css('display', '');
    $('#Register').css('display', 'none');
}