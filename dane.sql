-- dane do sprawdzenia trigerek, trigereczek2 oraz procedury spr_pesel

CREATE TABLE osoba(
	id_osoba int identity not null PRIMARY KEY,
	imie varchar(20) not null,
	nazwisko varchar(20) not null,
	pesel CHAR(11) not null,
	pensja int not null,
	data_ur date not null
);

CREATE TABLE osoba_historia(
	id_hist int IDENTITY PRIMARY KEY not null,
	id_osoba int not null,
	imie varchar(20) not null,
	nazwisko varchar(20) not null,
	pesel CHAR(11) not null,
	pensja int not null,
	data_ur date not null,
	operacja char not null,
	data date not null
);

INSERT INTO osoba (imie, nazwisko, pesel, pensja, data_ur) VALUES ('Daniel', 'Sienkiewicz', 92121511350, 151234, '1992-12-15');
INSERT INTO osoba (imie, nazwisko, pesel, pensja, data_ur) VALUES ('milena', 'szklaraska', 92121511350, 3, '1992-12-15');

SELECT * FROM osoba;
SELECT * FROM osoba_historia;
DELETE  FROM osoba;
DELETE  FROM osoba_historia;
DROP TRIGGER trigerek;
DROP FUNCTION spr_pesel;
DROP TRIGGER trigereczek;
DROP TRIGGER trigereczek2;

DELETE  FROM osoba WHERE id_osoba = 6;