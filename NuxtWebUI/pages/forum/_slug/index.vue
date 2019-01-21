<template>


	<div class="grid-container full">
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-8 large-8 news-column">
				<nuxt-link class="nav-link" :to="$i18n.path('forum')" exact>
					{{ $t('links.forum-top') }}
				</nuxt-link>
				<template v-if="subcategories.length > 0">
					<fieldset class="main-area-title">
						<legend ><h2>{{$route.params.parentCategoryName}} subcategories</h2></legend>
					</fieldset>
					<forum-categories :category-items="subcategories" :isSubCategory="true" ></forum-categories>
					
				</template>
				<template v-if="threads.length > 0">
					<fieldset class="main-area-title">
						<legend ><h2>{{$route.params.parentCategoryName}} Threads</h2></legend>
					</fieldset>
					<forum-threads :thread-items="threads"  :isSubCategory="false" ></forum-threads>					
				</template>
			</div>
			<div class="cell small-12 medium-4 aside-b-column"> 
				<fieldset class="aside-b-title">
					<legend ><h2>Latest comments</h2></legend>
				</fieldset>
			</div>
		</div>
	</div>
</template>
<script >
	import { mapActions, mapGetters } from 'vuex';
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import ForumCategories from "@/components/forum/ForumCategories"
	import ForumThreads from "@/components/forum/ForumThreads"
	export default {	
		mixins:[StringTruncateMixin, PageInfoMixin],	
		components: {
			ForumCategories,
			ForumThreads
		},
		data(){
			return{
				subcategories:[],
				threads:[]
			}
		},
		created(){
			if (!process.server) {
				this.loadSubCategories().then(()=>{
					this.loadThreads();
				})
			}
		},
		methods:{
			
			loadSubCategories(){
				return this.$axios.$get('/forum/getsubcategorybyslugasync',{
					params:{
						"slug":this.$route.params.slug}
					})
				.then((data)=>{
					this.subcategories=data;
				}).
				catch((error)=>{
					console.log("error getting data from '/forum/getsubcategorybyslugasync " + error)
				})
			},
			loadThreads(){
				return this.$axios.$get('/forum/getforumthreadsbycategoryslugasync',{
					params:{
						"slug":this.$route.params.slug}
					})
				.then((data)=>{
					this.threads=data;
				}).
				catch((error)=>{
					console.log("error getting data from '/forum/getforumthreadsbycategoryslugasync " + error)
				})
			}
		},

		head() {
			return {
				title: "Forum - " + this.$route.params.slug,
				meta: [
				{ hid: 'description', name: 'description', content: 'Forum main categories @ 8a.nu' }
				]
			}
		}
	}

</script>