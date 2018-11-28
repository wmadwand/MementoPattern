using System;
using System.Collections;
using System.Collections.Generic;

namespace Recall
{
    public class Hero
    {
        private int _bullets = 10;
        private int _lives = 5;

        public void Shoot()
        {
            _bullets--;
            Console.WriteLine($"Bullets now {_bullets}");

        }

        public HeroMemento SaveState()
        {
            Console.WriteLine($"Saved state with {_bullets} bullets");
            return new HeroMemento(_bullets, _lives);
        }

        public void RestoreState(HeroMemento memento)
        {
            _bullets = memento.Bullets;
            _lives = memento.Lives;

            Console.WriteLine($"Restored state with {_bullets} bullets");
        }
    }

    public class HeroMemento
    {
        public HeroMemento(int bullets, int lives)
        {
            Bullets = bullets;
            Lives = lives;
        }

        public int Bullets { get; }
        public int Lives { get; }
    }

    public class GameHistory
    {
        public Stack<HeroMemento> History { get; } = new Stack<HeroMemento>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            GameHistory gameHistory = new GameHistory();

            hero.Shoot();

            gameHistory.History.Push(hero.SaveState());

            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();

            hero.RestoreState(gameHistory.History.Pop());

            hero.Shoot();
            hero.Shoot();
        }
    }
}
