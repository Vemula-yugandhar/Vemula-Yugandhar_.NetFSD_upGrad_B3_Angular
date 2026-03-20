create database EventDb

USE EventDb;

-----User Information Table 

create table UserInfo (
     emailId varchar(30) PRIMARY KEY,
	 userName varchar(50) NOT NULL check(Len(userName) > 0),
	 [Role] varchar(30) NOT NULL check(Role in('admin', 'Participant')),
	 [Password] varchar(30) NOT NULL check(Len(Password) BETWEEN 6 AND 20)
);

insert into UserInfo values('yugandharvemula44@gmail.com', 'Yugandhar', 'admin','Yugandhar@1234');
insert into UserInfo values('Manoj56@gmail.com', 'Manoj', 'Participant','Manoj@4657');
insert into UserInfo values('nani9867@gmail.com', 'Nani', 'admin','Nani@4657');

SELECT * FROM UserInfo where role='admin';

----- --------Event Details Table-------------------

create table EventDetails(
    EventId int PRIMARY KEY,
	EventName varchar(50) NOT NULL,
	EventCategory varchar(50) NOT NULL,
	EventDate datetime NOT NULL,
	[Description] varchar(200),
	[Status] varchar(10) check(Status in ('active', 'in-active'))
);


insert into EventDetails values(101, 'Cultural Fest', 'Cultural', '2026-05-20 17:30:00', 'Music, dance and art performances.', 'active');
 insert into EventDetails values(102,'AI Workshop', 'Education', '2026-06-10 09:00:00', 'Hands-on workshop on Artificial Intelligence.', 'in-active');
 insert into EventDetails values(103,'Startup Meetup', 'Business', '2026-07-05 14:00:00', 'Networking event for startup founders.', 'active');


 select * from EventDetails;


 -------------------Speakers Details Table-----------------------

 create table SpeakersDetails (
       SpeakerId int PRIMARY KEY,
	   SpeakerName varchar(50) NOT NULL check(len(SpeakerName) > 0)
 );

 INSERT INTO SpeakersDetails values(201, 'Ashok');
 insert into SpeakersDetails values(202, 'Madhu');
 insert into SpeakersDetails values(203, 'Deepthi');


 select * from SpeakersDetails;

 -------Session Information Table With Foreign Key------

 create table SessionInfo (
      SessionId int PRIMARY KEY,
	  EventId int NOT NULL,
	  SessionTitle varchar(50) NOT NULL,
	  SpeakerId int NOT NULL,
	  [Description] varchar(250),
	  SessionStart dateTime NOT NULL,
	  SessionEnd datetime NOT NULL,
	  SessionUrl varchar(100),
	  FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
	  FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)

 );

 insert into SessionInfo values(3, 101, 'Cultural Dance Workshop', 201,
 'Interactive dance learning session.',
 '2026-05-20 17:00:00',
 '2026-05-20 18:00:00',
 'https://meet.com/dance-session');

  insert into SessionInfo values(2, 102, 'Introduction to AI', 202,
 'Basics of Artificial Intelligence concepts.',
 '2026-04-15 10:00:00',
 '2026-04-15 11:00:00',
 'https://meet.com/ai-session'); 
   

 insert into SessionInfo values(1, 103, 'Startup Funding Guide', 203,
 'How to raise funds for startups.',
 '2026-07-05 14:00:00',
 '2026-07-05 15:30:00',
 'https://meet.com/startup-session');


 select * from SessionInfo;



 -------Event Participants Details Table-------

 create table ParticipantEventDetails (
    Id int PRIMARY KEY,
	ParticipantEmailId varchar(30) NOT NULL,
	EventId int NOT NULL,
	SessionId INT NOT NULL,
	IsAttended bit check(IsAttended IN (0,1)),
	FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(emailId),
	FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
	FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
 );

 insert into ParticipantEventDetails values (1, 'yugandharvemula44@gmail.com', 101, 1, 1);
 insert into ParticipantEventDetails values (2, 'Manoj56@gmail.com', 102, 2, 0);

 select * from ParticipantEventDetails;