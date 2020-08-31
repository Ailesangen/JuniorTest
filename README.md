# JuniorTest
ASP.NET Core Web API + Postgresql

Задание выполнял по условию, ничего лишнего.
База Postgresql, создается с помощью моделей (Code first model).
В качестве IDE использовал VS Code.
API/запросы проверял через Postman, скриншоты добавлю в корень проекта.

Документация (чтобы была):
https://localhost:<port>/api/employees
https://localhost:<port>/api/posts
Получить список GET
Добавить запись POST
Изменить PUT
Удалить DELETE
При удалении/изменении дополнительно указывать PrimaryKey записи, например так:
DELETE https://localhost:<port>/api/employees/2
