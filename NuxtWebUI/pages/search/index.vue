<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-8 large-8">

				<div class="input-group">
				  <span class="input-group-label">@</span>
				  <input class="input-group-field" @keyup.enter="doSearch" type="text" v-model="query" placeholder="search areas, crags, routes...">
				  <div class="input-group-button">
				    <button type="button" @click="doSearch" class="button">SEARCH</button>
				  </div>
				</div>
				

				<div v-if="dataLoaded">
					<div v-for="result in searchResults" :key="result.category" v-if="result.count">
						<fieldset class="main-area-title">
							<legend ><h2>{{ $t('searchCategories.' + result.category) }}</h2></legend>
						</fieldset>
						
						<component :is="result.category" :items="result.items"/>

						<div v-if="result.count > 0" class="text-center">
							<nuxt-link class="button" :to="{ name: 'search-category', params: {  
								category: result.category },
								query: { query: query } }">
								SEE ALL {{ result.count }} {{ $t(`searchCategories.${result.category}`) }}
							</nuxt-link>
						</div>

					</div>
				</div>

			</div>
			<div class="cell small-12 medium-4 aside-b-column"> 
				<fieldset class="aside-b-title">
					<legend ><h2>CATEGORiES</h2></legend>
					<ul>
						<li v-for="result in searchResults" :key="result.category">

							<nuxt-link :to="{ name: 'search-category', params: {  
								category: result.category },
								query: { query: query } }">
								{{ $t(`searchCategories.${result.category}`) }} ({{ result.count }})
							</nuxt-link>
						</li>
					</ul>
				</fieldset>
			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {PageInfoMixin} from "@/assets/js/vueMixins.js"
	
	import AreasList from "@/components/crags/AreasList"
	import CragsList from "@/components/crags/CragsList"
	import ZlaggablesList from "@/components/crags/ZlaggablesList"
	
	export default{
		mixins:[PageInfoMixin],
		components: {
			'areas': AreasList,
			'crags': CragsList,
			'zlaggables': ZlaggablesList
		},

		// we're watching the page querystring parameter
		// to refresh if it changes
		watchQuery: ['query'],

		// Key for <nuxt-child> (transitions)
  		key: (to) => to.fullPath,

		data(){
			return {
				query: "",
				searchResults: [],
				dataLoaded: false
			}
		},
		
  		mounted(){
  			this.query = this.$route.query.query

  			if (this.query) {
  				this.executeSearch(this.query)
  			}
  		},

		methods:{
			doSearch() {
				this.$router.push({ query: { ...this.$route.query, query: this.query }})
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
		},
		
		head() {
			return {
				title: "Search - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Search @ 8a.nu' }
				]
			}
		}
	}
</script>
