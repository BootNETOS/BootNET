using System;

namespace BootNET.Core.Coroutines;

/// <summary>
///     When yielded from a coroutine executor, waits until the given condition is met.
/// </summary>
public class WaitUntil : CoroutineControlPoint
{
    private readonly Func<bool> condition;

    /// <summary>
    ///     Initializes a new instance of the <see cref="WaitUntil" /> class that can be used to
    ///     halt the execution of a coroutine until the given condition is met.
    /// </summary>
    /// <param name="condition">
    ///     The delegate that has to return <see langword="true" /> in order to continue the execution of
    ///     the coroutine.
    /// </param>
    public WaitUntil(Func<bool> condition)
    {
        this.condition = condition;
    }

    public override bool CanContinue => condition();
}