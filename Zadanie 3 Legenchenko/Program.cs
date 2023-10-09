using System;
using System.Collections.Generic;

// Определение делегата TaskDelegate
public delegate void TaskDelegate(string task);

public class TaskManager
{
    // Список задач
    private List<string> tasks = new List<string>();

    // Метод для добавления задачи
    public void AddTask(string task)
    {
        tasks.Add(task);
    }

    // Метод для выполнения задачи с использованием делегата
    public void ExecuteTask(TaskDelegate taskDelegate)
    {
        foreach (var task in tasks)
        {
            taskDelegate(task);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляра класса TaskManager
        TaskManager taskManager = new TaskManager();

        // Добавление задач
        taskManager.AddTask("Задача 1");
        taskManager.AddTask("Задача 2");

        // Определение делегата для отправки уведомления
        TaskDelegate notifyDelegate = (task) => Console.WriteLine($"Отправка уведомления для {task}");

        // Определение делегата для записи в журнал
        TaskDelegate logDelegate = (task) => Console.WriteLine($"Запись в журнал для {task}");

        // Выполнение задач с использованием делегатов
        taskManager.ExecuteTask(notifyDelegate);
        taskManager.ExecuteTask(logDelegate);
    }
}
