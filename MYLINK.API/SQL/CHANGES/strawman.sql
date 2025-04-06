use ce;
create table users (id int primary key identity, firstname varchar(50), lastname varchar(50), username varchar(100), email varchar(100), employee tinyint, employeeid varchar(100), microsoftid varchar(100), ncrid varchar(100), oracleid varchar(100), azureid varchar(100));
create table employees (id int primary key identity, employeeid varchar(100), employeetenure varchar(50), employeestartdate datetime, employee_returndate datetime, hrid varchar(100), hrsystemconstring varchar(250));
create table bu(id int primary key identity, buname varchar(100), buhqaddress1 varchar(150), buhqaddress2 varchar(150), buhqcity varchar(100), buhqstate varchar(100), buhqpostal varchar(100));
create table certifications (id int primary key identity, employee tinyint, employeeid varchar(100), certname varchar(150), revision varchar(50), certdate datetime, revisedate datetime, bu int, comments varchar(1000));
create table userprofile(id int primary key identity, address1 varchar(150), address2 varchar(150), city varchar(100), stateregion varchar(150), country varchar(150), phone varchar(150), cellphone varchar(150), sms tinyint, email varchar(150), maritalstatus varchar(100), university1 varchar(150), university2 varchar(150), linkedinurl varchar(150), instagramurl varchar(150), vimeourl varchar(150), facebookurl varchar(150), googleurl varchar(150)); 
create table certrequirements(id int primary key identity, certid int, learnid1 int, learnid2 int, learnid3 int, learnid4 int, learnid5 int);
create table learndetail (id int primary key identity, description char(100), category char(50), startdate varchar(100), enddate varchar(100), certauthority varchar(100), status varchar(50));
create table resdetail (id int primary key identity, description char(100), category char(50), startdate varchar(100), enddate varchar(100), certauthority varchar(100), status varchar(50));
create table gagridconfig (id, regionid, gridinstance, nodeid, nodename, sqllocaltype, nodedbms1, nodedbm1sid, node1ip, node1port, nodedbms2, nodedbm2sid, node2ip, node2port, nodedbms3, nodedbm3sid, node3ip, node3port);
create table certcalogue(id int primary key identity, description char(100), certtype int, vendor varchar(150), version varchar(150), endoflife tinyint, enddate varchar(100), trainingid int);
create table certtype(id int primary key identity, description char(100));
create table batch(id int primary key identity, batchname varchar(150), filelocationpath varchar(200), batchtype int, batchstatus int);
create table batchtype(id int primary key identity, batchtypename varchar(150));

//JSS Added Blob Field For Users and Certificates Requires that a file be stored somewhere on the Internet which is accessible.
alter table users add profileurl varchar(150);
alter table certifications add certificationbloburl varchar(150);




//SEED DATA
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





