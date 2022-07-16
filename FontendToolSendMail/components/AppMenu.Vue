<template>
    <div id="app-menu">
        <NuxtLink to="/HomePage" class="btnHome">
            <div class="margin30"></div>
            Home
        </NuxtLink>
        <button @click="displayListSystem" class="menu-item1">
            {{System}}
        </button>
        <div id="list-System" class="close">
            <NuxtLink to="/SendMailPage" class="menu-item2">
                <div class="margin30"></div>
                Send mail
            </NuxtLink>
        </div>
        <div @click="displayListModel" class="menu-item1">
            {{Module}}
        </div>
        <div id="list-Model" class="close">
            <NuxtLink to="/UserListPage" class="menu-item2">
                <div class="margin30"></div>
                User
            </NuxtLink>
        </div>
    </div>
</template>
<script>
    export default {
        async beforeMount(){

        },
        data(){
            return{
                System: 'System  ▲',
                Module: 'Module  ▲',
            }
        },
        methods: {
             displayListSystem(){
                var itemElement= document.getElementById("list-System");
                if(itemElement.classList.length==1){
                    itemElement.classList.add("open");
                    this.System='System  ▼';
                }
                else{
                    itemElement.classList.remove("open");
                    this.System='System  ▲';
                }
            },
            displayListModel(){
                var itemElement= document.getElementById("list-Model");
                console.log(itemElement.classList);
                if(itemElement.classList.length==1){
                    itemElement.classList.add("open");
                    this.Module='Module  ▼';
                }
                else{
                    itemElement.classList.remove("open");
                    this.Module='Module  ▲';
                }
            }
        }
    }
</script>
<style>
    #app-menu{
        width: 17%;
        min-height: 680px;
    }
    .btnHome{
        width: 100%;
        height: 45px;
        border: 1px solid #ccc;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 19px;
        font-weight: bold;
        display: flex;
        align-items: center;
        text-decoration: none;
        color: black;
    }
    .margin30{
        margin-left: 30px;
    }
    .menu-item1{
        width: 100%;
        height: 45px;
        border: 1px solid #ccc;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 19px;
        font-weight: bold;
        display: flex;
        align-items: center;
        color: #007BFF;
        justify-content: center;
        cursor: pointer;
    }
    .menu-item2{
        width: 100%;
        height: 35px;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 17px;
        font-weight: bold;
        display: flex;
        align-items: center;
        text-decoration: none;
        color: black;
    }
    .btnHome:hover,.menu-item2:hover{
        cursor: pointer;
        background-color: #f0f0f0;
    }
    .close{
        display: none;
    }
    .open{
        display: block;
    }
</style>