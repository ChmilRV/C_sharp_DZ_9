﻿using System;
using static System.Console;
using System.Management;
using System.Windows.Forms;
//using System.Timers;
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
За получением подробной информации по работе с этим методом обратитесь к Вашему преподавателю или в MSDN.
Для решения этой задачи Вам понадобится класс Timer из пространства имен System.Timers,
событие которого Elapsed, типа делегата ElapsedEventHandler,
происходит через определенный интервал времени, который задан в свойстве Interval.
Методы Start() и Stop() запускают и останавливают таймер, соответственно.
Вы также можете захотеть делать паузы в работе приложения,
в этом случае можно вызвать метод Sleep() класса Thread из пространства имен System.Threading,
передав в него необходимое количество миллисекунд.*/
namespace C_sharp_DZ_9_1
{
    public class Tamagochi
    {
        public string Name { get; set; } = "Чудик";
        public void ShowChudik()
        {
            WriteLine();



        }
        public string FeedMe()
        {
            string feedMe = "Покорми меня!";
            WriteLine(feedMe);
            return feedMe;
        }
        public void WalkWithMe() { WriteLine("Погуляй со мной!"); }
        public void PutMeToBad() { WriteLine("Положи спать!"); }
        public void HealMe() { WriteLine("Полечи меня!"); }
        public void PlayWithMe() { WriteLine("Поиграй со мной!"); }
        delegate void Request(string request);
        event Request Notify;


    }


    class Program
    {
        static void Main(string[] args)
        {
            Title = "Тамагочи";
            bool dead = false;
            //Timer timer1 = new Timer();
            //timer1.Interval = 2000;
            //timer1.Start();
            //MessageBox.Show("Тестовое сообщение", "Шапка окна", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            Tamagochi chudik = new Tamagochi();
            WriteLine(chudik.Name);
            chudik.FeedMe();
            chudik.WalkWithMe();
            chudik.PutMeToBad();
            chudik.HealMe();
            chudik.PlayWithMe();
            MessageBox.Show(chudik.FeedMe(), chudik.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show(chudik.FeedMe(), chudik.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show(chudik.FeedMe(), chudik.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show(chudik.FeedMe(), chudik.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show(chudik.FeedMe(), chudik.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            do
            {




            } while (!dead);
            
            

            ReadKey();
        }
    }
}