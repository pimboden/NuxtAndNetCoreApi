<template>
	<div class="cragHeader bg-light">
		<div class="grid-x">
			<div class="cell small-2">
				<img src="/gallery/gallery1.jpg" title="imagetitle" />
			</div>
			<div class="cell small-4">
				Crag:
				{{ crag.name }}<br>
				<span v-if="crag.area">{{ crag.area.name }}, </span>{{ crag.countryName }}<br>
			</div>
			<div class="cell small-6">
				<div class="grid-x grid-full-height">
					
					<div class="cell small-12">
						<div class="grid-x statistics text-center">
								<div class="cell small-3">
									<span class="val">{{ crag.totalAscents }}</span><span class="desc">ASCENTS</span>
								</div>
								<div class="cell small-3">
									<span class="val">{{ crag.averageRating | roundPercentage }}</span><span class="desc">RATING</span>
								</div>
								<div class="cell small-3">
									<span class="val">{{ crag.onsightRate | roundPercentage }}</span><span class="desc">OS RATE</span>
								</div>
								<div class="cell small-3">
									<span class="val">{{ crag.totalZlaggables }}</span><span class="desc">ROUTES IN DB</span>
								</div>
						</div>
					</div>

					<div class="cell small-12 align-self-bottom text-right">
						<a href="#" class="button">FOLLOW</a>
					</div>
				</div>
			</div>
		</div>
		
		
		
	</div>
</template>
<script>
	import { mapActions, mapGetters } from 'vuex';
	export default {
		props: {
			crag:{
				type:Object,
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
<style lang="scss" media="screen">
	.cragHeader {
		img {
			border-radius: 50%;
			width: 100px;
			height: 100px;
		}
		.statistics {
			div {
				span {
					font-size: 0.8em;

					&.val {
						font-weight: bold;
						font-size: 1.1em;
					}

					&.desc {
						display: block;
						font-size: 0.7em;
					}
				}
			}
		}
	}
	
</style>