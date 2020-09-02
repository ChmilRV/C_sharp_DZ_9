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
    public delegate void TamaDelegate();
    public class Tamagochi
    {
        public event TamaDelegate TamaNotify;
        public string Name { get; set; } = "Чудик";
        public int LifeCount { get; set; } = 3;
        public void ShowChudik()
        {
            WriteLine();
        }

        public void FeedMe()
        {

            MessageBox.Show("Покорми мня!!!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);


        }

        public void WalkWithMe() => MessageBox.Show("Погуляй со мной!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        public void PutMeToBad() => MessageBox.Show("Положи спать!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        public void PlayWithMe() => MessageBox.Show("Поиграй со мной!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        public void HealMe() => MessageBox.Show("Полечи меня!", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        public void DeadTama()
        {
            MessageBox.Show("Конец!", Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void TamaEventDo()
        {
            TamaNotify += FeedMe;
            TamaNotify += WalkWithMe;
            TamaNotify?.Invoke();
        }


        class Program
        {



            static void Main(string[] args)
            {
                Title = "Тамагочи";
                //bool dead = false;
                Tamagochi pers1 = new Tamagochi();

                //TamaDelegate Feed = new TamaDelegate(pers1.FeedMe);
                //TamaDelegate Walk = new TamaDelegate(pers1.WalkWithMe);
                //TamaDelegate Bad = new TamaDelegate(pers1.PutMeToBad);
                //TamaDelegate Play = new TamaDelegate(pers1.PlayWithMe);


                //pers1.TamaNotify += pers1.FeedMe;
                //pers1.TamaNotify += pers1.WalkWithMe;
                pers1.TamaEventDo();

                //Feed();


                //do
                //{

                //} while (dead);



                ReadKey();
            }

            private static void Program_TamaEvent()
            {
                throw new NotImplementedException();
            }
        }
    }
}
