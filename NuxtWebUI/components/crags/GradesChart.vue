<template>
	<div>
		<bar-chart :data="chartData" :options="chartOptions" />
	</div>
</template>
<script>
	import BarChart from "@/components/common/bar-chart"

	export default {
		props:{
			grades:{
				type: Object,
				required: true
			}
		},
		components: {
			BarChart
		},
		data(){
			return {
				chartData: { 
					...this.getChartData(),
				},
				chartOptions: {
					maintainAspectRatio: false,
					tooltips: {
						backgroundColor: '#ffffff',
						titleFontColor: '#000000',
						titleFontSize: 14,
						bodyFontColor: '#000000',
						caretPadding: 10,
						borderColor: '#000000',
						borderWidth: 1,
						footerFontColor: '#000000',
						displayColors: false,	
						callbacks: {
							label(item, data) {
								var label = data.datasets[item.datasetIndex].label || ''

			                    label = item.yLabel + " " + label.toUpperCase()
			                    return label;
							}
						}
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
			                gridLines: {
			                	display: false,
			                	tickMarkLength: 10,
			                	drawOnChartArea: false,
			                	drawBorder: false,
			                	color: "black",
			                	borderDashOffset: 30
			                }
			            }]
					}
				}
			}
		},
		created() {
		},
		methods:{
			getChartData() {
				var tempGrades = 	[
				{"gradeindex": 1, "grade": "1"},
				{"gradeindex": 2, "grade": "2"},
				{"gradeindex": 3, "grade": "3a"},
				{"gradeindex": 4, "grade": "3b"},
				{"gradeindex": 5, "grade": "3c"},
				{"gradeindex": 6, "grade": "4a"},
				{"gradeindex": 7, "grade": "4b"},
				{"gradeindex": 8, "grade": "4b"},
				{"gradeindex": 9, "grade": "4c"},
				{"gradeindex": 11, "grade": "5a"},
				{"gradeindex": 10, "grade": "5a"},
				{"gradeindex": 12, "grade": "5b"},
				{"gradeindex": 13, "grade": "5b"},
				{"gradeindex": 14, "grade": "5c"},
				{"gradeindex": 15, "grade": "5c"},
				{"gradeindex": 16, "grade": "6a"},
				{"gradeindex": 17, "grade": "6a+"},
				{"gradeindex": 18, "grade": "6b"},
				{"gradeindex": 19, "grade": "6b+"},
				{"gradeindex": 20, "grade": "6c"},
				{"gradeindex": 21, "grade": "6c+"},
				{"gradeindex": 22, "grade": "7a"},
				{"gradeindex": 23, "grade": "7a+"},
				{"gradeindex": 24, "grade": "7b"},
				{"gradeindex": 25, "grade": "7b+"},
				{"gradeindex": 26, "grade": "7c"},
				{"gradeindex": 27, "grade": "7c+"},
				{"gradeindex": 28, "grade": "8a"},
				{"gradeindex": 29, "grade": "8a+"},
				{"gradeindex": 30, "grade": "8b"},
				{"gradeindex": 31, "grade": "8b+"},
				{"gradeindex": 32, "grade": "8c"},
				{"gradeindex": 33, "grade": "8c+"},
				{"gradeindex": 34, "grade": "9a"},
				{"gradeindex": 35, "grade": "9a+"},
				{"gradeindex": 36, "grade": "9b"},
				{"gradeindex": 37, "grade": "9b+"},
				{"gradeindex": 38, "grade": "9c"},
				{"gradeindex": 39, "grade": "8c/+"},
				{"gradeindex": 40, "grade": "8c+/9a"},
				{"gradeindex": 41, "grade": "9a/+"},
				{"gradeindex": 42, "grade": "9a+/9b"}
				]
			
				tempGrades.forEach((grade) => {
					var routeCount = 0
					grade.grade = grade.grade.toUpperCase()
					if (!isNaN(this.grades[grade.gradeindex])) {
						routeCount = this.grades[grade.gradeindex]
					}
					grade.routeCount = routeCount
				})


				// remove and merge duplicate grades
				var i = tempGrades.length
				tempGrades.sort((a, b) => { return a.gradeindex - b.gradeindex })
				while (i--) {
					var grade = tempGrades[i]

					// remove empty ones from both ends
					if ([1,2,39,40,41,42].includes(grade.gradeindex)) {
						if (grade.routeCount == 0) {
							tempGrades.splice(i, 1)
							continue
						}
					}
					

					var previousGrade
					if (i > 0) {
						previousGrade = tempGrades[i-1] 
					}
					else {
						continue
					}

					// add 3b and 3c grades to previous
					if ([5,4].includes(grade.gradeindex)) {
						previousGrade.routeCount += grade.routeCount
						tempGrades.splice(i, 1)
						continue
					}

					// if 3a, rename to 3
					if (grade.gradeindex == 3) {
						grade.grade = '3'
						continue
					}
					

					// if lower than 6a take bigger gradeindex if cuplicate
					// if 6a or higher, take smaller gradeindex
					var takeBigger = parseInt(grade.grade) < 6

					if (takeBigger) {
						if (grade.grade == previousGrade.grade) {
							grade.routeCount += previousGrade.routeCount
							tempGrades.splice(i-1, 1)
						}
					}
					else {
						if (grade.grade == previousGrade.grade) {
							previousGrade.routeCount += grade.routeCount
							tempGrades.splice(i, 1)
						}
					}
					
				}
			
				return {
					labels: tempGrades.map(g => g.grade),
					datasets: [
					    {
					    	label: 'ROUTES',
							data: tempGrades.map(g => g.routeCount),
							backgroundColor: '#000000'
					    }
					]
				}
			}
		},
		computed: {
		},
		filters: {
		}
	}
</script>