<template>
    <div id="SendMail-Page">
        <EmailSalary></EmailSalary>
    </div>
</template>
<script>
    import EmailSalary from '../components/EmailSalary.vue'
    export default {
        components: { 
            EmailSalary,
        },
        name: 'UserListPage',
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
    #SendMail-Page{
        width: 83%;
    }
</style>