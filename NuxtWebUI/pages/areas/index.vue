<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-8 large-8 news-column">
				<fieldset class="main-area-title">
					<legend ><h2>AREAS</h2></legend>
				</fieldset>

				<paging></paging><br>

				<areas-list :items="areas"></areas-list>

				<paging></paging><br>

			</div>
			<div class="cell small-12 medium-4 aside-b-column"> 
				<fieldset class="aside-b-title">
					<legend ><h2>TRENDING AREAS</h2></legend>
				</fieldset>
				<areas-list-small :areas="trendingAreas" :hideNumbers="false"></areas-list-small>

				<fieldset class="aside-b-title">
					<legend ><h2>NEW AREAS</h2></legend>
				</fieldset>
				<areas-list-small :areas="latestAreas" :hideNumbers="true"></areas-list-small>
			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import AreasList from "@/components/crags/AreasList"
	import AreasListSmall from "@/components/crags/AreasListSmall"
	import Paging from "@/components/common/Paging"
	export default{
		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			AreasList,
			AreasListSmall,
			Paging
		},

		// we're watching the page querystring parameter
		// to refresh if it changes
		watchQuery: ['page', 'sortfield'],

		data(){
			return {
				areas:[],
				latestAreas: [],
				trendingAreas:[]
			}
		},
		
		async asyncData (context) {
			let [latest, trending, areas] = await Promise.all([
				context.$axios.$get('/areas/getlatest', {
					params: {
						'limit': 5
					}
				}),

				context.$axios.$get('/areas/gettrending', {
					params: {
						'limit': 5
					}
				}),

				context.$axios.$get('/areas/getall',{
					params:{
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || ''
					}
				})
				
			])

			return {
				areas:areas,
				latestAreas:latest,
				trendingAreas:trending
			};
			
			
		},
  		mounted(){
  		},
		methods:{
		},
		computed: {
			headerTitle() {
				return "areas"
			},
			breadcrumbs() {
				return []
			}
		},
		head() {
			return {
				title: "Areas - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Areas @ 8a.nu' }
				]
			}
		},
	

		validate ({ params, query }) {
			var valid = true
			
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
