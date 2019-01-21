<template>



  <div class="grid-container full">
    <div class="grid-x grid-margin-x">
      <div class="cell small-12 medium-8 large-6 news-column">
        <fieldset class="news-titel">
          <legend ><h2>.. check the console for more nasty details</h2></legend>
        </fieldset>
        <div class="grid-x">
          <ul>
           <li><strong>NODE_ENV: </strong>{{ process_env }} </li>
           <li><strong>user auth for api:</strong>{{ process_useauth }}</li>
           <li><strong></strong>{{ name }}</li>
           <li><strong></strong>{{ pwd }}</li>
           <li><strong></strong>{{ hashed }}</li>
          </ul>
          <h3>countries:</h3>
          <ul><li v-for="country in countries">{{ country.slug }}</li></ul>
        </div>
      </div>
      <div class="cell small-12 medium-2 large-3 videos-column"> 
        <fieldset class="videos-titel">
        <legend ><h2>Latest nideos</h2></legend>

      </fieldset>
      <div class="grid-x">
        
      </div>
    </div>
    <div class="cell small-12 medium-offset-8 medium-2 large-offset-0 large-3 editorial-column"> 
      <fieldset class="editorial-titel">
        <legend ><h2>Editorial</h2></legend>
      </fieldset>
    </div>
  </div>
</div>

</template>

<script>
import NewsContent from '~/components/NewsContent.vue'
import VideoContent from '~/components/VideoContent.vue'
export default {
  data() {
    return {
      process_env: process.env.NODE_ENV,
      process_useauth: process.env.API_USE_BASIC_AUTH,
      name: process.env.API_BASIC_AUTH_NAME || "",
      pwd: process.env.API_BASIC_AUTH_PWD || "",
      countries: []
    }
  },
  components: {
  },
  head() {
    return {
      title: "Home - 8a.nu",
      meta: [
          { hid: 'description', name: 'description', content: 'debugpage @ 8a.nu' }
      ]
    }
  },
  computed: {
    hashed() {
      if (this.process_useauth) {
        var base64 = Buffer.from(this.name + ":" + this.pwd).toString('base64');
        return base64;
      }
      else {
        return "dude, no password"
      } 

    }
  },
  mounted(){
    console.log("debug data: this", this);

    console.log("start loading countries from server")
    this.$axios.$get('/countries/getall')
      .then((data)=>{
        this.countries = data
      });
    console.log("data returned from '/countries/getall':")
    console.log(this.countries);

  },

}
</script>

<style>

</style>
