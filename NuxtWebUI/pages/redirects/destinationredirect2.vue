<template>
  <div class="container-fluid pl-0">
    <div class="pagetitlecontainer">
      <h2>redirects - destinationredirect2</h2>
    </div>
    <nuxt-link class="nav-link" to="/redirects" exact>back</nuxt-link>
    <div class="pagecontent row">
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
        title: "redirects destination test - 8a.nu",
        meta: [
        { hid: 'description', name: 'description', content: '' }
        ]
      }
    }
}
</script>

<style>

</style>
