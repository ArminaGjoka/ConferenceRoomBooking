﻿// <auto-generated />
using System;
using Final_Project_Conference_Room_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final_Project_Conference_Room_Booking.Migrations
{
    [DbContext(typeof(ConferenceRoomBookingContext))]
    [Migration("20230226195929_i")]
    partial class i
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("ConfirmedFromId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ConfirmedFromId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.ConferenceRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConferenceRooms");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.ReservationHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("ReservationHolders");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.UnavailabilityPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConferenceRoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceRoomId");

                    b.ToTable("UnavailabilityPeriods");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.Booking", b =>
                {
                    b.HasOne("Final_Project_Conference_Room_Booking.Models.User", "ConfirmedFrom")
                        .WithMany("Bookings")
                        .HasForeignKey("ConfirmedFromId")
                        .HasConstraintName("FK_Bookings_User");

                    b.HasOne("Final_Project_Conference_Room_Booking.Models.ConferenceRoom", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("FK_Bookings_ConferenceRooms");

                    b.Navigation("ConfirmedFrom");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.ReservationHolder", b =>
                {
                    b.HasOne("Final_Project_Conference_Room_Booking.Models.Booking", "Booking")
                        .WithMany("ReservationHolders")
                        .HasForeignKey("BookingId")
                        .IsRequired()
                        .HasConstraintName("FK_ReservationHolders_Bookings");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.UnavailabilityPeriod", b =>
                {
                    b.HasOne("Final_Project_Conference_Room_Booking.Models.ConferenceRoom", "ConferenceRoom")
                        .WithMany("UnavailabilityPeriods")
                        .HasForeignKey("ConferenceRoomId")
                        .IsRequired()
                        .HasConstraintName("FK_UnavailabilityPeriods_ConferenceRooms");

                    b.Navigation("ConferenceRoom");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.Booking", b =>
                {
                    b.Navigation("ReservationHolders");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.ConferenceRoom", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("UnavailabilityPeriods");
                });

            modelBuilder.Entity("Final_Project_Conference_Room_Booking.Models.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
