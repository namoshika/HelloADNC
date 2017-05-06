using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebSite.Data;
using WebSite.Models;

namespace WebSite.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("WebSite.Models.ContentCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int?>("GroupId");

                    b.Property<int>("Order");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Tag");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("OwnerId");

                    b.ToTable("ContentCard");
                });

            modelBuilder.Entity("WebSite.Models.ContentInfoExpr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Content");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("ContentInfoExpr");
                });

            modelBuilder.Entity("WebSite.Models.ContentTakao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Content");

                    b.Property<string>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("ContentTakao");
                });

            modelBuilder.Entity("WebSite.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("UseById");

                    b.HasKey("Id");

                    b.HasIndex("UseById");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("WebSite.Models.Page", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<string>("Description");

                    b.Property<int?>("GroupId");

                    b.Property<int>("Order");

                    b.Property<string>("Parameters");

                    b.Property<string>("ParentId");

                    b.Property<int?>("PinId");

                    b.Property<string>("Summary");

                    b.Property<string>("ThumbnailUrl");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PinId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("WebSite.Models.Pin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TitleId");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.ToTable("RootPin");
                });

            modelBuilder.Entity("WebSite.Models.ContentCard", b =>
                {
                    b.HasOne("WebSite.Models.Group")
                        .WithMany("Card")
                        .HasForeignKey("GroupId");

                    b.HasOne("WebSite.Models.Page", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("WebSite.Models.ContentInfoExpr", b =>
                {
                    b.HasOne("WebSite.Models.Page", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("WebSite.Models.ContentTakao", b =>
                {
                    b.HasOne("WebSite.Models.Page", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("WebSite.Models.Group", b =>
                {
                    b.HasOne("WebSite.Models.Page", "UseBy")
                        .WithMany()
                        .HasForeignKey("UseById");
                });

            modelBuilder.Entity("WebSite.Models.Page", b =>
                {
                    b.HasOne("WebSite.Models.Group")
                        .WithMany("Page")
                        .HasForeignKey("GroupId");

                    b.HasOne("WebSite.Models.Page", "Parent")
                        .WithMany("Child")
                        .HasForeignKey("ParentId");

                    b.HasOne("WebSite.Models.Pin")
                        .WithMany("Page")
                        .HasForeignKey("PinId");
                });

            modelBuilder.Entity("WebSite.Models.Pin", b =>
                {
                    b.HasOne("WebSite.Models.Page", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");
                });
        }
    }
}
