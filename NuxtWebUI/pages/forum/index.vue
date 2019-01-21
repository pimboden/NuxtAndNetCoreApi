<template>
	<div class="grid-container full main-area" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 medium-8 large-8 news-column">
				<fieldset class="main-area-title">
					<legend ><h2>Forum Categories</h2></legend>
				</fieldset>
				<forum-categories v-if="categories.length > 0" :category-items="categories" :isSubCategory="false" ></forum-categories>

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
<script>
	import { mapActions, mapGetters } from 'vuex';
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import ForumCategories from "@/components/forum/ForumCategories"
	export default{
		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			ForumCategories
		},

		data(){
			return {
				categories:[],
				latestComments:[]
			}
		},
		
		async asyncData (context) {
			let [cats, comments] = await Promise.all([
				context.$axios.$get('/forum/getallrootcategoriesasync'),
				context.$axios.$get('/forum/getlatestcommentsasync'),
				])
			
			return {categories:cats,
				latestComments:comments
			};

		},
		methods:{
			
		},
		head() {
			return {
				title: "Forum - 8a.nu",
				meta: [
				{ hid: 'description', name: 'description', content: 'Forum main categories @ 8a.nu' }
				]
			}
		},
	}
</script>
