<template>
	<section class="cell left-main-bar">
		<div class="grid-container fluid ">
			<left-login></left-login>
			<left-rankings></left-rankings>
			<left-stats></left-stats>
			<left-comments></left-comments>
		</div>
	</section>
</template>

<script>
import LeftLogin from '~/components/LeftLogin'
import LeftRankings from '~/components/LeftRankings'
import LeftStats from '~/components/LeftStats'
import LeftComments from '~/components/LeftComments'

export default {
	components: {
		LeftLogin,
		LeftRankings,
		LeftStats,
		LeftComments
	}
}
</script>