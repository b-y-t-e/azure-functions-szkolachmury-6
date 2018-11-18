# azure-functions-szkolachmury-6

Opis zadania:
1. Stwórz prostą funkcję, opartą o timer, która dodaje wiadomości do kolejki typu Storage Queue. Kilka przykładów tutaj: https://docs.microsoft.com/en-us/sandbox/functions-recipes/queue-storage
2. Stwórz drugą funkcję, która czeka na wiadomości w Storage Queue i zapisuje jej do bazy – może to być darmowa wersja Azure SQL Database
3. Stwórz trzecią funkcję, która reaguje na request http i dla podanej w parametrze daty z dokładnością do dnia (żeby było prościej) zwraca z bazy Azure SQL wszystkie komunikaty z tego dnia, które tam zostały zapisane, najlepiej w postaci JSON’a
4. Stwórz Azure API Management (kiedy będziesz miał już wszystkie inne elementy gotowe) i wystaw na Azure API Management funkcję z zadania nr 3. Dodatkowo, dodaj do wywołania tej funkcji politykę, która nie pozwala jej wywołać częściej w minucie niż trzy razy
