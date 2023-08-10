using BootNET.Core;

namespace BootNET.Shell;

/// <summary>
///     Basic Terminal Shell.
/// </summary>
public static class Terminal
{
    #region Fields

    public static CommandManager CommandManager { get; set; } = new();

    #endregion

    #region Methods

    /// <summary>
    ///     Run the terminal.
    /// </summary>
    public static void Run()
    {
        Console.ResetColor();
        Console.Write(">");
        var input = Console.ReadLine();
        var response = CommandManager.ProcessInput(input);
        Console.WriteLine(response);
    }

    #endregion
}