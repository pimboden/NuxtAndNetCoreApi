export default function ({ isHMR, app, store, route, params, error, redirect }) {
  const defaultLocale = app.i18n.fallbackLocale
  // If middleware is called from hot module replacement, ignore it
  if (isHMR) return

  // get locale from url
let locale = defaultLocale;
var reg = /^\/(\w{2})(\/|$)/
var match = reg.exec(route.path);
if (match) {
  locale = match[1];
}

if (store.state.locales.indexOf(locale) === -1) {
  return error({ message: 'This page could not be found.', statusCode: 404 })
}
  // Set locale
  store.commit('updateLocale', locale)
  app.i18n.locale = store.state.locale
  // If route is /<defaultLocale>/... -> redirect to /...
  if (locale === defaultLocale && route.fullPath.indexOf('/' + defaultLocale) === 0) {
    const toReplace = '^/' + defaultLocale
    const re = new RegExp(toReplace)
    return redirect(
      route.fullPath.replace(re, '/')
      )
  }
}