using System;

namespace Tests.Style
{
    public class Statements
    {
        public int Prop { get; set; }
        public int Other { get; private set; }

        void M(bool someCondition, int a)
        {
            if (someCondition) DoSomething(); // Noncompliant
            a = 1; a = 2; // Noncompliant
            Func<object, bool> item1 = o => { return true; };
            Func<object, bool> item2 = o => { var r = false; return r; }; // Noncompliant
            var s = "a; b";
            for (int i = 0; i < 3; i++)
            {
                DoSomething();
            }
            if (someCondition)
            {
                DoSomething();
            }
            else DoSomething(); // Noncompliant
        }

        void DoSomething() { }
    }
}
