var fnborrar = function(){
  frmprincipal = document.getElementById("principal")
   alert("Se borrara toda la informacion") 
   frmprincipal.reset();
  
  }
  

  
  window.onload= function(){
  
      var btnborrar;
  
      btnborrar = document.getElementById("login");
      btnborrar.onclick = fnborrar;
  }

  var request = require('request');

var url = 'http://localhost:3000/api/v1/login/'
var user = 'test35';
var pass = 'mypassword';

// Save these for future requests
var userId;
var authToken;

