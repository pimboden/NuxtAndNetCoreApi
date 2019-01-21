<template>
  <div class="container-fluid pl-0">
    <div class="pagetitlecontainer">
      <h2>{{ $t('videos.title') }}</h2>
    </div>

    <div class="pagecontent row">

      <div class="col-6 pr-0">
        <h3>LATEST VIDEOS</h3>

        CONTENT

      </div>

      <div class="col-3">
        <h3>CATEGORIES</h3>

      </div>

      <div class="col-3">
        <h3>FAVORITES</h3>

      </div>
    </div>
  </div>
</template>

<script>
  import { mapActions, mapGetters } from 'vuex';
  import {PageInfoMixin} from "@/assets/js/vueMixins.js"
  export default {
    mixins:[PageInfoMixin],
    head() {
      return {
        title: "Videos - 8a.nu",
        meta: [
        { hid: 'description', name: 'description', content: 'videos @ 8a.nu' }
        ]
      }
    }
  }
</script>

<style>

</style>
