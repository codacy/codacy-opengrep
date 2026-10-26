using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tests.Security
{
    class Deserialization
    {
        void M(Stream stream)
        {
            var myBinaryFormatter = new BinaryFormatter();
            myBinaryFormatter.Deserialize(stream); // Noncompliant

            var restricted = new BinaryFormatter();
            restricted.Binder = new CustomBinder();
            restricted.Deserialize(stream);
        }
    }

    class CustomBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override System.Type BindToType(string assemblyName, string typeName) => null;
    }
}
