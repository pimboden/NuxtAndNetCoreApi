<template>
	<div class="grid-container full main-area" >
		
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-12 large-12 news-column">
				<fieldset class="main-area-title">
					<legend ><h2>CRAGS ({{ $route.params.category }}) - {{ $route.params.country }} - {{ $route.params.crag }}</h2></legend>
				</fieldset>
				<crag-header :crag="crag"></crag-header>
				<crag-sub-navigation></crag-sub-navigation>

				<fieldset class="main-area-title">
					<legend ><h2>GRADES</h2></legend>
				</fieldset>

				<div><grades-chart :grades="crag.grades" /></div>

				<fieldset class="main-area-title">
					<legend ><h2>SEASON</h2></legend>
				</fieldset>
				
				<div class="grid-x">
					<div class="cell medium-3">
						<season-chart :season="crag.season" />
					</div>	
					<div class="cell medium-9">Ratings would be here</div>
				</div>

				<div class="grid-x">
					<div class="cell small-12 medium-4">
						here would be google maps böxli if crag has location defined

						.. access .. 
						<!-- {{ crag.access }} -->
					</div>
					<div class="cell small-12 medium-4">
						.. description ..
						<!-- {{ crag.description }} -->
					</div>
				</div>

				<fieldset class="main-area-title">
					<legend ><h2>GALLERY</h2></legend>
				</fieldset>

				

			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import CragHeader from "@/components/crags/CragHeader"
	import CragSubNavigation from "@/components/crags/CragSubNavigation"
	import SeasonChart from "@/components/crags/SeasonChart"
	import GradesChart from "@/components/crags/GradesChart"

	export default{

		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			CragHeader,
			CragSubNavigation,
			SeasonChart,
			GradesChart
		},

		data(){
			return {
				crag: null
			}
		},

		computed: {
			headerTitle() {
				return this.crag.name
			},
			breadcrumbs() {
				var route = this.$route
				// console.log(route)
				var category = route.params.category == "sportclimbing" ? "sport climbing" : "bouldering"
				var rootTitle = category + ' ' + this.$t('links.crags')

				return [
			        { title: rootTitle, route: 'crags-category', params: {  
							category: route.params.category }},
			        
			        { title: this.crag.countryName, route: 'crags-category-country', params: {  
							category: route.params.category, 
							country: route.params.country }},
			        
			        { title: this.crag.name }
		    	]
			}
		},
		
		async asyncData (context) {
			return context.$axios.$get('/crags/get',{
					params:{
						"slug": context.route.params.crag,
						"country": context.route.params.country,
						'category': context.route.params.category
					}
				})
		      .then((data)=>{
		        return { crag: data }
		      }).
		      catch((error)=>{
		        console.log("error getting data from '/crags/get' " + error)
		      })
		},

		mounted() {
			
		},
		
		created() {
			
		},

		methods:{
			
		},
		head() {
			return {
				title: "Crags - 8a.nu",
				meta: [{ hid: 'description', name: 'description', content: 'Crags @ 8a.nu' }]
			}
		},
		
		validate ({ params }) {
			// must be sportclimbing or bouldering
			return /^(sportclimbing|bouldering)$/.test(params.category)
		}
	}
</script>
