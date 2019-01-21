<template>
  <div class="grid-container full">
    <div class="grid-x grid-margin-x">
      <div class="cell small-12 medium-8 large-6 news-column">
        <fieldset class="main-area-title">
          <legend ><h2>Latest news</h2></legend>
        </fieldset>
        <div class="grid-x">
          <news-content  v-for="item in latestNews" :key="item.id" :news="item"></news-content>
        </div>
      </div>
      <div class="cell small-12 medium-2 large-3 aside-a-column"> 
        <fieldset class="aside-a-title">
          <legend ><h2>Latest videos</h2></legend>

        </fieldset>
        <div class="grid-x">
          <video-content  v-for="item in latestNews" :key="item.id" :video="item"></video-content>
        </div>
      </div>
      <div class="cell small-12 medium-offset-8 medium-2 large-offset-0 large-3 aside-b-column"> 
        <fieldset class="aside-b-title">
          <legend ><h2>Editorial</h2></legend>
        </fieldset>
      </div>
    </div>
  </div>

</template>

<script>
  import { mapActions, mapGetters } from 'vuex';
  import NewsContent from '~/components/NewsContent.vue'
  import VideoContent from '~/components/VideoContent.vue'
  import {PageInfoMixin} from "@/assets/js/vueMixins.js"

  export default {
    mixins:[PageInfoMixin],
    components: {
      NewsContent,
      VideoContent
    },
    data() {
      return {
        latestNews: []
      }
    },
    asyncData (context) {
      return context.$axios.$get('/news/getlatest')
      .then((data)=>{
        return { latestNews: data }
      }).
      catch((error)=>{
        console.log("error getting data from '/news/getlatest/' " + error)
      })
    },
    head() {
      return {
        title: "Home - 8a.nu",
        meta: [
        { hid: 'description', name: 'description', content: 'homepage @ 8a.nu' }
        ]
      }
      
    }
  }
</script>

<style>

</style>
