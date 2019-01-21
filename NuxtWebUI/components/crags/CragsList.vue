<template>
	<div>
		<table class="main-area-table result-table">
			<thead>
				<tr>
					<th>&nbsp;</th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(0) }" append>{{$t('crags.cragname')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(1) }" append>{{$t('crags.country')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(2) }" append>{{$t('crags.numberofascents')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(3) }" append>{{$t('crags.rating')}}</nuxt-link></th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(crag, index) in items" :key="crag.slug">
					<td><i class="webicon" :class="routeClass(crag)"></i></td>
					<td>
						<nuxt-link  :to="{ name: 'crags-category-country-crag', params: {  
							category: (crag.category === 0 || crag.category === 'sportclimbing') ? 'sportclimbing' : 'bouldering', 
							country: crag.countrySlug, 
							crag: crag.slug } }" append>
							{{ crag.name }}
						</nuxt-link>
					</td>
					<td>
						<nuxt-link  :to="{ name: 'crags-category-country', params: {  
							category: (crag.category === 0 || crag.category === 'sportclimbing') ? 'sportclimbing' : 'bouldering', 
							country: crag.countrySlug } }" append>
							{{ crag.countryName }}
						</nuxt-link>
					</td>
					<td>{{ crag.totalAscents }}</td>
					<td>{{ crag.averageRating | roundPercentage }}</td>
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
			}
		},
		data(){
			return {
				sortfields: ['name', 'country', 'totalascents', 'averagerating'],
				sortDescending: 1,
			}
		},
		methods:{
			routeClass: function (crag) {
			  return {
			    'vl-lead': crag.category === 0,
			    'vl-bouldering': crag.category === 1
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