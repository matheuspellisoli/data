using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using data.Models;
using Newtonsoft.Json;

namespace data.Controllers
{
    [Route("api/date")]

    public class DateController : Controller{
    
    static Date _data = new Date();
  
   static Boolean ini = false; // 
    public DateController(){
        if(!ini){ // caso seja false ele set uma data padrão 
        _data.SetStringDate("01/01/1917 04:00");
        _data.ConvertStringToDate();
        }
        
        
        
    }
    [HttpGet]
    public ActionResult GetAll(){   
        ini = true; // informa que já foi executado       
         if(! Date.validateDate(_data.GetStringDate())){
             return StatusCode(500);
             }
          
          return new ObjectResult(_data);
        }
        
        [Produces("application/json")]
        [HttpPut]
        
        public ActionResult update([FromBody]  DateOperetion obj)
        {
           
           if (obj.date == "now"){
                obj.date = _data.GetStringDate();
            }else if(obj.date == null || !Date.validateDate(_data.GetStringDate())){
                return StatusCode(500);
            }
            
            _data.SetStringDate(obj.date);// altera a data 
            _data.ConvertStringToDate(); // converte para o objeto data  
            _data.ChangeDate(obj.op ,obj.value);
            return new ObjectResult(_data);
        }
    }
    }
