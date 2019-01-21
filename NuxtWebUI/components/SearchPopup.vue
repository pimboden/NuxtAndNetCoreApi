<template>
	<div class="searchPopup">
		<div class="input-group">
		  <input class="input-group-field" @input="typing = true" @keyup.enter="doSearch" type="text" v-model="query" placeholder="search areas, crags, routes...">
		  <div class="input-group-button">
		    <button type="button" @click="doSearch" class="button">SEARCH</button>
		  </div>
		</div>
		<div v-for="result in searchResults" :key="result.category" v-if="result.count">
			<div v-if="result.count > 0" class="text-center">

				<div>
					<h4 class="text-left">{{ $t('searchCategories.' + result.category) }}</h4>
				</div>

				<component :is="result.category" :items="result.items"/>

			</div>
		</div>
		<button type="button" class="button expanded" href="#" @click="goToSearchPage">Show all {{ totalResults }} results for <strong>'{{ query }}'</strong></button>
	</div>
</template>

<script >

	import AreasList from "@/components/search/AreasList"
	import CragsList from "@/components/search/CragsList"
	import ZlaggablesList from "@/components/search/ZlaggablesList"
	import _ from 'lodash'

	export default{
		components: {
			'areas': AreasList,
			'crags': CragsList,
			'zlaggables': ZlaggablesList
		},
		data(){
			return{
				query: "",
				searchResults: [],
				dataLoaded: false,
				typing: false
			}
		},
		computed: {
			totalResults() {
				var total = 0
				
				if (this.searchResults)
				{
					// get sum of result counts prop across all objects in array
					var total = this.searchResults.reduce(function(prev, cur) {
					  return prev + cur.count
					}, 0);
				}

				return total
			}
		},
		watch: {
			
			 query: _.debounce(function () {
		     		this.typing = false		     	
		     		this.doSearch()
		     	}, 1000)
		     
		},
		methods: {
			goToSearchPage() {
				let newRoute = {
					name: 'search',
					query: {
						query: this.query
					}					
				}
				this.$router.push(newRoute)
			},
			doSearch() {
				this.executeSearch(this.query)
			},

			executeSearch(s) {
				if (!process.server) {
					return this.$axios.$get('/search',{
						params:{
							"query":s
						}
					})
					.then((data)=>{
						this.searchResults = data
						this.dataLoaded = true
					}).
					catch((error)=>{
						console.log("error getting data from '/search " + error)
					});
				}
			}
		}
	}
</script>