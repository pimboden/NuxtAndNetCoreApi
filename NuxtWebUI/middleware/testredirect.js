export default function ({ params, route, redirect }) {
  if (route.path == "/redirects/destination") 
  {
  	var method = '301'
  	if (route.query && route.query.method)
  	{
  		method = route.query.method
  	}

  	// workaround for getting real server redirect
  	// if we're on the server side, we just make the normal redirect
  	// if client side, we redirect to the actual url so we get the 
  	// status code
  	if (process.server) {
    	redirect(method, '/redirects/destinationredirect')
  	}
  	else 
  	{
  		redirect(method, process.env.APP_URL + route.fullPath)
  	}
  }
  else if (route.path == "/redirects/destination2")
  {
  	var method = '301'
  	if (route.query && route.query.method)
  	{
  		method = route.query.method
  	}
  	redirect(method, '/redirects/destinationredirect2')
  }
  
}