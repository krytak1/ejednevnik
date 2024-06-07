using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationPracticeOne.Models;
using Task = AvaloniaApplicationPracticeOne.Models.Task;

namespace AvaloniaApplicationPracticeOne;

public partial class addTasksWindow : Window
{
    
    public addTasksWindow()
    {
        InitializeComponent();

        titleTBox = this.FindControl<TextBox>("titleTBox");
        descriptionTBox = this.FindControl<TextBox>("descriptionTBox");
        dueDataDPicker = this.FindControl<DatePicker>("dueDataDPicker");

#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void addTaskBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
        if (!string.IsNullOrWhiteSpace(titleTBox.Text) &&
            !string.IsNullOrWhiteSpace(descriptionTBox.Text) &&
            !string.IsNullOrWhiteSpace(dueDataDPicker.SelectedDate.ToString()))
        {
            string title = titleTBox.Text;
            string description = descriptionTBox.Text;
            DateOnly dueDate = DateOnly.FromDateTime(dueDataDPicker.SelectedDate.Value.DateTime);
            
            Models.Task newTask = new Models.Task
            {
                Title = title,
                Description = description,
                Duedata = dueDate
            };
            
            Service.GetDbContext().Tasks.Add(newTask);
            Service.GetDbContext().SaveChanges();
            
            new DailyPlannerWindow().Show();
            
            Close();
        }
    }
    
    private void BackBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        new DailyPlannerWindow().Show();
        Close();
    }
}