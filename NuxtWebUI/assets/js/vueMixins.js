import { mapActions, mapGetters } from 'vuex';
import moment from 'moment';


export const StringTruncateMixin ={
	methods:{
		truncateText(text, maxlength){
			return text.length > maxlength ? text.substr(0, maxlength-1) + '...' : text;
		}
	}
}
export const PageInfoMixin ={

	computed: {...mapGetters({
		pageInfoName: "pageInfo/name",
		pageInfoDescription:"pageInfo/description",
		pageInfoUrl:"pageInfo/url",
		pageInfoBreadcrumbs:"pageInfo/breadcrumbs"
	})},
	methods:{
		...mapActions({
			updatePageInfoName: "pageInfo/updateName", 
			updatePageInfoDescription:"pageInfo/updateDescription",
			updatePageInfoUrl:"pageInfo/updateUrl",
			updatePageInfoBreadcrumbs:"pageInfo/updateBreadcrumbs"
		}),
	},
	mounted(){
		var crumbs = []
		if (this.breadcrumbs) {
			crumbs = this.breadcrumbs
		}
		this.updatePageInfoBreadcrumbs(crumbs)

		var title = this.$metaInfo.title
		if (this.headerTitle && this.headerTitle.length)
			title = this.headerTitle
		this.updatePageInfoName(title);
		
		this.updatePageInfoDescription(this.$metaInfo.meta[0].content);
		this.updatePageInfoUrl(this.$route.fullPath);
		if (process.browser && process.env.NODE_ENV == "production") {
			window['dataLayer'].push({event: 'virtualPageView', pageUrl: this.pageInfoUrl, pageName: this.pageInfoName})
		}
		else{
		}
	}
}

export const IsoToLocaleDate ={
	computed: {...mapGetters({
		locale: "locale",
	})},
	methods:{
		getDateString(dateString){
			moment.locale(this.locale);
			if(dateString){
				return moment.parseZone(dateString).format( 'L');
			}	
			return "";
		},
		getTimeString(dateString){
			moment.locale(this.locale);
			if(dateString){
				return moment.parseZone(dateString).format( 'LT');
			}
			
			return "";
		},
		getNowDateString(){
			moment.locale(this.locale);
			return moment().format( 'L');			
		}		,
		getNowTimeString(){
			moment.locale(this.locale);
			return moment().format( 'LT');
			
		}
	}
}