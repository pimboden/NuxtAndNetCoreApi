<template>
<div class="paging">
	<nuxt-link v-if="isPreviousPageActive" :to="{ path: '', query: getLinkQuery(prevPageIndex) }" append>prev</nuxt-link>
	<span v-else>prev</span>
	<span>  |  </span>
	<nuxt-link :to="{ path: '', query: getLinkQuery(nextPageIndex) }" append>next</nuxt-link>
</div>
</template>

<script>
	export default {
		data(){
			return {}
		},
		computed: {
			isPreviousPageActive() {
				return this.currentPageIndex > 0
			},
			nextPageIndex() {
				return this.currentPageIndex + 1
			},
			prevPageIndex() {
				return this.currentPageIndex - 1;
			},
			currentPageIndex() {
				var page = this.$route.query.page || 0

				// convert page to number and test if it actually is a number
				var retval = +page
				if (isNaN(retval)) {
					retval = 0
				}
				return retval
			}

		},
		methods: {
			getLinkQuery(pageIndex) {
				var query = {
					...this.$route.query,
					page: pageIndex
				}
				return query
			}
		}
	}

</script>