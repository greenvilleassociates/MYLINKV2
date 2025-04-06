using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Models;

public partial class CeContext : DbContext
{
    public CeContext()
    {
    }

    public CeContext(DbContextOptions<CeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apilog> Apilogs { get; set; }

    public virtual DbSet<Batch> Batches { get; set; }

    public virtual DbSet<Batchtype> Batchtypes { get; set; }

    public virtual DbSet<Bu> Bus { get; set; }

    public virtual DbSet<Certcalogue> Certcalogues { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Certrequirement> Certrequirements { get; set; }

    public virtual DbSet<Certtype> Certtypes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeReview> EmployeeReviews { get; set; }

    public virtual DbSet<Gagridconfig> Gagridconfigs { get; set; }

    public virtual DbSet<Learndetail> Learndetails { get; set; }

    public virtual DbSet<Learningmodule> Learningmodules { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Resdetail> Resdetails { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Useraction> Useractions { get; set; }

    public virtual DbSet<Userhelp> Userhelps { get; set; }

    public virtual DbSet<Userlog> Userlogs { get; set; }

    public virtual DbSet<Userprofile> Userprofiles { get; set; }

    public virtual DbSet<Usersession> Usersessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:dbserver.590team1.info,1433;Initial Catalog=MYLINK;Persist Security Info=False;User ID=sa;Password=*Columbia1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apilog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__apilogs__3213E83F0E914DBC");

            entity.ToTable("apilogs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apirequestdetail)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("apirequestdetail");
            entity.Property(e => e.Apiurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("apiurl");
            entity.Property(e => e.Descr)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descr");
            entity.Property(e => e.Emplid).HasColumnName("emplid");
            entity.Property(e => e.EscalationId).HasColumnName("escalation_id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Logdate)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("logdate");
            entity.Property(e => e.NocOpId).HasColumnName("noc_op_id");
            entity.Property(e => e.Noccomments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("noccomments");
            entity.Property(e => e.Secpriority).HasColumnName("secpriority");
            entity.Property(e => e.Triagecasenumber)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("triagecasenumber");
        });

        modelBuilder.Entity<Batch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__batch__3213E83F092744A3");

            entity.ToTable("batch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batchname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("batchname");
            entity.Property(e => e.Batchstatus).HasColumnName("batchstatus");
            entity.Property(e => e.Batchtype).HasColumnName("batchtype");
            entity.Property(e => e.Filelocationpath)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("filelocationpath");
        });

        modelBuilder.Entity<Batchtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__batchtyp__3213E83FD954BA5B");

            entity.ToTable("batchtype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batchtypename)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("batchtypename");
        });

        modelBuilder.Entity<Bu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bu__3213E83F4E00786F");

            entity.ToTable("bu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Buhqaddress1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("buhqaddress1");
            entity.Property(e => e.Buhqaddress2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("buhqaddress2");
            entity.Property(e => e.Buhqcity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buhqcity");
            entity.Property(e => e.Buhqpostal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buhqpostal");
            entity.Property(e => e.Buhqstate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buhqstate");
            entity.Property(e => e.Buname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("buname");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
        });

        modelBuilder.Entity<Certcalogue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__certcalo__3213E83FC6A88CE8");

            entity.ToTable("certcalogue");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Certlevel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("certlevel");
            entity.Property(e => e.Certlistcost).HasColumnName("certlistcost");
            entity.Property(e => e.Certlistdiscountstd).HasColumnName("certlistdiscountstd");
            entity.Property(e => e.Certlistdiscountvprate).HasColumnName("certlistdiscountvprate");
            entity.Property(e => e.Certtype).HasColumnName("certtype");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Enddate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("enddate");
            entity.Property(e => e.Endoflife).HasColumnName("endoflife");
            entity.Property(e => e.Precursortraining1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("precursortraining1");
            entity.Property(e => e.Precursortraining2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("precursortraining2");
            entity.Property(e => e.Sku)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.Trainingid).HasColumnName("trainingid");
            entity.Property(e => e.Vendor)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("vendor");
            entity.Property(e => e.Version)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("version");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__certific__3213E83FEE692C4F");

            entity.ToTable("certifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bu).HasColumnName("bu");
            entity.Property(e => e.Certdate)
                .HasColumnType("datetime")
                .HasColumnName("certdate");
            entity.Property(e => e.Certificationbloburl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("certificationbloburl");
            entity.Property(e => e.Certlevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("certlevel");
            entity.Property(e => e.Certname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("certname");
            entity.Property(e => e.Certype).HasColumnName("certype");
            entity.Property(e => e.Comments)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Employeeidasinteger).HasColumnName("employeeidasinteger");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Revisedate)
                .HasColumnType("datetime")
                .HasColumnName("revisedate");
            entity.Property(e => e.Revision)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("revision");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Certrequirement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__certrequ__3213E83FD8BF3F01");

            entity.ToTable("certrequirements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Certid).HasColumnName("certid");
            entity.Property(e => e.Learnid1).HasColumnName("learnid1");
            entity.Property(e => e.Learnid2).HasColumnName("learnid2");
            entity.Property(e => e.Learnid3).HasColumnName("learnid3");
            entity.Property(e => e.Learnid4).HasColumnName("learnid4");
            entity.Property(e => e.Learnid5).HasColumnName("learnid5");
        });

        modelBuilder.Entity<Certtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__certtype__3213E83FD43A4C4C");

            entity.ToTable("certtype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("description");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__company__3213E83F8560513E");

            entity.ToTable("company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CertAuthority)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Companyname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companyname");
            entity.Property(e => e.Dynamicsid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dynamicsid");
            entity.Property(e => e.Ncralohaid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ncralohaid");
            entity.Property(e => e.Oracleid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("oracleid");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F8DB64DBE");

            entity.ToTable("employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Buid).HasColumnName("buid");
            entity.Property(e => e.Companyid)
                .HasDefaultValue(1)
                .HasColumnName("companyid");
            entity.Property(e => e.Employee1).HasColumnName("employee");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeReturndate)
                .HasColumnType("datetime")
                .HasColumnName("employee_returndate");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Employeeidasint).HasColumnName("employeeidasint");
            entity.Property(e => e.Employeestartdate)
                .HasColumnType("datetime")
                .HasColumnName("employeestartdate");
            entity.Property(e => e.Employeetenure)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employeetenure");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Hrid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("hrid");
            entity.Property(e => e.Hrsystemconstring)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("hrsystemconstring");
            entity.Property(e => e.Managerid).HasColumnName("managerid");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Storeid).HasColumnName("storeid");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Userprofileid).HasColumnName("userprofileid");
        });

        modelBuilder.Entity<EmployeeReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83FA439A81F");

            entity.ToTable("employee_reviews");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calendaryear)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("calendaryear");
            entity.Property(e => e.Employeefullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("employeefullname");
            entity.Property(e => e.Notesondelivery)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("notesondelivery");
            entity.Property(e => e.Reviewdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reviewdate");
            entity.Property(e => e.Reviewdetails)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("reviewdetails");
            entity.Property(e => e.Reviewgivendate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reviewgivendate");
            entity.Property(e => e.Reviewurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("reviewurl");
        });

        modelBuilder.Entity<Gagridconfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gagridco__3213E83F662BEC4C");

            entity.ToTable("gagridconfig");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gridinstance)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gridinstance");
            entity.Property(e => e.Node1ip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("node1ip");
            entity.Property(e => e.Node1port)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("node1port");
            entity.Property(e => e.Node2ip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("node2ip");
            entity.Property(e => e.Node2port)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("node2port");
            entity.Property(e => e.Node3ip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("node3ip");
            entity.Property(e => e.Node3port)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("node3port");
            entity.Property(e => e.Nodedbm1sid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodedbm1sid");
            entity.Property(e => e.Nodedbm2sid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodedbm2sid");
            entity.Property(e => e.Nodedbm3sid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodedbm3sid");
            entity.Property(e => e.Nodedbms1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodedbms1");
            entity.Property(e => e.Nodedbms2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodedbms2");
            entity.Property(e => e.Nodedbms3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodedbms3");
            entity.Property(e => e.Nodeid).HasColumnName("nodeid");
            entity.Property(e => e.Nodename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nodename");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Sqllocaltype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sqllocaltype");
        });

        modelBuilder.Entity<Learndetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__learndet__3213E83FCC53A3EA");

            entity.ToTable("learndetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cataloguesku)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cataloguesku");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category");
            entity.Property(e => e.Certauthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("certauthority");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Employeeidasint).HasColumnName("employeeidasint");
            entity.Property(e => e.Enddate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("enddate");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Learningmodulesid).HasColumnName("learningmodulesid");
            entity.Property(e => e.Startdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("startdate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Learningmodule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__learning__3213E83FD6B7E6C2");

            entity.ToTable("learningmodules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.Authorcomp).HasColumnName("authorcomp");
            entity.Property(e => e.Authorcontact)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("authorcontact");
            entity.Property(e => e.Cataloguesku)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cataloguesku");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Emprequired).HasColumnName("emprequired");
            entity.Property(e => e.Uisection).HasColumnName("uisection");
            entity.Property(e => e.Videourl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("videourl");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__manager__3213E83F528A6CCB");

            entity.ToTable("manager");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Companyid).HasColumnName("companyid");
            entity.Property(e => e.Emplid).HasColumnName("emplid");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Saddress1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("saddress1");
            entity.Property(e => e.Saddress2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("saddress2");
            entity.Property(e => e.Scity)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("scity");
            entity.Property(e => e.Sstate)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("sstate");
            entity.Property(e => e.Storeid).HasColumnName("storeid");
            entity.Property(e => e.Szipcode)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("szipcode");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__regions__3213E83F14FFAB69");

            entity.ToTable("regions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bu).HasColumnName("bu");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Hqaddress1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("hqaddress1");
            entity.Property(e => e.Hqaddress2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("hqaddress2");
            entity.Property(e => e.Hqcity)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("hqcity");
            entity.Property(e => e.Hqstate)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("hqstate");
            entity.Property(e => e.Hqzipcode)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("hqzipcode");
        });

        modelBuilder.Entity<Resdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__resdetai__3213E83F0C57D4D7");

            entity.ToTable("resdetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category");
            entity.Property(e => e.Certauthority)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("certauthority");
            entity.Property(e => e.Descr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descr");
            entity.Property(e => e.Emplid).HasColumnName("emplid");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Enddate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("enddate");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Startdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("startdate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stores__3213E83FB79848BE");

            entity.ToTable("stores");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address2");
            entity.Property(e => e.Bu).HasColumnName("bu");
            entity.Property(e => e.City)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.State)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("zipcode");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F96DA4CA5");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Azureid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("azureid");
            entity.Property(e => e.Companyid)
                .HasDefaultValue(1)
                .HasColumnName("companyid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Hashedpassword)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("hashedpassword");
            entity.Property(e => e.Jid).HasColumnName("jid");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Microsoftid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("microsoftid");
            entity.Property(e => e.Ncrid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ncrid");
            entity.Property(e => e.Oracleid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("oracleid");
            entity.Property(e => e.Passwordtype).HasColumnName("passwordtype");
            entity.Property(e => e.Plainpassword)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("plainpassword");
            entity.Property(e => e.Profileurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("profileurl");
            entity.Property(e => e.Role)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.ResetToken)
                .HasMaxLength(200)
                .HasColumnName("resettoken");
            entity.Property(e => e.ResetTokenExpiration)
                .HasColumnType("datetime")
                .HasColumnName("resettokenexpiration");
        });

        modelBuilder.Entity<Useraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__useracti__3213E83FA741FB5D");

            entity.ToTable("useractions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acknowledged).HasColumnName("acknowledged");
            entity.Property(e => e.Actionpriority).HasColumnName("actionpriority");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Userhelp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userhelp");

            entity.Property(e => e.Bestcontactnumber)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("bestcontactnumber");
            entity.Property(e => e.Descr)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descr");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Emplid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emplid");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Replied)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("replied");
            entity.Property(e => e.Repliedmanageremail)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("repliedmanageremail");
            entity.Property(e => e.Repliedmanagerid).HasColumnName("repliedmanagerid");
            entity.Property(e => e.Repliedmanagerphone)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("repliedmanagerphone");
            entity.Property(e => e.Severity).HasColumnName("severity");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Userlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userlogs__3213E83F0B3CC5C1");

            entity.ToTable("userlogs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descr)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descr");
            entity.Property(e => e.Emplid).HasColumnName("emplid");
            entity.Property(e => e.EscalationId).HasColumnName("escalation_id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Logdate)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("logdate");
            entity.Property(e => e.NocOpId).HasColumnName("noc_op_id");
            entity.Property(e => e.Noccomments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("noccomments");
            entity.Property(e => e.Role)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Secpriority).HasColumnName("secpriority");
            entity.Property(e => e.Triagecasenumber)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("triagecasenumber");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Userprofile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userprof__3213E83F92265540");

            entity.ToTable("userprofile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activepictureurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("activepictureurl");
            entity.Property(e => e.Address1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("address2");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cellphone");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Employeeid)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("employeeid");
            entity.Property(e => e.Facebookurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("facebookurl");
            entity.Property(e => e.Googleurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("googleurl");
            entity.Property(e => e.Instagramurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("instagramurl");
            entity.Property(e => e.Linkedinurl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("linkedinurl");
            entity.Property(e => e.Maritalstatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("maritalstatus");
            entity.Property(e => e.Phone)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Postalzip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("postalzip");
            entity.Property(e => e.Pronoun)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("pronoun");
            entity.Property(e => e.Sms).HasColumnName("sms");
            entity.Property(e => e.Stateregion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("stateregion");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Title2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("title2");
            entity.Property(e => e.University)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("university");
            entity.Property(e => e.University1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("university1");
            entity.Property(e => e.University2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("university2");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Vimeourl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("vimeourl");
        });

        modelBuilder.Entity<Usersession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usersess__3213E83F08046578");

            entity.ToTable("usersessions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Acknowledged).HasColumnName("acknowledged");
            entity.Property(e => e.Actionpriority).HasColumnName("actionpriority");
            entity.Property(e => e.Sessionend)
                .HasColumnType("datetime")
                .HasColumnName("sessionend");
            entity.Property(e => e.Sessionrecorded).HasColumnName("sessionrecorded");
            entity.Property(e => e.Sessionrecordurl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sessionrecordurl");
            entity.Property(e => e.Sessionstart)
                .HasColumnType("datetime")
                .HasColumnName("sessionstart");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("token");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
