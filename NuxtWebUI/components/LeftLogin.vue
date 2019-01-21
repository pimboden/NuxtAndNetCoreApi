<template>
	<div class="cell left-login">
		
		
		<div v-if="$auth.loggedIn">
			<button type="button" class="button" @click="logout">logout</button><br>
			logged in!
		</div>
		<div v-else>
			<button type="button" class="button" @click="login">login</button><br>
			not logged in!
		</div>
	</div>
</template>

<script>
	

export default {
	methods: {
		login() {
			this.$auth.loginWith('keycloak')
			.then(() => console.log('Logged In!'))
		},
		async logout() {
			console.log("do logout")
			await this.$auth.logout()
		}
	},
	mounted() {
		/*
		var authuser = this.$auth.user
		console.log("authuser", authuser)

		var storeuser = this.$store.state.auth.user
		console.log("storeuser", storeuser)

		console.log("this.$auth", this.$auth)
		*/
	}
}

</script>