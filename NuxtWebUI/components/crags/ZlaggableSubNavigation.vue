<template>
	<div>
		<ul class="menu align-center bg-dark">
			<li><nuxt-link  :to="{ name: 'crags-category-country-crag-sectors-sector-routes-route', params: {  
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag,
							sector: $route.params.sector,
							route: $route.params.route } }" append>
							TICKLIST
				</nuxt-link></li>
			
			<li><nuxt-link  :to="{ name: 'crags-category-country-crag-sectors-sector-routes-route-info', params: {  
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag,
							sector: $route.params.sector,
							route: $route.params.route } }" append>
							ROUTE INFORMATION
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'crags-category-country-crag-sectors-sector-routes-route-gallery', params: {  
							category:$route.params.category, 
							country: $route.params.country, 
							crag: $route.params.crag,
							sector: $route.params.sector,
							route: $route.params.route } }" append>
							GALLERY
				</nuxt-link></li>
		</ul>
	</div>
</template>