<template>
	<div>
		<select v-model="selected">
			<option value="en">GLOBAL</option>
			<option value="de">DE</option>
			<option value="fr">FR</option>
		</select>
	</div>
</template>

<script>
// import VueI18n from 'vue-i18n'

export default {
 	data() {
   		return {
   	 		// selected: this.$i18n.locale
   	 		// or
   	 		selected: this.$store.state.locale
    	}
   	},
   	created(){
   		//console.log("store", this.$store)
	},
	watch: {
		selected(val, redirect) {
			let country = "";
			if (val != "en") {
				country = "/" + val
			}
			let newloc = country + "/"
			this.$store.$router.push(newloc);
		}
	}
}

</script>