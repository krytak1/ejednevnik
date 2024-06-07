using System.Linq;
using System.Net.Mime;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplicationPracticeOne.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplicationPracticeOne;

public partial class DailyPlannerWindow : Window
{
    
    public DailyPlannerWindow()
    {
        InitializeComponent();
        
    }
    private void tasksWindowBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        new tasksWindow().Show();
        
        Close();
    }
    private void addTasksBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        new addTasksWindow().Show();
        
        Close();
    }
    private void leaveBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        new DailyPlannerWindow().Show();
        
        Close();
    }
}