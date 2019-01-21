<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-12 large-12 news-column">
				<fieldset class="main-area-title">
					<legend ><h2>CRAGS ({{ $route.params.category }}) - {{ $route.params.country }} - {{ $route.params.crag }}</h2></legend>
				</fieldset>
				<crag-header :crag="crag"></crag-header>
				<crag-sub-navigation></crag-sub-navigation>

				RANKING


			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import CragHeader from "@/components/crags/CragHeader"
	import CragSubNavigation from "@/components/crags/CragSubNavigation"

	export default{

		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			CragHeader,
			CragSubNavigation
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
				var category = route.params.category == "sportclimbing" ? "sport climbing" : "bouldering"
				var rootTitle = category + ' ' + this.$t('links.crags')

				return [
			        { title: rootTitle, route: 'crags-category', params: {  
							category: route.params.category }},
			        
			        { title: this.crag.countryName, route: 'crags-category-country', params: {  
							category: route.params.category, 
							country: route.params.country }},
			        
			        { title: this.crag.name, route: 'crags-category-country-crag', params: {  
							category: route.params.category, 
							country: route.params.country, 
							crag: route.params.crag }},
			        
			        { title: "ranking" }
		    	]
			}
		},

		async asyncData (context) {
			return context.$axios.$get('/crags/get',{
					params:{
						"slug": context.route.params.crag,
						"country": context.route.params.country,
						'category': context.route.params.category,
					}
				})
		      .then((data)=>{
		        return { crag: data }
		      }).
		      catch((error)=>{
		        console.log("error getting data from '/crags/get' " + error)
		      })
		},
		methods:{
			
		},
		head() {
			return {
				title: "Crags - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Crags @ 8a.nu' }
				]
			}
		},
		
		validate ({ params }) {
			// must be sportclimbing or bouldering
			return /^(sportclimbing|bouldering)$/.test(params.category)
		}
	}
</script>
