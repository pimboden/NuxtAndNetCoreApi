<template>
	<div>
		<table class="main-area-table result-table">
			<thead>
				<tr>
					<th></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(0) }" append>{{$t('crags.routes.route.tablehead.username')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(1) }" append>{{$t('crags.routes.route.tablehead.date')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(2) }" append>{{$t('crags.routes.route.tablehead.style')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(3) }" append>{{$t('crags.routes.route.tablehead.notes')}}</nuxt-link></th>
					<th><nuxt-link 
						:to="{ path: '', query: getLinkQuery(4) }" append>{{$t('crags.routes.route.tablehead.rating')}}</nuxt-link></th>
					<th>&nbsp;</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(ascent, index) in items">
					<td>IMG</td>
					<td>
						<nuxt-link  :to="{ name: 'user-slug', params: {  
							slug: ascent.user.slug 
							} }">
							{{ ascent.user.firstName }} {{ ascent.user.lastName }} 
						</nuxt-link>
					</td>
					<td>{{ getDateString(ascent.date) }}</td>
					<td><ascent-type :type="ascent.type"></ascent-type></td>
					<td>{{ ascent.comment }}</td>
					<td>{{ ascent.rating | ratingToStars }}</td>
				</tr>
			</tbody>
		</table>
	</div>
</template>
<script>
	import {IsoToLocaleDate} from "@/assets/js/vueMixins.js"
	import AscentType from "@/components/common/AscentType"

	export default {
		mixins:[IsoToLocaleDate],
		props:{
			items:{
				type:Array,
				required:true
			}
		},
		data(){
			return {
				sortfields: ['username', 'date', 'style', 'notes', 'rating'],
				sortDescending: 1,
			}
		},
		components: {
			AscentType
		},
		computed: {
			currentSortField() {
				var retval = 'date'
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
		methods:{
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
		filters: {
			ratingToStars(val) {
				var char = "* "
				return Array(val + 1).join(char);
			}
		}
	}
</script>