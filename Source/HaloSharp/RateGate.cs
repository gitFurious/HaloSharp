using System;
using System.Collections.Concurrent;
using System.Threading;
using HaloSharp.Model;

namespace HaloSharp
{
    public class RateGate : IDisposable
    {
        private readonly Timer _exitTimer;
        private readonly ConcurrentQueue<int> _exitTimes;
        private readonly SemaphoreSlim _semaphore;
        private readonly int _timeoutMilliseconds;

        private readonly int _timeUnitMilliseconds;

        private bool _isDisposed;

        public RateGate(RateLimit rateLimit)
        {
            _timeUnitMilliseconds = (int)rateLimit.TimeSpan.TotalMilliseconds;
            _timeoutMilliseconds = (int)rateLimit.Timeout.TotalMilliseconds;

            _semaphore = new SemaphoreSlim(rateLimit.RequestCount, rateLimit.RequestCount);
            _exitTimes = new ConcurrentQueue<int>();
            _exitTimer = new Timer(ExitTimerCallback, null, _timeUnitMilliseconds, Timeout.Infinite);
        }

        private void ExitTimerCallback(object state)
        {
            int exitTime;
            var exitQueueNotEmpty = _exitTimes.TryPeek(out exitTime);
            while (exitQueueNotEmpty && unchecked(exitTime - Environment.TickCount) <= 0)
            {
                _semaphore.Release();
                _exitTimes.TryDequeue(out exitTime);
                exitQueueNotEmpty = _exitTimes.TryPeek(out exitTime);
            }

            var timeUntilNextCheck = exitQueueNotEmpty
                ? Math.Min(_timeUnitMilliseconds, Math.Max(0, exitTime - Environment.TickCount))
                : _timeUnitMilliseconds;

            _exitTimer.Change(timeUntilNextCheck, -1);
        }

        public bool WaitToProceed()
        {
            return _semaphore.Wait(_timeoutMilliseconds);
        }

        public void SignalExit()
        {
            var timeToExit = unchecked(Environment.TickCount + _timeUnitMilliseconds);
            _exitTimes.Enqueue(timeToExit);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    _semaphore.Dispose();
                    _exitTimer.Dispose();

                    _isDisposed = true;
                }
            }
        }
    }
}