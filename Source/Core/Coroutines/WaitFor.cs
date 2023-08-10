using Cosmos.HAL;

namespace BootNET.Core.Coroutines;

/// <summary>
///     When yielded from a coroutine executor, waits for the given amount of seconds.
/// </summary>
public class WaitFor : CoroutineControlPoint
{
    private bool canContinue;
    private readonly PIT.PITTimer timer;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitFor" /> class that can be used to
    ///     halt the execution of a coroutine for the given amount of time.
    /// </summary>
    /// <param name="nanoseconds">The amount of nanoseconds to wait for.</param>
    public WaitFor(ulong nanoseconds)
    {
        timer = new PIT.PITTimer(TimerElapsedCallback, nanoseconds, false);
        Global.PIT.RegisterTimer(timer);
    }

    public override bool CanContinue => canContinue;

    /// <summary>
    ///     Returns a <see cref="WaitFor" /> object that can be yielded from a coroutine
    ///     executor to halt the execution of the coroutine for the given amount of nanoseconds.
    /// </summary>
    /// <param name="ns">The amount of nanoseconds to halt the coroutine for.</param>
    public static WaitFor Nanoseconds(ulong ns)
    {
        return new WaitFor(ns);
    }

    /// <summary>
    ///     Returns a <see cref="WaitFor" /> object that can be yielded from a coroutine
    ///     executor to halt the execution of the coroutine for the given amount of milliseconds.
    /// </summary>
    /// <param name="ms">The amount of milliseconds to halt the coroutine for.</param>
    public static WaitFor Milliseconds(uint ms)
    {
        return new WaitFor(ms * 1000000);
    }

    /// <summary>
    ///     Returns a <see cref="WaitFor" /> object that can be yielded from a coroutine
    ///     executor to halt the execution of the coroutine for the given amount of seconds.
    /// </summary>
    /// <param name="s">The amount of seconds to halt the coroutine for.</param>
    public static WaitFor Seconds(uint s)
    {
        return new WaitFor(s * 1000 * 1000000);
    }

    /// <summary>
    ///     Returns a <see cref="WaitFor" /> object that can be yielded from a coroutine
    ///     executor to halt the execution of the coroutine for the given amount of minutes.
    /// </summary>
    /// <param name="m">The amount of minutes to halt the coroutine for.</param>
    public static WaitFor Minutes(uint m)
    {
        return Seconds(m * 60);
    }

    private void TimerElapsedCallback()
    {
        canContinue = true;
    }
}