<template>
    <div id="User-Edit-Page">
        <UserEdit></UserEdit>
    </div>
</template>
<script>
    import UserEdit from '../components/User/UserEdit.Vue';
    export default {
        components: { 
            UserEdit,
        },
        name: 'EditUserPage',
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
    #User-Edit-Page{
        width: 83%;
        background-color: #f0f0f0;
        min-height: 680px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>