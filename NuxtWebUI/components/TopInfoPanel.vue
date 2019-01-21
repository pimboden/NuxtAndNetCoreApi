<template>
	<div class="cell top-info-panel">
		
		<div class="grid-x">
			<div class="cell row-1">
				<div class="grid-x">
					<div class="cell medium-2 hide-for-small-only">&nbsp;</div>
					<div class="cell medium-8 small-12">

						<div class="grid-x">
							<div class="cell small-2 ">
								<div class="country-changer">Global
								</div>

							</div>
							<div class="cell medium-9 hide-for-small-only">
								&nbsp;
							</div>

							<div class="cell small-10 medium-1">
								<div class="date">{{today}}
								</div>
							</div>
						</div>
					</div>
					<div class="cell medium-2 hide-for-small-only">&nbsp;</div>

				</div>
			</div>
			<div class="cell row-2">

				<div class="grid-x">
					<div class="cell medium-2 hide-for-small-only">&nbsp;</div>
					<div class="cell medium-8 small-12">

						<div class="grid-x">
							<div class="cell small-2 ">
								<div class="login-title">Log in
								</div>

							</div>
							<div class="cell small-10 medium-9">
								<h1 class="current-page">{{this.pageInfoName}}
								</h1>
								<breadcrumbs></breadcrumbs>
							</div>
							<div class="cell medium-1 hide-for-small-only social-media">
								<div class="instagram"><i class="fa fa-instagram" aria-hidden="true"></i>
								</div>
								<div class="facebook"><i class="fa fa-facebook-official" aria-hidden="true"></i>
								</div>

							</div>
						</div>
					</div>
					<div class="cell medium-2 hide-for-small-only">&nbsp;</div>

				</div>
			</div>
		</div>
	</div>
</template>

<script >
	import {IsoToLocaleDate} from "@/assets/js/vueMixins.js";
	import Breadcrumbs from '~/components/Breadcrumbs'
	import { mapActions, mapGetters } from 'vuex';
	export default{
		mixins:[ IsoToLocaleDate],
		components: {
			Breadcrumbs
		},
		data(){
			return{
				today: ''
			}
		},
		created(){
			this.today = this.getNowDateString();
		},
		computed: {...mapGetters({
			pageInfoName: "pageInfo/name",
			pageInfoDescription:"pageInfo/description",
			pageInfoUrl:"pageInfo/url",
			pageInfoBreadcrumbs: "pageInfo/breadcrumbs"
		})}		
	}
</script>