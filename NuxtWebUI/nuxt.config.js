const pkg = require('./package')
const webpack = require('webpack')
// let's require dotenv so we get .env configs 
// allready at build time
require('dotenv').config()

module.exports = {
  mode: 'universal',

  env: {
    //baseURL: process.env.API_URL_8A
  },


  /*
  ** Headers of the page
  */
  head: {
    title: pkg.name,
    meta: [
    { charset: 'utf-8' },
    { name: 'viewport', content: 'width=device-width, initial-scale=1, shrink-to-fit=no' },
    { hid: 'description', name: 'description', content: pkg.description }
    ],
    link: [
    { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico?v2' },
    { rel: 'stylesheet',  href: 'https://fonts.googleapis.com/css?family=IBM+Plex+Sans:400,700' }
    ],
  },

  /*
  ** Customize the progress-bar color
  */
  loading: { color: '#3B8070' },

  /*
  ** Global CSS
  */
  css: [
    // we just need:
    // yarn add -D node-sass sass-loader
    // and then we're able to add sass file here sass
    '~/assets/scss/main.scss'
    ],

  /*
  ** Plugins to load before mounting the App
  */
  plugins: [
  '~/plugins/i18n.js',
  '~/plugins/axios',
  { src: '~plugins/vue-slider-component.js', ssr: false }
  ],

  router: {
    middleware: ['i18n','testredirect','manualHotjar'],
    base: '/',
    linkActiveClass: 'active',

    scrollBehavior: function (to, from, savedPosition) {
     return {x: false, y: false}
   },

    /*
    scrollBehavior(to, from, savedPosition) {
      if (savedPosition) {
        return savedPosition
      } else {
        let position = {}
        if (to.matched.length < 2) {
          position = { x: 0, y: 0 }
        } else if (to.matched.some(r => r.components.default.options.scrollToTop)) {
          position = { x: 0, y: 0 }
        }
        if (to.hash) {
          position = { selector: to.hash }
        }
        return position
      }
    },
    */

    // test for creating routes for other languages
    extendRoutes (routes) {
      const languages = ['de', 'fr']
      const newRoutes = []
      
      // loop through all routes and copy them to all locales
      routes.forEach(r => {
        languages.forEach (l => {

          var path = r.path;

          if (path.includes('/articles'))
          {
            if (l == "de") {
              path = "/artikel"
            }
            else if (l == "fr") {
              path = "/articles"
            }
          }
          var route = {
            name: `${l}-${r.name}`,   // eg. de-name
            path: `/${l}${path}`,   // eg. /de/path
            component: r.component
          }

          newRoutes.push(route)
        })
      })

      routes.push(...newRoutes)
    }
  },

  /*
  ** Nuxt.js modules
  */
  modules: [
    // Doc: https://github.com/nuxt-community/axios-module#usage
    '@nuxtjs/axios',

    '@nuxtjs/auth',

    // https://github.com/nuxt-community/dotenv-module
    // Simple usage
    '@nuxtjs/dotenv',
    // With options
    //['@nuxtjs/dotenv', { /* module options */ }]

    // https://github.com/nuxt-community/modules/tree/master/packages/google-tag-manager
    ['~/modules/google-tag-manager', { id: process.env.GTM_ID || "GTM-WMTFBCH" }],
    ],

  /*
  ** Axios module configuration
  */
  axios: {
    // See https://github.com/nuxt-community/axios-module#options
    prefix: process.env.API_PREFIX_8A || '/api/v1.0/', 
    proxy: true,
    credentials: false
  },

  proxy: {
    '/api/': process.env.API_URL_8A,
  },

  auth: {
    // https://auth.nuxtjs.org/
    // workaround for keycloak (see /plugins/auth.js plugin):
    // https://github.com/nuxt-community/auth-module/pull/208#issuecomment-409205346
    // remember /plugins/axios.js adds basic auth and cors to axios requests so these have to be ignored
    plugins: [ '~/plugins/auth.js' ],
    strategies: {
      keycloak: {
        _scheme: 'oauth2',
        response_type: 'code',
        grant_type: 'authorization_code',
        decode_resource_access: true,
        authorization_endpoint: process.env.KEYCLOACK_AUTH_SERVER_URL + process.env.KEYCLOACK_REALM + process.env.KEYCLOAK_AUTHORIZATION_ENDPOINT,
        userinfo_endpoint: process.env.KEYCLOACK_AUTH_SERVER_URL + process.env.KEYCLOACK_REALM + process.env.KEYCLOAK_USERINFO_ENDPOINT,
        access_token_endpoint: process.env.KEYCLOACK_AUTH_SERVER_URL + process.env.KEYCLOACK_REALM + process.env.KEYCLOAK_TOKEN_ENDPOINT,
        client_id: process.env.KEYCLOACK_CLIENTID,
        scope: ['openid', 'profile', 'email'],
        token_type: 'Bearer',
        token_key: 'access_token'
      }
    },
    redirect: {
      login: '/login', // route created for testing
      logout: '/logout', // route created for testing
      callback: '/callback', // route created for testing
      user: '/user'
    }
  },

  /*
  ** Build configuration
  */
  build: {
    /*
    ** You can extend webpack config here
    */

 /*   plugins:[
    new webpack.ProvidePlugin({  
      jQuery: 'jquery',
      $: 'jquery'
    })],*/
    // plugins: [
    //   new webpack.ProvidePlugin({_: 'lodash'})
    // ],
    extend(config, ctx) {

    },
    vendor: [
    '~/assets/scss/foundation-sites/js/foundation.core.js',
    '~/assets/scss/foundation-sites/js/foundation.slider.js',
    '~/assets/scss/foundation-sites/js/foundation.util.motion.js',
    '~/assets/scss/foundation-sites/js/foundation.util.triggers.js',
    '~/assets/scss/foundation-sites/js/foundation.util.keyboard.js',
    '~/assets/scss/foundation-sites/js/foundation.util.touch.js',
    'vue-slider-component',
    'vue-chartjs'
    ]
  }
}
