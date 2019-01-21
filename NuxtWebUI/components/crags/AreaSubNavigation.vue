<template>
	<div>
		<ul class="menu align-center bg-dark">
			
			<li><nuxt-link  :to="{ name: 'areas-country-area', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							AREA INFORMATION
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'areas-country-area-ranking', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							RANKING
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'areas-country-area-feed', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							FEED
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'areas-country-area-gallery', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							GALLERY
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'areas-country-area-routes', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							ROUTE LIST
				</nuxt-link></li>
		</ul>
	</div>
</template>