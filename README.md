# Przykłady ze szkolenia Entity Framework dla zaawansowanych

## Opis
Szkolenie poświęcone problemom wydajnościowym, które są często spotykane gdy używamy Entity Framework.
Aplikacja zbudowana z użyciem SQL Server zawierającą 3 tabele, przechowującą połączenia (Calls) i powiązane urządzenia (Devices) i kontakty (Contacts).
Aplikacja konsolowa zbudowana w oparciu o Code First.

Materiał zainspirowany artykułem i przykładami
https://www.red-gate.com/simple-talk/dotnet/net-tools/entity-framework-performance-and-what-you-can-do-about-it/

## Uruchomienie
1. Zainstaluj SQL Server np. w wersji Express
2. Sklonuj to repozytorium.
3. Uruchom aplikację. Aplikacja utworzy automatyczne nową bazę danych SQL Server o nazwie `RadioDb` i wypełni przykładowymi danymi.

## Problemy wydajnościowe
1. Pobieranie więcej danych niż potrzebne
2. Problem pobierania N+1
3. Pobieranie większej ilości kolumn niż potrzebne
4. Narzut śledzenia obiektów
5. Porównanie metod Find, First, Single
6. Modyfikacja obiektów
7. Masowe wstawanie rekordów
8. Kaskadowe usuwanie
9. Efektywne mapowanie obiektów DTO z użyciem AutoMapper
10. Obsługa transakcji
11. Obsługa konkurencyjności
12. Wyszukiwanie po parametrach opcjonalnych
13. Widoki
14. Cache a metody Skip i Take
15. Generowanie pregenerowanych widoków z użyciem Power Tools
16. Zastosowanie interceptorów

## Aplikacja
1. ANTS Performance Profiler

## Biblioteki
1. Bogus
2. MethodTimer.Fody
3. AutoMapper


