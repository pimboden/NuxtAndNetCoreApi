// Include Google Tag Manager Script
window['<%= options.layer %>'] = window['<%= options.layer %>'] || [];
window['<%= options.layer %>'].push({
  event: 'gtm.js', 'gtm.start': new Date().getTime()
});

// Every time the route changes (fired on initialization too)
// maybe later we make this so that the meta title is received from the
// router function:


// this pushes to the google GTM but doesn't get the right meta.title
export default ({app: {router}}) => {
  
  /*
  router.afterEach((to, from) => {
    	window['<%= options.layer %>'].push(to.gtm || {pageType: 'PageView', pageUrl: to.fullPath})
  })
  */
}

