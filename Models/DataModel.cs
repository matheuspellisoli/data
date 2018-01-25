using System.Runtime.Serialization;
using System;
using System.Text.RegularExpressions;

namespace data.Models
{
    public class Date{
        [DataMember]  
        public int day { get; set; }

        [DataMember]  
        public int month { get; set; }

       [DataMember]  
        public int year { get; set; }
        
        [DataMember]  
        public int hour { get; set; }

        [DataMember]  
        public int minute { get; set; }
      
       [DataMember]  
        public String stringDate { get; set; }

        public int GetDay(){
            return this.day;
        }

        public void SetDay(int day){
             this.day = day;
        }

        public int GetMonth(){
            return this.month;
        }

        public void SetMonth(int month){
             this.month = month;
        }

        public int GetYear(){
            return this.year;
        }

        public void SetYear(int year){
             this.year = year;
        }        

        public int GetHour(){
            return this.hour;
        }

        public void SetHour(int hour){
             this.hour = hour;
        } 

        public int GetMinute(){
            return this.minute;
        }

        public void SetMinute(int minute){
             this.minute = minute;
        } 

        public String GetStringDate(){
            return this.stringDate;
        }  

        public void SetStringDate(String stringDate){
             this.stringDate = stringDate;
        }
        public static  Boolean  validateDate (string date){
           
            Regex dateRule = new Regex(@"^(\d{2}|\d)\D(\d{2}|\d)\D(\d{4}) (\d{2}|\d):(\d{2}|\d)$");//expressão regular 

            if(dateRule.IsMatch(date)){
                return true;
            }

            return false;
            
        }

        public void ConvertStringToDate(){
            String _stringDate = this.GetStringDate();
            String expression = @"^(\d{2}|\d)\D(\d{2}|\d)\D(\d{4}) (\d{2}|\d):(\d{2}|\d)$";            
            if(validateDate(this.GetStringDate())){
            Match match = Regex.Match(_stringDate,expression);//separa a string em 5 grupos determinado na  expressão regular 
            this.SetDay(Int32.Parse(match.Groups[1].Value));
            this.SetMonth(Int32.Parse(match.Groups[2].Value));
            this.SetYear(Int32.Parse(match.Groups[3].Value));
            this.SetHour(Int32.Parse(match.Groups[4].Value));
            this.SetMinute(Int32.Parse(match.Groups[5].Value));
            }
        }

        public void ConvertDateToString(){
            this.SetStringDate(this.GetDay() +"/"+ this.GetMonth() +"/"+ this.GetYear() +" "+ this.GetHour() +":"+ this.GetMinute());
        }


        public int HowManyDay(int month){

            int[] months = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};// quantos dias tem cada mês 

            return months[month];
        }
	

    
        public void ChangeDate(char op, long value){
            switch(op){
                case '+':
                    this.DateAdd(value);
                    break;
                case '-':
                    this.DateSubtract(value);
                    break;
                default:
                    Console.WriteLine("erro");
                    break;
            }
        }


        public void DateAdd (long value){
            
            for(int i =0; i < value; i++){
              if(this.GetMonth() == 12 ){
                   this.SetMonth(1);
                   this.SetYear(this.GetYear() + 1);
               }else if(this.GetDay() == HowManyDay(this.GetMonth())){ //verifica quantos dias tem o mês 
                    this.SetDay(1);
                    this.SetMonth(this.GetMonth() + 1);
               }else if(this.GetHour() == 25 ){
                    this.SetHour(1);
                    this.SetDay(this.GetDay() + 1);
               }else if(this.GetMinute() == 60 ){
                    this.SetMinute(0); 
                    this.SetHour(this.GetHour() + 1);                    
               }

               this.SetMinute(this.GetMinute() + 1);
            }

            this.ConvertDateToString();
        }

        public void DateSubtract (long value){
            for(int i = 0  ; i < value ; i++){                
                if(this.GetMonth() == 0 ){
                   this.SetMonth(12);
                   this.SetYear(this.GetYear() - 1);
               }else if(this.GetDay() == 0){                                       
                    this.SetMonth(this.GetMonth() - 1);
                    this.SetDay(HowManyDay(this.GetMonth()));
               }else if(this.GetHour() == 0 ){
                    this.SetHour(24);
                    this.SetDay(this.GetDay() - 1);
               }else if(this.GetMinute() == 0 ){
                    this.SetMinute(60); 
                    this.SetHour(this.GetHour() - 1);                    
               }

              
            
               this.SetMinute(this.GetMinute() - 1);
            }

             

               this.ConvertDateToString();
        }
    }

}