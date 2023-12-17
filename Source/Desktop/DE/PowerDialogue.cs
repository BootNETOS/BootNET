/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using BootNET.Desktop.SurfaceKit;
using BootNET.Desktop.TextKit;
using BootNET.Desktop.UIKit;
using System.Collections.Generic;
using System.Threading;

namespace BootNET.Desktop.DE
{
    /// <summary>
    /// Responsible for displaying power dialogues.
    /// </summary>
    public static class PowerDialogue
    {
        /// <summary>
        /// Get the description for the power dialogue.
        /// </summary>
        private static string GetDescription()
        {
            string actionVerb = _isRebooting ? "restart" : "power off";
            string timeWord = _secondsRemaining == 1 ? "second" : "seconds";
            return $"The system will {actionVerb} automatically in {_secondsRemaining} {timeWord}.";
        }

        /// <summary>
        /// Perform the power action.
        /// </summary>
        private static void PerformPowerAction()
        {
            if (_dialogue == null || _dialogue.Surface.SurfaceManager.SystemMenu == null)
            {
                return;
            }
            _dialogue.Surface.SurfaceManager.RemoveAllSurfaces(removeShellSurfaces: false);
            _dialogue.Surface.SurfaceManager.SystemMenu.HideMenu = true;
            _dialogue.Surface.SurfaceManager.SystemMenu.OnMenuHideCompleted.Bind((args) =>
            {
                if (_isRebooting)
                {
                    Cosmos.System.Power.Reboot();
                }
                else
                {
                    Cosmos.System.Power.Shutdown();
                }
            });
        }

        /// <summary>
        /// Show a power dialogue.
        /// </summary>
        /// <param name="surfaceManager">The surface manager.</param>
        /// <param name="isRebooting">True if the user is rebooting, otherwise false for shutting down.</param>
        public static void ShowPowerDialogue(SurfaceManager surfaceManager, bool isRebooting)
        {
            if (_dialogue != null)
            {
                _dialogue.Surface.SurfaceManager.Focus = _dialogue.Surface;
                return;
            }
            _isRebooting = isRebooting;
            _secondsRemaining = COUNTDOWN_TIME;
            string actionName = isRebooting ? "Restart" : "Power Off";
            UIButton actionButton = new(actionName);
            actionButton.OnMouseClick.Bind((args) => PerformPowerAction());
            List<UIButton> buttons = new()
            {
                new("Cancel"),
                actionButton
            };
            UIDialogue dialogue = new(
                surfaceManager,
                actionName,
                new TextBlock(GetDescription()),
                buttons,
                Resources.Power
            );
            _dialogue = dialogue;
            dialogue.Surface.OnRemoved.Bind((args) =>
            {
                _dialogue = null;
            });
        }
        /// <summary>
        /// Seconds remaining until an automatic power action is performed.
        /// </summary>
        private static int _secondsRemaining;

        /// <summary>
        /// True if the user is rebooting, otherwise false for shutting down.
        /// </summary>
        private static bool _isRebooting;

        /// <summary>
        /// The existing power dialogue.
        /// </summary>
        private static UIDialogue? _dialogue = null;

        /// <summary>
        /// Time before an automatic power action is performed.
        /// </summary>
        private const int COUNTDOWN_TIME = 60;
    }
}
