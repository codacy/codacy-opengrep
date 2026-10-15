using System.IO;

namespace Tests.Bugs
{
    class Disposable : System.IDisposable
    {
        public void Dispose() { }
    }

    class Twice
    {
        void M()
        {
            var foo = new Disposable();
            foo.Dispose();
            foo.Dispose(); // Noncompliant

            using (var bar = new Disposable())
            {
                bar.Dispose(); // Noncompliant
            }

            var baz = new Disposable();
            baz.Dispose();
            baz = new Disposable();
            baz.Dispose();
        }
    }
}
