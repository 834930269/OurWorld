$(document).ready(function () {
    $("#firstmenu").mouseover(
        function () {
            $(this).css('background-color', 'black');
            $(this).css('color', '#5BC0DE');
        }
    );
    $("#firstmenu").mouseout(
        function () {
            $(this).css('background-color', '#191919');
            $(this).css('color', '#bdbdbd');
        }
    );

    $("#secondmenu").hover(
        function () {
            $(this).css('background-color', 'black');
            $(this).css('color', '#5BC0DE');
        },
        function () {
            $(this).css('background-color', '#191919');
            $(this).css('color', '#bdbdbd');
    });
    $("#thirdmenu").hover(
        function () {
            $(this).css('background-color', 'black');
            $(this).css('color', '#5BC0DE');
        },
        function () {
            $(this).css('background-color', '#191919');
            $(this).css('color', '#bdbdbd');
    });
    $("#fourthmenu").hover(
        function () {
            $(this).css('background-color', 'black');
            $(this).css('color', '#5BC0DE');
        },
        function () {
            $(this).css('background-color', '#191919');
            $(this).css('color', '#bdbdbd');
    });
});
