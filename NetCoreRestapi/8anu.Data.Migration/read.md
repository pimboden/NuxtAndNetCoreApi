# 8anu.Data.Migration

command line tool for migrating data from the old 8a.nu site to the new one

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

- get the old database
- run "/scripts/prepare old database for entity framework scaffolding.sql" (takes about 13 minutes)
- edit /migrationsettings.json
- run 'dotnet run cleandb' 
- run 'dotnet run' this will create x number of rows for seeding the db when starting the app
- run 'dotnet run all nocopy' this will create all rows and not copy the files. this will also create sql files to /sql folder

### Word about scaffolding database with entityframework

for starters when running entityframework scaffolding there will be some tables that can't be scaffolded. The tables needed are scaffolded correctly after running "/scripts/prepare old database for entity framework scaffolding.sql" on the DB. 

How to run the scaffolding:
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=DBNAME;;User ID=root;;Password=PASSWORD;Convert Zero Datetime=True" Pomelo.EntityFrameworkCore.MySql -o Model
https://www.learnentityframeworkcore.com/walkthroughs/existing-database

### To-do & to keep in mind:
- environments
	- possibility to overwrite seeding locally so that not all data is migrated every time? 

- set weird data to "tobeverified" category?

- to consider. maybe add property DeleteDestinationFile (bool) to set if already generated data should be deleted even when new data is not created. 
	- or then just don't delete the destination data in the begginning...

#### done:
+ create json configuration file
+ create classes for each configuration type
+ open configuration file
+ generate output based on configuration file
+ copy configuration to api project
+ copy output to api project
+ open configuration file when seeding database
+ delete depending on the order of the configuration
+ seed data from json files
+ generate data from database
+ check if migrations not run and run them
+ add property to not generate specific class
+ NU-36 fix score table crag names
+ NU-37 fix Fix score-table crag names

#### Here's a list of changes made to the tables after import

added new index:
country
grades
points_grade
points_how
score_how
user_settings
score

cannot add index, have to be done otherwise:
adminLocalSite
crag_comments_val
galleryRating
news_all_onlocal
ranking_snapshot

not needed
cookie
crag_best_grades_val
crag_environment_val
crag_guides
crag_height_val
crag_holds_val
crag_neg_features_val
crag_no_of_routes_val
crag_overhang_val
crag_pictures
crag_pos_features_val
crag_road_map_val
crag_rock_type_val
crag_sunshine_val
crag_walk_val
crag_where_val
forum_delmsg
mail_list
pages
password_reset_tokens
votingsCountry
user_visits
yellow_grades


readme.md layout based on: https://gist.github.com/PurpleBooth/109311bb0361f32d87a2