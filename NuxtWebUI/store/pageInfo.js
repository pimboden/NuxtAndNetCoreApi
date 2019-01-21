const state = () => ({
	name:'',
	description:'',
	url:'',
	breadcrumbs: []
})

const getters = {
	name: state => {
		return state.name
	},
	description: state => {
		return state.description
	},
	url: state => {
		return state.url
	},
	breadcrumbs: state => {
		return state.breadcrumbs
	}
}

const mutations = {
	updateName : (state, name) => {
		state.name = name
	},
	updateDescription : (state, description) => {
		state.description = description
	},
	updateUrl: (state, url) => {
		state.url = url
	},
	updateBreadcrumbs: (state, breadcrumbs) => {
		state.breadcrumbs = breadcrumbs
	}
}
const actions = {
	updateName: ({ commit }, name) => {
		commit("updateName", name);
	},
	updateDescription: ({ commit }, description) => {
		commit("updateDescription", description);
	},
	updateUrl: ({ commit }, url) => {
		commit("updateUrl", url);
	}
	,
	updateBreadcrumbs: ({ commit }, breadcrumbs) => {
		commit("updateBreadcrumbs", breadcrumbs);
	}
};

export default{
	state,
	getters,
	mutations,
	actions
}

