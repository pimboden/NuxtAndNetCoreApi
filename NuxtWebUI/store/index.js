const state = () => ({
	locales: ['en', 'de', 'fr'],
	locale: 'en'
})
const getters = {
	locale: state => {
		return state.locale
	},
	locales: state => {
		return state.locales
	}
}

const mutations = {
	updateLocale : (state, locale) =>{
		if (state.locales.indexOf(locale) !== -1) {
			state.locale = locale
		}
	}
}
const actions = {
	updateLocale: ({ commit }, locale) => {
		commit("updateLocale", locale);
	}
}
export default{
	state,
	getters,
	mutations,
	actions
}