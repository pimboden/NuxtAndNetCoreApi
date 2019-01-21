using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _8anu.Api.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    slug = table.Column<string>(maxLength: 50, nullable: true),
                    iso2 = table.Column<string>(maxLength: 2, nullable: true),
                    iso3 = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grading_systems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vl_grade = table.Column<string>(maxLength: 5, nullable: true),
                    type = table.Column<string>(maxLength: 50, nullable: true),
                    grade = table.Column<string>(maxLength: 25, nullable: true),
                    category = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grading_systems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    slug = table.Column<string>(maxLength: 255, nullable: true),
                    title = table.Column<string>(maxLength: 100, nullable: true),
                    description = table.Column<string>(nullable: true),
                    date_published = table.Column<DateTime>(nullable: false),
                    legacy_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "test_models",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    message = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_models", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    country_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(nullable: true),
                    published = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.id);
                    table.ForeignKey(
                        name: "FK_areas_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    slug = table.Column<string>(maxLength: 255, nullable: false),
                    first_name = table.Column<string>(maxLength: 30, nullable: false),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    gender = table.Column<int>(nullable: false),
                    country_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "crags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    slug = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    beauty = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    family_friendly = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    walking_time = table.Column<int>(nullable: true),
                    rain_safety = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    height = table.Column<int>(nullable: true),
                    protection = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    parking = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    beginner_friendly = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    latitude = table.Column<double>(nullable: true),
                    longitude = table.Column<double>(nullable: true),
                    area_id = table.Column<int>(nullable: true),
                    season = table.Column<int>(nullable: true),
                    steepness = table.Column<int>(nullable: true),
                    exposition = table.Column<int>(nullable: true),
                    seaside = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    rock_quality = table.Column<int>(nullable: true),
                    category = table.Column<string>(maxLength: 255, nullable: true),
                    published = table.Column<bool>(nullable: false),
                    city = table.Column<string>(maxLength: 100, nullable: true),
                    country_id = table.Column<int>(nullable: false),
                    town = table.Column<string>(maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    approach = table.Column<string>(type: "TEXT", nullable: true),
                    access = table.Column<string>(type: "TEXT", nullable: true),
                    notes = table.Column<string>(type: "TEXT", nullable: true),
                    rock_type = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crags", x => x.id);
                    table.ForeignKey(
                        name: "FK_crags_areas_area_id",
                        column: x => x.area_id,
                        principalTable: "areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_crags_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ascents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTimeOffset>(type: "TIMESTAMP DEFAULT CURRENT_TIMESTAMP", nullable: false),
                    type = table.Column<string>(maxLength: 2, nullable: true),
                    rating = table.Column<int>(nullable: true),
                    project = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    tries = table.Column<int>(nullable: true),
                    repeat = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    difficulty = table.Column<string>(maxLength: 255, nullable: true),
                    steepness = table.Column<int>(nullable: true),
                    protection = table.Column<int>(nullable: true),
                    style = table.Column<string>(maxLength: 6, nullable: true),
                    comment = table.Column<string>(type: "TEXT", nullable: true),
                    zlaggable_id = table.Column<int>(nullable: true),
                    zlaggable_type = table.Column<string>(maxLength: 255, nullable: true),
                    height = table.Column<int>(nullable: true),
                    zlaggable_key = table.Column<string>(maxLength: 255, nullable: true),
                    score = table.Column<int>(nullable: true),
                    sits = table.Column<int>(nullable: true),
                    exclude_from_ranking = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    chipped = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    note = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ascents", x => x.id);
                    table.ForeignKey(
                        name: "FK_ascents_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forum_categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    slug = table.Column<string>(maxLength: 100, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: true),
                    user_id = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_forum_categories_forum_categories_parent_id",
                        column: x => x.parent_id,
                        principalTable: "forum_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_forum_categories_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sectors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    crag_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    latitude = table.Column<double>(nullable: true),
                    longitude = table.Column<double>(nullable: true),
                    ordering = table.Column<int>(nullable: true),
                    category = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sectors", x => x.id);
                    table.ForeignKey(
                        name: "FK_sectors_crags_crag_id",
                        column: x => x.crag_id,
                        principalTable: "crags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forum_threads",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    slug = table.Column<string>(maxLength: 255, nullable: false),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    forum_category_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_threads", x => x.id);
                    table.ForeignKey(
                        name: "FK_forum_threads_forum_categories_forum_category_id",
                        column: x => x.forum_category_id,
                        principalTable: "forum_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_forum_threads_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "boulders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    difficulty = table.Column<string>(maxLength: 10, nullable: false),
                    sector_id = table.Column<int>(nullable: false),
                    topo_num = table.Column<string>(maxLength: 10, nullable: true),
                    reference_width = table.Column<int>(nullable: true),
                    path = table.Column<string>(type: "TEXT", nullable: true),
                    grade = table.Column<string>(maxLength: 255, nullable: true),
                    grading_system = table.Column<string>(maxLength: 255, nullable: true),
                    notes = table.Column<string>(type: "TEXT", nullable: true),
                    sit_down_start = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    traverse = table.Column<sbyte>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boulders", x => x.id);
                    table.ForeignKey(
                        name: "FK_boulders_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    difficulty = table.Column<string>(maxLength: 10, nullable: false),
                    sector_id = table.Column<int>(nullable: false),
                    topo_num = table.Column<string>(maxLength: 10, nullable: true),
                    reference_width = table.Column<int>(nullable: true),
                    path = table.Column<string>(type: "TEXT", nullable: true),
                    grade = table.Column<string>(maxLength: 255, nullable: true),
                    grading_system = table.Column<string>(maxLength: 255, nullable: true),
                    notes = table.Column<string>(type: "TEXT", nullable: true),
                    spit = table.Column<int>(nullable: true),
                    length = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.id);
                    table.ForeignKey(
                        name: "FK_routes_sectors_sector_id",
                        column: x => x.sector_id,
                        principalTable: "sectors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forum_comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    forum_thread_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_forum_comments_forum_threads_forum_thread_id",
                        column: x => x.forum_thread_id,
                        principalTable: "forum_threads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_forum_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_areas_country_id",
                table: "areas",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_ascents_user_id",
                table: "ascents",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ascents_zlaggable_id_zlaggable_type",
                table: "ascents",
                columns: new[] { "zlaggable_id", "zlaggable_type" });

            migrationBuilder.CreateIndex(
                name: "IX_boulders_sector_id",
                table: "boulders",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "IX_crags_area_id",
                table: "crags",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_crags_country_id",
                table: "crags",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_crags_slug_category",
                table: "crags",
                columns: new[] { "slug", "category" });

            migrationBuilder.CreateIndex(
                name: "IX_forum_categories_parent_id",
                table: "forum_categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_forum_categories_user_id",
                table: "forum_categories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_forum_comments_forum_thread_id",
                table: "forum_comments",
                column: "forum_thread_id");

            migrationBuilder.CreateIndex(
                name: "IX_forum_comments_user_id",
                table: "forum_comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_forum_threads_forum_category_id",
                table: "forum_threads",
                column: "forum_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_forum_threads_user_id",
                table: "forum_threads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_forum_threads_slug_forum_category_id",
                table: "forum_threads",
                columns: new[] { "slug", "forum_category_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_routes_sector_id",
                table: "routes",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "IX_sectors_crag_id",
                table: "sectors",
                column: "crag_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_country_id",
                table: "users",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ascents");

            migrationBuilder.DropTable(
                name: "boulders");

            migrationBuilder.DropTable(
                name: "forum_comments");

            migrationBuilder.DropTable(
                name: "grading_systems");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "test_models");

            migrationBuilder.DropTable(
                name: "forum_threads");

            migrationBuilder.DropTable(
                name: "sectors");

            migrationBuilder.DropTable(
                name: "forum_categories");

            migrationBuilder.DropTable(
                name: "crags");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
