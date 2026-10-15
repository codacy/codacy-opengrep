using System;
using System.Runtime.Serialization;

namespace Tests.Security
{
    [Serializable]
    public class InternalUrl // Noncompliant
    {
        private string url;

        public InternalUrl(string tmpUrl)
        {
            if (!tmpUrl.StartsWith("http://localhost/"))
            {
                throw new ArgumentException("Invalid url");
            }
            url = tmpUrl;
        }
    }

    [Serializable]
    public class ValidatedUrl : IDeserializationCallback
    {
        private string url;

        public ValidatedUrl(string tmpUrl)
        {
            if (!tmpUrl.StartsWith("http://localhost/"))
            {
                throw new ArgumentException("Invalid url");
            }
            url = tmpUrl;
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (!url.StartsWith("http://localhost/"))
            {
                throw new ArgumentException("Invalid url");
            }
        }
    }
}
