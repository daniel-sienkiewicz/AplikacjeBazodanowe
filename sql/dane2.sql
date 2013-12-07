-- dane do sprawdzenia triggear 2 (trigerek_dane2)

CREATE TABLE klient (
id_klient int PRIMARY KEY IDENTITY not null,
imie varchar(20) not null,
nazwisko varchar(20) not null
 );
 
CREATE TABLE towar(
id_towar int PRIMARY KEY identity not null, 
nazwa varchar(20) not null, 
opis varchar(50) not null, 
ilosc_sztuk int not null, 
cena_netto decimal (8, 2) not null, 
podatek decimal (8, 2) not null
);

CREATE TABLE zakup(
id_zakup int PRIMARY KEY IDENTITY not null, 
id_klient int REFERENCES klient(id_klient) not null,
data_zakupu date not null
);

CREATE TABLE koszyk(
id_zakup int REFERENCES zakup(id_zakup) not null,
id_towar int REFERENCES towar(id_towar) not null,
ilosc int not null, 
cena_netto decimal (8, 2) not null, 
podatek decimal (8, 2) not null
);

INSERT INTO klient (imie, nazwisko) values('Daniel', 'Sienkiewicz');
INSERT INTO klient (imie, nazwisko) values('Michal', 'Skalkowski')
INSERT INTO klient (imie, nazwisko) values('Maciej', 'Zbierowski');
INSERT INTO klient (imie, nazwisko) values('Arnold', 'Boczek');

INSERT INTO towar (nazwa, opis, ilosc_sztuk, cena_netto, podatek) values ('boczek', 'boczek', 3, 20.00, 0.10);
INSERT INTO towar (nazwa, opis, ilosc_sztuk, cena_netto, podatek) values ('karkowka', 'karkowka', 5, 10.00, 0.40);
INSERT INTO towar (nazwa, opis, ilosc_sztuk, cena_netto, podatek) values ('kabanos', 'kabanos', 89, 5.00, 0.05);
INSERT INTO towar (nazwa, opis, ilosc_sztuk, cena_netto, podatek) values ('smalec', 'smalec', 12, 2.00, 0.10);
INSERT INTO towar (nazwa, opis, ilosc_sztuk, cena_netto, podatek) values ('cebula', 'cebula', 23, 9.00, 0.10);

INSERT INTO zakup (id_klient, data_zakupu) VALUES (1, '2013-12-12');
INSERT INTO zakup (id_klient, data_zakupu) VALUES (2, '2002-10-12');
INSERT INTO zakup (id_klient, data_zakupu) VALUES (3, '2013-09-12');
INSERT INTO zakup (id_klient, data_zakupu) VALUES (2, '2008-03-12');
INSERT INTO zakup (id_klient, data_zakupu) VALUES (4, '2012-01-12');

INSERT INTO koszyk (id_zakup, id_towar, ilosc, cena_netto, podatek) VALUES (1, 2, 3, 40.00, 0.40);
INSERT INTO koszyk (id_zakup, id_towar, ilosc, cena_netto, podatek) VALUES (2, 5, 1, 5.00, 0.40);
INSERT INTO koszyk (id_zakup, id_towar, ilosc, cena_netto, podatek) VALUES (1, 3, 24, 120.00, 0.40);
INSERT INTO koszyk (id_zakup, id_towar, ilosc, cena_netto, podatek) VALUES (4, 4, 10, 20.00, 0.40);
INSERT INTO koszyk (id_zakup, id_towar, ilosc, cena_netto, podatek) VALUES (8, 5, 2, 100.00, 0.40);

SELECT * FROM klient;
SELECT * FROM towar;
SELECT * FROM koszyk;
SELECT * FROM zakup;

DROP TRIGGER trigerek_dane2;
DELETE FROM koszyk;
DROP VIEW klienci_statystyki;