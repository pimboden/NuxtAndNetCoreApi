<template>
	<div>
		<template v-for="(area, index) in items">
			<div class="grid-x">
				<div class="cell small-1 text-left">
					
				</div>
				<div class="cell auto text-left">
					<nuxt-link  :to="{ name: 'areas-country-area', params: {  
						country: area.countrySlug, 
						area: area.slug } }" append>
						{{ area.name }}, {{ area.countryName }}
					</nuxt-link>
				</div>
				<div class="cell auto text-center">
					{{ area.totalZlaggables }} routes/boulders
				</div>
				<div class="cell auto text-right">
					{{ area.totalAscents }} Ascents!!!!!!!!
				</div>
			</div>
		</template>
	</div>
</template>
<script>
	export default {
		props:{
			items:{
				type:Array,
				required:true
			}
		},

		filters: {
			roundPercentage(val) {
				var rounded = Math.round(val * 10 ) / 10
				var fixed = rounded.toFixed(1)
				return fixed
			}
		}
	}
</script>