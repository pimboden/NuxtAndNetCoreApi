<template>
	
	<div>
		<h2>ROUTES</h2>
		<zlaggable-grade-slider :grades="area.grades" />
		<span>(zlags in area) {{ area.totalZlaggables }} / (results) {{ totalResults }}</span>
		<paging></paging>
		<zlaggables-list :items="zlaggables" :showCategory="true"></zlaggables-list>
		<paging></paging>
	</div>

</template>


<script>
	import ZlaggablesList from "@/components/crags/ZlaggablesList"
	import ZlaggableGradeSlider from "@/components/crags/ZlaggableGradeSlider"
	import Paging from "@/components/common/Paging"
	import {PageInfoMixin} from "@/assets/js/vueMixins.js"

	export default{
		mixins:[PageInfoMixin],
		props: ['area'],

		watchQuery: ['sortfield', 'page', 'grade'],

		components: {
			ZlaggablesList,
			ZlaggableGradeSlider,
			Paging
		},

		data(){
			return {
				zlaggables: null,
				totalResults: 0
			}
		},
		
		async asyncData (context) {
		    return context.$axios.$get('/routes/getallforarea', {
					params:{
						"areaSlug": context.route.params.area,
						"countrySlug": context.route.params.country,
						'pageIndex': context.route.query.page || 0,
						'sortfield': context.route.query.sortfield || '',
						'grade': context.route.query.grade || '',
					}
				})
		      .then((data)=>{
		        return { 
		        	zlaggables: data.items,
					totalResults: data.count
		        }
		      }).
		      catch((error)=>{
		        console.log("error getting data from '/routes/getallforarea' " + error)
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
			        { title: 'route list' }
		    	]
			}
		},

		head() {
			return {
				title: "area routes - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Areas @ 8a.nu' }
				]
			}
		},

		validate ({ query }) {
			var retval = true

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