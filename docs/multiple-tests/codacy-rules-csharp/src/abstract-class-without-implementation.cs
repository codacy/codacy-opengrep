namespace Tests.Practices
{
    public abstract class Animal // Noncompliant
    {
        public abstract void Move();
        public abstract void Feed();
    }

    public abstract class Lamp
    {
        private bool switchLamp = false;

        public abstract void Glow();

        public void FlipSwitch()
        {
            switchLamp = !switchLamp;
        }
    }
}
