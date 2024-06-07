using System.Linq;
using System.Net.Mime;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplicationPracticeOne.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplicationPracticeOne;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();

    }
    
    private void OpenDailyPlanner_Click(object? sender, RoutedEventArgs e)
    {
        new DailyPlannerWindow().Show();
        Close();
    }
}