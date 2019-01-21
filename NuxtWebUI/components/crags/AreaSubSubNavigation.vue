<template>
	<div>
		<ul class="menu align-center bg-dark">
			<li><nuxt-link  :to="{ name: 'areas-country-area-routes', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							ROUTE LIST
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'areas-country-area-crags', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							CRAG LIST
				</nuxt-link></li>

			<li><nuxt-link  :to="{ name: 'areas-country-area-map', params: {  
							country: $route.params.country, 
							area: $route.params.area } }">
							MAP
				</nuxt-link></li>
		</ul>
	</div>
</template>