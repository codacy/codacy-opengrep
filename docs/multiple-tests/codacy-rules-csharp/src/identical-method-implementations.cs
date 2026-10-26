namespace Tests.Practices
{
    class Codes
    {
        private const string CODE = "secret";
        private int callCount = 0;

        public string GetCode()
        {
            callCount++;
            return CODE;
        }

        public string GetName() // Noncompliant
        {
            callCount++;
            return CODE;
        }

        public string GetOther()
        {
            return CODE;
        }
    }
}
