Projekt ASP.NET Core z bazą danych
Opis instalacji:
Pobranie projektu:

Pobierz projekt z repozytorium GitHub.
Umieść projekt w odpowiednim katalogu na swoim komputerze.
Konfiguracja bazy danych:

Utwórz bazę danych na swoim serwerze SQL.
Skonfiguruj połączenie z bazą danych w pliku appsettings.json w projekcie ASP.NET Core. Znajdziesz tam sekcję ConnectionStrings do edycji.
Migracje:

Otwórz konsole pakietów projektu.
Uruchom komendę migrations add InitialMigration, aby utworzyć migrację inicjalną.
Następnie uruchom komendę  database update, aby zastosować migracje i utworzyć strukturę bazy danych.
Uruchomienie projektu:

Uruchom projekt w środowisku Visual Studio lub za pomocą terminala komendą dotnet run.
Upewnij się, że aplikacja jest dostępna pod adresem localhost:5000 (lub localhost:5001 z protokołem HTTPS).
Otwarcie strony:

Otwórz przeglądarkę i przejdź do adresu localhost:5000 (lub localhost:5001).
Rejestracja:

Zarejestruj nowe konto na stronie, aby uzyskać dostęp do aplikacji.
Konfiguracja:
Po zalogowaniu się na konto administratora (domyślne konto: administrator@admin.pl, hasło: test123@), zyskujesz dodatkowe uprawnienia.
Dostępy:


Dla niezalogowanego użytkownika:
        Logowanie
        Rejestracja

Dla zalogowanego użytkownika:
        Wyświetlanie listy kontaktów.
        Wylogowywanie

Dla administratora:
        Wyświetlanie zakładki kontakty.
        Dodawanie grup.
        Dodawanie adresów.
        Dodawanie Kontaktów.
