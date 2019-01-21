<template>
	<div class="thread-detail">
		<div class="thread-info grid-x">
			<div class="thread-user  cell small-12 medium-2">
				{{threadInfo.userFullName}}
			</div>
			<div class="thread-data cell small-12 medium-10">
				<div class="grid-x">
					<div class="thread-date  cell small-12">

						{{getDateString(threadInfo.created)}}
					</div>
					<div class="thread-title cell small-12">
						{{threadInfo.title}}
					</div>
				</div>
			</div>
		</div>

		<div class="thread-comments  cell small-12">
			<div class="grid-x" lass="thread-comment" v-for="(threadComment , index) in threadComments">
				<div class="thread-user  cell small-12 medium-2">
					{{threadComment.userFullName}}
				</div>
				<div class="thread-data cell small-12 medium-10">
					<div class="grid-x">
						<div class="thread-date  cell small-12">

							{{getDateString(threadComment.created)}}
						</div>
						<div class="thread-title cell small-12">
							{{threadComment.content}}
						</div>
					</div>
				</div>
			</div>			
		</div>

	</div>
</template>
<script>
	import {IsoToLocaleDate} from "@/assets/js/vueMixins.js";
	export default {
		mixins:[ IsoToLocaleDate],
		props:{
			threadInfo:{
				type:Object,
				required:true
			},
			threadComments:{
				type:Array,
				required:true
			}
		},
		data(){
			return {}
		},
		created(){

		},
		mounted(){

		},
		methods:{
		}
	}

</script>

<style scoped>
.thread-comments{
	margin-top: 30px;
	margin-left: 20px;  
}
</style>