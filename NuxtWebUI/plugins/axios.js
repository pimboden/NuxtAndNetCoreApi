// more info: https://axios.nuxtjs.org/extend.html

export default function ({ $axios, redirect }) {
  $axios.onRequest(config => {



    // don't mess with authetication axios calls, only 
    // with /api/ calls
    // console.log(config.url)
    // console.log(config)


    // lets see if we are on client side
    // don't add cors to keycloak server
    if (!process.server) {
      if (config.url.includes(process.env.KEYCLOACK_AUTH_SERVER_URL)) {
        // console.log("don't add cors", config.url)
        return
      }

      // console.log("add cors", config.url)
      // add allow origin header
      config.headers['Access-Control-Allow-Origin'] = '*' 
    }
    
    // add basic auth if we need it
    if (process.env.API_USE_BASIC_AUTH == 'true') {
    	// can't use btoa() here since server side rendering doesn't know about that function
    	var base64 = Buffer.from(process.env.API_BASIC_AUTH_NAME + ":" + process.env.API_BASIC_AUTH_PWD).toString('base64');
    	// var base64 = btoa(process.env.API_BASIC_AUTH_NAME + ":" + process.env.API_BASIC_AUTH_PWD)
    	config.headers['Authorization'] = "Basic " + base64
    }
  })
}