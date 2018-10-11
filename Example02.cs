using System;
using System.Collections.Generic;

namespace Memento
{
    //object that stores the historical state
    public class Memento<T>
    {
        private T state;

        public T GetState()
        {
            return state;
        }

        public void SetState(T state)
        {
            this.state = state;
        }
    }

    //the object that we want to save and restore, such as a check point in an application
    public class Originator<T>
    {
        private T state;

        //for saving the state
        public Memento<T> CreateMemento()
        {
            Memento<T> m = new Memento<T>();
            m.SetState(state);
            return m;
        }

        //for restoring the state
        public void SetMemento(Memento<T> m)
        {
            state = m.GetState();
        }

        //change the state of the Originator
        public void SetState(T state)
        {
            this.state = state;
        }

        //show the state of the Originator
        public void ShowState()
        {
            Console.WriteLine(state.ToString());
        }
    }

    //object for the client to access
    public static class Caretaker<T>
    {
        //list of states saved
        private static List<Memento<T>> mementoList = new List<Memento<T>>();

        //save state of the originator
        public static void SaveState(Originator<T> orig)
        {
            mementoList.Add(orig.CreateMemento());
        }

        //restore state of the originator
        public static void RestoreState(Originator<T> orig, int stateNumber)
        {
            orig.SetMemento(mementoList[stateNumber]);
        }
    }

    class Program3
    {
        static void Main3(string[] args)
        {
            Originator<string> orig = new Originator<string>();

            orig.SetState("state0");
            Caretaker<string>.SaveState(orig); //save state of the originator
            orig.ShowState();

            orig.SetState("state1");
            Caretaker<string>.SaveState(orig); //save state of the originator
            orig.ShowState();

            orig.SetState("state2");
            Caretaker<string>.SaveState(orig); //save state of the originator
            orig.ShowState();

            //restore state of the originator
            Caretaker<string>.RestoreState(orig, 0);
            orig.ShowState();  //shows state0
        }
    }

}
