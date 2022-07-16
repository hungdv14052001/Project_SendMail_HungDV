<template>
  <div>
    <div>
      <AppHeader></AppHeader>
    </div>
    <div id="main">
      <AppMenu></AppMenu>
        <Nuxt />
    </div>
    <div class="app-footer">
      Copyright © 2021 DevFast
    </div>
  </div>
</template>

<script>
  import AppHeader from '../components/AppHeader.vue';
  import AppMenu from '../components/AppMenu.Vue';
  export default {
    components: { 
      AppHeader,
      AppMenu,
    },
  }
</script>
<style>
  #main{
    display: flex;
    width: 100%;
  }
  .app-footer{
    width: 100%;
    height: 70px;
    display: flex;
    justify-content: center;
    align-items: center;
    color: #fff;
    font-size: 17px;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #303030;
  }
</style>
