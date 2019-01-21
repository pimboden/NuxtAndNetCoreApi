<template>

	<h1>AREA FEED</h1>

</template>

<script>

import {PageInfoMixin} from "@/assets/js/vueMixins.js"

export default {
	mixins:[PageInfoMixin],
	props: ['area'],
	computed: {
		headerTitle() {
			return this.area.name
		},
		breadcrumbs() {
			var route = this.$route
			return [
		        { title: 'areas', route: 'areas' },
		        { title: route.params.country, route: 'areas-country', params: { country: route.params.country } },
		        { title: this.area.name, route: 'areas-country-area', params: { country: route.params.country, area: route.params.area } },
		        { title: 'Feed' }
	    	]
		}
	},
	mounted() {
		
	},
	head() {
		return {
			title: "area - 8a.nu",
			meta: [
			{ hid: 'description', name: 'description', content: 'Areas @ 8a.nu' }
			]
		}
	},

}

</script>