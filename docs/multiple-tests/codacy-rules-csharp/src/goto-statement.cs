namespace Tests.Style
{
    public class Jumps
    {
        void M(int i)
        {
        loop:
            i++;
            if (i < 10)
            {
                goto loop; // Noncompliant
            }
            switch (i)
            {
                case 1:
                    goto case 2; // Noncompliant
                case 2:
                    break;
                default:
                    break;
            }
            // this comment mentions goto but is fine
        }
    }
}
