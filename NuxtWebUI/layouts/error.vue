<template>
  <div class="container">
    <h1 v-if="error.statusCode === 404">Page not found</h1>
    <h1 v-else>An error occurred</h1>
    <p class="description">{{ this.error }}</p>
    <nuxt-link to="/">Home page</nuxt-link>
  </div>
</template>

<script>
export default {
  props: ['error'],

  mounted(){
    // since we can't reach meta.title in the /modules/google-tag-manager-plugin.js
    // this is the way to go:
    // https://github.com/MatteoGabriele/vue-analytics/issues/32
    
    if (process.browser && process.env.NODE_ENV == "production") {
      window['dataLayer'].push({event: 'virtualPageView', pageUrl: this.$route.fullPath, pageName: this.message})
    }
    
  },

  computed: {
    statusCode () {
      return (this.error && this.error.statusCode) || 500
    },
    message () {
      return this.error.message || '<%= messages.client_error %>'
    }
  }
}
</script>