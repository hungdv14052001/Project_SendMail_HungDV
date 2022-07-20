<template>
    <div id="register-contairner">
        <div class="register-header">
            <div class="header-content">
                Register
            </div>
            <button @click="closeForm" class="btnClose">X</button>
        </div>
        <div class="sep"></div>
        <div class="body-item border-none">
            <div class="sub-item">
                <input type="text" class="txt-control" placeholder="First name" v-model="firstname">
            </div>
            <div class="sub-item">
                <input type="text" class="txt-control" placeholder="Last name" v-model="lastname">
            </div>
        </div>
        <div class="validation-cotairner">
            <div id="validation-First" v-if="isFirstname">
                Enter your first name!
            </div>
            <div id="validation-Last" v-if="isLastname">
                Enter your last name!
            </div>
        </div>
        <div class="body-item">
            <input type="text" class="txt-control" placeholder="Email" v-model="email">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Email" v-if="isEmail">
                {{validateEmail}}
            </div>
        </div>
        <div class="body-item">
            <input type="text" class="txt-control" placeholder="User name" v-model="userName">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Name" v-if="isUserName">
                Enter your user name!
            </div>
        </div>
        <div class="body-item">
            <input type="password" class="txt-control" placeholder="Password" v-model="password">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Password" v-if="isPassword">
                Enter your password!
            </div>
        </div>
        <div class="body-item">
            <input type="password" class="txt-control" placeholder="Confirm password" v-model="confirmPassword">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Confirm" v-if="isConfirm">
                {{validateConfirm}}
            </div>
        </div>
        <button @click="Register" class="btn-register">Register</button>
    </div>
</template>
<script>
    export default{

        data(){
            return{
                firstname:'',
                lastname: '',
                userName: '',
                email: '',
                password: '',
                confirmPassword: '',
                validateEmail: '',
                validateConfirm: '',
                isFirstname: false,
                isLastname: false,
                isUserName: false,
                isEmail: false,
                isPassword: false,
                isConfirm: false,
            };
        },
        methods: {
            /// <summary>
            /// close Form Register
            /// </summary>
            closeForm(){
                var itemElement= document.getElementById("register");
                itemElement.classList.remove("openFlex");
            },

            /// <summary>
            /// Register User
            /// </summary>
            Register(){
                var resultCheck= true;
                this.validateEmail='Enter your email!';
                this.validateConfirm='Enter your confirm password!';
                if(this.firstname.length==0){
                    this.isFirstname= true;
                    resultCheck= false;
                }
                else{
                    this.isFirstname= false;
                }
                if(this.lastname.length==0){
                    this.isLastname= true;
                    resultCheck= false;
                }
                else{
                    this.isLastname= false;
                }
                if(this.userName.length==0){
                    this.isUserName= true;
                    resultCheck= false;
                }
                else{
                    this.isUserName= false;
                }
                if(this.email.length==0){
                    this.isEmail= true;
                    resultCheck= false;
                }
                else{
                    this.isEmail= false;
                }
                if(this.password.length==0){
                    this.isPassword= true;
                    resultCheck= false;
                }
                else{
                    this.isPassword= false;
                }
                if(this.confirmPassword.length==0){
                    this.isConfirm= true;
                    resultCheck= false;
                }
                else{
                    this.isConfirm= false;
                }
                if(resultCheck==false){
                    return;
                }
                if(!this.email.includes('@')||!this.email.includes('.')){
                    this.isEmail= true;
                    return;
                }
                if(this.password!=this.confirmPassword){
                    this.isConfirm= true;
                    return;
                }
                var dataUser={
                    userName: this.userName,
                    email: this.email,
                    status: false,
                    password: this.password,
                    fullName: this.firstname+ ' '+this.lastname
                }
                
                try{
                    this.postData('https://localhost:44348/api/Users', dataUser)
                    .then(data => {
                    });
                    alert("Register successful!");
                    location.reload();
                }
                catch{
                    alert("Register fail!");
                    return;
                }
            },
            
            /// <summary>
            /// function postData(url = '', data = {}) to post data into API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="data"></param>
            /// <returns>response.json()</returns>
            async postData(url = '', data = {}) {
                const response = await fetch(url, {
                    method: 'POST',
                    headers: {
                    'Content-Type': 'application/json'
                    },
                    redirect: 'follow', 
                    referrerPolicy: 'no-referrer', 
                    body: JSON.stringify(data) 
                });
                return response.json(); 
            }
        }
    }
</script>
<style>
    #register-contairner{
        width: 420px;
        height: 450px;
        background-color: white;
        border-radius: 5px;
    }
    .register-header{
        width: 91%;
        margin-left: 8%;
        height: 50px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-top: 10px;
    }
    .header-content{
        font-family: Arial, Helvetica, sans-serif;
        font-weight: bold;
        color: black;
        font-size: 27px;
    }
    .btnClose{
        font-family: Arial, Helvetica, sans-serif;
        font-weight: bold;
        color: black;
        font-size: 20px;
        width: 30px;
        height: 30px;
        color: #ccc;
        display: flex;
        justify-content: center;
        align-items: center;
        border-radius: 5px;
        margin-top: -30px;
    }
    .btnClose:hover{
        background-color: #ccc;
        color: black;
        cursor: pointer;
    }
    .sep{
        width: 84%;
        margin: 10px 0;
        margin-left: 8%;
        height: 1px;
        background-color: #ccc;
    }
    .body-item{
        height: 32px;
        width: 84%;
        margin-left: 8%;
        border: 1px solid #ccc;
        border-radius: 3px;
        display: flex;
        align-items: center;
    }
    .border-none{
        border: none;
        border-radius: none;
        justify-content: space-between;
    }
    .sub-item{
        height: 32px;
        width: 46%;
        margin: 10px 0;
        border: 1px solid #ccc;
        border-radius: 3px;
        display: flex;
        align-items: center;
    }
    .txt-control{
        width: 90%;
        height: 30px;
        margin-left: 15px;
        outline: none;
        border: none;
    }
    .btn-register{
        width: 50%;
        margin-left: 25%;
        margin-top: 10px;
        height: 45px;
        color: white;
        background-color: #303030;
        border: none;
        border-radius: 23px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 21px;
        font-weight: bold;
    }
    .validation-cotairner{
        height: 23px;
        color: #ff0000;
        margin-left: 8%;
        display: flex;
    }
    .va{
        margin-left: 50px;
    }
</style>