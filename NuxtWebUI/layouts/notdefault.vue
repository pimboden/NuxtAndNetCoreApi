<template>
  <div class="container">
    <div>
      <logo/>
      <CountryChanger/>
      <Navigation/> 
    </div>
    <div class="pagecontent"><nuxt/></div>
  </div>
</template>

<script>
  import Logo from '~/components/Logo.vue'
  import Navigation from '~/components/Navigation.vue'
  import CountryChanger from '~/components/CountryChanger.vue'

  export default {
    components: {
      Logo,
      Navigation,
      CountryChanger
    },
  
    data() {
      return {
        canonicalPath: 'https://test.8a.nu' + this.$route.fullPath
      }
    },

    head () {
      return {
        link: [{ rel: 'canonical', href:this.canonicalPath }] 
      }
    },

    methods: {
      getCanonical() {
        return 'https://test.8a.nu' + this.$route.fullPath
      }
    }
  }

</script>

<style>
html
{
  font-family: "Source Sans Pro", -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
  font-size: 16px;
  word-spacing: 1px;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  box-sizing: border-box;
}
*, *:before, *:after
{
  box-sizing: border-box;
  margin: 0;
}
.title
{
  font-family: "Quicksand", "Source Sans Pro", -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif; /* 1 */
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}
.container
{
  min-height: 100vh;
  /*display: flex;*/
  justify-content: center;
  align-items: center;
  text-align: center;
}
.pagecontent {
  margin-top: 50px;
}
.button--green
{
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #3b8070;
  color: #3b8070;
  text-decoration: none;
  padding: 10px 30px;
}
.button--green:hover
{
  color: #fff;
  background-color: #3b8070;
}
.button--grey
{
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #35495e;
  color: #35495e;
  text-decoration: none;
  padding: 10px 30px;
  margin-left: 15px;
}
.button--grey:hover
{
  color: #fff;
  background-color: #35495e;
}
</style>
