<template>
<nav v-if="showBreadcrumbs" aria-label="You are here:" role="navigation">
<ul class="breadcrumbs">
	<li v-for="(crumb, index) in this.pageInfoBreadcrumbs" :key="index">
		<nuxt-link v-if="crumb.route" :to="{ name: crumb.route, params: crumb.params, query: crumb.query }">{{ crumb.title }}</nuxt-link>
		<span v-else>{{ crumb.title }}</span>
	</li>
</ul>
</nav>
</template>

<script>

import { mapGetters } from 'vuex';	
export default {
	computed: {...mapGetters({
		pageInfoBreadcrumbs: "pageInfo/breadcrumbs"
		}),

		showBreadcrumbs() {
			return this.pageInfoBreadcrumbs && this.pageInfoBreadcrumbs.length
		}
	}		
}

</script>