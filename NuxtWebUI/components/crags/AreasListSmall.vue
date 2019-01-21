<template>
	<ol class="arealist-small" :class="{'no-numbers': hideNumbers}">
		<li v-for="(area, index) in areas" :key="area.id">
			<div class="grid-x">
				<div class="small-10">
					<nuxt-link  :to="{ name: 'areas-country-area', params: {  
						country: area.countrySlug, 
						area: area.slug } }">
						{{ area.name }}
					</nuxt-link>, 
					<nuxt-link  :to="{ name: 'areas-country', params: {  
						country: area.countrySlug } }">
						{{ area.countryName }}
					</nuxt-link>
				</div>
			</div>
		</li>
	</ol>
</template>
<script>
	export default {
		props:{
			areas:{
				type:Array,
				required:true
			},
			hideNumbers:{
				type: Boolean,
				required: false,
				default: false
			}
		},
	}
</script>
<style lang="scss" media="screen">
	.areaslist-small {
		li {
			height: 50px;
		    // font-size: 1.5em;

		    // a, span {
		    // 	font-size: 0.65em;	
		    // }
		}

		&.no-numbers {
			list-style-type: none;
		}
	}
</style>