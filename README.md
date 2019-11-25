# AplikacjaRandkowa
Ćwiczebna aplikacja w ASP.NET Core MVC.

Podajemy dane kobiety, oraz mężczyzny, a aplikacja oblicza na podstawie kryteriów - czy są dopasowani do siebie, czy nie.

1. .Net Core 2.2, czyste APS.NET Core MVC (nie użyłem RazorPages, bo w poprzednim projekcie ich użyłem i chciałem się nauczyć bez RazorPages).
2. Kluczowe dla dopasowania dwóch osób usługi MatchCriteria oraz MatchGovernor są wstrzykiwane jako zależności do kontrolera
3. Bez bazy danych - stan utrzymywany między stronami za pomocą ukrytego pola ze zserializowanymi danymi z poprzedniego kroku formularza
4. Walidacja następuje po każdym wysłaniu danych formularza, a dodatkowo jeszcze raz (ktoś może manipulować danymi zserializowanymi i zapisanymi w polu ukrytym), przed uruchomieniem instacji modelu MatchModel, która dokonuje właściwego dopasowania i zwraca wynik
5. Rozdzielenie listy kryteriów dopsowania MatchCriteria od decyzji (MatchGovernor) na podstawie kryteriów - czy mamy dopasowanie, czy nie
6. Kobieta i mężczyzna implementują interfejs IPerson, co umożliwia łatwe wprowadzenie dopasowań kobieta-kobieta i mężczyzna-mężczyzna
7. Spory problem sprawiło mi utrzymywanie synchronizacji wyświetlanych w adresie URL-i z rzeczywistym widokiem - nie są asynchronizowane, t.j. widok dotyczący kobiety (akcja krok1Get) wyświetlam z kroku podsumowania (akcja krok2post)
8. Walidacja działa w różnych locale (en-us , pl-pl)
9. Nie dołączałem logowania błędów / wyjątków, to dołączyłbym w większej aplikacji
10. Nie podłączałem słowników do wielojęzyczności, bo to nie było w wymaganiach
