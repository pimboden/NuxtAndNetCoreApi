using Microsoft.EntityFrameworkCore;

namespace _8anu.Data.Migration.Model
{
    public partial class _8a_oldContext : DbContext
    {
        public virtual DbSet<AnnaMilReport> AnnaMilReport { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<ArticlesCategories> ArticlesCategories { get; set; }
        public virtual DbSet<CardCounter> CardCounter { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<CookieTest> CookieTest { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CountryActive> CountryActive { get; set; }
        public virtual DbSet<Crag> Crag { get; set; }
        public virtual DbSet<CragArea> CragArea { get; set; }
        public virtual DbSet<CragAscents> CragAscents { get; set; }
        public virtual DbSet<CragAutoSuggest> CragAutoSuggest { get; set; }
        public virtual DbSet<CragBestGrades> CragBestGrades { get; set; }
        public virtual DbSet<CragComments> CragComments { get; set; }
        public virtual DbSet<CragEditBy> CragEditBy { get; set; }
        public virtual DbSet<CragEnvironment> CragEnvironment { get; set; }
        public virtual DbSet<CragHeight> CragHeight { get; set; }
        public virtual DbSet<CragHolds> CragHolds { get; set; }
        public virtual DbSet<CragInfo> CragInfo { get; set; }
        public virtual DbSet<CragNegFeatures> CragNegFeatures { get; set; }
        public virtual DbSet<CragNoOfRoutes> CragNoOfRoutes { get; set; }
        public virtual DbSet<CragOverhang> CragOverhang { get; set; }
        public virtual DbSet<CragPosFeatures> CragPosFeatures { get; set; }
        public virtual DbSet<CragRoadMap> CragRoadMap { get; set; }
        public virtual DbSet<CragRockType> CragRockType { get; set; }
        public virtual DbSet<CragSectors> CragSectors { get; set; }
        public virtual DbSet<CragSunshine> CragSunshine { get; set; }
        public virtual DbSet<CragTopos> CragTopos { get; set; }
        public virtual DbSet<CragUserRating> CragUserRating { get; set; }
        public virtual DbSet<CragWalk> CragWalk { get; set; }
        public virtual DbSet<CragWhere> CragWhere { get; set; }
        public virtual DbSet<ForumMessageCount> ForumMessageCount { get; set; }
        public virtual DbSet<ForumNicks> ForumNicks { get; set; }
        public virtual DbSet<Forums> Forums { get; set; }
        public virtual DbSet<ForumSections> ForumSections { get; set; }
        public virtual DbSet<ForumsLastpost> ForumsLastpost { get; set; }
        public virtual DbSet<ForumThreads> ForumThreads { get; set; }
        public virtual DbSet<GalleryCategories> GalleryCategories { get; set; }
        public virtual DbSet<GalleryPaths> GalleryPaths { get; set; }
        public virtual DbSet<GalleryPics> GalleryPics { get; set; }
        public virtual DbSet<GalleryRatingSum> GalleryRatingSum { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<HackerDetection> HackerDetection { get; set; }
        public virtual DbSet<ImagesFirstpage> ImagesFirstpage { get; set; }
        public virtual DbSet<LinkCategories> LinkCategories { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MobileSavedSession> MobileSavedSession { get; set; }
        public virtual DbSet<MyUpdates> MyUpdates { get; set; }
        public virtual DbSet<NewsAll> NewsAll { get; set; }
        public virtual DbSet<ObjectClasses> ObjectClasses { get; set; }
        public virtual DbSet<ObjectClassesSub> ObjectClassesSub { get; set; }
        public virtual DbSet<ObjectComments> ObjectComments { get; set; }
        public virtual DbSet<ObjectCommentsBeta> ObjectCommentsBeta { get; set; }
        public virtual DbSet<ObjectXml> ObjectXml { get; set; }
        public virtual DbSet<Passlist> Passlist { get; set; }
        public virtual DbSet<PointsGrade> PointsGrade { get; set; }
        public virtual DbSet<PointsHow> PointsHow { get; set; }
        public virtual DbSet<PollDaddy> PollDaddy { get; set; }
        public virtual DbSet<PollData> PollData { get; set; }
        public virtual DbSet<PollQs> PollQs { get; set; }
        public virtual DbSet<ProductNews> ProductNews { get; set; }
        public virtual DbSet<Punkter> Punkter { get; set; }
        public virtual DbSet<QuickSearch> QuickSearch { get; set; }
        public virtual DbSet<Ranking> Ranking { get; set; }
        public virtual DbSet<RankingAllTime> RankingAllTime { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<ScoreGrades> ScoreGrades { get; set; }
        public virtual DbSet<ScoreGradesBeta> ScoreGradesBeta { get; set; }
        public virtual DbSet<ScoreHow> ScoreHow { get; set; }
        public virtual DbSet<ScoreNotes> ScoreNotes { get; set; }
        public virtual DbSet<ScoreUpdates> ScoreUpdates { get; set; }
        public virtual DbSet<ScoreYellowGrades> ScoreYellowGrades { get; set; }
        public virtual DbSet<SessionTokens> SessionTokens { get; set; }
        public virtual DbSet<ShopOrders> ShopOrders { get; set; }
        public virtual DbSet<ShopProducts> ShopProducts { get; set; }
        public virtual DbSet<ShopSuppliers> ShopSuppliers { get; set; }
        public virtual DbSet<SiScore> SiScore { get; set; }
        public virtual DbSet<Sponsors> Sponsors { get; set; }
        public virtual DbSet<SponsorsBanners> SponsorsBanners { get; set; }
        public virtual DbSet<SponsorsBannersClicks> SponsorsBannersClicks { get; set; }
        public virtual DbSet<SponsorsCampaignsBeta> SponsorsCampaignsBeta { get; set; }
        public virtual DbSet<SponsorsContestants> SponsorsContestants { get; set; }
        public virtual DbSet<StatObjektImpressions> StatObjektImpressions { get; set; }
        public virtual DbSet<StatPagesAlias> StatPagesAlias { get; set; }
        public virtual DbSet<Traininglog> Traininglog { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }
        public virtual DbSet<UserinfoAddress> UserinfoAddress { get; set; }
        public virtual DbSet<UserLinks> UserLinks { get; set; }
        public virtual DbSet<Userloggedin> Userloggedin { get; set; }
        public virtual DbSet<Useronline> Useronline { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }
        public virtual DbSet<VotingAlternatives> VotingAlternatives { get; set; }
        public virtual DbSet<Votings> Votings { get; set; }
        public virtual DbSet<WwwGradjustering> WwwGradjustering { get; set; }
        public virtual DbSet<YellowPages> YellowPages { get; set; }

        // Unable to generate entity type for table 'adminLocalSite'. Please see the warning messages.
        // Unable to generate entity type for table 'cookie'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_best_grades_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_comments_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_environment_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_guides'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_height_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_holds_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_neg_features_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_no_of_routes_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_overhang_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_pictures'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_pos_features_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_road_map_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_rock_type_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_sunshine_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_walk_val'. Please see the warning messages.
        // Unable to generate entity type for table 'crag_where_val'. Please see the warning messages.
        // Unable to generate entity type for table 'forum_delmsg'. Please see the warning messages.
        // Unable to generate entity type for table 'galleryRating'. Please see the warning messages.
        // Unable to generate entity type for table 'mail_list'. Please see the warning messages.
        // Unable to generate entity type for table 'news_all_onlocal'. Please see the warning messages.
        // Unable to generate entity type for table 'pages'. Please see the warning messages.
        // Unable to generate entity type for table 'password_reset_tokens'. Please see the warning messages.
        // Unable to generate entity type for table 'ranking_snapshot'. Please see the warning messages.
        // Unable to generate entity type for table 'shop_cart'. Please see the warning messages.
        // Unable to generate entity type for table 'sponsors_banners_country'. Please see the warning messages.
        // Unable to generate entity type for table 'stat_page_hits'. Please see the warning messages.
        // Unable to generate entity type for table 'stat_pages'. Please see the warning messages.
        // Unable to generate entity type for table 'statistik_data'. Please see the warning messages.
        // Unable to generate entity type for table 'statistik_namn'. Please see the warning messages.
        // Unable to generate entity type for table 'updates_time'. Please see the warning messages.
        // Unable to generate entity type for table 'user_visits'. Please see the warning messages.
        // Unable to generate entity type for table 'votingsCountry'. Please see the warning messages.
        // Unable to generate entity type for table 'yellow_grades'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Data Source=localhost;Initial Catalog=8a_legacy_live;;User ID=root;;Password=BpJ9yHGn;Convert Zero Datetime=True;TreatTinyAsBoolean=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnaMilReport>(entity =>
            {
                entity.ToTable("anna_mil_report");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasColumnName("customer")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Dist)
                    .HasColumnName("dist")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.End)
                    .IsRequired()
                    .HasColumnName("end")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasColumnName("from")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Start)
                    .IsRequired()
                    .HasColumnName("start")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasColumnName("to")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.ToTable("articles");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("categoryId");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("index_countryCode");

                entity.HasIndex(e => e.ObjectCls)
                    .HasName("index_objectCLS");

                entity.HasIndex(e => new { e.CategoryId, e.ObjectCls, e.UserId, e.Hide })
                    .HasName("ix_getUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasMaxLength(6);

                entity.Property(e => e.EditDate)
                    .HasColumnName("editDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Hide)
                    .HasColumnName("hide")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Html)
                    .IsRequired()
                    .HasColumnName("html");

                entity.Property(e => e.LangCountryCode)
                    .IsRequired()
                    .HasColumnName("langCountryCode")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectCls)
                    .IsRequired()
                    .HasColumnName("objectCLS")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(150);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.VideoBlog)
                    .HasColumnName("videoBlog")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ArticlesCategories>(entity =>
            {
                entity.ToTable("articles_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(50)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CardCounter>(entity =>
            {
                entity.ToTable("cardCounter");

                entity.HasIndex(e => new { e.UserId, e.PageId })
                    .HasName("userID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PageId)
                    .HasColumnName("pageID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("configuration");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CookieTest>(entity =>
            {
                entity.ToTable("cookieTest");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrowserInfo)
                    .IsRequired()
                    .HasColumnName("browserInfo");

                entity.Property(e => e.CookieTest1)
                    .HasColumnName("cookieTest")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("time")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("country");

                entity.HasIndex(e => e.Short)
                    .HasName("index_short");

                //entity.Property(e => e.DatabaseId)
                //      .HasColumnName("id");

                entity.Property(e => e.Short)
                    .HasColumnName("short")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Iso)
                    .HasColumnName("iso")
                    .HasMaxLength(2);

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(100);

                entity.Property(e => e.Whole)
                    .IsRequired()
                    .HasColumnName("whole")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CountryActive>(entity =>
            {
                entity.HasKey(e => e.PriOrder);

                entity.ToTable("countryActive");

                entity.Property(e => e.PriOrder)
                    .HasColumnName("priOrder")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("id")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Crag>(entity =>
            {
                entity.ToTable("crag");

                entity.HasIndex(e => e.CountryId)
                    .HasName("crag_country");

                entity.HasIndex(e => new { e.Name, e.CountryId, e.Type })
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessInfo)
                    .IsRequired()
                    .HasColumnName("access_info")
                    .HasColumnType("text");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AscentEditDate)
                    .HasColumnName("ascent_edit_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.AscentOs)
                    .HasColumnName("ascent_os")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.AscentRate)
                    .HasColumnName("ascent_rate")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.AscentRate1year)
                    .HasColumnName("ascent_rate_1year")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.Ascents)
                    .HasColumnName("ascents")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ascents1year)
                    .HasColumnName("ascents_1year")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasColumnName("country_id")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CragAreaId)
                    .HasColumnName("crag_area_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Dbscore)
                    .HasColumnName("dbscore")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.DriveTime)
                    .IsRequired()
                    .HasColumnName("drive_time")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EditDate)
                    .HasColumnName("edit_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.GoggleMapX)
                    .IsRequired()
                    .HasColumnName("goggleMapX")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GoggleMapY)
                    .IsRequired()
                    .HasColumnName("goggleMapY")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(150);

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasColumnName("sname")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TotalRate)
                    .HasColumnName("total_rate")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragArea>(entity =>
            {
                entity.ToTable("crag_area");

                entity.HasIndex(e => new { e.Name, e.CountryId })
                    .HasName("ix_cragname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasColumnName("country_id")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragAscents>(entity =>
            {
                entity.ToTable("crag_ascents");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ascents)
                    .HasColumnName("ascents")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CragId)
                    .HasColumnName("crag_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CragSectorId)
                    .HasColumnName("crag_sector_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GradeComment)
                    .IsRequired()
                    .HasColumnName("grade_comment")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasColumnName("grade_name")
                    .HasMaxLength(5)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OsRate)
                    .HasColumnName("osRate")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Qindex)
                    .HasColumnName("qindex")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.Property(e => e.TopoDesc)
                    .IsRequired()
                    .HasColumnName("topo_desc")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TopoNum)
                    .HasColumnName("topo_num")
                    .HasColumnType("float(10,1)")
                    .HasDefaultValueSql("'0.0'");
            });

            modelBuilder.Entity<CragAutoSuggest>(entity =>
            {
                entity.ToTable("crag_auto_suggest");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ascents)
                    .HasColumnName("ascents")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Dataval)
                    .IsRequired()
                    .HasColumnName("dataval")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragBestGrades>(entity =>
            {
                entity.HasKey(e => e.BestGradesId);

                entity.ToTable("crag_best_grades");

                entity.Property(e => e.BestGradesId).HasColumnName("best_grades_id");

                entity.Property(e => e.BestGrades)
                    .IsRequired()
                    .HasColumnName("best_grades")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragComments>(entity =>
            {
                entity.ToTable("crag_comments");

                entity.Property(e => e.CragCommentsId).HasColumnName("crag_comments_id");

                entity.Property(e => e.CragComments1)
                    .IsRequired()
                    .HasColumnName("crag_comments")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<CragEditBy>(entity =>
            {
                entity.HasKey(e => e.CragId);

                entity.ToTable("crag_edit_by");

                entity.Property(e => e.CragId)
                    .HasColumnName("crag_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragEnvironment>(entity =>
            {
                entity.HasKey(e => e.EnvironmentId);

                entity.ToTable("crag_environment");

                entity.Property(e => e.EnvironmentId).HasColumnName("environment_id");

                entity.Property(e => e.Environment)
                    .IsRequired()
                    .HasColumnName("environment")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RatingValues)
                    .HasColumnName("rating_values")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragHeight>(entity =>
            {
                entity.HasKey(e => e.HeightId);

                entity.ToTable("crag_height");

                entity.Property(e => e.HeightId).HasColumnName("height_id");

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasColumnName("height")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragHolds>(entity =>
            {
                entity.HasKey(e => e.CragHoldId);

                entity.ToTable("crag_holds");

                entity.Property(e => e.CragHoldId)
                    .HasColumnName("crag_hold_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Hold)
                    .IsRequired()
                    .HasColumnName("hold")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CragInfo>(entity =>
            {
                entity.HasKey(e => e.CragId);

                entity.ToTable("crag_info");

                entity.Property(e => e.CragId)
                    .HasColumnName("crag_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CragStatus)
                    .HasColumnName("crag_status")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragNegFeatures>(entity =>
            {
                entity.HasKey(e => e.NegFeaturesId);

                entity.ToTable("crag_neg_features");

                entity.Property(e => e.NegFeaturesId).HasColumnName("neg_features_id");

                entity.Property(e => e.NegFeatures)
                    .IsRequired()
                    .HasColumnName("neg_features")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RatingValues)
                    .HasColumnName("rating_values")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragNoOfRoutes>(entity =>
            {
                entity.HasKey(e => e.NoOfRouteId);

                entity.ToTable("crag_no_of_routes");

                entity.Property(e => e.NoOfRouteId).HasColumnName("no_of_route_id");

                entity.Property(e => e.NoOfRoute)
                    .IsRequired()
                    .HasColumnName("no_of_route")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RatingValues)
                    .HasColumnName("rating_values")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragOverhang>(entity =>
            {
                entity.HasKey(e => e.OverhangId);

                entity.ToTable("crag_overhang");

                entity.Property(e => e.OverhangId).HasColumnName("overhang_id");

                entity.Property(e => e.Overhang)
                    .IsRequired()
                    .HasColumnName("overhang")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragPosFeatures>(entity =>
            {
                entity.HasKey(e => e.PosFeaturesId);

                entity.ToTable("crag_pos_features");

                entity.Property(e => e.PosFeaturesId).HasColumnName("pos_features_id");

                entity.Property(e => e.PosFeatures)
                    .IsRequired()
                    .HasColumnName("pos_features")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RatingValues)
                    .HasColumnName("rating_values")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragRoadMap>(entity =>
            {
                entity.HasKey(e => e.RoadMapId);

                entity.ToTable("crag_road_map");

                entity.Property(e => e.RoadMapId).HasColumnName("road_map_id");

                entity.Property(e => e.RoadMap)
                    .IsRequired()
                    .HasColumnName("road_map")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<CragRockType>(entity =>
            {
                entity.HasKey(e => e.RockTypeId);

                entity.ToTable("crag_rock_type");

                entity.Property(e => e.RockTypeId).HasColumnName("rock_type_id");

                entity.Property(e => e.RockType)
                    .IsRequired()
                    .HasColumnName("rock_type")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CragSectors>(entity =>
            {
                entity.ToTable("crag_sectors");

                entity.HasIndex(e => new { e.Name, e.CragId })
                    .HasName("index_sectorname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Ascents)
                    .HasColumnName("ascents")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CragId)
                    .HasColumnName("crag_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GoggleMapX)
                    .IsRequired()
                    .HasColumnName("goggleMapX")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GoggleMapY)
                    .IsRequired()
                    .HasColumnName("goggleMapY")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnName("info")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CragSunshine>(entity =>
            {
                entity.HasKey(e => e.SunshineId);

                entity.ToTable("crag_sunshine");

                entity.Property(e => e.SunshineId).HasColumnName("sunshine_id");

                entity.Property(e => e.Sunshine)
                    .IsRequired()
                    .HasColumnName("sunshine")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CragTopos>(entity =>
            {
                entity.HasKey(e => e.TopoId);

                entity.ToTable("crag_topos");

                entity.Property(e => e.TopoId)
                    .HasColumnName("topo_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CragId)
                    .HasColumnName("crag_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragUserRating>(entity =>
            {
                entity.HasKey(e => new { e.CragId, e.UserId });

                entity.ToTable("crag_user_rating");

                entity.Property(e => e.CragId)
                    .HasColumnName("crag_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ground)
                    .HasColumnName("ground")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Protection)
                    .HasColumnName("protection")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rock)
                    .HasColumnName("rock")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Scenary)
                    .HasColumnName("scenary")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Walk)
                    .HasColumnName("walk")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Warmup)
                    .HasColumnName("warmup")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CragWalk>(entity =>
            {
                entity.HasKey(e => e.WalkId);

                entity.ToTable("crag_walk");

                entity.Property(e => e.WalkId).HasColumnName("walk_id");

                entity.Property(e => e.RatingValues)
                    .HasColumnName("rating_values")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Walk)
                    .IsRequired()
                    .HasColumnName("walk")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CragWhere>(entity =>
            {
                entity.ToTable("crag_where");

                entity.Property(e => e.CragWhereId)
                    .HasColumnName("crag_where_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CragWhereName)
                    .IsRequired()
                    .HasColumnName("crag_where_name")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ForumMessageCount>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("forumMessageCount");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MsgCount)
                    .HasColumnName("msgCount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ForumNicks>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("forum_nicks");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasColumnName("nick")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Forums>(entity =>
            {
                entity.HasKey(e => e.ForumId);

                entity.ToTable("forums");

                entity.HasIndex(e => e.Country)
                    .HasName("index_country");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("index_objectId");

                entity.HasIndex(e => e.SectionId)
                    .HasName("index_sectionId");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_userId");

                entity.Property(e => e.ForumId)
                    .HasColumnName("forumId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ForumChild)
                    .HasColumnName("forumChild")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ForumDate)
                    .HasColumnName("forumDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ForumMsg)
                    .IsRequired()
                    .HasColumnName("forumMsg");

                entity.Property(e => e.ForumSub)
                    .IsRequired()
                    .HasColumnName("forumSub")
                    .HasColumnType("text");

                entity.Property(e => e.ForumThread)
                    .HasColumnName("forumThread")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Hits)
                    .HasColumnName("hits")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasColumnType("text");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SectionId)
                    .HasColumnName("sectionId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserType)
                    .HasColumnName("userType")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ForumSections>(entity =>
            {
                entity.ToTable("forum_sections");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasColumnName("desc")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastObjectCommentInfo)
                    .IsRequired()
                    .HasColumnName("lastObjectCommentInfo")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Posts)
                    .HasColumnName("posts")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Threads)
                    .HasColumnName("threads")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ForumsLastpost>(entity =>
            {
                entity.HasKey(e => e.ForumId);

                entity.ToTable("forums_lastpost");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.ForumId)
                    .HasColumnName("forumId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Posts)
                    .HasColumnName("posts")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ForumThreads>(entity =>
            {
                entity.ToTable("forum_threads");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("countryCode");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("objectId");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Head)
                    .IsRequired()
                    .HasColumnName("head")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Html)
                    .IsRequired()
                    .HasColumnName("html");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastObjectCommentDate)
                    .HasColumnName("lastObjectCommentDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.LastObjectCommentId)
                    .HasColumnName("lastObjectCommentId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MessageCount)
                    .HasColumnName("messageCount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(150);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<GalleryCategories>(entity =>
            {
                entity.HasKey(e => e.GalleryCatId);

                entity.ToTable("galleryCategories");

                entity.Property(e => e.GalleryCatId)
                    .HasColumnName("galleryCatId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GalleryCatDesc)
                    .HasColumnName("galleryCatDesc")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<GalleryPaths>(entity =>
            {
                entity.HasKey(e => e.GalleryPathId);

                entity.ToTable("galleryPaths");

                entity.Property(e => e.GalleryPathId)
                    .HasColumnName("galleryPathId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GalleryPath)
                    .HasColumnName("galleryPath")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GalleryPathDesc)
                    .HasColumnName("galleryPathDesc")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<GalleryPics>(entity =>
            {
                entity.HasKey(e => e.GalleryId);

                entity.ToTable("galleryPics");

                entity.HasIndex(e => e.GalleryPicSelected)
                    .HasName("galleryPicSelected");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.GalleryId)
                    .HasColumnName("galleryId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CragId)
                    .HasColumnName("cragId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GalleryCatyId)
                    .HasColumnName("galleryCatyId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GalleryDate)
                    .HasColumnName("galleryDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.GalleryPathId)
                    .HasColumnName("galleryPathId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GalleryPic)
                    .HasColumnName("galleryPic")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GalleryPicConvertedName)
                    .IsRequired()
                    .HasColumnName("galleryPicConvertedName")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GalleryPicDesc)
                    .IsRequired()
                    .HasColumnName("galleryPicDesc");

                entity.Property(e => e.GalleryPicHeight)
                    .HasColumnName("galleryPicHeight")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GalleryPicPhotografer)
                    .IsRequired()
                    .HasColumnName("galleryPicPhotografer")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GalleryPicResz)
                    .HasColumnName("galleryPicResz")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GalleryPicSelected)
                    .HasColumnName("galleryPicSelected")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GalleryPicSelectedDate)
                    .HasColumnName("galleryPicSelectedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.GalleryPicThmn)
                    .HasColumnName("galleryPicThmn")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GalleryPicWidth)
                    .HasColumnName("galleryPicWidth")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<GalleryRatingSum>(entity =>
            {
                entity.HasKey(e => e.GalleryId);

                entity.ToTable("galleryRatingSum");

                entity.Property(e => e.GalleryId)
                    .HasColumnName("galleryId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.VoteCount)
                    .HasColumnName("voteCount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.VoteRating)
                    .HasColumnName("voteRating")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.ToTable("grades");

                entity.HasIndex(e => e.Boulder)
                    .HasName("boulder");

                entity.HasIndex(e => e.Grade)
                    .HasName("grade");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Boulder)
                    .IsRequired()
                    .HasColumnName("boulder")
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<HackerDetection>(entity =>
            {
                entity.ToTable("hacker_detection");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cookies)
                    .HasColumnName("cookies")
                    .HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                      .HasColumnType("timestamp");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasMaxLength(255);

                entity.Property(e => e.Server)
                    .HasColumnName("server")
                    .HasColumnType("text");

                entity.Property(e => e.Vars)
                    .HasColumnName("vars")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ImagesFirstpage>(entity =>
            {
                entity.ToTable("images_firstpage");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("countryCode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FootText)
                    .HasColumnName("footText")
                    .HasMaxLength(255);

                entity.Property(e => e.FootUrl)
                    .HasColumnName("footUrl")
                    .HasMaxLength(255);

                entity.Property(e => e.HeadText)
                    .HasColumnName("headText")
                    .HasMaxLength(255);

                entity.Property(e => e.HeadUrl)
                    .HasColumnName("headUrl")
                    .HasMaxLength(255);

                entity.Property(e => e.Hide)
                    .HasColumnName("hide")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("imageUrl")
                    .HasMaxLength(255);

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<LinkCategories>(entity =>
            {
                entity.ToTable("linkCategories");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("messages");

                entity.HasIndex(e => e.FromUserId)
                    .HasName("FromUserID");

                entity.HasIndex(e => e.ToUserId)
                    .HasName("ToUserID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.FromUserDelete)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FromUserId)
                    .HasColumnName("FromUserID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HasBeenRead)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Htmlmessage)
                    .IsRequired()
                    .HasColumnName("HTMLMessage");

                entity.Property(e => e.MessageSubject).HasMaxLength(255);

                entity.Property(e => e.ObjectCls)
                    .IsRequired()
                    .HasColumnName("objectCLS")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ParentMessageId).HasColumnName("ParentMessageID");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.SendDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.TextMessage).IsRequired();

                entity.Property(e => e.ToUserDelete)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ToUserId)
                    .HasColumnName("ToUserID")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<MobileSavedSession>(entity =>
            {
                entity.ToTable("mobile_saved_session");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NetSessionId)
                    .IsRequired()
                    .HasColumnName("netSessionId")
                    .HasColumnType("char(24)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<MyUpdates>(entity =>
            {
                entity.ToTable("myUpdates");

                entity.HasIndex(e => e.MyUserId)
                    .HasName("myUserId");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("ObjectClass");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MyUserId)
                    .HasColumnName("myUserId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'CLS_UserAscentUpdate'");

                entity.Property(e => e.ObjectValue1)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<NewsAll>(entity =>
            {
                entity.ToTable("news_all");

                entity.HasIndex(e => e.Country)
                    .HasName("index_country");

                entity.HasIndex(e => e.Datum)
                    .HasName("index_date");

                entity.HasIndex(e => e.Headline)
                    .HasName("headline");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(10);

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Debate)
                    .HasColumnName("debate")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Headline)
                    .HasColumnName("headline")
                    .HasColumnType("tinyint(3)");

                entity.Property(e => e.Hide)
                    .HasColumnName("hide")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Image2)
                    .IsRequired()
                    .HasColumnName("image2")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Kategori)
                    .HasColumnName("kategori")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.KeepAlive)
                    .HasColumnName("keepAlive")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OnAll)
                    .HasColumnName("onAll")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rubrik)
                    .IsRequired()
                    .HasColumnName("rubrik")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(150);

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Var)
                    .HasColumnName("var")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ObjectClasses>(entity =>
            {
                entity.ToTable("object_classes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasColumnName("desc")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ObjectClassesSub>(entity =>
            {
                entity.ToTable("object_classes_sub");

                entity.HasIndex(e => e.MasterClass)
                    .HasName("MasterClass");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasColumnName("desc")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MasterClass)
                    .IsRequired()
                    .HasColumnName("masterClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SubClass)
                    .IsRequired()
                    .HasColumnName("subClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ObjectComments>(entity =>
            {
                entity.ToTable("object_comments");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("objectId");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.HasIndex(e => new { e.ObjectId, e.ObjectClass })
                    .HasName("ix_objectIdClass");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Head)
                    .IsRequired()
                    .HasColumnName("head")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Html)
                    .IsRequired()
                    .HasColumnName("html");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(150);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ObjectCommentsBeta>(entity =>
            {
                entity.ToTable("object_comments_beta");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("objectId");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.HasIndex(e => new { e.ObjectId, e.ObjectClass })
                    .HasName("ix_objectIdClass");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Head)
                    .IsRequired()
                    .HasColumnName("head")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Html)
                    .IsRequired()
                    .HasColumnName("html");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ObjectXml>(entity =>
            {
                entity.ToTable("object_xml");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("objectId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Xml)
                    .IsRequired()
                    .HasColumnName("xml");
            });

            modelBuilder.Entity<Passlist>(entity =>
            {
                entity.ToTable("passlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasMaxLength(255);

                entity.Property(e => e.HashHash)
                    .HasColumnName("hash_hash")
                    .HasMaxLength(255);

                entity.Property(e => e.LastChanged)
                    .HasColumnName("last_changed")
                      .HasColumnType("timestamp");
                    
            });

            modelBuilder.Entity<PointsGrade>(entity =>
            {
                entity.HasKey(e => e.Grade);

                entity.ToTable("points_grade");

                entity.HasIndex(e => e.Grade)
                    .HasName("grade");

                entity.HasIndex(e => e.Score)
                    .HasName("index_score");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Boulder)
                    .IsRequired()
                    .HasColumnName("boulder")
                    .HasColumnType("char(5)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<PointsHow>(entity =>
            {
                entity.HasKey(e => e.How);

                entity.ToTable("points_how");

                entity.HasIndex(e => e.How)
                    .HasName("how");

                entity.Property(e => e.How)
                    .HasColumnName("how")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("smallint(3)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<PollDaddy>(entity =>
            {
                entity.ToTable("poll_daddy");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script")
                    .HasColumnType("text");

                entity.Property(e => e.ShowResult)
                    .HasColumnName("show_result")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<PollData>(entity =>
            {
                entity.ToTable("poll_data");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.QId)
                    .HasColumnName("qId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<PollQs>(entity =>
            {
                entity.ToTable("poll_qs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ProductNews>(entity =>
            {
                entity.ToTable("product_news");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("countryCode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HeadText)
                    .IsRequired()
                    .HasColumnName("headText")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HeadUrl)
                    .IsRequired()
                    .HasColumnName("headUrl")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("imageUrl")
                    .HasMaxLength(255);

                entity.Property(e => e.MoShortText)
                    .HasColumnName("moShortText")
                    .HasMaxLength(255);

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ReviewUrl)
                    .HasColumnName("reviewUrl")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Punkter>(entity =>
            {
                entity.ToTable("punkter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Topic)
                    .HasColumnName("topic")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<QuickSearch>(entity =>
            {
                entity.ToTable("quick_search");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("ix_objectId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AscentType)
                    .HasColumnName("ascentType")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sql)
                    .IsRequired()
                    .HasColumnName("sql")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("ranking");

                entity.HasIndex(e => e.Participate)
                    .HasName("participate");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AgeBonus)
                    .HasColumnName("age_bonus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BoulderScore)
                    .HasColumnName("boulder_score")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OsScore)
                    .HasColumnName("os_score")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OsScoreB)
                    .HasColumnName("os_score_b")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Participate)
                    .HasColumnName("participate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RouteScore)
                    .HasColumnName("route_score")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TradScore)
                    .HasColumnName("trad_score")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<RankingAllTime>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("ranking_all_time");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BoulderScore)
                    .HasColumnName("boulder_score")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Participate)
                    .HasColumnName("participate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RouteScore)
                    .HasColumnName("route_score")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TradScore)
                    .HasColumnName("trad_score")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.ToTable("routes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(4);

                entity.Property(e => e.Crag)
                    .HasColumnName("crag")
                    .HasMaxLength(30);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.Hard).HasColumnName("hard");

                entity.Property(e => e.How).HasColumnName("how");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.Soft).HasColumnName("soft");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("score");

                entity.HasIndex(e => e.Country)
                    .HasName("country");

                entity.HasIndex(e => e.Crag)
                    .HasName("crag");

                entity.HasIndex(e => e.Date)
                    .HasName("date");

                entity.HasIndex(e => e.Fa)
                    .HasName("fa");

                entity.HasIndex(e => e.Grade)
                    .HasName("grade");

                entity.HasIndex(e => e.How)
                    .HasName("how");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("ObjectClass");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.HasIndex(e => e.What)
                    .HasName("what");

                entity.HasIndex(e => new { e.Chipped, e.What })
                    .HasName("index_chipped");

                entity.HasIndex(e => new { e.ObjectClass, e.UserRecommended })
                    .HasName("index_recommended");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altgrade)
                    .HasColumnName("altgrade")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Chipped)
                    .HasColumnName("chipped")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Crag)
                    .HasColumnName("crag")
                    .HasMaxLength(50);

                entity.Property(e => e.CragSector)
                    .HasColumnName("cragSector")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExcludeFromRanking)
                    .HasColumnName("excludeFromRanking")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Fa)
                    .HasColumnName("fa")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.How)
                    .HasColumnName("how")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'CLS_UserAscent'");

                entity.Property(e => e.ProjectAscentDate)
                    .HasColumnName("projectAscentDate")
                    .HasMaxLength(30);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RecDate)
                    .HasColumnName("recDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'2005-01-31 00:00:00'");

                entity.Property(e => e.Repeat)
                    .HasColumnName("repeat")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Scrag)
                    .HasColumnName("scrag")
                    .HasMaxLength(30);

                entity.Property(e => e.Steepness).HasColumnName("steepness");

                entity.Property(e => e.TotalScore)
                    .HasColumnName("totalScore")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserRecommended)
                    .HasColumnName("userRecommended")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.What)
                    .HasColumnName("what")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.YellowId)
                    .HasColumnName("yellowId")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ScoreGrades>(entity =>
            {
                entity.ToTable("score_grades");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FraBoulder)
                    .IsRequired()
                    .HasColumnName("fraBoulder")
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FraGrade)
                    .IsRequired()
                    .HasColumnName("fraGrade")
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Hueco)
                    .IsRequired()
                    .HasColumnName("hueco")
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UsaGrade)
                    .IsRequired()
                    .HasColumnName("usaGrade")
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ScoreGradesBeta>(entity =>
            {
                entity.ToTable("score_grades_beta");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FraBoulders)
                    .IsRequired()
                    .HasColumnName("fra_boulders")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FraBouldersInput).HasColumnName("fra_boulders_input");

                entity.Property(e => e.FraBouldersSelector).HasColumnName("fra_boulders_selector");

                entity.Property(e => e.FraRoutes)
                    .IsRequired()
                    .HasColumnName("fra_routes")
                    .HasColumnType("char(12)");

                entity.Property(e => e.FraRoutesInput).HasColumnName("fra_routes_input");

                entity.Property(e => e.FraRoutesSelector).HasColumnName("fra_routes_selector");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.UsaBoulders)
                    .IsRequired()
                    .HasColumnName("usa_boulders")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UsaBouldersInput).HasColumnName("usa_boulders_input");

                entity.Property(e => e.UsaBouldersSelector).HasColumnName("usa_boulders_selector");

                entity.Property(e => e.UsaRoutes)
                    .IsRequired()
                    .HasColumnName("usa_routes")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UsaRoutesInput).HasColumnName("usa_routes_input");

                entity.Property(e => e.UsaRoutesSelector).HasColumnName("usa_routes_selector");
            });

            modelBuilder.Entity<ScoreHow>(entity =>
            {
                entity.ToTable("score_how");

                entity.HasIndex(e => e.Id)
                    .HasName("how");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("smallint(3)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ScoreNotes>(entity =>
            {
                entity.ToTable("score_notes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(20)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ScoreBoulder)
                    .HasColumnName("scoreBoulder")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ScoreUpdates>(entity =>
            {
                entity.ToTable("score_updates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AscentId)
                    .HasColumnName("ascentId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<ScoreYellowGrades>(entity =>
            {
                entity.ToTable("score_yellow_grades");

                entity.HasIndex(e => e.Crag)
                    .HasName("index_crag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AscentType)
                    .HasColumnName("ascentType")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Crag)
                    .IsRequired()
                    .HasColumnName("crag")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Grades)
                    .IsRequired()
                    .HasColumnName("grades")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<SessionTokens>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("session_tokens");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ShopOrders>(entity =>
            {
                entity.ToTable("shop_orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CartId)
                    .HasColumnName("cartId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("currency")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CustInfo)
                    .IsRequired()
                    .HasColumnName("custInfo");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.DibstransactId)
                    .HasColumnName("DIBSTransactId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("orderId")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OrderInfo)
                    .IsRequired()
                    .HasColumnName("orderInfo");

                entity.Property(e => e.PaymentWindow)
                    .HasColumnName("paymentWindow")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TotalVat)
                    .HasColumnName("totalVAT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ShopProducts>(entity =>
            {
                entity.ToTable("shop_products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categories)
                    .HasColumnName("categories")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("currency")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasColumnName("desc")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Mediate)
                    .HasColumnName("mediate")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NoPayment)
                    .HasColumnName("noPayment")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OrginalPrice)
                    .IsRequired()
                    .HasColumnName("orginalPrice")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Pic)
                    .IsRequired()
                    .HasColumnName("pic")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SupId)
                    .HasColumnName("supId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SupProdId)
                    .IsRequired()
                    .HasColumnName("supProdId")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ShopSuppliers>(entity =>
            {
                entity.ToTable("shop_suppliers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Http)
                    .IsRequired()
                    .HasColumnName("http")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<SiScore>(entity =>
            {
                entity.ToTable("SI_score");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Sponsors>(entity =>
            {
                entity.ToTable("sponsors");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Http)
                    .IsRequired()
                    .HasColumnName("http")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(24)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<SponsorsBanners>(entity =>
            {
                entity.ToTable("sponsors_banners");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("ix_objectClass");

                entity.HasIndex(e => e.Position)
                    .HasName("position");

                entity.HasIndex(e => e.SponsorId)
                    .HasName("sponsorId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassType)
                    .HasColumnName("classType")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.DestinationUrl)
                    .IsRequired()
                    .HasColumnName("destinationUrl")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.FrameTarget)
                    .IsRequired()
                    .HasColumnName("frameTarget")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MediaType)
                    .IsRequired()
                    .HasColumnName("mediaType")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'CLS_Banner'");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publishDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.SponsorId)
                    .HasColumnName("sponsorId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("text");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<SponsorsBannersClicks>(entity =>
            {
                entity.ToTable("sponsors_banners_clicks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BannerId)
                    .HasColumnName("banner_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.SponsorId)
                    .HasColumnName("sponsor_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<SponsorsCampaignsBeta>(entity =>
            {
                entity.ToTable("sponsors_campaigns_beta");

                entity.HasIndex(e => e.EndDate)
                    .HasName("endDate");

                entity.HasIndex(e => e.Position)
                    .HasName("position");

                entity.HasIndex(e => e.StartDate)
                    .HasName("startDate");

                entity.HasIndex(e => e.Type)
                    .HasName("type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Alt)
                    .IsRequired()
                    .HasColumnName("alt")
                    .HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Internal).HasColumnName("internal");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.SponsorId)
                    .HasColumnName("sponsorId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<SponsorsContestants>(entity =>
            {
                entity.ToTable("sponsors_contestants");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CompName)
                    .IsRequired()
                    .HasColumnName("comp_name")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Retail)
                    .IsRequired()
                    .HasColumnName("retail")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SponsorId)
                    .HasColumnName("sponsor_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<StatObjektImpressions>(entity =>
            {
                entity.ToTable("statObjektImpressions");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("objectId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Impressions)
                    .HasColumnName("impressions")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("objectId")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<StatPagesAlias>(entity =>
            {
                entity.ToTable("stat_pages_alias");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PageAlias)
                    .IsRequired()
                    .HasColumnName("pageAlias")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasColumnName("pageName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Traininglog>(entity =>
            {
                entity.ToTable("traininglog");

                entity.HasIndex(e => e.Time)
                    .HasName("time");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(11)");

                entity.Property(e => e.Adrenaline)
                    .IsRequired()
                    .HasColumnName("adrenaline")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'00'");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.Feeling)
                    .HasColumnName("feeling")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FysicalQuality)
                    .HasColumnName("fysicalQuality")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Hrs)
                    .HasColumnName("hrs")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.InOutDoor)
                    .IsRequired()
                    .HasColumnName("inOutDoor")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Meters)
                    .HasColumnName("meters")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Moves)
                    .HasColumnName("moves")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasColumnName("place")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("time")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TopForm)
                    .IsRequired()
                    .HasColumnName("topForm")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("bigint(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.ToTable("userinfo");

                entity.HasIndex(e => e.Country)
                    .HasName("country");

                entity.HasIndex(e => e.FName)
                    .HasName("index_f_name");

                entity.HasIndex(e => e.LName)
                    .HasName("index_l_name");

                entity.HasIndex(e => e.MyPicture)
                    .HasName("user_picture");

                entity.HasIndex(e => e.Sex)
                    .HasName("sex");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Annanymous)
                    .HasColumnName("annanymous")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BestArea)
                    .HasColumnName("best_area")
                    .HasMaxLength(250);

                entity.Property(e => e.BetaAccess)
                    .HasColumnName("beta_access")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Competitions)
                    .HasColumnName("competitions")
                    .HasMaxLength(40);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.Deactivated)
                    .HasColumnName("deactivated")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasColumnName("f_name")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GuideArea)
                    .HasColumnName("guide_area")
                    .HasMaxLength(250);

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasColumnName("l_name")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MyPicture)
                    .HasColumnName("my_picture")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OInterrests)
                    .HasColumnName("o_interrests")
                    .HasMaxLength(250);

                entity.Property(e => e.Occupation)
                    .HasColumnName("occupation")
                    .HasMaxLength(250);

                entity.Property(e => e.Presentation)
                    .HasColumnName("presentation")
                    .HasColumnType("text");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(150);

                entity.Property(e => e.Sponsor1)
                    .HasColumnName("sponsor1")
                    .HasMaxLength(250);

                entity.Property(e => e.Sponsor1Www)
                    .HasColumnName("sponsor1_www")
                    .HasMaxLength(250);

                entity.Property(e => e.Sponsor2)
                    .HasColumnName("sponsor2")
                    .HasMaxLength(250);

                entity.Property(e => e.Sponsor2Www)
                    .HasColumnName("sponsor2_www")
                    .HasMaxLength(250);

                entity.Property(e => e.Sponsor3)
                    .HasColumnName("sponsor3")
                    .HasMaxLength(250);

                entity.Property(e => e.Sponsor3Www)
                    .HasColumnName("sponsor3_www")
                    .HasMaxLength(250);

                entity.Property(e => e.Started)
                    .HasColumnName("started")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.WorstArea)
                    .HasColumnName("worst_area")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<UserinfoAddress>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userinfo_address");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(120)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<UserLinks>(entity =>
            {
                entity.ToTable("userLinks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SubmitMail)
                    .IsRequired()
                    .HasColumnName("submitMail")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SubmitName)
                    .IsRequired()
                    .HasColumnName("submitName")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Userloggedin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userloggedin");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NetSessionId)
                    .IsRequired()
                    .HasColumnName("netSessionId")
                    .HasMaxLength(24)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("int(15)")
                    .HasDefaultValueSql("'2'");
            });

            modelBuilder.Entity<Useronline>(entity =>
            {
                entity.ToTable("useronline");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.ToTable("user_settings");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ExtBlogFeedUrl)
                    .IsRequired()
                    .HasColumnName("extBlogFeedUrl")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ExtBlogUrl)
                    .IsRequired()
                    .HasColumnName("extBlogUrl")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GradeFrom).HasColumnName("grade_from");

                entity.Property(e => e.Langue)
                    .IsRequired()
                    .HasColumnName("langue")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("'ENG'");

                entity.Property(e => e.LastDays)
                    .HasColumnName("last_days")
                    .HasColumnType("mediumint unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaxRoutes).HasColumnName("max_routes");

                entity.Property(e => e.Newsletter)
                    .HasColumnName("newsletter")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReceiveMessages)
                    .HasColumnName("receive_messages")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.StartPage)
                    .HasColumnName("start_page")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<VotingAlternatives>(entity =>
            {
                entity.ToTable("votingAlternatives");

                entity.HasIndex(e => e.VotingId)
                    .HasName("voting_id");

                entity.HasIndex(e => new { e.VotingId, e.Alternative })
                    .HasName("votingID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alternative)
                    .IsRequired()
                    .HasColumnName("alternative")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Votes)
                    .HasColumnName("votes")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.VotingId)
                    .HasColumnName("votingID")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Votings>(entity =>
            {
                entity.ToTable("votings");

                entity.HasIndex(e => e.Active)
                    .HasName("votes_active");

                entity.HasIndex(e => e.Question)
                    .HasName("question")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<WwwGradjustering>(entity =>
            {
                entity.ToTable("www_gradjustering");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("mediumint unsigned");

                entity.Property(e => e.English)
                    .HasColumnName("english")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Led)
                    .HasColumnName("led")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasColumnName("namn")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NewGrade)
                    .IsRequired()
                    .HasColumnName("new_grade")
                    .HasMaxLength(7)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StartGrade)
                    .IsRequired()
                    .HasColumnName("start_grade")
                    .HasMaxLength(7)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<YellowPages>(entity =>
            {
                entity.ToTable("yellow_pages");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("countryCode");

                entity.HasIndex(e => e.ObjectClass)
                    .HasName("objectClass");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GoggleMapX)
                    .IsRequired()
                    .HasColumnName("goggleMapX")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GoggleMapY)
                    .IsRequired()
                    .HasColumnName("goggleMapY")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnName("info")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectClass)
                    .IsRequired()
                    .HasColumnName("objectClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SubClass)
                    .IsRequired()
                    .HasColumnName("subClass")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");
            });
        }
    }
}
