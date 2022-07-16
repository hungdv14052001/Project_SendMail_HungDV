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
                <input type="text" class="txt-control" placeholder="First name" v-model="Firstname">
            </div>
            <div class="sub-item">
                <input type="text" class="txt-control" placeholder="Last name" v-model="Lastname">
            </div>
        </div>
        <div class="validation-cotairner">
            <div id="validation-First" class="close">
                Enter your first name!
            </div>
            <div id="validation-Last" class="va close">
                Enter your last name!
            </div>
        </div>
        <div class="body-item">
            <input type="text" class="txt-control" placeholder="Email" v-model="Email">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Email" class="close">
                {{validateEmail}}
            </div>
        </div>
        <div class="body-item">
            <input type="text" class="txt-control" placeholder="User name" v-model="UserName">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Name" class="close">
                Enter your user name!
            </div>
        </div>
        <div class="body-item">
            <input type="password" class="txt-control" placeholder="Password" v-model="Password">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Password" class="close">
                Enter your password!
            </div>
        </div>
        <div class="body-item">
            <input type="password" class="txt-control" placeholder="Confirm password" v-model="ConfirmPassword">
        </div>
        <div class="validation-cotairner">
            <div id="validation-Confirm" class="close">
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
                Firstname:'',
                Lastname: '',
                UserName: '',
                Email: '',
                Password: '',
                ConfirmPassword: '',
                validateEmail: '',
                validateConfirm: '',
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
                this.validateEmail='Enter your email!';
                this.validateConfirm='Enter your confirm password!';
                if(this.checkValidation('validation-First', this.Firstname)==false ||this.checkValidation('validation-Last', this.Lastname)==false ||this.checkValidation('validation-Email', this.Email)==false || this.checkValidation('validation-Name', this.UserName)==false||this.checkValidation('validation-Password', this.Password)==false||this.checkValidation('validation-Confirm', this.ConfirmPassword)==false){
                    return;
                }
                if(!this.Email.includes('@')||!this.Email.includes('.')){
                    var itemId= document.getElementById('validation-Email');
                    this.validateEmail = 'Invalid email!';
                    if(itemId.classList.length==1){
                        itemId.classList.add("open");
                    }
                    return;
                }
                if(this.Password!=this.ConfirmPassword){
                    var itemId= document.getElementById('validation-Confirm');
                    this.validateConfirm = 'The entered passwords do not match. Try again!';
                    if(itemId.classList.length==1){
                        itemId.classList.add("open");
                    }
                    return;
                }
                var dataUser={
                    userName: this.UserName,
                    email: this.Email,
                    status: false,
                    password: this.Password,
                    fullName: this.Firstname+ this.Lastname
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
            },
            checkValidation(id, value){
                var result= false;
                var itemId= document.getElementById(id);
                if(value.length==0){
                    itemId.classList.add("open");
                }
                else{
                    itemId.classList.remove("open");
                    result= true;
                }
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