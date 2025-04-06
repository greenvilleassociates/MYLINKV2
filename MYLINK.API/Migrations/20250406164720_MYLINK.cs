using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYLINK.Migrations
{
    /// <inheritdoc />
    public partial class MYLINK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apilogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    emplid = table.Column<int>(type: "int", nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    logdate = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    secpriority = table.Column<int>(type: "int", nullable: true),
                    noccomments = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    noc_op_id = table.Column<int>(type: "int", nullable: true),
                    escalation_id = table.Column<int>(type: "int", nullable: true),
                    triagecasenumber = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    apiurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    apirequestdetail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__apilogs__3213E83F0E914DBC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "batch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batchname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    filelocationpath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    batchtype = table.Column<int>(type: "int", nullable: true),
                    batchstatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__batch__3213E83F092744A3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "batchtype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batchtypename = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__batchtyp__3213E83FD954BA5B", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    buhqaddress1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    buhqaddress2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    buhqcity = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    buhqstate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    buhqpostal = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bu__3213E83F4E00786F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certcalogue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    certtype = table.Column<int>(type: "int", nullable: true),
                    vendor = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    version = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    endoflife = table.Column<byte>(type: "tinyint", nullable: true),
                    enddate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    trainingid = table.Column<int>(type: "int", nullable: true),
                    precursortraining1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    precursortraining2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sku = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    certlistcost = table.Column<double>(type: "float", nullable: true),
                    certlistdiscountstd = table.Column<double>(type: "float", nullable: true),
                    certlistdiscountvprate = table.Column<double>(type: "float", nullable: true),
                    certlevel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__certcalo__3213E83FC6A88CE8", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee = table.Column<byte>(type: "tinyint", nullable: true),
                    employeeid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    certname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    revision = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    certdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    revisedate = table.Column<DateTime>(type: "datetime", nullable: true),
                    bu = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    certificationbloburl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    certlevel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    certype = table.Column<int>(type: "int", nullable: true),
                    employeeidasinteger = table.Column<int>(type: "int", nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__certific__3213E83FEE692C4F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certrequirements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certid = table.Column<int>(type: "int", nullable: true),
                    learnid1 = table.Column<int>(type: "int", nullable: true),
                    learnid2 = table.Column<int>(type: "int", nullable: true),
                    learnid3 = table.Column<int>(type: "int", nullable: true),
                    learnid4 = table.Column<int>(type: "int", nullable: true),
                    learnid5 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__certrequ__3213E83FD8BF3F01", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certtype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__certtype__3213E83FD43A4C4C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    dynamicsid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ncralohaid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    oracleid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CertAuthority = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__company__3213E83F8560513E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee_reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeefullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    reviewdate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    reviewgivendate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    reviewdetails = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    calendaryear = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    notesondelivery = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    reviewurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3213E83FA439A81F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    employeetenure = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    employeestartdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    employee_returndate = table.Column<DateTime>(type: "datetime", nullable: true),
                    hrid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    hrsystemconstring = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    userprofileid = table.Column<int>(type: "int", nullable: true),
                    managerid = table.Column<int>(type: "int", nullable: true),
                    regionid = table.Column<int>(type: "int", nullable: true),
                    buid = table.Column<int>(type: "int", nullable: true),
                    storeid = table.Column<int>(type: "int", nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    employeeidasint = table.Column<int>(type: "int", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    employee = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3213E83F8DB64DBE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gagridconfig",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionid = table.Column<int>(type: "int", nullable: true),
                    gridinstance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nodeid = table.Column<int>(type: "int", nullable: true),
                    nodename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sqllocaltype = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nodedbms1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nodedbm1sid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    node1ip = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    node1port = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    nodedbms2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nodedbm2sid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    node2ip = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    node2port = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    nodedbms3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    nodedbm3sid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    node3ip = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    node3port = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gagridco__3213E83F662BEC4C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "learndetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    category = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    startdate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    enddate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    certauthority = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    employeeidasint = table.Column<int>(type: "int", nullable: true),
                    employeeid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    employee = table.Column<byte>(type: "tinyint", nullable: true),
                    learningmodulesid = table.Column<int>(type: "int", nullable: true),
                    cataloguesku = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__learndet__3213E83FCC53A3EA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "learningmodules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cataloguesku = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    videourl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    author = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    authorcomp = table.Column<byte>(type: "tinyint", nullable: true),
                    authorcontact = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    emprequired = table.Column<byte>(type: "tinyint", nullable: true),
                    uisection = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__learning__3213E83FD6B7E6C2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manager",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    emplid = table.Column<int>(type: "int", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    storeid = table.Column<int>(type: "int", nullable: true),
                    saddress1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    saddress2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    scity = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    sstate = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    szipcode = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__manager__3213E83F528A6CCB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    bu = table.Column<int>(type: "int", nullable: true),
                    hqaddress1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    hqaddress2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    hqcity = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    hqstate = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    hqzipcode = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__regions__3213E83F14FFAB69", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resdetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    category = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    startdate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    enddate = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    certauthority = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    emplid = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    employee = table.Column<byte>(type: "tinyint", nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__resdetai__3213E83F0C57D4D7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    regionid = table.Column<int>(type: "int", nullable: true),
                    bu = table.Column<int>(type: "int", nullable: true),
                    address1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    address2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    city = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    state = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    zipcode = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stores__3213E83FB79848BE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "useractions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    acknowledged = table.Column<byte>(type: "tinyint", nullable: true),
                    actionpriority = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__useracti__3213E83FA741FB5D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userhelp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: true),
                    emplid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descr = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    severity = table.Column<int>(type: "int", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    bestcontactnumber = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    replied = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    repliedmanagerid = table.Column<int>(type: "int", nullable: true),
                    repliedmanagerphone = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    repliedmanageremail = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "userlogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    emplid = table.Column<int>(type: "int", nullable: true),
                    fullname = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    logdate = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    secpriority = table.Column<int>(type: "int", nullable: true),
                    noccomments = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    noc_op_id = table.Column<int>(type: "int", nullable: true),
                    escalation_id = table.Column<int>(type: "int", nullable: true),
                    triagecasenumber = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    role = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userlogs__3213E83F0B3CC5C1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userprofile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    address2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    city = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    stateregion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    country = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    phone = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    cellphone = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    sms = table.Column<byte>(type: "tinyint", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    maritalstatus = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    university1 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    university2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    linkedinurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    instagramurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    vimeourl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    facebookurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    googleurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    university = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    title = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    pronoun = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    title2 = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    activepictureurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    employeeid = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    postalzip = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userprof__3213E83F92265540", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    employee = table.Column<byte>(type: "tinyint", nullable: true),
                    employeeid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    microsoftid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ncrid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    oracleid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    azureid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    plainpassword = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    hashedpassword = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    passwordtype = table.Column<int>(type: "int", nullable: true),
                    jid = table.Column<int>(type: "int", nullable: true),
                    profileurl = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    role = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    fullname = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    resettoken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    resettokenexpiration = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F96DA4CA5", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usersessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: true),
                    token = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    acknowledged = table.Column<byte>(type: "tinyint", nullable: true),
                    actionpriority = table.Column<int>(type: "int", nullable: true),
                    sessionstart = table.Column<DateTime>(type: "datetime", nullable: true),
                    sessionend = table.Column<DateTime>(type: "datetime", nullable: true),
                    sessionrecorded = table.Column<int>(type: "int", nullable: true),
                    sessionrecordurl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usersess__3213E83F08046578", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apilogs");

            migrationBuilder.DropTable(
                name: "batch");

            migrationBuilder.DropTable(
                name: "batchtype");

            migrationBuilder.DropTable(
                name: "bu");

            migrationBuilder.DropTable(
                name: "certcalogue");

            migrationBuilder.DropTable(
                name: "certifications");

            migrationBuilder.DropTable(
                name: "certrequirements");

            migrationBuilder.DropTable(
                name: "certtype");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "employee_reviews");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "gagridconfig");

            migrationBuilder.DropTable(
                name: "learndetail");

            migrationBuilder.DropTable(
                name: "learningmodules");

            migrationBuilder.DropTable(
                name: "manager");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "resdetail");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropTable(
                name: "useractions");

            migrationBuilder.DropTable(
                name: "userhelp");

            migrationBuilder.DropTable(
                name: "userlogs");

            migrationBuilder.DropTable(
                name: "userprofile");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "usersessions");
        }
    }
}
