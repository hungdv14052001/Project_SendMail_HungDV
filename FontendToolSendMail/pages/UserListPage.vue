<template>
    <div id="User-List-Page">
        <UserList></UserList>
    </div>
</template>
<script>
    import UserList from '../components/User/UserList.Vue';
    export default {
        components: { 
            UserList,
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
    #User-List-Page{
        width: 83%;
    }
</style>