﻿// <auto-generated />
using System;
using MailBox.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MailBox.Migrations
{
    [DbContext(typeof(MailBoxDBContext))]
    [Migration("20210105151504_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MailBox.Database.Attachment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MailID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("MailBox.Database.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MailBox.Database.GroupUser", b =>
                {
                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("GroupID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("MailBox.Database.Mail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SenderID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("SenderID");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("MailBox.Database.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MailBox.Database.UserMail", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("MailID")
                        .HasColumnType("int");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<int>("RecipientType")
                        .HasColumnType("int");

                    b.HasKey("UserID", "MailID");

                    b.HasIndex("MailID");

                    b.HasIndex("UserID");

                    b.ToTable("UserMails");
                });

            modelBuilder.Entity("MailBox.Database.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MailBox.Database.Attachment", b =>
                {
                    b.HasOne("MailBox.Database.Mail", "Mail")
                        .WithMany("Attachments")
                        .HasForeignKey("MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");
                });

            modelBuilder.Entity("MailBox.Database.Group", b =>
                {
                    b.HasOne("MailBox.Database.User", "Owner")
                        .WithMany("Groups")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MailBox.Database.GroupUser", b =>
                {
                    b.HasOne("MailBox.Database.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MailBox.Database.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MailBox.Database.Mail", b =>
                {
                    b.HasOne("MailBox.Database.User", "Sender")
                        .WithMany("CreatedMails")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("MailBox.Database.User", b =>
                {
                    b.HasOne("MailBox.Database.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MailBox.Database.UserMail", b =>
                {
                    b.HasOne("MailBox.Database.Mail", "Mail")
                        .WithMany("UserMails")
                        .HasForeignKey("MailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MailBox.Database.User", "User")
                        .WithMany("UserMails")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MailBox.Database.Group", b =>
                {
                    b.Navigation("GroupUsers");
                });

            modelBuilder.Entity("MailBox.Database.Mail", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("UserMails");
                });

            modelBuilder.Entity("MailBox.Database.User", b =>
                {
                    b.Navigation("CreatedMails");

                    b.Navigation("Groups");

                    b.Navigation("GroupUsers");

                    b.Navigation("UserMails");
                });

            modelBuilder.Entity("MailBox.Database.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}