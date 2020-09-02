using System;
using static System.Console;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Разработать приложение «Тамагочи». Жизненный цикл персонажа — 1-2 минуты.
Персонаж случайным образом выдаёт просьбы (но подряд одна и та же просьба не выдаётся).
Просьбы могут быть следующие: Покормить, Погулять, Уложить спать, Полечить, Поиграть.
Если просьбы не удовлетворяются трижды, персонаж «заболевает» и просит его полечить.
В случае отказа — «умирает». Персонаж отображается в консольном окне при помощи псевдографики.
Диалог с персонажем осуществляется посредством вызова метода Show() класса MessageBox
из пространства имен System.Windows.Forms.
Для решения этой задачи Вам понадобится класс Timer из пространства имен System.Timers,
событие которого Elapsed, типа делегата ElapsedEventHandler,
происходит через определенный интервал времени, который задан в свойстве Interval.
Методы Start() и Stop() запускают и останавливают таймер, соответственно.
Вы также можете захотеть делать паузы в работе приложения,
в этом случае можно вызвать метод Sleep() класса Thread из пространства имен System.Threading,
передав в него необходимое количество миллисекунд.*/
namespace C_sharp_DZ_9_1
{
    public class Tama
    {
        public string Name { get; set; } = "Персонаж";
        public int LifeCount { get; set; }
        Tama(string name, int lifeCount)
        {
            Name = name;
            LifeCount = lifeCount;
        }
        public void ShowTama()
        {
            WriteLine("(.^.)()()()()()()...");
        }
        private void Life(Object source, System.Timers.ElapsedEventArgs e)
        {
            ShowTama();
            WriteLine($"{Name} хочет есть. Жизней {LifeCount}.");
            Random _rand = new Random();
            DialogResult result = MessageBox.Show("Покорми мня!!!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                WriteLine($"{Name} покормлен. Жизней {LifeCount}.");
                
            }
            else
            {
                WriteLine($"{Name} непокормлен. Жизней {LifeCount}.");
                
            }
            
        }
        //public static int WalkWithMe()
        //{
        //    DialogResult result = MessageBox.Show("Погуляй со мной!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        //    if (result == DialogResult.Yes) return 1;
        //    else return -1;
        //}
        //public static int PutMeToBad() 
        //{
        //    DialogResult result = MessageBox.Show("Положи спать!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //    if (result == DialogResult.Yes) return 1;
        //    else return -1;
        //}
        //public static int PlayWithMe() 
        //{
        //    DialogResult result = MessageBox.Show("Поиграй со мной!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes) return 1;
        //    else return -1;
        //}
        //public static int HealMe()
        //{
        //    DialogResult result = MessageBox.Show("Полечи меня!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if (result == DialogResult.Yes) return 1;
        //    else return -1;
        //}
        public void Kill(Object source, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("Конец!", Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        }

    class Program
        {
            private static System.Timers.Timer aTimer;
            private static void SetTimer(Tama pers)
            {
                aTimer = new System.Timers.Timer(2000);
                aTimer.Elapsed += pers.Life;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
                
            }
            private static System.Timers.Timer killTimer;
            private static void SetKillTimer(Tama pers)
            {
                killTimer = new System.Timers.Timer(15000);
                killTimer.Elapsed += pers.Kill;
                killTimer.AutoReset = false;
                killTimer.Enabled = true;
                
            }


            static void Main(string[] args)
            {
                Title = "Тамагочи";
                Tama pers = new Tama("Igor", 3);
                SetTimer(pers);
                SetKillTimer(pers);

                //do
                //{
                //    WriteLine($"Жизней до: {LifeCount}.");
                //    LifeCount =+ TamaEventDo();
                //    WriteLine($"Жизней после: {LifeCount}.");
                //} while (LifeCount >= 0);

                ReadKey();
            }
        }
    }
}
