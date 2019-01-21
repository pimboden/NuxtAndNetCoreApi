<template>

<div class="grid-container full main-area" >
	<div class="grid-x grid-margin-x">
		<div class="cell small-12 medium-12 large-12 news-column">
			<zlaggable-header :zlaggable="zlaggable"></zlaggable-header>
			<zlaggable-sub-navigation></zlaggable-sub-navigation>

			<fieldset class="main-area-title">
				<legend ><h2>ROUTE INFO</h2></legend>
			</fieldset>
		</div>
	</div>
</div>

</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin, IsoToLocaleDate} from "@/assets/js/vueMixins.js"
	import ZlaggableHeader from "@/components/crags/ZlaggableHeader"
	import ZlaggableSubNavigation from "@/components/crags/ZlaggableSubNavigation"
	import AscentType from "@/components/common/AscentType"

	export default{

		mixins:[StringTruncateMixin, PageInfoMixin, IsoToLocaleDate],

		components: {
			ZlaggableHeader,
			ZlaggableSubNavigation
		},

		data(){
			return {
				zlaggable: null,
				ascents: []
			}
		},
		
		async asyncData (context) {
			return context.$axios.$get('/routes/get', {
					params: {
						"zlaggableSlug": context.route.params.route,
						"sectorSlug": context.route.params.sector,
						"category": context.route.params.category,
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || ''
					}
				})
		      .then((data)=>{
		        return { zlaggable: data }
		      }).
		      catch((error)=>{
		        console.log("error getting data from '/routes/get' " + error)
		      })	
		},

		methods: {
			
		},

		head() {
			return {
				title: "Route - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Crags @ 8a.nu' }
				]
			}
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

			        { title: this.zlaggable.name, route: 'crags-category-country-crag-sectors-sector-routes-route', params: {  
							category: route.params.category, 
							country: route.params.country, 
							crag: route.params.crag,
							sector: route.params.sector,
							route: route.params.route }},

					{ title: "route information" }
			        
		    	]
			}
		},

		validate ({ params }) {
			// must be sportclimbing or bouldering
			return /^(sportclimbing|bouldering)$/.test(params.category)
		},
	}
</script>