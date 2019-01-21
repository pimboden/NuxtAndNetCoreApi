<template>
	<article class="cell small-12 medium-6 large-12 video-item">

		<img src="https://placehold.it/160x100">
		<div class="title">
			<h4>{{ video.title }}</h4>
		</div>
		<footer>
			VENGA! (1)   (13) comments
		</footer>
		
	</article>
</template>
<script>

export default{
	props:['video']
}
</script>