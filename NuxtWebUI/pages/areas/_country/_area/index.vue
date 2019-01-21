<template>
	<div>
	<h2>GRADES</h2>
	<div>
		<grades-chart :grades="area.grades" />
	</div>
	<h2>SEASON</h2>
	<div class="grid-x">
		<div class="cell medium-3">
			<season-chart :season="area.season" />
		</div>	
		<div class="cell medium-9">Ratings would be here</div>
	</div>
	
	</div>
</template>

<script>

import {PageInfoMixin} from "@/assets/js/vueMixins.js"
import SeasonChart from "@/components/crags/SeasonChart"
import GradesChart from "@/components/crags/GradesChart"

export default {
	mixins:[PageInfoMixin],
	props: ['area'],
	components: {
		SeasonChart,
		GradesChart
	},
	computed: {
		headerTitle() {
			return this.area.name
		},
		breadcrumbs() {
			var route = this.$route
			return [
		        { title: 'areas', route: 'areas' },
		        { title: route.params.country, route: 'areas-country', params: { country: route.params.country } },
		        { title: this.area.name }
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