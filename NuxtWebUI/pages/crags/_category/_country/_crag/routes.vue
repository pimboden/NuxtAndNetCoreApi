<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-12 large-12 news-column">
				<fieldset class="main-area-title">
					<legend ><h2>CRAGS ({{ $route.params.category }}) - {{ $route.params.country }} - {{ $route.params.crag }}</h2></legend>
				</fieldset>
				<crag-header :crag="crag"></crag-header>
				<crag-sub-navigation></crag-sub-navigation>

				ROUTES
				<zlaggable-grade-slider :grades="crag.grades" />

				<span>(zlags in area) {{ crag.totalZlaggables }} / (results) {{ totalResults }} {{ routeLegend }}</span>
				<div>
					SECTOR:
					<select v-model="selectedSector" @change="sectorChanged">
						<option value="">All Sectors</option>
						<option v-for="sector in sectors" v-bind:value="sector.slug">{{ sector.name }} ({{ sector.totalZlaggables }})</option>
					</select>	
				</div>
				<Paging></Paging><br>
				<zlaggables-list :items="zlaggables" :showCategory="false"></zlaggables-list>
				<Paging></Paging>
			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import CragHeader from "@/components/crags/CragHeader"
	import CragSubNavigation from "@/components/crags/CragSubNavigation"
	import ZlaggablesList from "@/components/crags/ZlaggablesList"
	import ZlaggableGradeSlider from "@/components/crags/ZlaggableGradeSlider"
	import Paging from "@/components/common/Paging"

	export default{

		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			CragHeader,
			CragSubNavigation,
			ZlaggablesList,
			Paging,
			ZlaggableGradeSlider
		},

		// we're watching the sector querystring parameter
		// to refresh if it changes
		watchQuery: ['sector', 'sortfield', 'page', 'grade'],

		data(){
			return {
				selectedSector: this.$route.query.sector || '',
				crag: null,
				sectors: [],
				zlaggables: [],
				totalResults: 0
			}
		},
		
		async asyncData (context) {
			let [crag, sectors, zlaggables] = await Promise.all([
				context.$axios.$get('/crags/get', {
					params:{
						"slug": context.route.params.crag,
						"country": context.route.params.country,
						'category': context.route.params.category
					}
				}),
				context.$axios.$get('/sectors/getallforcrag', {
					params:{
						"cragSlug": context.route.params.crag,
						"countrySlug": context.route.params.country,
						'category': context.route.params.category
					}
				}),
					context.$axios.$get('/routes/getallforcrag', {
					params:{
						"cragSlug": context.route.params.crag,
						"cragCountry": context.route.params.country,
						'category': context.route.params.category,
						'sectorSlug': context.route.query.sector || null,
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || '',
						'grade': context.route.query.grade || '',
						
					}
				})
			])

			return {
				crag:crag,
				sectors:sectors,
				zlaggables:zlaggables.items,
				totalResults: zlaggables.count
			}
		},
		filters: {
			roundPercentage(val) {
				var rounded = Math.round(val * 10 ) / 10
				var fixed = rounded.toFixed(1)
				return fixed
			}
		},
		computed: {
			routeLegend() {
				// add s (plural) to text if zero or more than one routes...
				var retval = "route"
				if (this.zlaggables.length != 1) {
					retval += "s"
				}
				return retval;
			},
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
			        
			        { title: "route list" }
		    	]
			}
		},
		methods: {
			sectorChanged() {
				let sectorSlug = this.selectedSector
				this.$router.push({ query: { ...this.$route.query, sector: sectorSlug, page: 0 }})
			}
		},
		head() {
			return {
				title: "Crags - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Crags @ 8a.nu' }
				]
			}
		},
		
		validate ({ params, query }) {
			// must be sportclimbing or bouldering
			var retval = /^(sportclimbing|bouldering)$/.test(params.category)

			// chec that grade is a number and has only 2 parameters
			if (query.grade) {
				try {
					var grade = query.grade
					if (grade && grade.length > 0) {
						var grades = grade.split(',')
						if (grades.length > 2) {
							throw "parameter 'grade' has too many items"
						}
						grades.forEach((g) => {
							if (isNaN(parseInt(g))) {
								throw "parameter " + g + " is not a number"
							}
						})
					}
				}
				catch(exception) {
					retval = false
				}
			}

			return retval
		}
	}
</script>
