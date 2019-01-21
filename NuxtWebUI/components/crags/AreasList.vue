<template>
	<div>
		<table class="main-area-table result-table">
			<thead>
				<tr>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(0) }" append>{{$t('areas.areaname')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(1) }" append>{{$t('areas.country')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(2) }" append>{{$t('areas.numberofascents')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(3) }" append>{{$t('areas.rating')}}</nuxt-link></th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(area, index) in items" :key="area.id">
					<td>
						<nuxt-link  :to="{ name: 'areas-country-area', params: {  
							country: area.countrySlug, 
							area: area.slug } }" append>
							{{ area.name }}
						</nuxt-link>
					</td>
					<td>
						<nuxt-link  :to="{ name: 'areas-country', params: {  
							country: area.countrySlug } }" append>
							{{ area.countryName }}
						</nuxt-link>
					</td>
					<td>{{ area.totalAscents }}</td>
					<td>{{ area.averageRating | roundPercentage }}</td>
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

		filters: {
			roundPercentage(val) {
				var rounded = Math.round(val * 10 ) / 10
				var fixed = rounded.toFixed(1)
				return fixed
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

		methods: {
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

		  
	}
</script>