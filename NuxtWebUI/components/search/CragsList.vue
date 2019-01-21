<template>

	<div>
		<template v-for="(crag, index) in items">
			<div class="grid-x">
			<div class="cell small-1 text-left">
				<category-type :category="crag.category"></category-type>
			</div>
			<div class="cell auto text-left">
				<nuxt-link  :to="{ name: 'crags-category-country-crag', params: {  
					category: (crag.category === 0 || crag.category === 'sportclimbing') ? 'sportclimbing' : 'bouldering', 
					country: crag.countrySlug, 
					crag: crag.slug } }" append>
					{{ crag.name }}<span v-if="crag.areaName">, {{ crag.areaName }}</span>, {{ crag.countryName }}
				</nuxt-link>
			</div>
			<div class="cell auto text-center">
				{{ crag.totalZlaggables }} routes/boulders
			</div>
			<div class="cell auto text-right">
				{{ crag.totalAscents }} Ascents
			</div>
			</div>
		</template>
	</div>
</template>
<script>

	import CategoryType from "@/components/common/CategoryType"

	export default {
		components: {
			CategoryType
		},
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