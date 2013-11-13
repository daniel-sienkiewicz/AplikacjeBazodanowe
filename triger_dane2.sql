-- Trigger robiacy update na bazie danych po sprzedarzy produktu, sprawdzajacy stan towaru czy jest odpowiednia ilosc do sprzedazy

CREATE TRIGGER trigerek_dane2 ON koszyk
AFTER INSERT AS 
BEGIN  
DECLARE kursor_dane2 CURSOR 
FOR SELECT id_towar, ilosc from inserted
DECLARE @id_towar int, @ilosc int
OPEN kursor_dane2
FETCH NEXT FROM kursor_dane2 INTO @id_towar, @ilosc
WHILE @@FETCH_STATUS = 0
	BEGIN
		IF ((SELECT ilosc_sztuk FROM towar WHERE id_towar = @id_towar) - @ilosc) >= 0
		BEGIN
			UPDATE towar SET ilosc_sztuk = ilosc_sztuk - @ilosc WHERE id_towar = @id_towar;
			print 'Wykonano Update'
		
		END
		
		ELSE
		BEGIN
			print 'Za malo towaru'
			ROLLBACK	
		END
		
		FETCH NEXT FROM kursor_dane2
		INTO @id_towar, @ilosc
	END
CLOSE kursor_dane2
DEALLOCATE kursor_dane2
END
GO