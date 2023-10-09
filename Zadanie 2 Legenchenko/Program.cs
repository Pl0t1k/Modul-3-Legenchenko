using System;

// Определение класса "Уведомление"
public class Notification
{
    // Определение делегата для события
    public delegate void NotificationEventHandler(string message);

    // Определение событий
    public event NotificationEventHandler MessageNotification;
    public event NotificationEventHandler CallNotification;
    public event NotificationEventHandler EmailNotification;

    // Методы для вызова событий
    public void OnMessageNotification(string message)
    {
        MessageNotification?.Invoke(message);
    }

    public void OnCallNotification(string message)
    {
        CallNotification?.Invoke(message);
    }

    public void OnEmailNotification(string message)
    {
        EmailNotification?.Invoke(message);
    }
}

namespace Zadanie_2_Legenchenko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра класса "Уведомление"
            var notification = new Notification();

            // Регистрация обработчиков событий
            notification.MessageNotification += (message) => Console.WriteLine($"Сообщение: {message}");
            notification.CallNotification += (message) => Console.WriteLine($"Звонок: {message}");
            notification.EmailNotification += (message) => Console.WriteLine($"Электронное письмо: {message}");

            // Вызов событий
            notification.OnMessageNotification("Привет, это сообщение!");
            notification.OnCallNotification("Привет, это звонок!");
            notification.OnEmailNotification("Привет, это электронное письмо!");
        }
    }
}
