<template>
	<div class="grid-container full">
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-8 large-8 news-column">
				<nuxt-link class="nav-link" :to="$i18n.path('forum')" exact>
					{{ $t('links.forum-top') }}
				</nuxt-link>
				
				<template v-if="threads.length > 0">
					<fieldset class="main-area-title">
						<legend ><h2>{{$route.params.parentCategoryName}} Threads</h2></legend>
					</fieldset>
					<forum-threads :thread-items="threads"  :isSubCategory="true" ></forum-threads>
				</template>
			</div>
			<div class="cell small-12 medium-4 aside-b-column"> 
				<fieldset class="aside-b-title">
					<legend ><h2>Latest comments</h2></legend>
				</fieldset>
				<div class="grid-x">
					<ul>
						<li v-for="comment in latestComments"  :key="comment.id">
							{{ truncateText(comment.content,25) }}
						</li>
					</ul>
				</div>
			</div>
		</div>
	</div>	
</template>
<script >
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import { mapActions, mapGetters } from 'vuex';
	import ForumThreads from "@/components/forum/ForumThreads"
	export default {		
		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			ForumThreads
		},
		data(){
			return{
				threads:[],
				latestComments:[]
			}
		},

		created(){
			if (!process.server) {
				this.loadThreads();
				this.loadLatestComments();
			}
		},

		methods:{
			loadThreads(){
				return this.$axios.$get('/forum/getforumthreadsbycategoryslugasync',{
					params:{
						"slug":this.$route.params.subcategorySlug}
					})
				.then((data)=>{
					this.threads=data;
				}).
				catch((error)=>{
					console.log("error getting data from '/forum/getforumthreadsbycategoryslugasync " + error)
				})
			},
			loadLatestComments(){
				return this.$axios.$get('/forum/getlatestcommentsbycategoryslugasync',{
					params:{
						"categorySlug":this.$route.params.subcategorySlug}
					})
				.then((data)=>{
					this.latestComments=data;
				}).
				catch((error)=>{
					console.log("error getting data from '/forum/getlatestcommentsbycategoryslugasync " + error)
				})
			}
		},

		head() {
			return {
				title: "Forum - " + this.$route.params.subcategorySlug,
				meta: [
				{ hid: 'description', name: 'description', content: 'Forum main categories @ 8a.nu' }
				]
			}
		}
	}

</script>