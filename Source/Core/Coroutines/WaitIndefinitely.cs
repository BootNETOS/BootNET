namespace BootNET.Core.Coroutines;

/// <summary>
///     When yielded from a coroutine executor, halts the execution of the
///     coroutine until the <see cref="Continue" /> method is called on the object.
/// </summary>
public class WaitIndefinitely : CoroutineControlPoint
{
    private bool canContinue;

    public override bool CanContinue => canContinue;

    /// <summary>
    ///     Invalidates this wait and makes the coroutine able to execute instructions again.
    /// </summary>
    public void Continue()
    {
        canContinue = true;
    }
}