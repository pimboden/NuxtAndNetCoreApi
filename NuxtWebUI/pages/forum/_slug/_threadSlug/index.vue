<template>
	<div>
<!-- 		{{$route.params.slug}}<br/>
	{{$route.params.threadSlug}}<br/> -->
		<forum-thread :thread-info="thread" :thread-comments="comments" v-if="dataLoaded"></forum-thread>
	</div>
</template>
<script>
	import ForumThread from "@/components/forum/ForumThread"
	
	export default {
		components: {
			ForumThread
		},
		data(){
			return{
				slug:this.$route.params.slug,
				threadSlug:this.$route.params.threadSlug,
				thread:null,
				comments:[],
				dataLoaded:false
			}
		},
		created(){
			if (!process.server) {
				return this.$axios.$get('/forum/getcategorythread',{
					params:{
						"categorySlug":this.slug,
						"threadSlug":this.threadSlug,
					}
				})
				.then((data)=>{
					this.thread={...data.threadInfo};
					this.comments=[...data.threadComments];
					this.dataLoaded =true;
				}).
				catch((error)=>{
					console.log("error getting data from '/forum/getcategorythread " + error)
				});
			}
		},
		mounted(){
			
		},
		methods:{

		}
	}

</script>