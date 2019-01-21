<template>
	<no-ssr>
		<vue-slider ref="slider" v-model="gradeRange" :data="sliderData" :lazy="options.lazy" :options="options" @callback="cb"></vue-slider>
	</no-ssr>
</template>
<script>
	export default {
		props:{
			grades:{
				type:Object,
				required:true
			}
		},
		data(){
			return {
				gradeRange: [], // selected graderange for vue-slider
				tempGrades: [], // stores grades with indexes
				minGrade: null, // store minimum grade here 
				maxGrade: null, // store maximum grade here
				options: {
					piecewise: true,
					startAnimation: false,
					lazy: true // due to a little bug, lazy has to be set as it's own property to vue-slider
				}
			}
		},
		created() {
			
			this.generateSliderData()
			
			var min = this.minGrade
			var max = this.maxGrade
			
			var qstring = this.$route.query.grade
			if (qstring && qstring.length > 0) {
				try {
					var qgrades = qstring.split(',').map(item => parseInt(item))
					qgrades.sort((a, b) => { return a - b })

					// get first grade
					var g = qgrades[0]
					if (g > min.gradeindex && g < max.gradeindex) {
						min = this.getGradeByIndex(g, true)
					}
					
					// get second grade (max)
					if (qgrades.length > 1) {
						g = qgrades[1]
						if (g >= min.gradeindex && g < max.gradeindex)
						{
							max = this.getGradeByIndex(g, false)
						}
					}
					else {
						max = min
					}
				}
				catch(error) {
					min = this.minGrade
					max = this.maxGrade
				}
			}

			this.gradeRange = [min.grade, max.grade]
			
		},
		methods: {
			getGradeByIndex(gradeIndex, isMin) {
				var retval

				while(true) {
					retval = this.tempGrades.find(g => { return g.gradeindex == gradeIndex }) 
					if (retval != null) {
						break
					}
					else {
						gradeIndex += isMin ? -1 : 1
					}

					if (gradeIndex < this.minGrade.gradeindex) {
						retval = this.minGrade
						break
					}
					else if (gradeIndex > this.maxGrade.gradeindex) {
						retval = this.maxGrade
						break
					}
				}

				return retval
			},
			cb(val) {
				var gradeIndexes = this.tempGrades.filter(g => {
				  return g.grade === val[0] || g.grade === val[1]
				}).map(g => g.gradeindex)

				var range = gradeIndexes.join()
				var query = {
					...this.$route.query,
					page: 0,
					grade: range
				}
				this.$router.push({path: '', query: query})
			},
			generateSliderData() {
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

				var i = tempGrades.length
				tempGrades.sort((a, b) => { return a.gradeindex - b.gradeindex })
				while (i--) {
					var grade = tempGrades[i]

					var previousGrade
					if (i > 0) {
						previousGrade = tempGrades[i-1] 
					}
					else {
						continue
					}

					// if greater than 5 take bigger gradeindex if cuplicate
					// if smaller than 6 take smaller gradeindex
					// this is for the search .. so we get the right results if there's zlaggables for the duplicates
					var takeBigger = parseInt(grade.grade) > 5

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

				// remove empty ones
				i = tempGrades.length
				while (i--) {
					var grade = tempGrades[i]

					if (tempGrades[i].routeCount == 0) {
						tempGrades.splice(i, 1)
					}					
				}

				this.tempGrades = tempGrades
				this.minGrade = tempGrades[0]
				this.maxGrade = tempGrades[tempGrades.length-1]
			}
		},
		computed: {
			sliderData() {
				return this.tempGrades.map(g => g.grade)
			}
		}

	}
</script>