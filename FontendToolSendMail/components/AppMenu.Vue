<template>
    <div id="app-menu">
        <NuxtLink to="/HomePage" class="btnHome">
            <div class="margin30"></div>
            Home
        </NuxtLink>
        <div>
            <NuxtLink to="/UserListPage" class="menu-item2">
                <div class="margin30"></div>
                User
            </NuxtLink>
        </div>
        <div>
            <NuxtLink to="/SendMailPage" class="menu-item2">
                <div class="margin30"></div>
                Send mail
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
            }
        },
        methods: {
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
</style>