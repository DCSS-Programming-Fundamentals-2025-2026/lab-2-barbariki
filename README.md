### core Віталій Єременко  
## Функціонал   Як перевірити  Очікуваний результат
List через Enumerator  GetEnumerator() + MoveNext() + Current  Всі елементи перебираються по черзі

Сортування за замовчуванням  list.Sort() (IComparable)  Елементи відсортовані по priority

Альтернативне сортування  list.Sort(new DeliveryTitleComparer())  Елементи відсортовані по назві

Статистика (Stats)  ShowDayResult() / ShowAllDaysResult()  Правильна кількість departured по днях
