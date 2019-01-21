<template>
	<div>
		<table class="main-area-table">
			<thead>
				<tr>
					<th>&nbsp;</th>
					<th>{{$t('forum.threads')}}</th>
					<th>{{$t('forum.comments')}}</th>
					<th>{{$t('forum.latestcomment')}}</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(categoryItem, index) in categoryItems" :key="categoryItem.categorySlug">

					<td class="title">
						<template v-if="isSubCategory" >
							<nuxt-link  :to="{ name: 'forum-slug-subcategorySlug', params: {slug:$route.params.slug, subcategorySlug: categoryItem.categorySlug, parentCategoryName:categoryItem.categoryName} }" append>
								{{ categoryItem.categoryName }}
							</nuxt-link>
						</template>
						<template v-else>
							<nuxt-link  :to="{ name: 'forum-slug', params: { slug: categoryItem.categorySlug, parentCategoryName:categoryItem.categoryName } }" append>
								{{categoryItem.categoryName }}
							</nuxt-link>
						</template>

					</td>
					<td>{{categoryItem.threadsCount}}</td>
					<td>{{categoryItem.commentsCount}}</td>
					<td>
						<div v-if="categoryItem.latesCommentDate">
							<template v-if="isSubCategory">
								<nuxt-link  :to="{ name: 'forum-slug-subcategorySlug-threadSlug', params: {slug:$route.params.slug, subcategorySlug: categoryItem.categorySlug,  threadSlug: categoryItem.latesCommentThreadSlug} }" append>
									{{getDate(categoryItem.latesCommentDate)}} {{getTime(categoryItem.latesCommentDate)}}
								</nuxt-link>
							</template>
							<template v-else>
								<nuxt-link  :to="{ name: 'forum-slug-threadSlug', params: {slug:categoryItem.categorySlug, threadSlug: categoryItem.latesCommentThreadSlug} }" append>
									{{getDate(categoryItem.latesCommentDate)}} {{getTime(categoryItem.latesCommentDate)}}
								</nuxt-link>
							</template>
							<br/>
							<span class="smaller">{{$t('forum.latestcommentby')}} {{categoryItem.latesCommentUserFullName}}</span>
						</div>
					</td>
				</tr>
			</tbody>
		</table>
	</div>
</template>
<script>
	import * as moment from 'moment';
	import { mapActions, mapGetters } from 'vuex';
	export default {
		props:{
			categoryItems:{
				type:Array,
				required:true
			},
			isSubCategory:{
				type:Boolean,
				required:false
			}
		},
		data(){
			return{
				prop:""
			}
		},
		computed: {...mapGetters({
			locale: "locale",
		})},
		created(){
			moment.locale(this.locale);
		},
		mounted(){

		},
		methods:{
			getDate(dateTime){
				return moment(dateTime).format('L');
			},
			getTime(dateTime){
				return moment(dateTime).format('LT');
			}
		}
	}

</script>