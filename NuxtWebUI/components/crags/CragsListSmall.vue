<template>
	<ol class="craglist-small" :class="{'no-numbers': hideNumbers}">
		<li v-for="(crag, index) in crags" :key="crag.slug">
			<div class="grid-x">
				<div class="small-10">
					<nuxt-link  :to="{ name: 'crags-category-country-crag', params: {  
						category: crag.category === 0 ? 'sportclimbing' : 'bouldering', 
						country: crag.countrySlug, 
						crag: crag.slug } }">
						{{ crag.name }}
					</nuxt-link>, 
					<span v-if="crag.town">{{ crag.town }},</span>
					<nuxt-link  :to="{ name: 'crags-category-country', params: {  
						category: crag.category === 0 ? 'sportclimbing' : 'bouldering',
						country: crag.countrySlug } }">
						{{ crag.countryName }}
					</nuxt-link>
				</div>
				<div class="small-2 text-right">
					<i class="webicon" :class="routeClass(crag)"></i>
				</div>
			</div>
		</li>
	</ol>
</template>
<script>
	export default {
		props:{
			crags:{
				type:Array,
				required:true
			},
			hideNumbers:{
				type: Boolean,
				required: false,
				default: false
			}
		},
		methods:{
			routeClass: function (crag) {
			  return {
			    'vl-lead': crag.category === 0,
			    'vl-bouldering': crag.category === 1
			  }
			}
		}
	}
</script>
<style lang="scss" media="screen">
	.craglist-small {
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