-- Procedura sprawdzajaca czy pesel jest ok

CREATE FUNCTION spr_pesel (@pesel CHAR(11))
RETURNS BIT
AS
BEGIN
	IF(LEN(@pesel) = 11) AND (ISNUMERIC(@pesel) = 0)
		RETURN 0
	DECLARE
		@wagi AS TABLE (pozycja TINYINT IDENTITY(1,1), waga TINYINT)
	INSERT INTO @wagi VALUES (1), (3), (7), (9), (1), (3) ,(7), (9), (1), (3), (1) 
	IF (SELECT SUM(CONVERT(TINYINT, SUBSTRING(@pesel, pozycja, 1)) *waga)%10 FROM @wagi) = 0
		RETURN 1
	RETURN 0
END