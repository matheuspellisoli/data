$(document).ready(function(){
    var toggle = true;
    $("#toggleButton").click(function(){ 
        if(toggle){
            $("#Button").removeClass("toggleRight");
            $("#Button").addClass("toggleLeft");

            $("#toggleLabel").text("+");
            $("#toggleLabelHiden").text("-");
            toggle = false;
        }else{
            $("#Button").removeClass("toggleLeft");
            $("#Button").addClass("toggleRight");

            $("#toggleLabel").text("-");
            $("#toggleLabelHiden").text("+");
            toggle = true;

            
        }
    })
});