using System.Windows.Controls;
using MoneyManager.Main.ViewModels;

namespace MoneyManager.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl
    {
        
        public Schedule()
        {
            InitializeComponent();
            DataContext = new ScheduleViewModel();
            /* Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@312e312e30ErbYfogaQurE4W+mpMu0B+8y9MzNoA5+eit15bG1Zzw=");
             ScheduleAppointmentCollection appointmentCollection = new ScheduleAppointmentCollection();
             //Creating new event   
             ScheduleAppointment clientMeeting = new ScheduleAppointment();
             DateTime currentDate = DateTime.Now;
             DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
             DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
             clientMeeting.StartTime = startTime;
             clientMeeting.EndTime = endTime;
             clientMeeting.Subject = "ClientMeeting";
             appointmentCollection.Add(clientMeeting);
             Scheduler.ItemsSource = appointmentCollection;*/
            

            //Events.Add(new MyCustomEvent() { DateFrom = startDate.AddDays(2), DateTo = startDate.AddDays(5), Label = "Overlapping event 2" });
            //Events.Add(new MyCustomEvent() { DateFrom = startDate.AddDays(4), DateTo = startDate.AddDays(6), Label = "Overlapping event 3" });
            //Events.Add(new MyCustomEvent() { DateFrom = startDate.AddDays(7), DateTo = startDate.AddDays(8), Label = "Event 4" });

            // draw days with events calendar
        }
       
    }
}
