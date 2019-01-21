﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _8anu.Api.Data.Contexts;

namespace _8anu.Api.Migrations
{
    [DbContext(typeof(DomainModelMySqlContext))]
    [Migration("20180822103228_ChangeNewsLegacyId")]
    partial class ChangeNewsLegacyId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Area", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CountryId")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.Property<bool>("Published")
                        .HasColumnName("published");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("areas");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Ascent", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<sbyte?>("Chipped")
                        .HasColumnName("chipped")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Comment")
                        .HasColumnName("comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnName("date")
                        .HasColumnType("TIMESTAMP DEFAULT CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Difficulty")
                        .HasColumnName("difficulty")
                        .HasMaxLength(255);

                    b.Property<sbyte?>("ExcludeFromRanking")
                        .HasColumnName("exclude_from_ranking")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Height")
                        .HasColumnName("height");

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<int?>("Note")
                        .HasColumnName("note");

                    b.Property<sbyte?>("Project")
                        .HasColumnName("project")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Protection")
                        .HasColumnName("protection");

                    b.Property<int?>("Rating")
                        .HasColumnName("rating");

                    b.Property<sbyte>("Recommended")
                        .HasColumnName("recommended")
                        .HasColumnType("tinyint(1)");

                    b.Property<sbyte?>("Repeat")
                        .HasColumnName("repeat")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Score")
                        .HasColumnName("score");

                    b.Property<int?>("Sits")
                        .HasColumnName("sits");

                    b.Property<int?>("Steepness")
                        .HasColumnName("steepness");

                    b.Property<string>("Style")
                        .HasColumnName("style")
                        .HasMaxLength(6);

                    b.Property<int?>("Tries")
                        .HasColumnName("tries");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasMaxLength(2);

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.Property<int?>("ZlaggableId")
                        .HasColumnName("zlaggable_id");

                    b.Property<string>("ZlaggableKey")
                        .HasColumnName("zlaggable_key")
                        .HasMaxLength(255);

                    b.Property<string>("ZlaggableType")
                        .HasColumnName("zlaggable_type")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ZlaggableId", "ZlaggableType");

                    b.HasIndex("ZlaggableId", "ZlaggableType", "Type");

                    b.ToTable("ascents");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Boulder", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnName("difficulty")
                        .HasMaxLength(10);

                    b.Property<string>("Grade")
                        .HasColumnName("grade")
                        .HasMaxLength(255);

                    b.Property<string>("GradingSystem")
                        .HasColumnName("grading_system")
                        .HasMaxLength(255);

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnName("path")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReferenceWidth")
                        .HasColumnName("reference_width");

                    b.Property<int>("SectorId")
                        .HasColumnName("sector_id");

                    b.Property<sbyte>("SitDownStart")
                        .HasColumnName("sit_down_start")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.Property<string>("TopoNum")
                        .HasColumnName("topo_num")
                        .HasMaxLength(10);

                    b.Property<sbyte?>("Traverse")
                        .HasColumnName("traverse")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("boulders");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Country", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ISO2")
                        .HasColumnName("iso2")
                        .HasMaxLength(2);

                    b.Property<string>("ISO3")
                        .HasColumnName("iso3")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Slug")
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Crag", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Access")
                        .HasColumnName("access")
                        .HasColumnType("TEXT");

                    b.Property<string>("Approach")
                        .HasColumnName("approach")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AreaId")
                        .HasColumnName("area_id");

                    b.Property<sbyte?>("Beauty")
                        .HasColumnName("beauty")
                        .HasColumnType("tinyint(4)");

                    b.Property<sbyte?>("BeginnerFriendly")
                        .HasColumnName("beginner_friendly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Category")
                        .HasColumnName("category")
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(100);

                    b.Property<int>("CountryId")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Exposition")
                        .HasColumnName("exposition");

                    b.Property<sbyte?>("FamilyFriendly")
                        .HasColumnName("family_friendly")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Height")
                        .HasColumnName("height");

                    b.Property<double?>("Latitude")
                        .HasColumnName("latitude");

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<double?>("Longitude")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("TEXT");

                    b.Property<sbyte?>("Parking")
                        .HasColumnName("parking")
                        .HasColumnType("tinyint(4)");

                    b.Property<sbyte?>("Protection")
                        .HasColumnName("protection")
                        .HasColumnType("tinyint(4)");

                    b.Property<bool>("Published")
                        .HasColumnName("published");

                    b.Property<sbyte?>("RainSafety")
                        .HasColumnName("rain_safety")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("RockQuality")
                        .HasColumnName("rock_quality");

                    b.Property<string>("Rocktype")
                        .HasColumnName("rock_type")
                        .HasMaxLength(255);

                    b.Property<sbyte?>("Seaside")
                        .HasColumnName("seaside")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Season")
                        .HasColumnName("season");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.Property<int?>("Steepness")
                        .HasColumnName("steepness");

                    b.Property<string>("Town")
                        .HasColumnName("town")
                        .HasMaxLength(255);

                    b.Property<int?>("WalkingTime")
                        .HasColumnName("walking_time");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Slug", "Category");

                    b.ToTable("crags");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.ForumCategory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId")
                        .HasColumnName("parent_id");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(100);

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("forum_categories");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.ForumComment", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnName("content");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<int>("ForumThreadId")
                        .HasColumnName("forum_thread_id");

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ForumThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("forum_comments");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.ForumThread", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<int>("ForumCategoryId")
                        .HasColumnName("forum_category_id");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(255);

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ForumCategoryId");

                    b.HasIndex("UserId");

                    b.HasIndex("Slug", "ForumCategoryId")
                        .IsUnique();

                    b.ToTable("forum_threads");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.GradingSystem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .HasColumnName("category")
                        .HasMaxLength(50);

                    b.Property<string>("Grade")
                        .HasColumnName("grade")
                        .HasMaxLength(25);

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasMaxLength(50);

                    b.Property<string>("VLGrade")
                        .HasColumnName("vl_grade")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.ToTable("grading_systems");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.NewsItem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnName("date_published");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<string>("Slug")
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("news");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Route", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnName("difficulty")
                        .HasMaxLength(10);

                    b.Property<string>("Grade")
                        .HasColumnName("grade")
                        .HasMaxLength(255);

                    b.Property<string>("GradingSystem")
                        .HasColumnName("grading_system")
                        .HasMaxLength(255);

                    b.Property<int?>("LegacyId")
                        .HasColumnName("legacy_id");

                    b.Property<int?>("Length")
                        .HasColumnName("length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnName("path")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReferenceWidth")
                        .HasColumnName("reference_width");

                    b.Property<int>("SectorId")
                        .HasColumnName("sector_id");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.Property<int?>("Spit")
                        .HasColumnName("spit");

                    b.Property<string>("TopoNum")
                        .HasColumnName("topo_num")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("routes");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Sector", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .HasColumnName("category")
                        .HasMaxLength(255);

                    b.Property<int>("CragId")
                        .HasColumnName("crag_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<double?>("Latitude")
                        .HasColumnName("latitude");

                    b.Property<double?>("Longitude")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("text");

                    b.Property<int?>("Ordering")
                        .HasColumnName("ordering");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CragId");

                    b.ToTable("sectors");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.TestModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("Message")
                        .HasColumnName("message")
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.ToTable("test_models");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CountryId")
                        .HasColumnName("country_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<DateTime>("DateModified")
                        .HasColumnName("date_modified");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(30);

                    b.Property<int>("Gender")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(30);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Area", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Ascent", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Boulder", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Crag", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("_8anu.Api.Common.DataEntities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.ForumCategory", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.ForumCategory", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("_8anu.Api.Common.DataEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.ForumComment", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.ForumThread", "ForumThread")
                        .WithMany("ForumComments")
                        .HasForeignKey("ForumThreadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_8anu.Api.Common.DataEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.ForumThread", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.ForumCategory", "ForumCategory")
                        .WithMany("ForumThreads")
                        .HasForeignKey("ForumCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_8anu.Api.Common.DataEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Route", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.Sector", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.Crag", "Crag")
                        .WithMany("Sectors")
                        .HasForeignKey("CragId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_8anu.Api.Common.DataEntities.User", b =>
                {
                    b.HasOne("_8anu.Api.Common.DataEntities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}