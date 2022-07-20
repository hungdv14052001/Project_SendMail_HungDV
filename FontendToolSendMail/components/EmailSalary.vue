<template>
    <div id="Email-Salary">
        <div class="title-Page">
            <div class="margin30">Send mail</div>
        </div>
        <div class="Email-Salary-contairner">
            <div class="input-file-title">
                <div class="margin30"></div>
                Input file:
            </div>
            <div class="newheight">
                <VueFileAgent @change="getFile($event)" class="margin30 getFile" accept=".csv, .xlsx, .xls" v-model="file"></VueFileAgent>
            </div>
            <div class="margin30">
                CC Email
            </div>
            <div class="input-file-contairner mg0">
                <div class="margin30 lbCC">
                    CC
                </div>
                <div class="txtCC">
                    <input placeholder="CC Email" type="text" class="inputCC" v-model="ccEmail" />
                </div>
                <button @click="doUpload" class="margin30 btnCheck">Upload</button>
                <button @click="clear" class=" margin30 btnClear">Clear</button>
            </div>
            <div class="input-file-title">
                <div class="margin30"></div>
                Employee in file
            </div>
            <div class="title-row-list">
                <div class="col-typeE1">
                    ID
                </div>
                <div class="col-typeE3">
                    Name
                </div>
                <div class="col-typeE3">
                    Email
                </div>
                <div class="col-typeE2">
                    Basic Salary
                </div>
                <div class="col-typeE2">
                    Number Day
                </div>
                <div class="col-typeE2">
                    Bonus
                </div>
                <div class="col-typeE2">
                    Deduction
                </div>
            </div>
            <li v-for="employee in ListEmployee" class="title-row-list boolnone">
                <div class="col-typeE1">
                    {{employee.id}}
                </div>
                <div class="col-typeE3">
                    {{employee.name}}
                </div>
                <div class="col-typeE3">
                    {{employee.email}}
                </div>
                <div class="col-typeE2">
                    {{employee.basicSalary}}
                </div>
                <div class="col-typeE2">
                    {{employee.numberDay}}
                </div>
                <div class="col-typeE2">
                    {{employee.bonus}}
                </div>
                <div class="col-typeE2">
                    {{employee.deduction}}
                </div>
            </li>
        </div>
        <div id="load-contairer" class="close">
            <div class="loader"></div>
        </div>
    </div>
</template>
<script>
    import Vue from 'vue';
    import VueFileAgent from 'vue-file-agent';
    import VueFileAgentStyles from 'vue-file-agent/dist/vue-file-agent.css';

    Vue.use(VueFileAgent);

    const apiUpload='https://localhost:44348/api/SendMail/upload?ccEmail=';
    export default{
        data(){
            return{
                excelData: null,
                ListEmployee: [],
                ccEmail: '',
                file: '',
            }
        },
        methods: {

            /// <summary>
            /// get file of input
            /// </summary>
            getFile(e){
                this.excelData = e.target.files[0];
            },

            /// <summary>
            /// get file and send mail for employee
            /// </summary>
            async doUpload(){
                const excelData= this.excelData;
                const ccEmail= this.ccEmail;
                if(excelData==null){
                    alert("Input file, please!")
                    return;
                }
                const formdata= new FormData();
                formdata.append('file', excelData, 'excelData.xlsx')
                
                if (confirm('Do you want to Check and Send mail for employee?')) {
                    var it= document.getElementById("load-contairer");
                    it.classList.add("openFlex");
                    this.postFile(apiUpload+ this.ccEmail, formdata)
                    .then(data=>{
                        this.ListEmployee= data;
                        it.classList.remove("openFlex");    
                    });
                } else {
                    alert("Cancelled");
                }
            },
            
            /// <summary>
            /// clear file and cc Email
            /// </summary>
            clear(){
                this.file='';
                this.ListEmployee= [];
                this.ccEmail='';
            },

            /// <summary>
            /// post File from API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="file"></param>
            /// <returns>response.json()</returns>
            async postFile(url = '' , file) {
                const response = await fetch(url, {
                    method: 'POST',
                    body: file
                });
                return response.json(); 
            },
        }
    }
</script>
<style>
    #Email-Salary{
        width: 100%;
        min-height: 680px;
    }
    .title-Page, .input-file-title{
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
    .input-file-title{
        border: none;
        color: black;
    }
    .Email-Salary-contairner{
        width: 100%;
        min-height: 635px;
        background-color: #F0F0F0;
        height: 70px;
    }
    .input-file-contairner{
        display: flex;
        height: 45px;
        align-items: center;
    }
    .input-file {
        content: 'Browser';
    }
    .btnCheck{
        background-color: #007BFF;
        color: white;
        font-family: Arial;
        border-radius: 3px;
        height: 32px;
        width: 80px;
        margin: 0 10px;
    }
    .btnClear{
        background-color: white;
        color: #007BFF;
        font-family: Arial;
        border-radius: 3px;
        height: 32px;
        width: 80px;
        margin: 0 10px;
        border: 1px solid #007BFF;
    }
    .margin30{
        margin-left: 30px;
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
    .boolnone{
        font-weight: 500;
    }
    .col-typeE1{
        height: 100%;
        width: 5%;
        margin-left: 2%;
        display: flex;
        align-items: center;
    }
    .col-typeE2{
        height: 100%;
        width: 11%;
        display: flex;
        align-items: center;
    }
    .col-typeE3{
        height: 100%;
        width: 24%;
        display: flex;
        align-items: center;
        justify-content: left;
    }
    #load-contairer{
        position: fixed;
        justify-content: center;
        align-items: center;
        top: 0;
        bottom: 0;
        right: 0;
        left: 0;
        background-color: rgba(204, 204, 204, 0.5);
    }
    .openFlex{
        display: flex;
    }
    .loader {
        border: 16px solid #f3f3f3;
        border-radius: 50%;
        border-top: 16px solid blue;
        border-right: 16px solid green;
        border-bottom: 16px solid red;
        border-left: 16px solid pink;
        width: 120px;
        height: 120px;
        -webkit-animation: spin 2s linear infinite;
        animation: spin 2s linear infinite;
    }

    @-webkit-keyframes spin {
        0% { -webkit-transform: rotate(0deg); }
        100% { -webkit-transform: rotate(360deg); }
    }

    @keyframes spin {
        0% { transform: rotate(0deg); }
        100% { transform: rotate(360deg); }
    }
    .close{
        display: none;
    }
    .openFlex{
        display: flex;
    }
    .open{
        display: block;
    }
    .newheight{
        height: 180px;
        display: flex;
        width: 20px;
    }
    .txtCC{
        display: flex;
        justify-content: center;
        align-items: center;
        height: 32px;
        width: 250px;
        border: 1px solid #ccc;
        background-color: white;
    }
    .inputCC{
        width: 90%;
        height: 100%;
        outline: none;
    }
    .newheight VueFileAgent{
        height: 100px;
    }
    .getFile{
        width: 300px;
        position: absolute;
    }
    .lbCC{
        display: flex;
        justify-content: center;
        align-items: center;
        height: 32px;
        width: 40px;
        background-color: white;
        border: 1px solid #ccc;
    }
</style>