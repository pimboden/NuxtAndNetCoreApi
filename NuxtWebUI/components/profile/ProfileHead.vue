<template>
	<div class="profile-head">
		<div class="grid-x profile-data">
			<div class="cell small-6 medium-2 profile-column-1"><img :src="profileData.avatar"></div>
			<div class="cell small-6  profile-column-2">
				<div class="username"><h2>{{profileData.firstname}} {{profileData.lastname}} </h2></div>
				<div class="location" v-if="profileData.geoData">
					<a :href="'https://www.google.com/maps/?q='+profileData.geoData.latitude+','+profileData.geoData.longitude">
						<i class="fa fa-map-marker" aria-hidden="true"></i><span>{{profileData.geoData.name}}</span>
					</a>
				</div>
				<div class="age">{{profileData.age}} </div>
				<div class="social-media" v-for="(socialmediaInfo, index) in profileData.socialMediaInfos">
					<div class="instagram">
						<i class="fa fa-instagram" aria-hidden="true"></i>
					</div>
					<div class="facebook">
						<i class="fa fa-facebook-official" aria-hidden="true"></i>
					</div>
				</div>
			</div>
			<div class="cell small-6 medium-2  profile-column-3">
				<div class="number">459</div>
				<div class="text">Followers</div>
				<div class="button"><a>Follow</a></div>
			</div>
			<div class="cell small-6 medium-2  profile-column-4">
				<div class="number">65</div>
				<div class="text">Following</div>
				<div class="button"><a>Message</a></div
				</div>
			</div>
		</div>
		<div class="grid-x profile-navigation">
			<div class="cell small-6 medium-2">
				<a>Routes</a>
			</div>
			<div class="cell small-6 medium-2">
				<a>Boulders</a>
			</div>
			<div class="cell small-6 medium-2">
				<a>Competition</a>
			</div>
			<div class="cell small-6 medium-2">
				<a>Gallery</a>
			</div>
			<div class="cell small-6 medium-2">
				<a class="active">About</a>
			</div>
			<div class="cell small-6 medium-2">
				<a class="settings"><i class="fa fa-cog" aria-hidden="true"></i></a>
			</div>
		</div>
	</div>
</template>
<script>
	export default {
		props:{
			profileData:{type: Object , required:true},
		},
		data(){
			return{
				user:""
			}
		},
		created(){

		},
		mounted(){

		},
		methods:{
		}
	}

</script>