<template>



  <div class="grid-container full">
    <div class="grid-x grid-margin-x">
      <div class="cell small-12 medium-8 large-6 news-column">
        <fieldset class="news-titel">
          <legend ><h2>.. check the console for more nasty details</h2></legend>
        </fieldset>
        <div class="grid-x">
          <ul>
          <li><a @click="throwTestException">throw test exception</a></li>
          <li><a @click="throwTestException2">throw another test exception</a></li>
          </ul>
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
  asyncData ({ params, error}) {
    error({ statusCode: 500, message: 'test exception.'})
  },
  data() {
    return {
      process_env: process.env.NODE_ENV
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
  mounted(){

    

  },
  
  methods: {
    throwTestException() {
      $context.res.statusCode = 500
      this.$root.error({ statusCode: 500, message: "this is a test exception" })
    },
    throwTestException2() {
      this.$root.error({ statusCode: 404, message: "this is another test exception" })
    }
  }

}
</script>

<style>

</style>
