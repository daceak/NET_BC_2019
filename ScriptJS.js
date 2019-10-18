// JavaScript source code
/*document.getElementById("ok").onclick = function() {
    var name = document.getElementById("name").value;
    var age = document.getElementById("age").value;

    var text = "Your name is " + name;
    text += " and you are " + age + " years old";

    document.getElementById("result").innerHTML = text; //innerHTML tas, ko ielikt html
    document.getElementById("ok").style.display = "none";*/
$(function() {                      //this means: execute js after html id processed. $ for jQuery
    $("#ok").click(function() {     //var atrast klasi ta pat ka css,piem., .blue. pirms tam noradot #
        var name = $("#name").val();
        var age = parseInt($("#age").val());
        age += 5;
        var text = "Your name is " + name;
        text += " and you are " + age + " years old";
        $("#result").html(text);
        $("#ok").hide();
    });
});
//ar jQuery nevajag veidot ciklu, lai visus objktus parveidotu, iem, #div   all divs
$(function() { 
    $("#plus").click(function() { 
        var num1 = parseInt($("#no1").val());
        var num2 = parseInt($("#no2").val());
        var result = num1 + num2;
        var text = "Sum is " + result;
        $("#mathResult").html(text);
    });

    $("#minus").click(function() {
        var num1 = parseInt($("#no1").val());
        var num2 = parseInt($("#no2").val());
        var result = num1 - num2;
        var text = "Difference is " + result;
        $("#mathResult").html(text);
    });
});