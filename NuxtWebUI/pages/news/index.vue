<template>
  <div class="container-fluid pl-0">
    <div class="pagetitlecontainer">
      <h2>{{ $t('news.title') }}</h2>
    </div>

    <div class="pagecontent row">

      <div class="col-6 pr-0">
        <h3>LATEST NEWS</h3>

        CONTENT
        <img src="/kuva6.png" style="width: 100px">

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
        title: "News - 8a.nu",
        meta: [
        { hid: 'description', name: 'description', content: 'news @ 8a.nu' }
        ]
      }
    }
}
</script>

<style>

</style>
