<template>
  <div class="container-fluid pl-0">
    <div class="pagetitlecontainer">
      <h2>redirects index</h2>
    </div>

    <div class="pagecontent row">
      <h3>method 1</h3>
      <nuxt-link class="nav-link" to="/redirects/destination?method=301" exact>
            destination 301
      </nuxt-link>
      <br/>
      <nuxt-link class="nav-link" to="/redirects/destination?method=302" exact>
            destination 302
      </nuxt-link>

      <h3>method 2</h3>
      <nuxt-link class="nav-link" to="/redirects/destination2?method=301" exact>
            destination2 301
      </nuxt-link>
      <br/>
      <nuxt-link class="nav-link" to="/redirects/destination2?method=302" exact>
            destination2 302
      </nuxt-link>

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
        title: "redirects - 8a.nu",
        meta: [
        { hid: 'description', name: 'description', content: '' }
        ]
      }
    }
}
</script>

<style>

</style>
