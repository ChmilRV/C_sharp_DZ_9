﻿using System;
using static System.Console;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Lifetime;
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
        public string Name { get; set; }
        public int LifeCount { get; set; }
        
        public Tama(string name, int lifeCount)
        {
            Name = name;
            LifeCount = lifeCount;
        }
        public static void ShowTama()
        {
            WriteLine("(.^.)()()()()()()...");
        }
        public int Life()
        {
            string[] requestArray = { "Покорми", "Погуляй", "Положи спать", "Поиграй", "Полечи" };
            Random _rand = new Random();
            string request = requestArray[_rand.Next(0, 5)];
            DialogResult result = MessageBox.Show(request, Name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes) return 1;
            else return -1;
        }
        public void Kill(Object source, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("Конец!", Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void LifeEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            ShowTama();
            Life();
        }


    }
    class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
                Title = "Тамагочи";
                Tama pers = new Tama("Igor", 3);
                aTimer = new System.Timers.Timer(5000);
                aTimer.Elapsed += pers.LifeEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
                

                //do
                //{
                //} while (LifeCount >= 0);

                ReadKey();
        }
        
    }
}
