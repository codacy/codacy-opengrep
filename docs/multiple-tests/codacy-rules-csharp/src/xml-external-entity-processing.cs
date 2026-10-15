using System.Xml;

namespace Tests.Security
{
    class Xml
    {
        public static void Decode()
        {
            XmlDocument parser = new XmlDocument();
            parser.XmlResolver = new XmlUrlResolver(); // Noncompliant
            parser.LoadXml("<root/>");

            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse; // Noncompliant

            var safe = new XmlReaderSettings();
            safe.DtdProcessing = DtdProcessing.Prohibit;
        }
    }
}
