﻿using System;

namespace HorseLifeSimulation
{
    public delegate void HorseEventHandler(object sender, HorseEventArgs e);

    public class Horse
    {
        static void HandleBirth(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка подiї народження нового коня {e.Name}.");
        }

        static void HandleDeath(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка подiї смертi коня {e.Name} у вiцi {e.Age} рокiв.");
        }
        public event HorseEventHandler Birth;
        public event HorseEventHandler Death;

        private string name;
        private int age;
        private bool isAlive;

        private Random rnd = new Random();

        public Horse(string name)
        {
            this.name = name;
            age = 0;
            isAlive = true;
        }
        public bool getIsAlive()
        {
            return isAlive;
        }
        protected virtual void OnBirth(HorseEventArgs e)
        {
            Console.WriteLine($"У коня {e.Name} народився новий потомок!");
            Birth?.Invoke(this, e);
        }

        protected virtual void OnDeath(HorseEventArgs e)
        {
            Console.WriteLine($"Кiнь {e.Name} помер у вiцi {e.Age} рокiв...");
            Death?.Invoke(this, e);
        }

        public void Live()
        {
            Thread thread = new Thread(() =>
            {
                while (isAlive)
                {
                    age++;
                    Console.WriteLine($"Кiнь {name} вiком {age} рокiв.");

                    // Моделюємо випадковi подiї
                    if (rnd.NextDouble() < 0.1 && age >= 8 )
                    {
                        HorseEventArgs birthArgs = new HorseEventArgs($"{name}_младший", 0);
                        OnBirth(birthArgs);
                        Horse child = new Horse(birthArgs.Name);
                        child.Birth += HandleBirth;
                        child.Death += HandleDeath;
                        child.Live();
                    }

                    if (rnd.NextDouble() < 0.01 * (age-5))
                    {
                        isAlive = false;
                        HorseEventArgs deathArgs = new HorseEventArgs(name, age);
                        OnDeath(deathArgs);
                    }

                    // Моделюємо хворобу
                    if (rnd.NextDouble() < 0.05)
                    {
                        Console.WriteLine($"Кiнь {name} захворiв.");
                        if (rnd.NextDouble() < 0.4)
                        {
                            Console.WriteLine($"Кiнь {name} помер вiд хвороби...");
                            isAlive = false;
                            HorseEventArgs deathArgs = new HorseEventArgs(name, age);
                            OnDeath(deathArgs);
                        }
                    }

                    Thread.Sleep(1000); 
                }
            });

            thread.Start();
        }
    }
}