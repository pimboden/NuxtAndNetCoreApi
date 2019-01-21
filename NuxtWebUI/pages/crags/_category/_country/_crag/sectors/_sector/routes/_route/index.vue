<template>

<div class="grid-container full main-area" >
	<div class="grid-x grid-margin-x">
		<div class="cell small-12 medium-12 large-12 news-column">
			<zlaggable-header :zlaggable="zlaggable"></zlaggable-header>
			<zlaggable-sub-navigation></zlaggable-sub-navigation>

			<fieldset class="main-area-title">
				<legend ><h2>TICKLIST</h2></legend>
			</fieldset>

			<paging></paging>
			<ascents-list name="myascents" :items="ascents"></ascents-list>
			<paging></paging>
		</div>
	</div>
</div>

</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin, IsoToLocaleDate} from "@/assets/js/vueMixins.js"
	import ZlaggableHeader from "@/components/crags/ZlaggableHeader"
	import ZlaggableSubNavigation from "@/components/crags/ZlaggableSubNavigation"
	import AscentsList from "@/components/crags/AscentsList"
	import Paging from "@/components/common/Paging"

	export default{

		mixins:[StringTruncateMixin, PageInfoMixin, IsoToLocaleDate],

		components: {
			ZlaggableHeader,
			ZlaggableSubNavigation,
			AscentsList,
			Paging
		},

		watchQuery: ['sortfield', 'page'],

		data(){
			return {
				zlaggable: null,
				ascents: []
			}
		},
		
		async asyncData (context) {
			let [zlaggable, ascents] = await Promise.all([
				context.$axios.$get('/routes/get', {
					params: {
						"zlaggableSlug": context.route.params.route,
						"sectorSlug": context.route.params.sector,
						"category": context.route.params.category
					}
				}),
				context.$axios.$get('/ascents/getallforroute', {
					params: {
						"zlaggableSlug": context.route.params.route,
						"sectorSlug": context.route.params.sector,
						"category": context.route.params.category,
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || ''
					}
				})
			])

			return {
				zlaggable:zlaggable,
				ascents:ascents
			}
		},

		mounted() {
			
		},

		computed: {
			headerTitle() {
				return this.zlaggable.name
			},
			breadcrumbs() {
				var route = this.$route
				var category = route.params.category == "sportclimbing" ? "sport climbing" : "bouldering"
				var rootTitle = category + ' ' + this.$t('links.crags')

				return [
			        { title: rootTitle, route: 'crags-category', params: {  
							category: route.params.category }},
			        
			        { title: this.zlaggable.countryName, route: 'crags-category-country', params: {  
							category: route.params.category, 
							country: route.params.country }},
			        
			        { title: this.zlaggable.cragName, route: 'crags-category-country-crag', params: {  
							category: route.params.category, 
							country: route.params.country, 
							crag: route.params.crag }},
			        
					{ title: this.zlaggable.sectorName, route: 'crags-category-country-crag-routes', 
						params: {  
							category: route.params.category, 
							country: route.params.country, 
							crag: route.params.crag
						}, 
						query: { sector: route.params.sector }},

			        { title: this.zlaggable.name }
			        
		    	]
			}
		},

		head() {
			return {
				title: "Route - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Route @ 8a.nu' }
				]
			}
		},
		
		validate ({ params }) {
			// must be sportclimbing or bouldering
			return /^(sportclimbing|bouldering)$/.test(params.category)
		},
	}
</script>