<template>
	<div>
		<table class="main-area-table result-table">
			<thead>
				<tr>
					<th v-if="showCategory">&nbsp;</th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(0) }" append>{{$t('crags.routes.grade')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(1) }" append>{{$t('crags.routes.name')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(2) }" append>{{$t('crags.routes.ascents')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(3) }" append>{{$t('crags.routes.ratio')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(4) }" append>{{$t('crags.routes.recommended')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(5) }" append>{{$t('crags.routes.stars')}}</nuxt-link></th>
					<th>&nbsp;</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(zlaggable, index) in items">
					<td v-if="showCategory"><i class="webicon" :class="routeClass(zlaggable)"></i></td>
					<td>{{ zlaggable.difficulty }}</td>
					<td>
						<nuxt-link  :to="{ name: 'crags-category-country-crag-sectors-sector-routes-route', params: {  
							category: zlaggable.category == 0 ? 'sportclimbing' : 'bouldering', 
							country: zlaggable.countrySlug, 
							crag: zlaggable.cragSlug,
							sector: zlaggable.sectorSlug,
							route: zlaggable.slug } }">
							{{ zlaggable.name }}
						</nuxt-link>
					</td>
					<td>{{ zlaggable.totalAscents }}</td>
					<td>{{ zlaggable.flashOnsightRate | roundPercentage }}</td>
					<td>{{ zlaggable.totalRecommendedRate | roundPercentage }}</td>
					<td>{{ zlaggable.averageRating | roundPercentage }}</td>
					<td><i class="webicon">ADD</i></td>
				</tr>
			</tbody>
		</table>
	</div>
</template>
<script>
	export default {
		props:{
			items:{
				type:Array,
				required:true
			},
			showCategory: {
				type: Boolean,
				default: true
			}
		},
		data(){
			return {
				sortfields: ['grade', 'name', 'totalascents', 'ratio', 'recommended', 'stars'],
				sortDescending: 1,
			}
		},
		methods:{
			routeClass: function (zlaggable) {
			  return {
			    'vl-lead': zlaggable.category === 0,
			    'vl-bouldering': zlaggable.category === 1
			  }
			},
			getSortField(sortFieldIndex) {
				var field = this.sortfields[sortFieldIndex]
				if (field == this.currentSortField) {
					field += this.sortDescending ? '' : '_desc'
				}
				return field
			},
			getLinkQuery(sortFieldIndex) {
				var sortField = this.getSortField(sortFieldIndex)
				var query = {
					...this.$route.query,
					page: 0,
					sortfield: sortField
				}
				return query
			}
		},
		computed: {
			currentSortField() {
				var retval = 'totalascents'
				if(this.$route.query.sortfield) {
					var sort = this.$route.query.sortfield
					this.sortDescending = sort.includes("_desc")
					if (this.sortDescending) {
						sort = sort.substr(0, sort.length - 5)
					}

					retval = sort
				}

				return retval
			}
		},
		filters: {
			roundPercentage(val) {
				var rounded = Math.round(val * 10 ) / 10
				var fixed = rounded.toFixed(1)
				return fixed
			}
		}
	}
</script>