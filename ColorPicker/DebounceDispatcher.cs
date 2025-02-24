using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public class DebounceDispatcher
{
    private CancellationTokenSource _cts = new CancellationTokenSource();

    public void Debounce(int milliseconds, Action action)
    {
        _cts.Cancel();
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        Task.Delay(milliseconds).ContinueWith(t =>
        {
            if (!token.IsCancellationRequested)
            {
                action.Invoke();
            }
        }, token);
    }
}
