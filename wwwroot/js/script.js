$(document).ready(function(){
    toggle = "+";
    $.get("/api/date", function(data, status){
        setValues(data)
        
    });
    $("#toggleButton").click(function(){ 
        if(toggle == "-"){
            $("#Button").removeClass("toggleRight");
            $("#Button").addClass("toggleLeft");

            $("#toggleLabel").text("+");
            $("#toggleLabelHiden").text("-");
            $("#toggleValue").val("+");
            toggle = "+";
        }else{
            $("#Button").removeClass("toggleLeft");
            $("#Button").addClass("toggleRight");

            $("#toggleLabel").text("-");
            $("#toggleLabelHiden").text("+");
            $("#toggleValue").val("-");
            toggle = "-";

            
        }
    })
});
function setValues(date){

    if(date.day <= 9){
        date.day = "0" + date.day
    }
    if(date.month <= 9){
        date.month = "0" + date.month
    }
    if(date.hour <= 9){
        date.hour = "0" + date.hour
    }
    if(date.minute <= 9){
        date.minute = "0" + date.minute
    }

    $("#date").val(date.year +"-"+ date.month +"-"+ date.day);    
    $("#hour").val(date.hour + ":" + date.minute);
    $("#minute").val();
    $("#dateLabel").text( date.day +"/"+ date.month +"/"+ date.year + " " + date.hour + ":" + date.minute)
}

function clear(){
    $("#date").val("");
    $("#hour").val("");
    $("#minute").val("");

    $("#errDate").text("");
    $("#errHour").text("");
    $("#errMinute").text("");
}


$("#clear").click(function(){
    clear();
})

function getdate(){
    var date = $("#date").val();
    if(date == ""){
        result = {
            error : true,
            value: null,
            info : { 
                message : "selecione uma data válido",
                code : 01
            }
        }
        return result;
    }
    result = {
        error : false,
        value: date = date[8] + date[9] +"/"+ date[5] + date[6] +"/"+ date[0] + date[1] + date[2] + date[3],
        info : {

            message : "Não ocorreu nenhum erro",
            code : 00
        }
    }

    return result;
}

function getHour(){
    
        if(hour == ""){
            result = {
                error : true,
                value: null,
                info : { 
                    message : "Informe um horário válido",
                    code : 02
                }
            }
            return result;
            
        }      
        result = {
            error : false,
            value:  hour,
            info : {
                message : "Não ocorreu nenhum erro",
                code : 00
            }
        }
    
        return result;
    
}

function getOperation(){
    return $("#toggleValue").val();
}   

function getMinute(){
    var minute = $("#minute").val();
   
        if(minute == ""){
            result = {
                error : true,
                value: null,
                info : { 
                    message : "Informe um valor válido",
                    code : 03
                }
            }
            return result;
            
        }      
        result = {
            error : false,
            value:  minute,
            info : {
                message : "Não ocorreu nenhum erro",
                code : 00
            }
        }
    
        return result;
    
}

$("#hour").keyup(function(){ 

    var tecla = event.keyCode;
    if(tecla != 8){
        if ($(this).val().length == 2){
            $(this).val($(this).val() + ":");
        }        
        
        if(tecla > 47 && tecla < 58){
        
        err = {
                error : false,
                value:  hour,
                info : {
                    message : "Não ocorreu nenhum erro",
                    code : 00
                }
            }   
        }else{
            console.log(tecla);
            err = {
                error : true,
                value: null,
                info : { 
                    message : "Digite apenas números",
                    code : 04
                }
            }            
        }
            if(err.error == false){
                $("#errHour").text("");
            }else{
                $("#errHour").text("");
                $("#errHour").text(err.info.message);        
            }
    }else{
        $("#errHour").text("");
    } 
});

$("#minute").keyup(function(){ 

    var tecla = event.keyCode;
    if(tecla != 8){
        if(tecla > 47 && tecla < 58){
        
        err = {
                error : false,
                value:  hour,
                info : {
                    message : "Não ocorreu nenhum erro",
                    code : 00
                }
            }   
        }else{
            console.log(tecla);
            err = {
                error : true,
                value: null,
                info : { 
                    message : "Digite apenas números",
                    code : 04
                }
            }            
        }
            if(err.error == false){
                $("#errMinute").text("");
            }else{
                $("#errMinute").text("");
                $("#errMinute").text(err.info.message);        
            }
    }else{
        $("#errMinute").text("");
    } 
});

$("#calculate").click(function(){
    err = false;
    var date = getdate();    


    if(date.error == false){
        err = false;
        $("#errDate").text("");
    }else{
        err = true;
        $("#errDate").text("");
        $("#errDate").text(date.info.message);        
    }

    var hour = getHour();
    

    if(hour.error == false ){
        err = false;
        $("#errHour").text("");
    }else{
        err = true;
        $("#errHour").text("");
        $("#errHour").text(hour.info.message);        
    }


    var minute = getMinute();
    
    if(minute.error == false){
        err = false;
        $("#errMinute").text("");
    }else{
        err = true;
        $("#errMinute").text("");
        $("#errMinute").text(minute.info.message);        
    }
    
    var operation = getOperation();

     if(!err){
        $.ajax({
            url: "/api/date",
            type: 'put',
          async: false,
          contentType: 'application/json; charset=utf-8',
            headers: {
                "Content-Type":"application/json"
               },
            success: function(data){
                setValues(data); 
            },
            error : function(err) {
                console.log(err)
            },
            data: JSON.stringify({
              date: date.value + " " + hour.value,
              op: operation,
              value: minute.value               
            })                                 
          })
     }
   

})


