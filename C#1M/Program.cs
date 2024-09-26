using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    abstract class Train : ITrain
    {
        string name;
        public double number { get; set; }
        public double cash { get; set; }
        public double number_free { get; set; }
        virtual public void set_m()
        {
            double w = 0; double b = 0; double C = 0;
            do
            {
                Console.WriteLine("Количество мест: ");
            } while (!Double.TryParse(Console.ReadLine(), out w) || w <= 0); number = w;
            do
            {
                Console.WriteLine("Стоимость места: ");
            } while (!Double.TryParse(Console.ReadLine(), out C) || C <= 0); cash = C;
            do
            {
                Console.WriteLine("Свободные места: ");
            } while (!Double.TryParse(Console.ReadLine(), out b) || b <= 0 || b > number); number_free = b;
        }
        virtual public void get_m()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Кол-во мест - " + number);
            Console.WriteLine("Стоимость места - " + cash);
            Console.WriteLine("Кол-во свободных мест - " + number_free);
        }
        virtual public void NAME()
        {
            Console.WriteLine("Поезд ");
        }
        virtual public void sell()
        {
            double a = 0;
            Console.WriteLine("Кол-во свободных мест - " + number_free);
            do
            {
                Console.WriteLine("Сколько билетов продать?: ");
            } while (!Double.TryParse(Console.ReadLine(), out a) || a < 0 || a >= number_free); number_free -= a;
        }
        virtual public void tea()
        {
            double d = number - number_free;
            Console.WriteLine("Вы разнесли " + d + " чая");
        }
        virtual public void unique() { }
    }
    interface ITrain
    {
        void NAME();
        void set_m();
        void get_m();
        void sell();
        void tea();
        void unique();
    }
    class Drezina : ITrain
    {
        const string name = "Дрезина";
        public double number { get; set; }
        public double cash { get; set; }
        public double number_free { get; set; }
        override public string ToString()
        {
            return (name);
        }
        public void set_m()
        {
            {
                double w = 0; double b = 0; double C = 0;
                do
                {
                    Console.WriteLine("Количество мест: ");
                } while (!Double.TryParse(Console.ReadLine(), out w) || w <= 0); number = w;
                do
                {
                    Console.WriteLine("Стоимость места: ");
                } while (!Double.TryParse(Console.ReadLine(), out C) || C <= 0); cash = C;
                do
                {
                    Console.WriteLine("Свободные места: ");
                } while (!Double.TryParse(Console.ReadLine(), out b) || b <= 0 || b > number); number_free = b;
            }
        }
        public void get_m()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Кол-во мест - " + number);
            Console.WriteLine("Стоимость места - " + cash);
            Console.WriteLine("Кол-во свободных мест - " + number_free);
        }
        public void NAME()
        {
            Console.WriteLine("Поезд ");
        }
        public void sell()
        {
            double a = 0;
            Console.WriteLine("Кол-во свободных мест - " + number_free);
            do
            {
                Console.WriteLine("Сколько билетов продать?: ");
            } while (!Double.TryParse(Console.ReadLine(), out a) || a < 0 || a > number_free); number_free -= a;
        }
        public void tea()
        {
            double d = number - number_free;
            Console.WriteLine("Вы разнесли" + d + " чая");
        }
        public void unique()
        {
            Console.WriteLine("Вы в дрезине,(*_*)");
        }
    }
    class SW : Train
    {
        const string name = "СВ";

        public string train_num { get; set; }
        public override void sell()
        {
            base.sell(); number = base.number;
        }
        public override void tea()
        {
            base.tea(); number = base.number; number_free = base.number_free;
        }
        public override void NAME()
        {
            base.NAME();
            Console.WriteLine(name);
        }
        public static bool operator <(SW m1, SW m2)
        {
            return (m1.number < m2.number);
        }
        public static bool operator >(SW m1, SW m2)
        {
            return (m1.number > m2.number);
        }
        public static SW operator +(SW m1, SW m2)
        {
            return new SW(m1.number + m2.number, m1.cash, m1.number_free + m2.number_free, m1.train_num + m2.train_num);
        }
        override public string ToString()
        {
            return (name);
        }
        override public void set_m()
        {
            base.set_m(); number = base.number; cash = base.cash; number_free = base.number_free;
            Console.WriteLine("Какой идентификатор вагона");
            train_num = Console.ReadLine();
        }
        override public void get_m()
        {
            base.get_m();
            Console.WriteLine("Номер вагона  - " + train_num);
        }
        override public void unique()
        {
            Console.WriteLine("Вы дали объявление о маршруте поезда");

        }
        public static void know()
        {
            Console.WriteLine("напомнить, что кондиционеров нет и окна открывать нельзя");
        }
        public SW()
        {
            cash = 150;
            number = 100;
            number_free = 50;
            train_num = "RUS1";
        }
        public SW(double number, double cash, double number_free, string train_num)
        {
            this.number = number;
            this.cash = cash;
            this.number_free = number_free;
            this.train_num = train_num;
        }
        public SW(double cash, double number_free)
        {
            this.cash = cash;
            this.number_free = number_free;
            train_num = "RUS2";
            number = 0;
        }
    }
    class Rest : Train
    {
        const string name = "Вагон ресторан";
        string colour { get; set; }
        override public string ToString()
        {
            return (name);
        }
        public override void sell()
        {
            base.sell(); number = base.number;
        }
        public override void tea()
        {
            base.tea(); number = base.number; number_free = base.number_free;
        }
        public override void unique()
        {
            Console.WriteLine("Вы поели на все ваши деньги:(");
        }
        public override void NAME()
        {
            base.NAME();
            Console.WriteLine(name);
        }
        override public void set_m()
        {
            base.set_m(); number = base.number; cash = base.cash; number_free = base.number_free;
            Console.WriteLine("Как еда?");
            colour = Console.ReadLine();
        }
        override public void get_m()
        {
            base.get_m();
            Console.WriteLine("Вкус - " + colour);
        }
    }
    class Kupe : Train
    {
        const string name = "Купе";
        string neighbors { get; set; }
        override public string ToString()
        {
            return (name);
        }
        public override void sell()
        {
            base.sell(); number = base.number;
        }
        public override void tea()
        {
            base.tea(); number = base.number; number_free = base.number_free;
        }
        public override void unique()
        {
            Console.WriteLine("Вы сидите (._.)");
        }
        public override void NAME()
        {
            base.NAME();
            Console.WriteLine(name);
        }
        override public void set_m()
        {
            base.set_m(); number = base.number; cash = base.cash; number_free = base.number_free;
            Console.WriteLine("Как вам соседи?");
            neighbors = Console.ReadLine();
        }
        override public void get_m()
        {
            base.get_m();
            Console.WriteLine("Соседи - " + neighbors);
        }
    }
    sealed class Tovar : Train
    {
        const string name = "Товарный";
        string tov { get; set; }
        public override void sell()
        {
            base.sell(); number = base.number;
        }
        public override void tea()
        {
            base.tea(); number = base.number; number_free = base.number_free;
        }
        public override void unique()
        {
            Console.WriteLine("Вас не пустили внутрь, но можете попытаться еще¯l_(ツ)_/¯");
        }
        public override void NAME()
        {
            base.NAME();
            Console.WriteLine(name);
        }
        override public string ToString()
        {
            return (name);
        }
        override public void set_m()
        {
            base.set_m(); number = base.number; cash = base.cash; number_free = base.number_free;
            Console.WriteLine("Какой товар везут?");
            tov = Console.ReadLine();
        }
        override public void get_m()
        {
            base.get_m();
            Console.WriteLine("Размер - " + tov);
        }
    }
    internal class Program
    {
        static void Func(ITrain item)
        {
            item.sell(); 
            Console.WriteLine("Вы продали билеты");
        }
        static void Main(string[] args)
        {
            int main_menu;
            do
            {
                Console.Clear();
                Console.WriteLine("1. 1 часть");
                Console.WriteLine("2. 2 и 3 часть");
                Console.WriteLine("0. Выход");
                if (!Int32.TryParse(Console.ReadLine(), out main_menu))
                {
                    Console.WriteLine("Некорректный ввод.");
                    main_menu = -1;
                }
                switch (main_menu)
                {
                    case 1: FirstTask(); break;
                    case 2: SecondTask(); break;
                }
            } while (main_menu != 0);
            void FirstTask()
            {
                int menu, menu2; SW m = new SW(), m2 = new SW();
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Добавление вашего SW");
                    Console.WriteLine("2. Вывод вашего SW");
                    Console.WriteLine("3. Выбрать выполняемый метод для SW");
                    Console.WriteLine("4. Сравнить SW");
                    Console.WriteLine("5. Совместить SW");
                    Console.WriteLine("0. Выход");
                    if (!Int32.TryParse(Console.ReadLine(), out menu))
                    {
                        Console.WriteLine("Некорректный ввод.");
                        menu = -1;
                    }
                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            m.set_m();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            m.get_m();
                            Console.ReadKey();
                            break;
                        case 3:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("1. Продать билеты");
                                Console.WriteLine("2. Разнести чай");
                                Console.WriteLine("3. Подать объявление о маршруте поезда");
                                Console.WriteLine("4. Подать очень важное объявление");
                                Console.WriteLine("0. Выход");
                                if (!Int32.TryParse(Console.ReadLine(), out menu2))
                                {
                                    Console.WriteLine("Некорректный ввод.");
                                    menu2 = -1;
                                }
                                switch (menu2)
                                {
                                    case 1:
                                        Console.Clear();
                                        m.sell();
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        m.tea();
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        m.unique();
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        SW.know();
                                        Console.ReadKey();
                                        break;
                                }
                            } while (menu2 != 0);
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Вот параметры моего вагона СВ:");
                            m2.get_m();
                            if (m > m2) Console.WriteLine("У вашего Св больше мест!");
                            else Console.WriteLine("К сожалению, ваш вагон меньше моего");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Вот параметры моего СВ");
                            m2.get_m();
                            m = m + m2;
                            Console.WriteLine("Ваш СВ стал блольше, за счет объединения");
                            Console.WriteLine("Вот новые параметры ВАШЕГО СВ:");
                            m.get_m();
                            Console.ReadKey();
                            break;


                    }
                } while (menu != 0);
            }
            void SecondTask()
            {
                int menu, menu2, i;
                List<ITrain> gg = new List<ITrain>();
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Добавление нового вагона");
                    Console.WriteLine("2. Просмотр свойств вагона");
                    Console.WriteLine("3. Выполнение действий с вагонами");
                    Console.WriteLine("4. Вывод всех вагонов");
                    Console.WriteLine("5. Выполнение функции");
                    Console.WriteLine("0. Выход");
                    if (!Int32.TryParse(Console.ReadLine(), out menu))
                    {
                        Console.WriteLine("Некорректный ввод.");
                        menu = -1;
                    }
                    switch (menu)
                    {
                        case 1:
                            Console.Clear();
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Выберите вагон, который хотите добавить");
                                Console.WriteLine("1. СВ");
                                Console.WriteLine("2. Ресторан");
                                Console.WriteLine("3. Дрезина");
                                Console.WriteLine("4. Купе");
                                Console.WriteLine("5. Товарный");
                                Console.WriteLine("0. Выход");
                                if (!Int32.TryParse(Console.ReadLine(), out menu2))
                                {
                                    Console.WriteLine("Некорректный ввод.");
                                    menu2 = -1;
                                }
                                switch (menu2)
                                {
                                    case 1:
                                        Console.Clear();
                                        SW m = new SW(); m.set_m(); gg.Add(m);
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Rest p = new Rest(); p.set_m(); gg.Add(p);
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Drezina l = new Drezina(); l.set_m(); gg.Add(l);
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        Kupe w = new Kupe(); w.set_m(); gg.Add(w);
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Console.Clear();
                                        Tovar g = new Tovar(); g.set_m(); gg.Add(g);
                                        Console.ReadKey();
                                        break;
                                }
                            } while (menu2 != 0);
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"Введите номер желаемого вагона (всего объектов:{gg.Count})");
                                Console.WriteLine("Введите ноль для возврата)");
                            } while (!Int32.TryParse(Console.ReadLine(), out i) || i < 0 || i > gg.Count); i--;
                            if (i >= 0)
                            {
                                gg[i].get_m();
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"Введите номер желаемого объекта (всего объектов:{gg.Count})");
                                Console.WriteLine("Введите ноль для возврата");
                            } while (!Int32.TryParse(Console.ReadLine(), out i) || i < 0 || i > gg.Count); i--;
                            if (i >= 0)
                            {
                                gg[i].sell();
                                gg[i].tea();
                                gg[i].unique();
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            Console.Clear();
                            foreach (var item in gg)
                            {
                                item.get_m();
                            }
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"Введите номер желаемого объекта (всего объектов:{gg.Count})");
                                Console.WriteLine("Введите ноль для возврата");
                            } while (!Int32.TryParse(Console.ReadLine(), out i) || i < 0 || i > gg.Count); i--;
                            if (i >= 0)
                            {
                                Func(gg[i]);
                                Console.ReadKey();
                            }
                            break;
                    }
                } while (menu != 0);

            }
        }
    }
}
