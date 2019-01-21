#!/bin/bash


chown -R www-data:www-data /var/aspnetcore/8anu/
chmod -R 777 /var/aspnetcore/8anu/
cp /var/aspnetcore/appsettings.*.json /var/aspnetcore/8anu/
cp /var/aspnetcore/migrationsettings.json /var/aspnetcore/8anu/Seed/input/
cp /var/aspnetcore/seed_data_json.zip /var/aspnetcore/8anu/Seed/input/