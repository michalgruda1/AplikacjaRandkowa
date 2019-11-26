# AplikacjaRandkowa
Ćwiczebna aplikacja w ASP.NET Core MVC.

Podajemy dane kobiety, oraz mężczyzny, a aplikacja oblicza na podstawie kryteriów - czy są dopasowani do siebie, czy nie.

1. .Net Core 2.2, czyste APS.NET Core MVC (nie użyłem RazorPages, bo w poprzednim projekcie ich użyłem i chciałem się nauczyć bez RazorPages).
2. Kluczowe dla dopasowania dwóch osób usługi CriteriaBuilder oraz MatchGovernor są wstrzykiwane jako zależności do kontrolera. Listę kryteriów dopasowania buduję w CriteriaBuilder, ale samo przeliczenie wyniku dopasowania dla danej pary oraz decyzję - jest dopasowanie, czy nie ma - podejmuje MatchGovernor. Muszą być spełnione dowolne 2 z 3 kryteriów, żeby było dopasowanie.
3. DO zbierania danych używam tylko ViewModelu - domena i wymagania były na tyle proste, że uznałem rozdzielenie ViewModel i EditModel za przesadę. Na koniec zbierania danych, tworzę model domenowy MatchModel i wykonuję kalkulację dopasowania.
4. Bez bazy danych - stan utrzymywany między stronami za pomocą ukrytego pola ze zserializowanymi danymi z poprzedniego kroku formularza
5. Walidacja następuje po każdym wysłaniu danych formularza, a dodatkowo jeszcze raz (ktoś może manipulować danymi zserializowanymi i zapisanymi w polu ukrytym), przed uruchomieniem instacji modelu MatchModel, która dokonuje właściwego dopasowania i zwraca wynik
6. Kobieta i mężczyzna implementują interfejs IPerson, co umożliwia łatwe wprowadzenie dopasowań kobieta-kobieta i mężczyzna-mężczyzna
7. Spory problem sprawiło mi utrzymywanie synchronizacji wyświetlanych w adresie URL-i z rzeczywistym widokiem - nie są zsynchronizowane, t.j. w pewnym szczególnym przypadku widok dotyczący kobiety wyświetlam z URL-em podsumowania (akcja krok2post). To bym poprawił.
8. Walidacja działa w różnych locale (en-us , pl-pl).
9. Nie dołączałem logowania błędów / wyjątków, nie było w wymaganiach, ale trzebaby podłączyć gdyby to miała by być część większej aplikacji.
10. Nie podłączałem słowników do wielojęzyczności, nie było w wymaganiach.
