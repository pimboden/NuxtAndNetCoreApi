<template>
	<article class="cell small-12 news-item">

		<img v-if="news.image" :src="news.image">
		<div class="title">
			<h4>{{ news.title }}</h4>
		</div>
		<div class="card-section">
			<div v-html="news.description"></div>
		</div>
		<footer>
			VENGA! (1)   (13) comments
		</footer>
		
	</article>
</template>
<script>

export default{
	props:['news']
}
</script>