<template>
  <div class="container-fluid pl-0">
    <div class="pagetitlecontainer">
      <h2>callback</h2>
    </div>

    <div class="pagecontent row">

      <div class="col-12 pr-0">
        <h3>CALLBACK</h3>

        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
        consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
        cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
        proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        <img src="/kuva6.png" style="width: 100px">

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
        title: "callback - 8a.nu",
        meta: [
        { hid: 'description', name: 'description', content: 'news @ 8a.nu' }
        ]
      }
    },
    mounted() {
      console.log("callback from auth")
    }
}
</script>

<style>

</style>
