Select * from Students where Id = 1
insert into Students (FirstName,LastName,EnrollDate,EmailAddress,CreatedAt,ModifiedAt)
values 
('Vijay','Copper','2021-12-13','Vijay@gmail.com','2021-12-11',null),
('Vishal','Jadhav','2021-12-13','Vishal@gmail.com','2021-12-11',null),
('Kalyani','Dhane','2021-12-13','Kalyani@gmail.com','2021-12-11',null),
('Pratik','Dhane','2021-12-13','Pratik@gmail.com','2021-12-11',null),
('Isha','Jadhav','2021-12-13','Isha@gmail.com','2021-12-11',null),
('Samira','lele','2021-12-13','Samira@gmail.com','2021-12-11',null);

select * from StudentCourseCollab
select * from Courses;
insert into Courses (CourseName,CourseFee,CreateAt)
values 
('Maths',800,'2021-12-13'),
('biology',700,'2021-12-13');

insert into StudentCourseCollab (Id,CourseId,CreateAt)
values 
(1,3,'2021-12-13'),
(2,3,'2021-12-13'),
(1,4,'2021-12-13'),
(2,4,'2021-12-13');

select s.Id, s.FirstName ,sc.Id, sc.CourseId,c.CourseId, c.CourseName as Collb from 
(Students s join StudentCourseCollab sc on s.Id = sc.Id)
join Courses c on sc.CourseId = c.CourseId