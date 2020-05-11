-- create menu item
insert into [UmMenuItem]
([Name], [NameOther], [IsActive], [URL], [ApplicationId], [ItemOrder])
values
('bank.shared.title', 'bank', 1, 'bank/list', 4, 17)

insert into [UmMenuItem]
([Name], [NameOther], [IsActive], [URL], [ApplicationId], [ItemOrder])
values
('vendor.shared.title', 'bank', 1, 'vendor/list', 4, 18)




-- assign menu item to user
insert into [UmUserMenuItem] ([UserId], [MenuItemId]) values (117, 3106)
insert into [UmUserMenuItem] ([UserId], [MenuItemId]) values (1431, 3106)
insert into [UmUserMenuItem] ([UserId], [MenuItemId]) values (1432, 3106)
insert into [UmUserMenuItem] ([UserId], [MenuItemId]) values (1433, 3106)
insert into [UmUserMenuItem] ([UserId], [MenuItemId]) values (1434, 3106)
insert into [UmUserMenuItem] ([UserId], [MenuItemId]) values (1435, 3106)
