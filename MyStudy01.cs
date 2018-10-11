using System;
using System.Collections.Generic;

namespace MementoMS01
{
    // Originator
    public class Hero
    {
        private int _bullets = 10;
        private int _lives = 5;

        public void Shoot()
        {
            if (_bullets > 0)
            {
                _bullets--;
                Console.WriteLine($"Bang! Bullets left: {_bullets}");
            }
        }

        public HeroMemento SaveState()
        {
            Console.WriteLine($"Save state: bullets {_bullets}");
            return new HeroMemento(_bullets, _lives);
        }

        public void RestoreState(HeroMemento memento)
        {
            _bullets = memento.Bullets;
            _lives = memento.Lives;

            Console.WriteLine($"RestoreState: bullets {_bullets}");
        }
    }

    // Memento
    public class HeroMemento
    {
        public int Bullets { get; }
        public int Lives { get; }

        public HeroMemento(int bullets, int lives)
        {
            Bullets = bullets;
            Lives = lives;
        }
    }

    // Caretaker
    public class GameHistory
    {
        public Stack<HeroMemento> History { get; }

        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameHistory game = new GameHistory();
            Hero hero = new Hero();

            hero.Shoot();

            game.History.Push(hero.SaveState());

            hero.Shoot();
            hero.Shoot();

            hero.RestoreState(game.History.Pop());

            hero.Shoot();
        }
    }
}
