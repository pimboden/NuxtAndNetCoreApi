<template>
	<i class="webicon" :class="[type]" :title="title">
		<svg id="typesvg" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 36 36">
			<defs></defs>
			<title>style_of_climbing</title>
			<path class="path" d="M18,33A15,15,0,1,1,33,18,15,15,0,0,1,18,33ZM18,6A12,12,0,1,0,30,18,12,12,0,0,0,18,6Z"/><circle class="circle" cx="18" cy="18" r="7.24"/></svg>
	</i>
</template>
<script>
	export default {
		props:{
			type:{
				type:String,
				required:true,
				validator(value) {
					return ['os', 'rp', 'f', 'tr', 'go'].indexOf(value) !== -1
				}
			}
		},
		computed: {
			title() {
				switch(this.Type) {
					case "os":
						return "onsight"
						break

					case "rp":
						return "redpoint"
						break

					case "f":
						return "flash"
						break

					case "tr":
						return "toprope"
						break

					case "go":
						return "go"
						break
				}
			}
		}
	}
</script>
<style lang="scss" media="screen">

.webicon {
	// onsight
	&.os 		{ #typesvg { fill: green; } }
	// flash
	&.f			{ #typesvg { fill: yellow; } }
	// redpoint
	&.rp		{ #typesvg { fill: red; } }
	// go
	&.go 		{ #typesvg { fill: blue; } }
	// tr
	&.tr		{ #typesvg { fill: gray; } }
}

</style>