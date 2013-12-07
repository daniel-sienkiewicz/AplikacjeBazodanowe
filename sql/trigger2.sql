-- Trigger archiwizujacy dane osoby po update

CREATE TRIGGER trigereczek ON osoba 
AFTER UPDATE AS 
BEGIN  
DECLARE kursor_hist CURSOR 
FOR SELECT id_osoba, imie, nazwisko, pesel, pensja, data_ur from inserted
DECLARE @id int, @imie varchar(20), @nazwisko varchar(20), @pesel CHAR(11), @pensja int, @data_ur date, @operacja char
OPEN kursor_hist
FETCH NEXT FROM kursor_hist INTO @id, @imie, @nazwisko, @pesel, @pensja, @data_ur
WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO osoba_historia (id_osoba, imie, nazwisko, pesel, pensja, data_ur, operacja, data) VALUES (@id, @imie, @nazwisko, @pesel, @pensja, @data_ur, 'U', GETDATE());
		print 'Zarchiwizowano'
		FETCH NEXT FROM kursor_hist
		INTO @id, @imie, @nazwisko, @pesel, @pensja, @data_ur
	END
CLOSE kursor_hist
DEALLOCATE kursor_hist
END
GO