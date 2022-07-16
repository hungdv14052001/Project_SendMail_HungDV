<template>
    <div id="User-List">
        <div class="title-Page">
            <div class="margin30">User</div>
        </div>
        <div class="User-list-contairner">
            <div class="title-list">
                <div @click="openSearch" class="margin30 cursor">{{titleSearch}}</div>
            </div>
            <div id="Search-el" class="close open">
                <div class="Search-By-Status">
                    <div class="margin30">Status:</div>
                    <input type="radio" class="margin30" v-model="status" :value="0" @change="setList"/>All
                    <input type="radio" class="margin30" v-model="status" :value="2" @change="setList"/>Inactive
                    <input type="radio" class="margin30" v-model="status" :value="1" @change="setList"/>Active
                </div>
                <div class="Search-contairner">
                    <div class="Search-By-String margin30">
                        <div>Name</div>
                        <div class="txt-contairner">
                            <input type="text" class="txt-search" placeholder="User name" v-model="userName" @change="setList"/>
                        </div>
                    </div>
                    <div class="Search-By-String margin30">
                        <div>Email</div>
                        <div class="txt-contairner">
                            <input type="text" class="txt-search" placeholder="Email" v-model="email" @change="setList"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="margintop40 Search-By-Status">
                <div class="margin30">
                    total: {{total}} User
                </div>
                <button class="btn-tranfer margin30"><<</button>
                <button class="btn-tranfer"><</button>
                <div class="current-Page">1</div>
                <button class="btn-tranfer">></button>
                <button class="btn-tranfer">>></button>
            </div>
            <div class="title-row-list">
                <div class="col-type1">
                    ID
                </div>
                <div class="col-type2">
                    FullName
                </div>
                <div class="col-type2">
                    UserName
                </div>
                <div class="col-type2">
                    Email
                </div>
                <div class="col-type3">
                    Status
                </div>
                <div class="col-type2 middle">
                    Action
                </div>
            </div>
            <li v-for="user in CurrentUserList" class="title-row-list boolnone">
                <div class="col-type1">
                    {{user.id}}
                </div>
                <div class="col-type2">
                    {{user.fullName}}
                </div>
                <div class="col-type2">
                    {{user.userName}}
                </div>
                <div class="col-type2 bluecolor">
                    {{user.email}}
                </div>
                <div class="col-type3">
                    <div v-if="user.status" class="active">
                        process
                    </div>
                    <div v-else class="inactive">
                        unprocess
                    </div>
                </div>
                <div class="col-type2 middle">
                    <NuxtLink class="btnEdit" :to="{ name: 'EditUserPage', params: { id: user.id}}">Edit</NuxtLink>
                    <button @click="confirmDelete(user.id)" class="btnDelete">delete</button>
                </div>
            </li>
        </div>
    </div>
</template>
<script>
    const userAPI= 'https://localhost:44348/api/Users';
    export default {
        /// <summary>
        /// get list User in api
        /// </summary>
        /// <param name="publicByBool"></param>
        /// <returns>string of public</returns>
        async beforeMount(){
            this.UserList = await fetch(userAPI)
                .then((res)=>res.json());
            this.CurrentUserList= this.UserList;
            this.total= this.UserList.length;
        },
        data(){
            return{
                UserList: [],
                CurrentUserList: [],
                status: 0,
                userName: '',
                email: '',
                total: 0,
                titleSearch: 'Searching criteria  ▼'
            };
        },
        methods: {

            /// <summary>
            /// set list when search 
            /// </summary>
            /// <param name="id"></param>
            setList(){
                this.CurrentUserList= this.UserList;
                if(this.status==1){
                    this.CurrentUserList= this.CurrentUserList.filter(function(user){
                        return user.status==true;
                    });
                }
                else if(this.status==2){
                    this.CurrentUserList= this.CurrentUserList.filter(function(user){
                        return user.status==false;
                    })
                }
                var key= this.userName;
                this.CurrentUserList= this.CurrentUserList.filter(function(user){
                    return user.userName.toLowerCase().includes(key.toLowerCase());
                })
                key= this.email;
                this.CurrentUserList= this.CurrentUserList.filter(function(user){
                    return user.email.toLowerCase().includes(key.toLowerCase());
                })
            },

            /// <summary>
            /// confirm delete User 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>response.json()</returns>
            confirmDelete(id) {
                if (confirm('Do you want to delete this User?')) {
                    this.dellBlog(id);
                    this.$router.push("/");
                } else {
                    alert("Cancelled");
                }
            },

            /// <summary>
            /// delete data from API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="data"></param>
            /// <returns>response.json()</returns>
            dellBlog(id){
                var option ={
                    method: 'DELETE',
                    header:{
                        'Content-Type' : 'application/json'
                    },
                };
                fetch('https://localhost:44348/api/Users/'+id, option)
                    .then(function(response) {
                        response.json();
                    });
                location.reload();
                alert("successful delete!");
            },

            /// <summary>
            /// open form search
            /// </summary>
            openSearch(){
                var itemElement= document.getElementById("Search-el");
                if(itemElement.classList.length==1){
                    itemElement.classList.add("open");
                    this.titleSearch= 'Searching criteria  ▼';
                }
                else{
                    itemElement.classList.remove("open");
                    this.titleSearch= 'Searching criteria  ▲';
                }
            }
        }
    }

</script>
<style>
    #User-List{
        width: 100%;
        min-height: 680px;
    }
    .title-Page, .title-list, .Search-By-Status{
        border: 1px solid #ccc;
        width: 100%;
        height: 45px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 19px;
        font-weight: bold;
        display: flex;
        align-items: center;
        color: #007BFF;
    }
    .title-list{
        color: black;
        border: none;
    }
    .Search-By-Status{
        color: black;
        border: none;
        font-weight: 500;
        font-size: 15px;
        height: 30px;
    }
    .User-list-contairner{
        width: 100%;
        min-height: 635px;
        background-color: #F0F0F0;
    }
    .Search-contairner{
        display: flex;
    }
    .Search-By-String{
        font-family: Arial, Helvetica, sans-serif;
        font-size: 15px;
        margin-top: 15px;
    }
    .txt-contairner{
        height: 32px;
        width: 250px;
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: white;
        border: 1px solid #ccc;
        border-radius: 3px;
        margin-top: 10px;
    }
    .txt-search{
        outline: none;
        width: 85%;
        height: 30px;
    }
    .btn-tranfer{
        height: 25px;
        width: 25px;
        background-color: white;
        border: 1px solid #ccc;
        border-radius: 50%;
        margin-left: 5px;
        color: #ccc;
        font-size: 13px;
        font-weight: bold;
    }
    .current-Page{
        height: 25px;
        width: 25px;
        background-color: #007BFF;
        border: 1px solid #ccc;
        border-radius: 50%;
        margin-left: 5px;
        color: white;
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 13px;
    }
    .margin30{
        margin-left: 30px;
    }
    .margintop40{
        margin-top: 30px;
    }
    .title-row-list{
        width: calc(100% - 60px);
        margin-left: 30px;
        height: 35px;
        border: 1px solid #ccc;
        background-color: white;
        display: flex;
        font-family: Arial;
        font-size: 17px;
        font-weight: bold;
    }
    .col-type1{
        height: 100%;
        width: 5%;
        margin-left: 2%;
        display: flex;
        align-items: center;
    }
    .col-type2{
        height: 100%;
        width: 20%;
        display: flex;
        align-items: center;
    }
    .col-type3{
        height: 100%;
        width: 13%;
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .boolnone{
        font-weight: 500;
    }
    .bluecolor{
        color: #007BFF;
    }
    .active, .inactive{
        width: 80px;
        height: 20px;
        background-color: #52C41A;
        border-radius: 10px;
        display: flex;
        justify-content: center;
        align-items: center;
        color: white;
    }
    .inactive{
        background-color: #BEBEBE;
        width: 100px;
    }
    .btnDelete{
        height: 25px;
        width: 70px;
        border: 1px solid red;
        color: red;
        border-radius: 3px;
    }
    .btnEdit{
        height: 25px;
        width: 50px;
        border: 1px solid #52C41A;
        color: #52C41A;
        border-radius: 3px;
        margin-left: 20px;
        text-decoration: none;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .middle{
        display: flex;
        justify-content: space-around;
        width: 15%;
    }
    .cursor{
        cursor: pointer;
    }
</style>