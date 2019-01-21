<template>
	
	<div>
		<h2>AREA CRAGS</h2>
		<paging></paging>
		<crags-list :items="crags"></crags-list>
		<paging></paging>
	</div>

</template>


<script>
	import CragsList from "@/components/crags/CragsList"
	import Paging from "@/components/common/Paging"
	import {PageInfoMixin} from "@/assets/js/vueMixins.js"

	export default {
		mixins:[PageInfoMixin],
		props: ['area'],

		watchQuery: ['page', 'sortfield'],

		components: {
			CragsList,
			Paging
		},

		data(){
			return {
				crags: []
			}
		},
		
		async asyncData (context) {
		    return context.$axios.$get('/crags/getallforarea', {
					params:{
						"areaSlug": context.route.params.area,
						"country": context.route.params.country,
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || ''
					}
				})
		      .then((data)=>{
		        return { crags: data }
		      }).
		      catch((error)=>{
		        console.log("error getting data from '/crags/getallforarea' " + error)
		      })	
		},

		filters: {
			roundPercentage(val) {
				var rounded = Math.round(val * 10 ) / 10
				var fixed = rounded.toFixed(1)
				return fixed
			}
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
			        { title: this.area.name, route: 'areas-country-area', params: { country: route.params.country, area: route.params.area } },
			        { title: 'crag list' }
		    	]
			}
		},

		head() {
			return {
				title: "area crags - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Areas @ 8a.nu' }
				]
			}
		},
	}
</script>