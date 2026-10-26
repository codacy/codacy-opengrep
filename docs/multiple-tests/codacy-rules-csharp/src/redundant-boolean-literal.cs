namespace Tests.Style
{
    public class Booleans
    {
        void M(bool flag, bool? maybe, int x)
        {
            if (BooleanMethod() == true) { } // Noncompliant
            if (BooleanMethod() == false) { } // Noncompliant
            if (BooleanMethod() || false) { } // Noncompliant
            DoSomething(!false); // Noncompliant
            DoSomething(BooleanMethod() == true); // Noncompliant
            flag = BooleanMethod() ? true : false; // Noncompliant
            flag = BooleanMethod() ? true : flag; // Noncompliant
            flag = BooleanMethod() ? flag : false; // Noncompliant
            for (var i = 0; true; i++) // Noncompliant
            {
                break;
            }
            if (maybe == true) { }
            if (BooleanMethod()) { }
            flag = !BooleanMethod();
            flag = x > 3 ? flag : BooleanMethod();
        }

        bool BooleanMethod() { return true; }
        void DoSomething(bool b) { }
    }
}
