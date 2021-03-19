using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MarathonSkills
{
    public static class Countown
    {
        
        private static DateTime MarathonStartTime = new DateTime(2021, 11, 24, 6, 0, 0);




        public static void Start(Label label) {

            Task.Run(() => UpdateTime(label));

            
        
        }

        private static async Task UpdateTime(Label label) {


            while (label.IsVisible)
            {
                TimeSpan TimeLeft = MarathonStartTime - DateTime.Now;
                

                label.Dispatcher.Invoke(() =>
                {
                    label.Content = String.Format("До начала марафона осталось дней: {0}, часов: {1}, минут: {2}", TimeLeft.Days, TimeLeft.Hours, TimeLeft.Minutes);

                });

                if(TimeLeft == TimeSpan.Zero)
                {
                    label.Content = "Марафон начался!";
                }

                await Task.Delay(1000);

            }

        
        
        }


    }
}
