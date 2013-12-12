--Daniel Sienkiewicz
--206358

--stworzenie tabeli klient
CREATE TABLE customer (
	id_customer int IDENTITY PRIMARY KEY NOT NULL, 
	name varchar(20),
	last_name varchar(30)
);

--stworzenie tabeli salon
CREATE TABLE car_dealer(
	id_car_dealer int IDENTITY PRIMARY KEY NOT NULL, 
	name VARCHAR(20) NOT NULL, 
	town VARCHAR(20) NOT NULL, 
);

--stworzenie tabeli samochod
CREATE TABLE cars(
	id_car int IDENTITY PRIMARY KEY NOT NULL, 
	make VARCHAR(20) NOT NULL, 
	model VARCHAR(20) NOT NULL, 
	price int, 
	capacity int, 
	id_customer int REFERENCES customer(id_customer) not null,
	id_car_dealer int REFERENCES car_dealer(id_car_dealer) not null,
);

--Insert
INSERT INTO customer (name, last_name) VALUES ('Daniel', 'Sienkiewicz');
INSERT INTO customer (name, last_name) VALUES ('Arnold', 'Boczek');
INSERT INTO customer (name, last_name) VALUES ('Ferdynand', 'Kiepski');
INSERT INTO customer (name, last_name) VALUES ('Cezary', 'Cezary');
INSERT INTO customer (name, last_name) VALUES ('Alojzy', 'Alojzewicz');
INSERT INTO customer (name, last_name) VALUES ('Bercik', 'Bercik');
INSERT INTO customer (name, last_name) VALUES ('Marian', 'Pazdzioch');

INSERT INTO car_dealer (name, town) VALUES ('Audi', 'Polkowice')
INSERT INTO car_dealer (name, town) VALUES ('Skoda', 'Lubin');
INSERT INTO car_dealer (name, town) VALUES ('BMW', 'Gdansk');
INSERT INTO car_dealer (name, town) VALUES ('Fiat', 'Glogow');
INSERT INTO car_dealer (name, town) VALUES ('Ford', 'Sopot');

INSERT INTO cars (make, model, price, capacity, id_customer, id_car_dealer) values('Audi', '80', 6000, 1800, 1, 2);
INSERT INTO cars (make, model, price, capacity, id_customer, id_car_dealer) values('Volkswagen', 'Sharan', 8000, 2000, 1, 3);
INSERT INTO cars (make, model, price, capacity, id_customer, id_car_dealer) values('Seat', 'Ibiza', 6000, 1900, 3, 1);
INSERT INTO cars (make, model, price, capacity, id_customer, id_car_dealer) values('Renault', 'Megane', 15000, 2200, 4, 5);