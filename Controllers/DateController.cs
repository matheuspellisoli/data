using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using data.Models;


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
         if(!_data.validateDate()){
             return StatusCode(500);
             }
          
          return new ObjectResult(_data);
        }
        
        
        [HttpPut]
        public IActionResult update( String date, long value, char op  ){            
            
            if(date == null){
                return StatusCode(500);
            }

            _data.SetStringDate(date);
            _data.ConvertStringToDate();
            _data.ChangeDate(op ,value);
                                   
            return new ObjectResult(_data);   
        }
    }

}
 
