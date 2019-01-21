<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-12 large-12 news-column">
				<area-header :area="area"></area-header>
				<area-sub-navigation></area-sub-navigation>
				<area-sub-sub-navigation v-if="showSubSubNavi"></area-sub-sub-navigation>
				<nuxt-child :area="area" />

			</div>
		</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex'
	import {StringTruncateMixin} from "@/assets/js/vueMixins.js"
	import AreaHeader from "@/components/crags/AreaHeader"
	import AreaSubNavigation from "@/components/crags/AreaSubNavigation"
	import AreaSubSubNavigation from "@/components/crags/AreaSubSubNavigation"

	export default{

		mixins:[StringTruncateMixin],
		components: {
			AreaHeader,
			AreaSubNavigation,
			AreaSubSubNavigation
		},

		data(){
			return {
				area: null
			}
		},
		
		async asyncData (context) {
		    return context.$axios.$get('/areas/get', {
					params:{
						"slug": context.route.params.area,
						"country": context.route.params.country
					}
				})
		      .then((data)=>{
		        return { area: data }
		      }).
		      catch((error)=>{
		        console.log("error getting data from '/routes/get' " + error)
		      })	
		},		
		validate ({ params }) {
			return true
		},
		computed: {
			showSubSubNavi() {
				return ['areas-country-area-routes', 'areas-country-area-crags', 'areas-country-area-map'].includes(this.$route.name)
			}
		}
	}
</script>
