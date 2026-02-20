#### *3.1* QA - Антон Скляр, Core - Віталій Єременко
---
#### *3.2*  Запуск тестів - команда `dotnet test` на рівні <b>sln</b> або <b>csproj nunit-project</b>
---
#### *3.3*  Функціонал   Як перевірити  Очікуваний результат
    List через Enumerator  GetEnumerator() + MoveNext() + Current  Всі елементи перебираються по черзі
    
    Сортування за замовчуванням  list.Sort() (IComparable)  Елементи відсортовані по priority
    
    Альтернативне сортування  list.Sort(new DeliveryTitleComparer())  Елементи відсортовані по назві
    
    Статистика (Stats)  ShowDayResult() / ShowAllDaysResult()  Правильна кількість departured по днях

