<template>
  <div id="home-page">
    <div class="title-Page">
        <div class="margin30">HomePage</div>
    </div>
    <div>
        <img src="../assets/images/bg.png" class="img-bg">
    </div>
  </div>
</template>

<script>
    export default {
        name: 'HomePage',
        async beforeMount(){
            this.idUser= localStorage.getItem('idUser')
            localStorage.setItem('idUser', this.idUser);
        },
        data(){
            return{
                idUser: 0,
            };
        },
        methods: {

        }
    }
</script>
<style>
    #home-page{
        width: 83%;
        min-height: 680px;
    }
    .title-Page{
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
    .margin30{
        margin-left: 30px;
    }
    .img-bg{
        width: 100%;
    }
</style>
