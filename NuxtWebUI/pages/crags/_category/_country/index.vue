<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-8 large-8 news-column">
				<fieldset class="main-area-title">
					<legend ><h2>CRAGS - {{ $route.params.country }}</h2></legend>
				</fieldset>
				
				<paging></paging>
				<div class="grid-x text-center cragsnavi">
					<nuxt-link class="small-6 align-middle" :to="{ name: 'crags-category-country', params: { category: 'sportclimbing', country: $route.params.country } }">{{ $t('crags.routes-link') }}</nuxt-link>
					<nuxt-link class="small-6 align-middle"  :to="{ name: 'crags-category-country', params: { category: 'bouldering', country: $route.params.country } }">{{ $t('crags.boulders-link') }}</nuxt-link>
				</div>
				<crags-list :items="crags"></crags-list>
				<paging></paging>

			</div>
			<div class="cell small-12 medium-4 aside-b-column"> 
				<fieldset class="aside-b-title">
					<legend ><h2>TRENDING CRAGS</h2></legend>
				</fieldset>
				<crags-list-small :crags="trendingCrags" :hideNumbers="false"></crags-list-small>

				<fieldset class="aside-b-title">
					<legend ><h2>NEW CRAGS</h2></legend>
				</fieldset>
				<crags-list-small :crags="latestCrags" :hideNumbers="true"></crags-list-small>

			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import CragsList from "@/components/crags/CragsList"
	import CragsListSmall from "@/components/crags/CragsListSmall"
	import Paging from "@/components/common/Paging"
	
	export default{
		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			CragsList,
			CragsListSmall,
			Paging
		},

		// we're watching the page querystring parameter
		// to refresh if it changes
		watchQuery: ['page', 'sortfield'],
		
		data(){
			return {
				crags:[],
				latestCrags: [],
				trendingCrags:[]
			}
		},
		
		async asyncData (context) {
			var limit = 5;

			let [latest, trending, crags] = await Promise.all([

				context.$axios.$get('/crags/getlatest', {
					params: {
						'limit': limit,
						'country': context.route.params.country
					}
				}),

				context.$axios.$get('/crags/gettrending', {
					params: {
						'limit': limit,
						'country': context.route.params.country
					}
				}),

				context.$axios.$get('/crags/getall', {
					params: {
						'category': context.route.params.category,
						'country': context.route.params.country,
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || ''
					}
				})

			])

			return {
				crags:crags,
				latestCrags:latest,
				trendingCrags:trending
			};
		
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
		
		computed: {

			headerTitle() {
				return "crags - " + this.$route.params.country
			},
			breadcrumbs() {
				var route = this.$route
				// console.log(route)
				var category = route.params.category == "sportclimbing" ? "sport climbing" : "bouldering"
				var rootTitle = category + ' ' + this.$t('links.crags')

				return [
			        { title: rootTitle, route: 'crags-category', params: {  
							category: route.params.category }},
			        
			        { title: route.params.country },
		    	]
			}
		},

		validate ({ params, query }) {
			// params category must be sportclimbing or bouldering
			var valid = /^(sportclimbing|bouldering)$/.test(params.category)
			
			// query.page can be null or empty
			// query.page must be number and greater than -1
			if (valid && query.page && query.page.length > 0)
			{
				valid = !isNaN(query.page) && parseInt(query.page) > -1
			}

			return valid
		}
	}
</script>
