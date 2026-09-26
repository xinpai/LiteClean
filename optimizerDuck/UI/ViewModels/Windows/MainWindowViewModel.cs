using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using optimizerDuck.Common.Extensions;
using optimizerDuck.Common.Helpers;

namespace optimizerDuck.UI.ViewModels.Windows;

public partial class MainWindowViewModel : LocalizedObject
{
    /// <summary>
    ///     Opens the official website in the default browser.
    /// </summary>
    [RelayCommand]
    private static void OpenWebsite()
    {
        try
        {
            Process.Start(
                new ProcessStartInfo
                {
                    FileName = Shared.OfficialWebsiteURL,
                    UseShellExecute = true,
                }
            );
        }
        catch
        {
            // Silently fail: opening a link is non-critical.
        }
    }
}
