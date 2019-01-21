<template>
	<nav class="cell top-navigation">
		<div class="grid-x">
			<div class="cell medium-2 hide-for-small-only">&nbsp;</div>
			<div class="cell medium-8 small-12">
				
				<div class="grid-x">
					<div class="cell small-1 ">
						<div class="logo"><img src="~/assets/images/8anu-logo.png">
						</div>
					</div>
					<div class="cell medium-10 show-for-medium-only navi-links">
						<ul>
							<li class="active">
								<nuxt-link class="nav-link" :to="$i18n.path('')" exact>
									{{ $t('links.home') }}
								</nuxt-link>
							</li> 
							<li>
								<nuxt-link class="nav-link" :to="$i18n.path('news')" exact>
									{{ $t('links.news') }}
								</nuxt-link>
							</li> 
							<li>articles</li>
							<li>
								<nuxt-link  :to="{ name: 'areas' }">
									{{ $t('links.areas') }}
								</nuxt-link>
							</li>
							<li>
								<nuxt-link  :to="{ name: 'crags-category', params: { category:'sportclimbing' } }">
									{{ $t('links.crags') }}
								</nuxt-link>
							</li> 
							<li>
								<nuxt-link class="nav-link" :to="$i18n.path('videos')" exact>
									{{ $t('links.videos') }}
								</nuxt-link>
							</li> 
							<li>
								<nuxt-link class="nav-link" :to="$i18n.path('forum')" exact>
									{{ $t('links.forum') }}
								</nuxt-link>
							</li>
							<li>Contact</li>
						</ul>
					</div>
					<div class="cell medium-10 show-for-large  navi-links">
						<ul>
							<li class="active">
								<nuxt-link class="nav-link" :to="$i18n.path('')" exact>
									{{ $t('links.home') }}
								</nuxt-link>
							</li> 
							<li>
								<nuxt-link class="nav-link" :to="$i18n.path('news')" exact>
									{{ $t('links.news') }}
								</nuxt-link>
							</li> 
							<li>
								<nuxt-link class="nav-link" :to="$i18n.path('articles')" exact>
									{{ $t('links.articles') }}
								</nuxt-link>
							</li> 
							<li>
								<nuxt-link class="nav-link" :to="$i18n.path('videos')" exact>
									{{ $t('links.videos') }}
								</nuxt-link>
							</li> 
							<li>Gallery</li>
							<li>
								<nuxt-link  :to="{ name: 'areas' }">
									{{ $t('links.areas') }}
								</nuxt-link>
							</li>
							<li>
								<nuxt-link  :to="{ name: 'crags-category', params: { category:'sportclimbing' } }">
									{{ $t('links.crags') }}
								</nuxt-link>
							</li> 
							<li>Gyms</li> 
							<li>Tick List</li> 
							<li>Ranking</li>
							<li>Blogs</li>
							<li>Contact</li>
						</ul>
					</div>
					<div class="cell small-10 show-for-small-only  navi-links">
						<ul>
							<li class="active"><nuxt-link class="nav-link" :to="$i18n.path('')" exact>
								{{ $t('links.home') }}
							</nuxt-link></li>
						</ul>
					</div>
					<div class="cell small-1">
						

						<div class="search">
							<!-- <nuxt-link  :to="{ name: 'search' }"> -->
								<i class="fa fa-search fa-2x" @click="openPopupMenu"></i>
								
							<!-- </nuxt-link> -->
						</div>
					</div>
				</div>
			</div>
			<div class="cell medium-2 hide-for-small-only">&nbsp;</div>
		</div>

		<transition name="menu-popover">
			<div class="popupMenu" v-show="searchVisible" @mouseleave="mouseLeave" @mouseenter="mouseEnter">
				<search-popup></search-popup>
			</div>
		</transition>	
	

	</nav>
</template>

<script >

	import SearchPopup from "@/components/SearchPopup.vue"
	import _ from 'lodash'

	export default{
		components: {
			SearchPopup
		},
		data() {
			return {
				searchVisible: false,
				mouseOver: true
			}
		},
		created(){
			
		},
		methods: {
			openPopupMenu() {
				this.searchVisible = true
			},
			closePopupMenu: 
				_.debounce(function () {
					if (!this.mouseOver) {
						this.searchVisible = false     		
					}
		     	}, 500)
			,
			mouseLeave() {
				this.mouseOver = false
				this.closePopupMenu()
			},
			mouseEnter() {
				this.mouseOver = true
			}
		},

	}
</script>

<style lang="scss" media="screen">
	

	.search {
		z-index: 1000;
	}

	.popupMenu {
		opacity: 0.9;
		z-index: 999;
		position: absolute; 
		top: 0; 
		height: 400px; 
		background-color: #2a2a2f;
		width: 1000px;
		
		left: 50%;
		-webkit-transform: translateX(-50%);
		transform: translateX(-50%);
		overflow: scroll;
		
		color: white;

		a {
			color: white;
			&:hover {
				color: white;
				text-decoration: underline;
			}
		}

		h4 {
			background-color: #babdc4;
			color: black;
			font-size: 0.8rem;
			padding-left: 5px;
		}

		// this is for the icon for now
		.cls-1 {
			fill: white;
		}

		.button {
			background-color: red;
		}
	}

	.menu-popover-enter,
	.menu-popover-leave-to {
	  opacity: 0;
	  //transform: rotateY(50deg);
	}
	.menu-popover-enter-to,
	.menu-popover-leave {
	  opacity: 1;
	  //transform: rotateY(0deg);
	}
	.menu-popover-enter-active,
	.menu-popover-leave-active {
	  transition: opacity 200ms ease-out;
	}
	
</style>