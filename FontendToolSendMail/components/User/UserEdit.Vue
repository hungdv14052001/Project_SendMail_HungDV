<template>
    <div id="user-edit-contairner">
        <div class="title-Page">
            <div class="margin30">Edit User</div>
        </div>
        <div class="Control-contairner">
            <div class="row-control">
                <div class="col-controlE">
                    <div class="title-controlE">
                        Name
                    </div>
                    <div class="txt-contairnerE">
                        <input type="text" placeholder="Name" class="txtControlE" v-model="userName">
                    </div>
                </div>
                <div class="col-controlE">
                    <div class="title-controlE">
                        Email
                    </div>
                    <div class="txt-contairnerE">
                        <input type="text" placeholder="Email" class="txtControlE" v-model="email">
                    </div>
                </div>
            </div>
            <div class="row-control">
                <div class="col-controlE">
                    <div class="title-controlE">
                        Password
                    </div>
                    <div class="txt-contairnerE">
                        <input type="Password" placeholder="Password" class="txtControlE" v-model="password">
                    </div>
                </div>
                <div class="col-controlE">
                    <div class="title-controlE">
                        Confirm
                    </div>
                    <div class="txt-contairnerE">
                        <input type="Password" placeholder="Confirm Password" class="txtControlE" v-model="confirmPassword">
                    </div>
                </div>
            </div>
            <div class="row-control">
                <div class="col-controlE">
                    <div class="title-controlE">
                        Status
                    </div>
                    <input type="radio" class="margin30" v-model="status" :value="true" />Inactive
                    <input type="radio" class="margin30" v-model="status" :value="false" />Active
                </div>
                <div class="col-controlE">
                </div>
            </div>
        </div>
        <div class="btn-contairner">
            <button @click="save" class="btnSave">Save</button>
            <button @click="cancel" class="btnCancel">Cancel</button>
        </div>
    </div>
</template>
<script>
    const userAPI= 'https://localhost:44348/api/Users/';
    export default {
        /// <summary>
        /// set current User
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            this.idUser= this.$route.params.id;
            var currentUser= await fetch(userAPI+this.idUser)
                .then((res)=>res.json());
            this.userName=currentUser.userName;
            this.email= currentUser.email;
            this.status= currentUser.status;
            this.fullName= currentUser.fullName;
        },
        
        data(){
            return{
                idUser: 0,
                status: false,
                userName: '',
                email: '',
                password: '',
                confirmPassword: '',
                fullName: '',
            };
        },
        methods: {
            /// <summary>
            /// cancel edit User
            /// </summary>
            cancel(){
                this.$router.push("/UserListPage");
            },
            /// <summary>
            /// Save edit User
            /// </summary>
            save(){
                if(this.userName.length==0||this.email.length==0||this.password.length==0||this.confirmPassword.length==0){
                    alert("Fill in all the information, please!");
                    return;
                }
                if(this.password!=this.confirmPassword){
                    alert("The entered passwords do not match. Try again!");
                    return;
                }
                var dataUser={
                    id: this.idUser,
                    userName: this.userName,
                    email: this.email,
                    status: this.status,
                    password: this.password,
                    fullName: this.fullName
                }
                try{
                    this.putData(userAPI+this.idUser, dataUser)
                        .then(data => {
                            alert("Successful PUT!");
                        });
                    this.$router.push("/UserListPage");
                }
                catch{}

            },
            
            /// <summary>
            ///  put data in API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="data"></param>
            /// <returns>response.json()</returns>
            async putData(url = '', data = {}) {
                const response = await fetch(url, {
                    method: 'PUT',
                    headers: {
                    'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data) 
                });
                return response.json();
            },
        }
    }
</script>
<style>
    #user-edit-contairner{
        min-height: 650px;
        width: 98%;
        background-color: white;
    }
    .Control-contairner{
        min-height: 500px;
    }
    .row-control{
        height: 40px;
        width: 100%;
        margin-top: 20px;
        display: flex;
        justify-content: space-around;
        align-items: center;
    }
    .col-controlE{
        display: flex;
        justify-content: end;
        width: 35%;
        height: 40px;
        align-items: center;
    }
    .title-controlE{
        margin-right: 10px;
    }
    .txt-contairnerE{
        height: 30px;
        background-color: white;
        border: 1px solid #ccc;
        border-radius: 3px;
        width: 80%;
        display: flex;
        justify-content: center;
    }
    .txtControlE{
        height: 100%;
        width:90%;
        border: none;
        outline: none;
    }
    .btn-contairner{
        height: 50px;
        display: flex;
        justify-content: center;
        align-items: center;
        border-radius: 1px solid #ccc;
    }
    .btnSave{
        background-color: #007BFF;
        color: white;
        font-family: Arial;
        border-radius: 3px;
        height: 35px;
        width: 80px;
        margin: 0 10px;
    }
    .btnCancel{
        background-color: white;
        color: #007BFF;
        font-family: Arial;
        border-radius: 3px;
        height: 35px;
        width: 80px;
        margin: 0 10px;
        border: 1px solid #007BFF;
    }
</style>