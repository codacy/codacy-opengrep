namespace Tests.Bugs
{
    class Operators
    {
        void M()
        {
            int target = -5;
            int num = 3;
            target =- num;  // Noncompliant
            target =+ num; // Noncompliant
            target = -num;
            target -= num;
            target =-1;
            bool b = true;
            bool c = !b;
        }
    }
}
