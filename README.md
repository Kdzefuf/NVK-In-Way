# NVK In Way Project

## Проблема: 

Студенты живущие в НВК постоянно сталкиваются с трудностями в организации своих поездок в город и на пары в УрФУ. Задача нашего сервиса упростить поиск попуток для студентов.

В нашем проекте разрабатывается для предоставления пользователям следующая функциональность:

- Создание водителями "поездок" из одной точки в другую. С целью их заработка денег и просто добрых дел.
- Регистрация пассажиров на "поездки" к водителю.
- Объединение пассажиров в группу для поедки вместе на такси.
- Система учета и демонстрации рейтинга и числа соверешенных поездок водителями и пассажирами.
- Возможность модерации.

## Основные сценарии использования

Водитель:
- Посмотреть список поездок
  - посмотреть список активных поездок
  - посмотреть пассажиров
  - написать пассажирам
  - исключить пассажира из поездки
- Создать поездку
- Редактировать профиль
  - добавить машину, удалить, изменить
 
Пассажир:
- Посмотреть список поездок
  - посмотреть информацию о поездке
  - отписаться от поездки
- Записаться на поездку созданную водителем
- Создать поиск группы на поедку на такси
  - удалить созданную группу поездки на такси
- Записать на поездку на такси

Модератор:
- Просмотр поездок
- Просмотр профилей
- Просмотр списока жалоб
- Исключение пользователей из сервиса

## Точки расширения

1. Возможность создания нового вида [пользователя](backend/NvkInWayWebApi.Domain/Models/Profiles/UserProfile.cs)
2. Добавление новых сущностей и репозиториев наследуюясь от [CommonRepository](backend/NvkInWayWebApi.Persistence/Repositories/CommonRepository.cs)

## Точки расширений не с точки зренения мехенизмов делегирования, наследования, работы с метаинформацией

- Существуюет возможность создать нескольких клиентов-ботов, взаимодействующий с единым бэкэндом
- Возможность создать интеграции с сервисами для уведомлений пользователя
- Планируется добавление геометок для поездок

## Использование DI-контейнеров:

- [Конфигурирование зависимостей слоя Persistance](backend/NvkInWayWebApi.Persistence/DependencyInjection.cs)
- [Конфигурирование зависимостей слоя Application](backend/NvkInWayWebApi.Application/DependencyInjection.cs)
- [Конфигурирование зависимостей Web Api](backend/NvkInWayWebApi/Program.cs)

## Разделение кода

Код в API разделяется на следующие слои:
- Domain
- Application
- Persistence
- Presentation

## Код обработки ошибок:
- [DriverRepository](backend/NvkInWayWebApi.Persistence/Repositories/DriverRepository.cs)
- И другие репозитории


