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
            <div class="input-file-contairner">
                <img src="../assets/images/logoexcel.jpg" width="40" class="margin30">
                <input type="file" class="margin30 input-file" @change="uploadFile($event)" name="myfile" accept=".csv, .xlsx, .xls"/>
            </div>
            <div class="input-file-contairner">
                <button @click="check" class=" margin30 btnCheck">Check and Send mail</button>
            </div>
            <div class="input-file-title">
                <div class="margin30"></div>
                Employee in file
            </div>
            <div class="title-row-list">
                <div class="col-type1">
                    ID
                </div>
                <div class="col-type2">
                    Name
                </div>
                <div class="col-type3">
                    Email
                </div>
                <div class="col-type2">
                    Basic Salary
                </div>
                <div class="col-type2">
                    Number Day
                </div>
                <div class="col-type2">
                    Bonus
                </div>
                <div class="col-type2">
                    Deduction
                </div>
            </div>
            <li v-for="employee in ListEmployee" class="title-row-list boolnone">
                <div class="col-type1">
                    {{employee.id}}
                </div>
                <div class="col-type2">
                    {{employee.name}}
                </div>
                <div class="col-type3">
                    {{employee.email}}
                </div>
                <div class="col-type2">
                    {{employee.basicSalary}}
                </div>
                <div class="col-type2">
                    {{employee.numberDay}}
                </div>
                <div class="col-type2">
                    {{employee.bonus}}
                </div>
                <div class="col-type2">
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
    export default{
        data(){
            return{
                excelData: null,
                ListEmployee: []
            }
        },
        methods: {

            /// <summary>
            /// get file of input
            /// </summary>
            uploadFile(e){
                this.excelData = e.target.files[0];
            },

            /// <summary>
            /// get file and send mail for employee
            /// </summary>
            async check(){
                const excelData= this.excelData;
                if(excelData==null){
                    alert("Input file, please!")
                    return;
                }
                const formdata= new FormData();
                formdata.append('file', excelData, 'excelData.xlsx')
                if (confirm('Do you want to Check and Send mail for employee?')) {
                    var it= document.getElementById("load-contairer");
                    it.classList.add("openFlex");
                    this.postFile('https://localhost:44348/api/SendMail/upload', formdata)
                    .then(data=>{
                        this.ListEmployee= data;
                        it.classList.remove("openFlex");    
                    });
                } else {
                    alert("Cancelled");
                }
            },
            /// <summary>
            /// post File from API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="file"></param>
            /// <returns>response.json()</returns>
            async postFile(url = '', file) {
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
        width: 200px;
        height: 30px;
        background-color: #007BFF;
        color: white;
        font-family: Arial, Helvetica, sans-serif;
        font-weight: bold;
        border-radius: 15px;
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
    .col-type1{
        height: 100%;
        width: 5%;
        margin-left: 2%;
        display: flex;
        align-items: center;
    }
    .col-type2{
        height: 100%;
        width: 13%;
        display: flex;
        align-items: center;
    }
    .col-type3{
        height: 100%;
        width: 22%;
        display: flex;
        align-items: center;
        justify-content: le;
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
</style>