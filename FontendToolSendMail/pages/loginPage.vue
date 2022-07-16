<template>
  <div @keydown.enter="Login" id="login-page">
    <div class="login-contairner">
        <div class="introduce-contairner">
            <img class="img-logo" src="../assets/images/devfast-logo.png" alt="Logo">
            <div class="introduce-content">
                <div class="devfast red">
                    DevFast
                </div>
                <div>
                    Done in the most
                </div>
                <div class="parent">
                    <div class="red">PROFICIENT </div> way.
                </div>
            </div>
        </div>
        <div class="control-contairner">
            <div class="control-item">
                <input class="txtControl" type="text" placeholder="User name" required v-model="username">
            </div>
            <div class="validation">
                <div id="username-Validation" class="close">
                    Enter your username!
                </div>
            </div>
            <div class="control-item">
                <input class="txtControl" type="password" placeholder="Password" v-model="password">
            </div>
            <div class="validation">
                <div id="password-Validation" class="close">
                    Enter your password!
                </div>
            </div>
            <button @click="Login" class="btnLogin">Login</button>
            <a class="foget-password" href="#">Foget password?</a>
            <div class="seperation"></div>
            <button @click="register" class="btnLogin btnRegister">Register</button>
        </div>
    </div>
    <div class="login-footer">
        Copyright © 2021 DevFast
    </div>
    <div id="register" class="close">
        <Register></Register>
    </div>
  </div>
</template>

<script>
    const userPAI= 'https://localhost:44348/api/Users';
    import Register from '../components/RegisterUser.vue';
    export default {
        layout: 'login',
        components: { 
            Register,
        },
        name: 'loginPage',
        async beforeMount(){
            this.userList = await fetch(userPAI)
                .then((res)=>res.json());
        },
        data(){
            return{
                username: '',
                password: '',
                userList: []
            };
        },
        methods: {
            /// <summary>
            /// User Login
            /// </summary>
            Login(){
                var loginResult= false;
                var username = this.username;
                var password = this.password;
                var idUser=0;
                if(this.checkValidation('username-Validation', username)==false||this.checkValidation('password-Validation', password)==false){
                    return;
                }
                for(var i= 0; i<this.userList.length;i++){
                    if(username==this.userList[i].userName && password==this.userList[i].password){
                        loginResult = true;
                        idUser= this.userList[i].id;
                    }
                }
                if(loginResult==true){
                  localStorage.setItem('idUser', idUser);
                  this.$router.push('HomePage');
                }
                else{
                    alert("Username or password is incorrect")
                }
            },

            /// <summary>
            /// Open form user
            /// </summary>
            register(){
                var itemElement= document.getElementById("register");
                itemElement.classList.add("openFlex");
            },

            /// <summary>
            /// delete data from API
            /// </summary>
            /// <param name="id"></param>
            /// <param name="value"></param>
            checkValidation(id, value){
                var itemId= document.getElementById(id);
                if(value.length==0){
                    itemId.classList.add("open");
                    return false;
                }
                else{
                    itemId.classList.remove("open");
                    return true;
                }
            }
        }
    }
</script>
<style>
  #login-page{
    width: 100%;
    height: 750px;
    background-color: #f0f0f0;
  }
  .login-contairner{
    width: 100%;
    height: 680px;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .red{
    color: #ff0000;
    margin-right: 5px;
  }
  .parent{
    display: flex;
  }
  .introduce-contairner{
    height: 400px;
    width: 30%;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 25px;
    margin-top: -150px;
  }
  .img-logo{
    height: 100px;
    margin-right: 10px;
  }
  .introduce-content{
    width: 300px;
    font-family: Arial, Helvetica, sans-serif;
    font-weight: bold;
  }
  .devfast{
    font-size: 35px;
  }
  .control-contairner{
    height: 360px;
    width: 22%;
    background-color: #fff;
    border-radius: 3px;
    margin-top: -40px;
  }
  .control-item{
    display: flex;
    justify-content: center;
    align-items: center;
    border: 1px solid #ccc;
    border-radius: 3px;
    width: 80%;
    margin-left: 10%;
    height: 36px;
    margin-top: 25px;
  }
  .validation{
    position: absolute;
    height: 15px;
    color: #ff0000;
    margin-left: 2%;
  }
  .close{
    display: none;
  }
  .open{
    display: block;
  }
  .openFlex{
        display: flex;
    }
  .txtControl{
    outline: none;
    border: none;
    height: 28px;
    width: 90%;
  }
  .btnLogin{
    border-radius: 18px;
    width: 80%;
    margin-left: 10%;
    height: 45px;
    margin-top: 25px;
    background-color: #303030;
    color: #ff0000;
    font-size: 21px;
    font-weight: bold;
    font-family: Arial, Helvetica, sans-serif;
  }
  
  .foget-password{
    width: 80%;
    margin-left: 10%;
    height: 36px;
    margin-top: 15px;
    text-decoration: none;
    display: flex;
    justify-content: center;
  }
  .btnRegister{
    color: #fff;
  }
  .login-footer{
    width: 100%;
    height: 70px;
    display: flex;
    justify-content: center;
    align-items: center;
    color: #fff;
    font-size: 17px;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #303030;
  }
  .seperation{
    width: 80%;
    margin-left: 10%;
    height: 1px;
    border-bottom: 1px solid #ccc;
  }
  #register{
    position: fixed;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    background-color: rgba(204, 204, 204, 0.4);
    justify-content: center;
    align-items: center;
}
</style>
