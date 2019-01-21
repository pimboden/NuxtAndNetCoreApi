<template>
  <div>
    <header class="grid-container fluid top">
      <top-advertisement/>
      <top-navigation/>
      <top-info-panel/>
    </header> 
    <div class="grid-container fluid body">
      <div class="cell top-info-panel">
        <div class="grid-x">
          <div class="cell row-1">
            <div class="grid-x">
              <div class="cell medium-2 hide-for-small-only">&nbsp;</div>
              <div class="cell medium-8 small-12">

                <div class="grid-x">
                  <div class="cell medium-2 hide-for-small-only">
                   <left-main-bar/>

                 </div>
                 <div class="cell medium-10 content-area">
                  <!--MAIN CONTENT AREA-->

                  <nuxt/> 
                </div>
              </div>
            </div>
            <div class="cell medium-2 hide-for-small-only right-advertisement"><img src="https://placehold.it/160x600"></div>

          </div>
        </div>

      </div>
    </div>
  </div>
</div>
</template>

<script>

import TopAdvertisement from '~/components/TopAdvertisement'
import TopNavigation from '~/components/TopNavigation'
import TopInfoPanel from '~/components/TopInfoPanel'
import LeftMainBar from '~/components/LeftMainBar'

export default {
  components: {
    TopAdvertisement,
    TopNavigation,
    TopInfoPanel,
    LeftMainBar
  },

  data() {
    return {
      canonicalPath: 'https://test.8a.nu' + this.$route.fullPath
    }
  },

  head () {
    return {
      link: [{ rel: 'canonical', href: this.getCanonical }] 
    }
  },

  methods: {
  },
}

</script>

<style>

</style>
