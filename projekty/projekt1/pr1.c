#include <stdlib.h>
#include <libpq-fe.h>
int searchT = 1;

void doSQL(PGconn *conn, char *command){
	PGresult *result;
	printf("%s\n", command);
	result = PQexec(conn, command);
	printf("Result message: %s\n", PQresultErrorMessage(result));	
	
	switch(PQresultStatus(result)) {
		case PGRES_TUPLES_OK:{
			int n = 0, m = 0;
			int nrows   = PQntuples(result);
			int nfields = PQnfields(result);
			for(m = 0; m < nrows; m++) {
				for(n = 0; n < nfields; n++)
					printf(" %s = %s", PQfname(result, n),PQgetvalue(result,m,n));
				printf("\n");
      			}

			if(nrows == 0 || nfields == 0){
				printf("Car does not exist in database!");
				searchT = 0;
			}
		}
	}

	PQclear(result);
}

//wyszukiwanie w bazie
void searchTMP(PGconn *conn, int id){
	char zapytanie[200];
	sprintf(zapytanie, "SELECT * FROM cars WHERE id_car = %d", id);	
	doSQL(conn, zapytanie);
}

//wypisanie calej bazy
void print(PGconn *conn){
	PGresult *result;
	result = PQexec(conn, "SELECT * FROM cars");

	if(PQresultStatus(result) == PGRES_TUPLES_OK){
		PQprintOpt pqp;
		pqp.header = 1;
		pqp.align = 1;
		pqp.html3 = 1;
		pqp.expanded = 0;
		pqp.pager = 0;
		pqp.fieldSep = "";
		pqp.tableOpt = "align=center";
		pqp.caption = "Cars list";
		pqp.fieldName = NULL;
		printf("<HTML><HEAD></HEAD><BODY>\n");
		PQprint(stdout, result, &pqp);
		printf("</BODY></HTML>\n");
	}
}

//dodanie do bazy
void add(PGconn *conn){

	char zapytanie[200];
	char make[20], model[20], yop[10];
	double price, capacity;
	
	printf("Set make: ");
	scanf("%s", make);
	
	printf("Set model: ");
	scanf("%s", model);
	
	printf("Set price: ");
	scanf("%lf", &price);
	
	printf("Set capacity: ");
	scanf("%lf", &capacity);
	
	printf("Set year of production: ");
	scanf("%s", yop);
	
	printf("Your data: %s, %s, %lf, %lf, %s", make, model, price, capacity, yop);
	sprintf(zapytanie, "INSERT INTO cars (make, model, price, capacity, yop) VALUES(\'%s\', \'%s\', %.2lf, %.1lf, \'%s\')", make, model, price, capacity, yop);
	doSQL(conn, zapytanie);
}

//update elementu w bazie
void update(PGconn *conn){
	int id;
	char zapytanie[200];
	char make[20], model[20], yop[10];
	double price, capacity;
	char odp;

	printf("Set id car to update: ");
	scanf("%d", &id);
	searchTMP(conn, id);
		
	if(searchT){
		sprintf(zapytanie, "SELECT * FROM cars WHERE id_car = %d", id);
		doSQL(conn, zapytanie);
		
		printf("Would you like to change make? Y/N: ");
		getchar();		
		scanf("%c", &odp);
		
		if(odp == 89 || odp == 121){
			printf("Set new make: ");
			scanf("%s", make);
			sprintf(zapytanie, "UPDATE cars SET make = \'%s\' WHERE id_car = %d", make, id); 
			doSQL(conn, zapytanie);
			odp = 0;

		}	
        	printf("Would you like to change model? Y/N: ");
		getchar();        	
		scanf("%c", &odp);
        	
		if(odp == 89 || odp == 121){
			printf("Set new model: ");
			scanf("%s", model);
			sprintf(zapytanie, "UPDATE cars SET model = \'%s\' WHERE id_car = %d", model, id); 
			doSQL(conn, zapytanie);
			odp = 0;
		}

		printf("Would you like to change price? Y/N: ");
		getchar();        
		scanf("%c", &odp);
        	
		if(odp == 89 || odp == 121){
                	printf("Set new price: ");
                	scanf("%lf", &price);
                	sprintf(zapytanie, "UPDATE cars SET price = %.2lf WHERE id_car = %d", price, id); 
                	doSQL(conn, zapytanie);
                	odp = 0;
	
        	} 
		
        	printf("Would you like to change capacity? Y/N: ");
		getchar();        
		scanf("%c", &odp);
        	
		if(odp == 89 || odp == 121){
                	printf("Set new capacity: ");
                	scanf("%lf", &capacity);
                	sprintf(zapytanie, "UPDATE cars SET capacity = %.1lf WHERE id_car = %d", capacity, id); 
                	doSQL(conn, zapytanie);
                	odp = 0;
	  
		}	 
		
       		printf("Would you like to change year of production? Y/N: ");
		getchar();       	 
		scanf("%c", &odp);
        	
		if(odp == 89 || odp == 121){
 	              	printf("Set new year of production: ");
			scanf("%s", yop);
                	sprintf(zapytanie, "UPDATE cars SET yop = \'%s\' WHERE id_car = %d", yop, id); 
               		doSQL(conn, zapytanie);
                	odp = 0;
        	}  
	}

	searchT = 1;
}

//usuniecie elementy z bazy
void drop(PGconn *conn){
	int id;
	char zapytanie[200];
	
	printf("Set id car to delete: ");
	scanf("%d", &id);
	searchTMP(conn, id);	
	
	if(searchT){
		sprintf(zapytanie, "DELETE FROM cars WHERE id_car = %d", id);
		doSQL(conn, zapytanie);	
	}

	searchT = 1;
}

//wyszukiwanie w bazie
void search(PGconn *conn){
	int id;
	char zapytanie[200];
	
	printf("Set id car to search: ");
	scanf("%d", &id);
	sprintf(zapytanie, "SELECT * FROM cars WHERE id_car = %d", id);
	doSQL(conn, zapytanie);
}

//strowrzenie triggera w bazie
void createTrigger(PGconn *conn){
	doSQL(conn, "CREATE FUNCTION car_wpis() RETURNS trigger AS $$ BEGIN IF character_length(NEW.make) < 2 THEN RAISE EXCEPTION 'Wrong make'; END IF; IF character_length(NEW.model) < 2 THEN RAISE EXCEPTION 'Wrong model'; END IF; IF NEW.price < 1000 THEN RAISE EXCEPTION 'Price to small'; END IF; IF NEW.capacity > 5 THEN RAISE EXCEPTION 'Wrong capacity'; END IF; RETURN NEW; END; $$ LANGUAGE plpgsql;");
	doSQL(conn, "CREATE TRIGGER car_insert BEFORE INSERT OR UPDATE ON cars FOR EACH ROW EXECUTE PROCEDURE car_wpis();");
}

void delTrigger(PGconn *conn){
	doSQL(conn, "DROP TRIGGER car_insert on cars;");
	doSQL(conn, "DROP FUNCTION car_wpis();");
}

void addData(PGconn *conn){

	//dodanie przykladowych danych
	doSQL(conn, "INSERT INTO cars (make, model, price, capacity, yop) values('Audi', '80', 6000.0, 1.8, '04.05.1991')");
        doSQL(conn, "INSERT INTO cars (make, model, price, capacity, yop) values('Volkswagen', 'Sharan', 8000.0, 2.0, '16.03.1997')");
        doSQL(conn, "INSERT INTO cars (make, model, price, capacity, yop) values('Audi', 'A3', 10000.0, 1.6, '25.12.1997')");
        doSQL(conn, "INSERT INTO cars (make, model, price, capacity, yop) values('Seat', 'Ibiza', 6000.0, 1.9, '01.09.2001')");
        doSQL(conn, "INSERT INTO cars (make, model, price, capacity, yop) values('Renault', 'Megane', 15000.0, 2.2, '10.02.2006')");
}

//usuniecie tabeli
void dropTable(PGconn *conn){
	doSQL(conn, "DROP TABLE cars");
}

int main(void){
	PGresult *result;
	PGconn   *conn;
	int z;
	conn = PQconnectdb("host=localhost port=5432 dbname=dsienkiewicz user=dsienkiewicz password=aplikacje");
	
	if(PQstatus(conn) == CONNECTION_OK) {
		printf("connection made\n");
    
		//czyszczenie ekranu
		system("clear");

		//menu
		do{
			printf("\n 1 - Create table");
			printf("\n 2 - Add sample data");
			printf("\n 3 - Print");
			printf("\n 4 - Add");
			printf("\n 5 - Drop from table");
			printf("\n 6 - Update");
			printf("\n 7 - Search");
                        printf("\n 8 - Add Trigger");
                        printf("\n 9 - Drop Trigger");
			printf("\n 10 - Drop Table");
			printf("\n 11 - Exit");
			printf("\n choice: ");
			scanf("%d", &z);
			
			switch(z){

				case 1: doSQL(conn, "CREATE TABLE cars(id_car SERIAL PRIMARY KEY, make VARCHAR(20), model VARCHAR(20), price money, capacity numeric(8,1), yop date);");
					break;
				case 2: addData(conn);
					break;
				case 3:	print(conn);
					break;
				case 4: add(conn);
					break;
				case 5: drop(conn);
					break;
				case 6:	update(conn);
					break;
				case 7: search(conn);
					break;
				case 8: createTrigger(conn);
					break;
				case 9: delTrigger(conn);
					break;
				case 10: dropTable(conn);
					break;
			}

		}while(z != 11);
		
		printf("Bye, bye ...\n");
	}
	
	else
		printf("connection failed: %s\n", PQerrorMessage(conn));

	PQfinish(conn);
	return EXIT_SUCCESS;
}
