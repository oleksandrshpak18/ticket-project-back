using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ticket_project_back.Data.Models;

namespace ticket_project_back.Data;

public partial class TicketDbContext : DbContext
{
    public TicketDbContext()
    {
    }

    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Cashier> Cashiers { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Performer> Performers { get; set; }

    public virtual DbSet<PerformerGenre> PerformerGenres { get; set; }

    public virtual DbSet<PerformerType> PerformerTypes { get; set; }

    public virtual DbSet<SeatType> SeatTypes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketOffice> TicketOffices { get; set; }

    public virtual DbSet<TicketPrice> TicketPrices { get; set; }

    public virtual DbSet<VEventVenueZone> VEventVenueZones { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    public virtual DbSet<VenueZone> VenueZones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cashier>(entity =>
        {
            entity.HasKey(e => e.CashierId).HasName("PK__Cashiers__B366F9FAFD8AE15C");

            entity.ToTable(tb => tb.HasTrigger("trg_Cashiers"));

            entity.Property(e => e.CashierId).HasColumnName("cashier_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.TicketOfficeId).HasColumnName("ticket_office_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.TicketOffice).WithMany(p => p.Cashiers)
                .HasForeignKey(d => d.TicketOfficeId)
                .HasConstraintName("FK__Cashiers__ticket__60A75C0F");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__031491A8D0D8B322");

            entity.ToTable(tb => tb.HasTrigger("trg_Cities"));

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.City1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Cities__country___412EB0B6");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__7E8CD055FB600902");

            entity.ToTable(tb => tb.HasTrigger("trg_Countries"));

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Country1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB852FC2DB0C");

            entity.ToTable(tb => tb.HasTrigger("trg_Customers"));

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F72772335527");

            entity.ToTable(tb => tb.HasTrigger("trg_Events"));

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.BeginTime).HasColumnName("begin_time");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EventDate)
                .HasColumnType("date")
                .HasColumnName("event_date");
            entity.Property(e => e.EventDescription)
                .HasColumnType("text")
                .HasColumnName("event_description");
            entity.Property(e => e.EventTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("event_title");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.Img)
                .HasColumnType("text")
                .HasColumnName("img");
            entity.Property(e => e.MinAgeRestriction).HasColumnName("min_age_restriction");
            entity.Property(e => e.PerformerId).HasColumnName("performer_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("FK__Events__event_ty__5441852A");

            entity.HasOne(d => d.Performer).WithMany(p => p.Events)
                .HasForeignKey(d => d.PerformerId)
                .HasConstraintName("FK__Events__performe__52593CB8");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Events__venue_id__534D60F1");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__Event_ty__BB84C6F3166ED0C8");

            entity.ToTable("Event_types", tb => tb.HasTrigger("trg_Event_types"));

            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.EventType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("event_type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__18428D421BBC4CBC");

            entity.ToTable(tb => tb.HasTrigger("trg_Genres"));

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Genre1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genre");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__465962291BCCEE98");

            entity.ToTable(tb => tb.HasTrigger("trg_Orders"));

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CashierId).HasColumnName("cashier_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OperationDatetime)
                .HasColumnType("datetime")
                .HasColumnName("operation_datetime");
            entity.Property(e => e.OperationNumber).HasColumnName("operation_number");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Cashier).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CashierId)
                .HasConstraintName("FK__Orders__cashier___66603565");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__customer__656C112C");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Order_it__3764B6BC6EE1789A");

            entity.ToTable("Order_items", tb => tb.HasTrigger("trg_Order_items"));

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Order_ite__order__778AC167");

            entity.HasOne(d => d.Ticket).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Order_ite__ticke__787EE5A0");
        });

        modelBuilder.Entity<Performer>(entity =>
        {
            entity.HasKey(e => e.PerformerId).HasName("PK__Performe__E95FC00D206C1DD8");

            entity.ToTable(tb => tb.HasTrigger("trg_Performers"));

            entity.Property(e => e.PerformerId).HasColumnName("performer_id");
            entity.Property(e => e.CareerBeginYear).HasColumnName("career_begin_year");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Img)
                .HasColumnType("text")
                .HasColumnName("img");
            entity.Property(e => e.PerformerTypeId).HasColumnName("performer_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Country).WithMany(p => p.Performers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Performer__count__44FF419A");

            entity.HasOne(d => d.PerformerType).WithMany(p => p.Performers)
                .HasForeignKey(d => d.PerformerTypeId)
                .HasConstraintName("FK__Performer__perfo__440B1D61");
        });

        modelBuilder.Entity<PerformerGenre>(entity =>
        {
            entity.HasKey(e => e.PerformerGenreId).HasName("PK__Performe__4345D24BACE1B7CB");

            entity.ToTable("Performer_genres", tb => tb.HasTrigger("trg_Performer_genres"));

            entity.Property(e => e.PerformerGenreId).HasColumnName("performer_genre_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.PerformerId).HasColumnName("performer_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.Genre).WithMany(p => p.PerformerGenres)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Performer__genre__48CFD27E");

            entity.HasOne(d => d.Performer).WithMany(p => p.PerformerGenres)
                .HasForeignKey(d => d.PerformerId)
                .HasConstraintName("FK__Performer__perfo__47DBAE45");
        });

        modelBuilder.Entity<PerformerType>(entity =>
        {
            entity.HasKey(e => e.PerformerTypeId).HasName("PK__Performe__C1D20953192F693B");

            entity.ToTable("Performer_types", tb => tb.HasTrigger("trg_Performer_types"));

            entity.Property(e => e.PerformerTypeId).HasColumnName("performer_type_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.PerformerType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("performer_type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<SeatType>(entity =>
        {
            entity.HasKey(e => e.SeatTypeId).HasName("PK__Seat_typ__5C2EB1970CD91EBE");

            entity.ToTable("Seat_types", tb => tb.HasTrigger("trg_Seat_types"));

            entity.Property(e => e.SeatTypeId).HasColumnName("seat_type_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.SeatType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("seat_type");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__D596F96BCE7B44B8");

            entity.ToTable(tb => tb.HasTrigger("trg_Tickets"));

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.RowNumber).HasColumnName("row_number");
            entity.Property(e => e.SeatNumber).HasColumnName("seat_number");
            entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");
            entity.Property(e => e.TicketPriceId).HasColumnName("ticket_price_id");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.TicketPrice).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketPriceId)
                .HasConstraintName("FK__Tickets__ticket___74AE54BC");
        });

        modelBuilder.Entity<TicketOffice>(entity =>
        {
            entity.HasKey(e => e.TicketOfficeId).HasName("PK__Ticket_o__6CA76C909D43E7E2");

            entity.ToTable("Ticket_offices", tb => tb.HasTrigger("trg_Ticket_offices"));

            entity.Property(e => e.TicketOfficeId).HasColumnName("ticket_office_id");
            entity.Property(e => e.BuildingNumber).HasColumnName("building_number");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.City).WithMany(p => p.TicketOffices)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Ticket_of__city___5DCAEF64");
        });

        modelBuilder.Entity<TicketPrice>(entity =>
        {
            entity.HasKey(e => e.TicketPriceId).HasName("PK__Ticket_p__3E9F664694F41AB9");

            entity.ToTable("Ticket_prices", tb => tb.HasTrigger("trg_Ticket_prices"));

            entity.Property(e => e.TicketPriceId).HasColumnName("ticket_price_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.VenueZoneId).HasColumnName("venue_zone_id");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketPrices)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Ticket_pr__event__70DDC3D8");

            entity.HasOne(d => d.VenueZone).WithMany(p => p.TicketPrices)
                .HasForeignKey(d => d.VenueZoneId)
                .HasConstraintName("FK__Ticket_pr__venue__71D1E811");
        });

        modelBuilder.Entity<VEventVenueZone>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vEventVenueZones");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Typ)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typ");
            entity.Property(e => e.Ven)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ven");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venues__82A8BE8DE121545B");

            entity.ToTable(tb => tb.HasTrigger("trg_Venues"));

            entity.Property(e => e.VenueId).HasColumnName("venue_id");
            entity.Property(e => e.BuildingNumber).HasColumnName("building_number");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Img)
                .HasColumnType("text")
                .HasColumnName("img");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.VenueName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("venue_name");

            entity.HasOne(d => d.City).WithMany(p => p.Venues)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Venues__city_id__4BAC3F29");
        });

        modelBuilder.Entity<VenueZone>(entity =>
        {
            entity.HasKey(e => e.VenueZoneId).HasName("PK__Venue_zo__5DFCAA358E01FCE3");

            entity.ToTable("Venue_zones", tb => tb.HasTrigger("trg_Venue_zones"));

            entity.Property(e => e.VenueZoneId).HasColumnName("venue_zone_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.RowsCount).HasColumnName("rows_count");
            entity.Property(e => e.SeatTypeId).HasColumnName("seat_type_id");
            entity.Property(e => e.SeatsPerRowCount).HasColumnName("seats_per_row_count");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.SeatType).WithMany(p => p.VenueZones)
                .HasForeignKey(d => d.SeatTypeId)
                .HasConstraintName("FK__Venue_zon__seat___4F7CD00D");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueZones)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Venue_zon__venue__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
