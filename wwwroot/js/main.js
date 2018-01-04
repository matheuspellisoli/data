function setDateTime(){
    $.get("/api/date", function(data, status){
        $("#Labeldate").empty();
        $("#Labeldate").append(data.stringDate);
        $("#date").val(data.day + "/" + data.month + "/" + data.year) 
        $("#time").val(data.hour+":"+data.minute) 
});


}

$(document).ready(function(){
    setDateTime();
    var erros = "";

    $("#date").keyup(function(){
        if ($(this).val().length == 2){
            $(this).val($(this).val() + "/");
        }else if ($(this).val().length == 5){
            $(this).val($(this).val() + "/");
        }
    });
    $("#time").keyup(function(){
        if ($(this).val().length == 2){
            $(this).val($(this).val() + ":");
        }
    });

    $("#calcular").click(function(){  
        var erro = false;
        if($("#date").val() == ""){
            erro = true;
            $("#date").addClass("erro");
        }else if($("#time").val() == ""){
            erro = true;
            $("#time").addClass("erro");
        }else if($("#op").val() == ""){
            erro = true;
            $("#op").addClass("erro");
        }else if($("#value").val() == ""){
            erro = true;
            $("#value").addClass("erro");
        }
        
        if(!erro){
            $("#date").removeClass("erro");
            $("#time").removeClass("erro");
            $("#op").removeClass("erro");
            $("#value").removeClass("erro");
            
            $.ajax({
                url: "http://localhost:5000/api/date/?date="+$("#date").val() +" "+ $("#time").val()  +"&op="+$("#op").val()+"&value="+$("#value").val(),
                type: 'put',
                contentType: "application/json; charset=utf-8",
                Accept: 'application/json',
                dataType: 'json',
                headers: {
                    "Content-Type":"application/json"
                   },
                success: function(data){
                    setDateTime(); 
                },
                error : function(err) {
                    console.log(err)
                },
                data:  {
                    date: $("#date").val(),
                    op: "+",
                    value: $("#value").val()
                },                
              });
            
        }
       

    });
});
