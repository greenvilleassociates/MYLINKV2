use ce;
//ALL SQL FOR 590 UP TO TODAY. MARCH20TH 2025

use ce;
create table users (id int primary key identity, firstname varchar(50), lastname varchar(50), username varchar(100), email varchar(100), employee tinyint, employeeid varchar(100), microsoftid varchar(100), ncrid varchar(100), oracleid varchar(100), azureid varchar(100));
create table employees (id int primary key identity, employeeid varchar(100), employeetenure varchar(50), employeestartdate datetime, employee_returndate datetime, hrid varchar(100), hrsystemconstring varchar(250));
create table bu(id int primary key identity, buname varchar(100), buhqaddress1 varchar(150), buhqaddress2 varchar(150), buhqcity varchar(100), buhqstate varchar(100), buhqpostal varchar(100));
create table certifications (id int primary key identity, employee tinyint, employeeid varchar(100), certname varchar(150), revision varchar(50), certdate datetime, revisedate datetime, bu int, comments varchar(1000));
create table userprofile(id int primary key identity, address1 varchar(150), address2 varchar(150), city varchar(100), stateregion varchar(150), country varchar(150), phone varchar(150), cellphone varchar(150), sms tinyint, email varchar(150), maritalstatus varchar(100), university1 varchar(150), university2 varchar(150), linkedinurl varchar(150), instagramurl varchar(150), vimeourl varchar(150), facebookurl varchar(150), googleurl varchar(150)); 
create table certrequirements(id int primary key identity, certid int, learnid1 int, learnid2 int, learnid3 int, learnid4 int, learnid5 int);
create table learndetail (id int primary key identity, description char(100), category char(50), startdate varchar(100), enddate varchar(100), certauthority varchar(100), status varchar(50), userid int, employeeidasint int, employeeid varchar(100), employee tinyint, learningmodulesid int, cataloguesku varchar(150));
create table resdetail (id int primary key identity, description char(100), category char(50), startdate varchar(100), enddate varchar(100), certauthority varchar(100), status varchar(50));
create table gagridconfig (id int primary key identity, regionid varchar(100), gridinstance int, nodeid int, nodename varchar(100), sqllocaltype varchar(100), nodedbms1 varchar(100), nodedbm1sid varchar(100), node1ip varchar(100), node1port varchar(10), nodedbms2 varchar(100), nodedbm2sid varchar(100), node2ip varchar(100), node2port varchar(10), nodedbms3 varchar(100), nodedbm3sid varchar(100), node3ip varchar(100), node3port varchar(10));
create table certcalogue(id int primary key identity, description char(100), certtype int, vendor varchar(150), version varchar(150), endoflife tinyint, enddate varchar(100), trainingid int);
create table certtype(id int primary key identity, description char(100));
create table batch(id int primary key identity, batchname varchar(150), filelocationpath varchar(200), batchtype int, batchstatus int);
create table batchtype(id int primary key identity, batchtypename varchar(150));
create table stores (id int primary key identity, description varchar(150), regionid int, bu int, address1 varchar(150), address2 varchar(150), city varchar(150), state varchar(150), zipcode varchar(150));
create table regions (id int primary key identity, description varchar(150), bu int, hqaddress1 varchar(150), hqaddress2 varchar(150), hqcity varchar(150), hqstate varchar(150), hqzipcode varchar(150));
create table manager (id int primary key identity, fullname varchar(150), emplid int, userid int, storeid int, saddress1 varchar(150), saddress2 varchar(150), scity varchar(150), sstate varchar(150), szipcode varchar(150));
create table userhelp (id int, emplid int, descr varchar(500), severity int);
create table apilogs (id int primary key identity, descr varchar(500), emplid int, fullname varchar(150), logdate varchar(150), secpriority int, noccomments varchar(500), noc_op_id int, escalation_id int, triagecasenumber varchar(200), apiurl varchar(150), apirequestdetail varchar(500));
create table userlogs (id int primary key identity, descr varchar(500), emplid int, fullname varchar(150), logdate varchar(150), secpriority int, noccomments varchar(500), noc_op_id int, escalation_id int, triagecasenumber varchar(200));
create table useractions (id int primary key identity, userid int, description varchar(100), acknowledged tinyint, actionpriority int);
create table usersessions (id int primary key identity, userid int, token varchar(100), acknowledged tinyint, actionpriority int, sessionstart datetime, sessionend datetime, sessionrecorded int, sessionrecordurl varchar(200));
create table company (id int primary key, companyname varchar(100), dynamicsid varchar(100), ncralohaid varchar(100), oracleid varchar(100));
alter table employees add companyid int;
alter table certifications add companyid int;
alter table bu add companyid int;
alter table manager add companyid int;


//COLIN NEEDED SOME CHANGES FOR HIS CODE
alter table employees add employeeidasint int;
alter table employees add EmployeeEmail varchar(150);
alter table employees add employee tinyint;
alter table certifications add EmployeeEmail varchar(150);


//Added Employee Selections by Different Ids - Required for Certificate Compliance. //Note Certifications can be to non employees.
alter table employees add managerid int;
alter table employees add regionid int;
alter table employees add buid int;
alter table employees add storeid int;
alter table certifications add employeeidasinteger int;


//JSS Added Blob Field For Users and Certificates Requires that a file be stored somewhere on the Internet which is accessible.
alter table users add profileurl varchar(150);
alter table certifications add certificationbloburl varchar(150);
alter table resdetail add location varchar(150);
alter table resdetail add emplid int;
alter table certifications add certlevel varchar(50);
alter table users add fullname varchar(200); 
alter table users add role varchar(50);
alter table resdetail add userid int; 
alter table resdetail add employee tinyint; 
alter table employees add fullname varchar(150);
alter table employees add userid int;
alter table employees add userprofileid int;
alter table certifications add userid int;
alter table certifications add fullname varchar(150);
alter table certifications add certype int; 
alter table certcalogue add precursortraining1 int;
alter table certcalogue add precursortraining2 int;
alter table certcalogue add sku varchar(150);
alter table certcalogue add certlistcost float;
alter table certcalogue add certlistdiscountstd float;
alter table certcalogue add certlistdiscountvprate float;


//SEED DATA
insert into certtype (description) values ('employee');
insert into certtype (description) values ('publicuser');
insert into batchtype (batchtypename) values ('userimport');
insert into batchtype (batchtypename) values ('certification catalogue');
insert into certtype (description) values ('network');
insert into certtype (description) values ('software development');
insert into certtype (description) values ('database');
insert into certtype (description) values ('project management');
insert into certtype (description) values ('cloud/hybrid');
insert into certcalogue( description, certtype, vendor, version) values ('CCNA', 1, 'Cisco Systems', '2025-2026V3');
insert into certcalogue( description, certtype, vendor, version) values ('CCDA', 1, 'Cisco Systems', '2025-2026V3');
insert into certcalogue( description, certtype, vendor, version) values ('CCNP', 1, 'Cisco Systems', '2025-2026V3');
insert into certcalogue( description, certtype, vendor, version) values ('CCDP', 1, 'Cisco Systems', '2025-2026V3');
insert into certcalogue( description, certtype, vendor, version) values ('AzureBasics', 5, 'Microsoft', '2024-2025V2');
insert into certcalogue( description, certtype, vendor, version) values ('AzureNetwork', 5, 'Microsoft', '2024-2025V2');
insert into certcalogue( description, certtype, vendor, version) values ('AzureMessaging', 5, 'Microsoft', '2024-2025V2');
insert into users (firstname, lastname, username, email, employee) VALUES ('Carolina', 'Turner', 'carolinanturner', 'carolinanturner@gmail.com', 1);
insert into users (firstname, lastname, username, email, employee) VALUES ('John', 'Stritzinger', 'jssg33', 'jstritzinger33@gmail.com', 2);
insert into users (firstname, lastname, username, email, employee) VALUES ('Kaleb', 'Bah', 'kbah', 'kbahsc33@gmail.com', 1);
insert into users (firstname, lastname, username, email, employee) VALUES ('Pravani', 'LongName', 'pravani', 'pravanisc33@gmail.com', 1);
insert into users (firstname, lastname, username, email, employee) VALUES ('Sambit', 'Sam', 'sambitsam96', 'sambitsam96@gmail.com', 2);
insert into users (firstname, lastname, username, email, employee) VALUES ('Colin', 'Richard', 'crichard', 'crichardsc33@gmail.com', 1);
