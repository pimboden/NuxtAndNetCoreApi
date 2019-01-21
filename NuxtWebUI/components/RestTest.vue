<template>
  <div class="rest-test">
  	{{testData.message}}
  </div>

</template>
<script>
export default {
	data() {
   return {
   	 testData:{message:'static message'}
    };
   }
	,created(){
		//this.loadTestData()
	}
	,methods:{
			loadTestData(){

				/*
				this.$axios.$get("/testmodels/getall", { headers: { 'Access-Control-Allow-Origin': '*' } })
				.then(data=>{
					this.testData = data;
				})
				.catch(e => console.log(e));
				*/

			}			
		}

}
</script>