#include<stdlib.h>
#include<libpg-fe.h>

int main(){
	PGconnect *myconnection = PQconnectdb("host=localhost port=5432 dbname=nazwa user=uzytkownik passowrdd=haslo");
	if(PQstatus(myconnection) == CONNECTION_OK){
		printf("dupa");	
	}
}
