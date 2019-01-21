const strategy = 'keycloak'

export default function ({ app }) {

  const { $axios, $auth } = app

  if (!$auth.loggedIn || !$auth.strategies[strategy])
    return

  const options = $auth.strategies.keycloak.options
  let token = $auth.getToken(strategy)
  let refreshToken = $auth.getRefreshToken(strategy)

  if (!token || !refreshToken)
    return

  // calculate timeout before token expiration (75% from expiration time)
  const tokenParsed = decodeToken.call(this, token)
  let refreshInterval = (tokenParsed.exp * 1000 - Date.now()) * 0.75

  // Limit 10 seconds (avoid self attack)
  if (refreshInterval < 10000) {
    refreshInterval = 10000
  }

  // keep refreshing token before expiration time
  let refresher = setInterval(async function () {
    try {
      const response = await $axios.post(options.access_token_endpoint,
        encodeQuery({
          refresh_token: refreshToken.replace(options.token_type + ' ', ''),
          client_id: options.client_id,
          grant_type: 'refresh_token'
        })
      )

      token = options.token_type + ' ' + response.data.access_token
      refreshToken = options.token_type + ' ' + response.data.refresh_token

      $auth.setToken(strategy, token)
      $auth.setRefreshToken(strategy, refreshToken)
      $axios.setToken(token)
    } catch (error) {
      $auth.logout()
      throw new Error('Erro while refreshing token')
    }
  }, refreshInterval)
}

// Properly encode data 
function encodeQuery (queryObject) {
  return Object.keys(queryObject)
    .map(
      key =>
        encodeURIComponent(key) + '=' + encodeURIComponent(queryObject[key])
    )
    .join('&')
}

// Decode JWT token
function decodeToken (str) {
  str = str.split('.')[1];

  str = str.replace('/-/g', '+');
  str = str.replace('/_/g', '/');
  switch (str.length % 4) {
    case 0:
      break;
    case 2:
      str += '==';
      break;
    case 3:
      str += '=';
      break;
    default:
      throw 'Invalid token';
  }

  str = (str + '===').slice(0, str.length + (str.length % 4));
  str = str.replace(/-/g, '+').replace(/_/g, '/');

  var atobbed = ""
  if (process.server) {
    // on serverside we have to use atob from npm
    var atob = require('atob')
    atobbed = atob(str)
  }
  else
  {
    // console.log("we're using atob on browser")
    
    if (atob) {
      // console.log("using atob")
      atobbed = atob(str)
    }
    else if (window.atob) {
      // console.log("using window.atob")
      atobbed = window.atob(str)
    }
    else {
      // console.log("no atob found")
    }
  }

  str = decodeURIComponent(escape(atobbed));

  str = JSON.parse(str);
  return str;
}