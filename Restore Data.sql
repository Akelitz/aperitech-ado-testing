delete from Movies where Title = 'Il piccolo principe';
update Movies set Title = 'Piovono Gnocchi' where Title = 'Piovono polpette';
update Movies set Title = 'I Croodz' where Title = 'I Croods';
set identity_insert Movies on
if not exists (select Id from Movies where Id = 33)
insert into Movies (Id, Year, Title) values(33, 2015, 'Il viaggio di Arlo');
if not exists (select Id from Movies where Id = 1)
insert into Movies (Id, Year, Title) values(1, 2015, 'Minions');
set identity_insert Movies off
set identity_insert Ratings on
if not exists (select Id from Ratings where MovieId = 33)
begin
insert into Ratings (Id, MovieId, Value) values (115, 33, 3);
insert into Ratings (Id, MovieId, Value) values (116, 33, 1);
insert into Ratings (Id, MovieId, Value) values (117, 33, 1);
insert into Ratings (Id, MovieId, Value) values (118, 33, 4);
end
if not exists (select Id from Ratings where MovieId = 1)
begin
insert into Ratings (Id, MovieId, Value) values (1, 1, 5);
insert into Ratings (Id, MovieId, Value) values (2, 1, 4);
insert into Ratings (Id, MovieId, Value) values (3, 1, 3);
insert into Ratings (Id, MovieId, Value) values (4, 1, 2);
end
set identity_insert Ratings off
