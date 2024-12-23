create table Products
(
    id serial primary key,
    Name varchar(50),
    Description varchar(150),
    Price decimal,
    StockQuantity int,
    CategoryName text,
    CreatedDate timestamp
);