using System.ServiceModel;

namespace Tests.Bugs
{
    [ServiceContract]
    interface IMyService // Noncompliant
    {
        int MyServiceMethod();
    }

    [ServiceContract]
    interface IGoodService
    {
        [OperationContract]
        int MyServiceMethod();
    }
}
