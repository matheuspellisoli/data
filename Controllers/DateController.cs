using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using data.Models;


namespace data.Controllers
{
    [Route("api/date")]

    public class DateController : Controller{
    
             static Date _data = new Date();

     
     static int ini = 0;
    public DateController(){
        if(ini == 0 ){
        _data.SetStringDate("01/01/1917 04:00");
        _data.ConvertStringToDate();
        }
        
        
        
    }
    [HttpGet]
    public ActionResult GetAll(){   
        ini = 1;         
         if(!_data.validateDate()){
             return StatusCode(500);
             }
          
          return new ObjectResult(_data);
        }
        
        
        [HttpPut]
        
        public IActionResult update( PutChange obj){
           
            
            if(obj.date == null){
                return StatusCode(500);
            }

            _data.SetStringDate(obj.date);
            _data.ConvertStringToDate();
            _data.ChangeDate(obj.op ,obj.value);
                                   
            return new ObjectResult(_data);   
        }
    }

}
 
/*

     static Date _data = new Date();

     date.Models.
     static int ini = 0;
    public DateController(){
        if(ini == 0 ){
        _data.SetStringDate("01/01/1917 04:00");
        _data.ConvertStringToDate();
        }
        
        
        
    }
    [HttpGet]
    public ActionResult GetAll(){   
        ini = 1;         
         if(!_data.validateDate()){
             return StatusCode(500);
             }
          
          return new ObjectResult(_data);
        }
        
        
        [HttpPut]
        
        public IActionResult update( PutChange obj){
           Console.WriteLine( obj.value);
            Console.WriteLine("1 - " + obj.date);
            if(obj.date == null){
                return StatusCode(500);
            }
            _data.SetStringDate(obj.date);
            _data.ConvertStringToDate();
            Console.WriteLine("2 - " + _data.GetDay());
            _data.ChangeDate(obj.op, obj.value);
            
            Console.WriteLine("2 - " + _data.GetDay());
            Console.WriteLine("3 - " + _data.GetStringDate());
            return new ObjectResult(_data);   
        }
    



 */
    
  