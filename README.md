# Vita Notes Manager

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-5C2D91?style=for-the-badge&logo=xamarin&logoColor=white)
![JSON](https://img.shields.io/badge/JSON-Storage-000000?style=for-the-badge&logo=json&logoColor=white)

Vita Notes Manager — это лёгкое консольное приложение на C# для хранения личных заметок и простых записей состояния в локальных JSON-файлах. В проекте есть вход по паролю и базовое XOR-шифрование сохранённых данных.

## Возможности

- Создание, просмотр и удаление заметок
- Хранение простых записей состояния по шкале от 1 до 10
- Локальное сохранение данных в зашифрованных JSON-файлах
- Проверка пароля при запуске приложения

## Запуск

```bash
dotnet run --project ConsoleApp
```

## Тесты

```bash
dotnet test ConsoleAppTests
```
