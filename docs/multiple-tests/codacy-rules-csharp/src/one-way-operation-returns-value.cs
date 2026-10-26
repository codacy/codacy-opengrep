using System.ServiceModel;

namespace Tests.Practices
{
    [ServiceContract]
    interface IMyService
    {
        [OperationContract(IsOneWay = true)]
        int SomethingHappened(int parameter); // Noncompliant

        [OperationContract(IsOneWay = true)]
        void Notify(int parameter);
    }
}
