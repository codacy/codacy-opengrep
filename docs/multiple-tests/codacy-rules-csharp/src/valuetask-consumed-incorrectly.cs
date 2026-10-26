using System.Threading.Tasks;

namespace Tests.Bugs
{
    class ValueTasks
    {
        async Task M()
        {
            ValueTask<int> vt = ComputeAsync();
            int result = await vt;
            result = await vt; // Noncompliant

            ValueTask<int> other = ComputeAsync();
            int value = other.Result; // Noncompliant

            ValueTask<int> checkedTask = ComputeAsync();
            if (checkedTask.IsCompletedSuccessfully)
            {
                value = checkedTask.Result;
            }
        }

        ValueTask<int> ComputeAsync() => new ValueTask<int>(1);
    }
}
