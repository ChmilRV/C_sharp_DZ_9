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
    public delegate int TamaDelegate();
    public class Tamagochi
    {
        SortedList<int, TamaDelegate> _sortedEvents = new SortedList<int, TamaDelegate>();
        Random _rand = new Random();
        public static event TamaDelegate TamaNotify
        {
            add
            {
                for (int key; ;)
                {
                    key = _rand.Next();
                    if (!_sortedEvents.ContainsKey(key))
                    {
                        _sortedEvents.Add(key, value);
                        break;
                    }
                }
            }
            remove
            {
                _sortedEvents.RemoveAt(_sortedEvents.IndexOfValue(value));
            }
        }




        public static string Name { get; set; } = "Персонаж";
        public static int LifeCount { get; set; }
        public static void ShowChudik()
        {
            WriteLine();
        }

        public static int FeedMe()
        {
            WriteLine($"{Name} хочет есть. Жизней {LifeCount}.");
            DialogResult result = MessageBox.Show("Покорми мня!!!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                WriteLine($"{Name} покормлен. Жизней {LifeCount}.");
                return 1;
            }
            else
            {
                WriteLine($"{Name} непокормлен. Жизней {LifeCount}.");
                return -1;
            }
            
        }
        public static int WalkWithMe()
        {
            DialogResult result = MessageBox.Show("Погуляй со мной!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes) return 1;
            else return -1;
        }
        public static int PutMeToBad() 
        {
            DialogResult result = MessageBox.Show("Положи спать!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) return 1;
            else return -1;
        }
        public static int PlayWithMe() 
        {
            DialogResult result = MessageBox.Show("Поиграй со мной!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) return 1;
            else return -1;
        }
        public static int HealMe()
        {
            DialogResult result = MessageBox.Show("Полечи меня!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) return 1;
            else return -1;
        }
        public void DeadTama()
        {
            MessageBox.Show("Конец!", Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        public static int TamaEventDo()
        {
            



            return (int)TamaNotify?.Invoke();

        }


        class Program
        {
            static void Main(string[] args)
            {
                Title = "Тамагочи";
                LifeCount = 5;
                do
                {
                    WriteLine($"Жизней до: {LifeCount}.");

                    LifeCount = LifeCount + TamaEventDo();
                    WriteLine($"Жизней после: {LifeCount}.");

                } while (LifeCount >= 0);
                WriteLine("Anykey.");
                ReadKey();
            }
        }
    }
}
