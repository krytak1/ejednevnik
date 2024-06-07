using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationPracticeOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;

namespace AvaloniaApplicationPracticeOne
{
    public partial class tasksWindow : Window
    {
        private DataGrid tasksDataGrid;

        public tasksWindow()
        {
            InitializeComponent();
            tasksDataGrid = this.FindControl<DataGrid>("TasksDataGrid");
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            LoadTasks(task => task.Duedata == today);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void LoadTasks(Func<Task, bool> filter)
        {
            var db = Service.GetDbContext();
            var tasks = db.Tasks.Where(filter).ToList();
            tasksDataGrid.Items = tasks.Count > 0
                ? tasks
                : new List<Task> { new Task { Title = "Нет задач для отображения" } };
        }
        
        private void ViewTodayTasks_OnClick(object? sender, RoutedEventArgs e)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            LoadTasks(task => task.Duedata == today);
        }

        private void ViewTomorrowTasks_OnClick(object? sender, RoutedEventArgs e)
        {
            DateOnly tomorrow = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            LoadTasks(task => task.Duedata == tomorrow);
        }

        private void ViewWeekTasks_OnClick(object? sender, RoutedEventArgs e)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            DateOnly endOfWeek = today.AddDays(7);
            LoadTasks(task => task.Duedata >= today && task.Duedata <= endOfWeek);
        }

        private void ViewAllTasks_OnClick(object? sender, RoutedEventArgs e)
        {
            LoadTasks(task => true);
        }

        private void ViewUpcomingTasks_OnClick(object? sender, RoutedEventArgs e)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            LoadTasks(task => task.Duedata > today);
        }

        private void ViewCompletedTasks_OnClick(object? sender, RoutedEventArgs e)
        {
            LoadTasks(task => task.Iscompleted == true);
        }
        
        private void DeleteTask_OnClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Task task)
            {
                Service.GetDbContext().Tasks.Remove(task);
                Service.GetDbContext().SaveChanges();
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                LoadTasks(t => t.Duedata == today);
            }
        }

        private void CompleteTask_OnClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Task task)
            {
                task.Iscompleted = true;
                Service.GetDbContext().Tasks.Update(task);
                Service.GetDbContext().SaveChanges();
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                LoadTasks(task => task.Duedata == today);

                button.Background = Brushes.LightGreen;
                button.Content = "Выполнено";
            }
        }

        private void leaveBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            new DailyPlannerWindow().Show();
        
            Close();
        }
    }
}