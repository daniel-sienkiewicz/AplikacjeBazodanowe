-- widok wyliczajacy cos tam

CREATE VIEW klienci_statystyki
AS
SELECT k.imie, k.nazwisko, SUM( (1+t.podatek)*t.cena_netto) AS suma, COUNT(z.id_klient) AS ilosc  
FROM (((klient k 
	INNER JOIN zakup z ON k.id_klient = z.id_klient)
		INNER JOIN koszyk kosz ON z.id_zakup = kosz.id_zakup) 
			INNER JOIN towar t ON t.id_towar = kosz.id_towar) GROUP BY k.nazwisko, k.imie;