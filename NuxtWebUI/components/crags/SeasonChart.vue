<template>
	<div>
		<line-chart :data="chartData" :options="chartOptions" />
	</div>
</template>
<script>
	import LineChart from "@/components/common/line-chart"

	export default {
		props:{
			season:{
				type:Array,
				required:true
			}
		},
		components: {
			LineChart
		},
		data(){
			return {
				chartData: {
				  labels: ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D'],
				  datasets: [
				    {
				      backgroundColor: '#000000',
				      borderColor: '#000000',
				      data: this.season,
				      fill: false,
					  cubicInterpolationMode: 'default',
					  lineTension: 0,
					  label: '',
					  pointRadius: 0,
					  borderWidth: 1
				    }
				  ],


				},
				chartOptions: {
					maintainAspectRatio: true,
					tooltips: {
						enabled: false
					},
					title: {
						display: false
					},
					legend: {
						display: false
					},
					scales: {		            	
						yAxes: [{
			                display: false
			            }],
			            xAxes: [{
			            	position: 'bottom',
			                gridLines: {
			                	display: true,
			                	tickMarkLength: 10,
			                	drawOnChartArea: false,
			                	drawBorder: false,
			                	color: "black",
			                	borderDashOffset: 30
			                },
			                ticks: {
			                	padding: 5	
			                }
			            }],
					}
				}
			}
		},
		methods:{
		},
		computed: {
		},
		filters: {
		}
	}
</script>