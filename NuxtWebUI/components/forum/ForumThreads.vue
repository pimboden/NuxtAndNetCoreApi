<template>
	<div>
		<table class="main-area-table">
			<thead>
				<tr>
					<th>&nbsp;</th>
					<th>{{$t('forum.comments')}}</th>
					<th>{{$t('forum.latestcomment')}}</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="(threadItem, index) in threadItems" :key="threadItem.categorySlug">

					<td class="title">
						<template v-if="isSubCategory" >
							<nuxt-link :to="{ name: 'forum-slug-subcategorySlug-threadSlug',params: {slug:$route.params.slug, subcategorySlug:$route.params.subcategorySlug, threadSlug: threadItem.threadSlug} }" append>{{ threadItem.threadTitle }}
							</nuxt-link>
						</template>
						<template v-else>
							<nuxt-link :to="{ name: 'forum-slug-threadSlug', params: {slug:$route.params.slug, threadSlug: threadItem.threadSlug} }" append>
								{{ threadItem.threadTitle }}
							</nuxt-link>
						</template>

					</td>
					<td>{{threadItem.commentsCount}}</td>
					<td>
						<div v-if="threadItem.latesCommentDate">
							<template v-if="isSubCategory">
								<nuxt-link  :to="{ name: 'forum-slug-subcategorySlug-threadSlug', params: {slug:$route.params.slug, subcategorySlug:$route.params.subcategorySlug, threadSlug: threadItem.threadSlug} }" append>
									{{getDate(threadItem.latesCommentDate)}} {{getTime(threadItem.latesCommentDate)}}
								</nuxt-link>
							</template>
							<template v-else>
								<nuxt-link  :to="{ name: 'forum-slug-threadSlug', params: {slug:$route.params.slug, threadSlug: threadItem.threadSlug} }" append>
									{{getDate(threadItem.latesCommentDate)}} {{getTime(threadItem.latesCommentDate)}}
								</nuxt-link>
							</template>
							<br/>
							<span class="smaller">{{$t('forum.latestcommentby')}} {{threadItem.latesCommentUserFullName}}</span>
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
			threadItems:{
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