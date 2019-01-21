<template>
	<div>
	<template v-for="(zlaggable, index) in items">
		<div class="grid-x">
		<div class="cell small-1 text-left">
			<category-type :category="zlaggable.category"></category-type>
		</div>
		<div class="cell auto text-left">
			<nuxt-link  :to="{ name: 'crags-category-country-crag-sectors-sector-routes-route', params: {  
				category: zlaggable.category == 0 ? 'sportclimbing' : 'bouldering', 
				country: zlaggable.countrySlug, 
				crag: zlaggable.cragSlug,
				sector: zlaggable.sectorSlug,
				route: zlaggable.slug } }">
				{{ zlaggable.name }}, {{ zlaggable.cragName }}<span v-if="zlaggable.areaName">, {{ zlaggable.areaName }}</span>, {{ zlaggable.countryName }}
			</nuxt-link>
		</div>
		<div class="cell auto text-center">
			{{ zlaggable.totalZlaggables }} routes/boulders
		</div>
		<div class="cell auto text-right">
			{{ zlaggable.totalAscents }} Ascents
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
			},
			showCategory: {
				type: Boolean,
				default: true
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