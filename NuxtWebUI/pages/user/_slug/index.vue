<template>
	<div class="grid-container full main-area user-page" >
		<div class="grid-x grid-margin-x">
			<div class="cell small-12 user-column">
				<profile-head :profile-data="profile"></profile-head>
			</div>
		</div>
		<div>{{profile}}</div>
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex';
	import {StringTruncateMixin, PageInfoMixin} from "@/assets/js/vueMixins.js"
	import ProfileHead from "@/components/profile/ProfileHead"
	export default{
		mixins:[StringTruncateMixin, PageInfoMixin],
		components: {
			ProfileHead
		},

		data(){
			return {
				profile:{}
			}
		},
		
		async asyncData (context) {
			debugger;
			let userSlug = context.route.params.slug;
			let [userProfileData] = await Promise.all([
				context.$axios.$get('/users/getbasicuserprofileasync',{
					params:{
						"slug":userSlug
					}
				})
				]);
			
			return {
				profile:userProfileData
			};

		},
		methods:{
			
		},
		head() {
			return {
				title: "Your profile",
				meta: [
				{ hid: 'description', name: 'description', content: 'User Profile' }
				]
			}
		}
	}
</script>
