using System;
using System.Runtime.InteropServices;

namespace Tests.Security
{
    class Com
    {
        [DllImport("ole32.dll")]
        static extern int CoSetProxyBlanket([MarshalAs(UnmanagedType.IUnknown)] object pProxy, uint dwAuthnSvc, uint dwAuthzSvc, IntPtr pServerPrincName, uint dwAuthnLevel, uint dwImpLevel, IntPtr pAuthInfo, uint dwCapabilities);

        void M(object proxy)
        {
            var hres1 = CoSetProxyBlanket(proxy, 0, 0, IntPtr.Zero, 0, 0, IntPtr.Zero, 0); // Noncompliant
        }
    }
}
