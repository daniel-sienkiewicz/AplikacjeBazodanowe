--Utwórz tabele klient(id_klient, nazwisko, kod), gdzie:
--id_klient - automatycznie nadawany, niepusty numer klienta, klucz g³ówny,
--nazwisko - niepusty ³añcuch znaków zmiennej d³ugoœci od 3 do 20 znaków,
--kod - kod pocztowy, dok³adnie 6 znaków

--oraz tabelê zakup(id_zakup, id_klient,nazwa_towaru,ilosc,cena), gdzie:
--id_zakup - niepusty klucz g³ówny, wartoœci nadawane automatycznie,
--id_klient - niepusty klucz obcy powi¹zany z kolumn¹ id_klient tabeli klient,
--nazwa_towaru - unikatowy ³añcuch znaków o zmiennej d³ugoœci od 5 do 60 znaków
--ilosc - liczba nieujemna, wartoœæ domyœlna 0,
--cena - kwota nie ni¿sza ni¿ 5 z³
--Rozwi¹zanie [3pkt]:

CREATE TABLE klient (
	id_klient int PRIMARY KEY IDENTITY NOT NULL,
	nazwisko varchar(20) NOT NULL,
	kod_pocztowy char(6),
);

CREATE TABLE zakup(
	id_zakup int PRIMARY KEY IDENTITY NOT NULL,
	id_klient int REFERENCES klient(id_klient) not null,
	nazwa_towaru varchar(60),
	ilosc int,
	cena DECIMAL (8,2)
);

--Utwórz widok raport(id_klient,nazwisko,kod,suma_wydanych_pieniedzy), gdzie
--id_klient, nazwisko, kod to kolumny z tabeli klient
--suma_wydanych_pieniedzy - ³¹czna suma wydanych pieniêdzy przed danego klienta (suma po ilosci*cena)
--Rozwi¹zanie [1 pkt]

CREATE VIEW klienci_raport
AS
SELECT k.id_klient, k.nazwisko, SUM(z.ilosc * z.cena) AS suma, COUNT(z.id_klient) AS ilosc  
FROM (klient k 
	INNER JOIN zakup z ON k.id_klient = z.id_klient) GROUP BY k.nazwisko;

--Utwórz wyzwalacz, który po wykonaniu zapytania:
--INSERT INTO raport(nazwisko,kod) VALUES ('Gondek','80-287');
--doda nowego klienta do tabeli klient,
--Rozwi¹zanie [3 pkt]

CREATE TRIGGER dodaj ON klient
INSTEAD OF INSERT
AS
BEGIN
DECLARE kursor_in CURSOR 
FOR SELECT nazwisko, kod_pocztowy from inserted
DECLARE @nazwisko varchar(20), @kod_pocztowy char(6)
OPEN kursor_in
FETCH NEXT FROM kursor_in INTO @nazwisko, @kod_pocztowy
WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO klient (nazwisko, kod_pocztowy) VALUES(@nazwisko, @kod_pocztowy)
	print 'Dodano'
		
	FETCH NEXT FROM kursor_in
	INTO @nazwisko, @kod_pocztowy
	
END
CLOSE kursor_in
DEALLOCATE kursor_in
END 
GO

INSERT INTO klient (nazwisko, kod_pocztowy) VALUES('kowalski', '59-100');
SELECT * FROM klient;

--Do tabeli klient dodaj kolumnê usuniêty, z domyœln¹ wartoœci¹ 0,
--Napisaæ wyzwalacz, który zamiast usun¹æ fizycznie klienta zmieni
--wartoœæ kolumny usuniêty z 0 na 1,
--Rozwi¹zanie [3 pkt]:

ALTER TABLE dbo.klient ADD unusniety int DEFAULT 0

CREATE TRIGGER zamien ON klient
INSTEAD OF DELETE
AS
BEGIN
	UPDATE klient
	set unusniety = 1
	WHERE id_klient IN (SELECT id_klient FROM DELETED)
END 
GO

DELETE FROM klient WHERE id_klient = 2;
SELECT * FROM klient;

--Napisaæ wyzwalacz, który po dodaniu klienta poprawi jego nazwisko, tak
--aby zaczyna³o siê z wielkiej litery, a pozosta³e litery zmieni na ma³e,
--Uwzglêdnij nazwiska dwucz³onowe, np: Janicka-Nowak,
--Rozwi¹zanie [2 pkt]

CREATE TRIGGER trigerek ON klient 
AFTER INSERT AS 
BEGIN  
DECLARE kursor_up CURSOR 
FOR SELECT id_klient, nazwisko from inserted
DECLARE @id int,  @nazwisko varchar(20)
OPEN kursor_up
FETCH NEXT FROM kursor_up INTO @id, @nazwisko
WHILE @@FETCH_STATUS = 0
	BEGIN
		
		IF (ascii(SUBSTRING(@nazwisko, 1, 1)) > 96)
		BEGIN
			UPDATE klient SET nazwisko = UPPER(left(@nazwisko, 1)) + LOWER(SUBSTRING(@nazwisko,2,len(@nazwisko))) where id_klient = @id;
			print 'Zmieniono: '+ @nazwisko
		END
		
		FETCH NEXT FROM kursor_up
		INTO @id, @nazwisko
	END
CLOSE kursor_up
DEALLOCATE kursor_up
END
GO

INSERT INTO klient (nazwisko, kod_pocztowy) VALUES ('sienDASicz', '59-100');
SELECT * FROM klient;

--Napisaæ funkcjê pomocnicz¹ sprawdz_kod(sprawdzany_kod) zwracaj¹c¹
--wartoœæ true, gdy kod jest napisany w prawid³owym formacie
--(dwie cyfry, myœlnik, trzy cyfry) lub false a w przeciwnym przypadku,
--Napisz wyzwalacz, który uniemo¿liwi modyfikacjê kodu pocztowego
--w tabeli klient na niepoprawny format, wykorzystaj funkcjê sprawdz_kod
--Rozwi¹zanie [3 pkt]

CREATE FUNCTION sprawdz_kod (@kod_pocztowy CHAR(6))
RETURNS BIT
AS
BEGIN
	IF (ASCII(SUBSTRING(@kod_pocztowy,3,3)) != 45 OR (ASCII(SUBSTRING(@kod_pocztowy, 1 ,1)) < 48) OR (ASCII(SUBSTRING(@kod_pocztowy, 1,1)) > 57) OR (ASCII(SUBSTRING(@kod_pocztowy, 2,1)) < 48) OR (ASCII(SUBSTRING(@kod_pocztowy, 2,1)) > 57) OR ASCII(SUBSTRING(@kod_pocztowy, 4,1)) < 48 OR (ASCII(SUBSTRING(@kod_pocztowy, 4,1)) > 57) OR (ASCII(SUBSTRING(@kod_pocztowy, 5,1)) < 48) OR (ASCII(SUBSTRING(@kod_pocztowy, 5,1)) > 57) OR (ASCII(SUBSTRING(@kod_pocztowy, 6,1)) < 48) OR (ASCII(SUBSTRING(@kod_pocztowy, 6,1)) > 57))
	BEGIN
		RETURN 0
	END
	
	RETURN 1
END