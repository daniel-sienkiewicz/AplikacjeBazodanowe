-- Trigger poprawiajacy imie i nazwisko aby zaczynalo sie z duzej litery, 
-- sprawdzajacy czy pensja jest wystarczajaco duza, osoba jest pelnoletnia oraz czy pesel jest ok

CREATE TRIGGER trigerek ON osoba 
AFTER INSERT AS 
BEGIN  
DECLARE kursor_up CURSOR 
FOR SELECT id_osoba, imie, nazwisko, pesel, pensja, data_ur from inserted
DECLARE @id int, @imie varchar(20), @nazwisko varchar(20), @pesel char(11), @pensja int, @data_ur date
OPEN kursor_up
FETCH NEXT FROM kursor_up INTO @id, @imie, @nazwisko, @pesel, @pensja, @data_ur
WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF (ascii(SUBSTRING(@imie, 1, 1)) > 96)
		BEGIN
			UPDATE osoba SET imie = UPPER(left(@imie, 1)) + SUBSTRING(@imie,2,LEN(@imie)) where id_osoba = @id;
			print 'Zmieniono: ' + @imie + ' ' + @nazwisko
		END
		
		IF (ascii(SUBSTRING(@nazwisko, 1, 1)) > 96)
		BEGIN
			UPDATE osoba SET nazwisko = UPPER(left(@nazwisko, 1)) + SUBSTRING(@nazwisko,2,LEN(@nazwisko)) where id_osoba = @id;
			print 'Zmieniono: ' + @imie + ' ' + @nazwisko
		END
		
		IF @pensja < 111
			BEGIN
				print 'Za mala pensja'
				ROLLBACK
			END
			
		IF YEAR( GETDATE() ) - YEAR( @data_ur ) < 18
			BEGIN
				print 'Nie pelnoletnia osoba'
				ROLLBACK
			END
		IF dbo.spr_pesel(@pesel) = 0
			BEGIN
				print 'Zly pesel'
				ROLLBACK
			END
		FETCH NEXT FROM kursor_up
		INTO @id, @imie, @nazwisko, @pesel, @pensja, @data_ur
	END
CLOSE kursor_up
DEALLOCATE kursor_up
END
GO