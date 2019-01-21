<template>
	<div>
		<ul class="menu align-center bg-dark">
			
			
			<li><nuxt-link  :to="{ name: 'crags-category-country-crag', params: {  
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag } }">
							CRAG INFORMATION
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'crags-category-country-crag-ranking', params: { 
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag } }">
							RANKING
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'crags-category-country-crag-gallery', params: { 
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag } }">
							GALLERY
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'crags-category-country-crag-routes', params: {  
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag } }">
							ROUTE LIST
				</nuxt-link></li>
		</ul>
	</div>
</template>