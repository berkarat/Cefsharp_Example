
//#region TIMER


function startTimer(duration, display) {
    var timer = duration;
   setInterval(function () {  display.textContent =   timer;  
   
   if    (timer <10)
   
   {
       document.getElementById("timer").style.backgroundColor = "red";
   }
      if (--timer < 0) {
               timer = 0;      
               //  window.location.href = ''  veya metod çağır !
   
               go_mainpage();
           }
       }, 1000);
   }
   
   
   window.onload =
   function (seconds) {
   var seconds=11;
   
           display = document.querySelector('#timer'); 
       startTimer(seconds, display);
   };
   
   
   //#endregion

//#region   GENERAL METHODS 

   
function go_mainpage(){

    object.getpage('mainpage.html');
    }


    function go_nextpage(url){

      object.getpage(url);
      }
  

   //#endregion


 
   


        //#region  Identity Page Methods
        function write_password(x) {

            var value = document.getElementById('txtbox').value;
         if (value.length < 4) {
          
         
          var input = document.getElementById('txtbox');
                input.value = input.value +x;}
        
          }
 
          function showpassword() {
            var x = document.getElementById("txtbox");
            if (x.type === "password") {
              x.type = "text";
            } else {
              x.type = "password";
            }
          }

          

function go_qrbuyscreen(){
    var input = document.getElementById('txtbox').value;
    object.message(input);
    var correct_url="http://stm/sil.html"
    var mainpage="http://stm/mainpage.html"
  
    array_test(input,correct_url,mainpage)
  
  
  }
  
  
  
  function  go_lastscreen (password,url){
    let arr = new Array();
  arr = [password,url];
   object.go_lastscreen(arr);

 }
  
          
        //#endregion

 