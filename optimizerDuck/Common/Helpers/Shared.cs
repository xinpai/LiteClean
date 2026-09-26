using System.Diagnostics;
using System.IO;

namespace optimizerDuck.Common.Helpers;

/// <summary>
///     Constants, links, install paths and the AppX package sets used by the bloatware scan.
/// </summary>
public static class Shared
{
    /// <summary>The product name shown throughout the UI.</summary>
    public const string AppName = "轻净 LiteClean";

    /// <summary>The official website, opened from the title bar.</summary>
    public const string OfficialWebsiteURL = "https://www.xp06.com/";

    /// <summary>The ASCII-art logo shown in the startup log banner.</summary>
    public const string RawLogo = """
              _     _ _        ____ _
             | |   (_) |_ ___ / ___| | ___  __ _ _ __
             | |   | | __/ _ \ |   | |/ _ \/ _` | '_ \
             | |___| | ||  __/ |___| |  __/ (_| | | | |
             |_____|_|\__\___|\____|_|\___|\__,_|_| |_|
       """;

    /// <summary>The project's GitHub repository.</summary>
    public const string GitHubRepoURL = "https://github.com/xinpai/LiteClean";

    /// <summary>The project documentation, which lives in the repository README.</summary>
    public const string DocumentationURL = $"{GitHubRepoURL}/blob/master/README.md";

    /// <summary>The third-party notices file on GitHub.</summary>
    public const string AcknowledgementsURL = $"{GitHubRepoURL}/blob/master/THIRD-PARTY-NOTICES.md";

    /// <summary>The name given to the restore point created before an apply.</summary>
    public const string RestorePointName = "LiteClean Restore Point";

    /// <summary>The GUID the bundled power plan is installed under.</summary>
    public const string PowerPlanGUID = "8ae61178-2c55-43f2-afb2-f83725823657";

    /// <summary>The full path of the running executable.</summary>
    public static readonly string ExePath = Environment.ProcessPath!;

    /// <summary>The directory that contains the running executable.</summary>
    public static readonly string ExeDir = Path.GetDirectoryName(ExePath)!;

    /// <summary>The file name of the running executable.</summary>
    public static readonly string ExeName = Path.GetFileName(ExePath);

    /// <summary>The file version of the running executable.</summary>
    public static readonly string FileVersion = FileVersionInfo
        .GetVersionInfo(ExePath)
        .FileVersion!;

    /// <summary>AppX package names the bloatware scan marks as safe to remove.</summary>
    public static readonly HashSet<string> SafeApps = new()
    {
        // Bing / MSN / News
        "Microsoft.BingWeather",
        "Microsoft.BingNews",
        "Microsoft.News",
        "MicrosoftStart",
        "Microsoft.BingFinance",
        "Microsoft.BingSports",
        "Microsoft.BingFoodAndDrink",
        "Microsoft.BingHealthAndFitness",
        "Microsoft.BingTravel",
        "Microsoft.BingTranslator", // Win10
        // Help, Tips & Feedback
        "Microsoft.GetStarted",
        "Microsoft.WindowsTips",
        "Microsoft.WindowsFeedbackHub",
        // Communications (Legacy/Discontinued)
        "Microsoft.Messaging",
        "Microsoft.OneConnect",
        "Microsoft.People",
        "Microsoft.SkypeApp",
        "MicrosoftTeams", // Old Teams (personal)
        "MSTeams", // New Teams
        // Office (Web Wrappers & Legacy)
        "Microsoft.OneNote",
        "Microsoft.Todos",
        "Microsoft.MicrosoftOfficeHub",
        "Microsoft.Office.OneNote",
        "Microsoft.Office.Sway",
        "Microsoft.MicrosoftJournal",
        "Microsoft.MicrosoftPowerBIForWindows",
        // Social & Wallet (Legacy)
        "Microsoft.Wallet",
        "Microsoft.MSWallet",
        // Mixed Reality & 3D (Legacy, not in Win11 images)
        "Microsoft.Microsoft3DViewer",
        "Microsoft.MixedReality.Portal",
        "Microsoft.Print3D",
        "Microsoft.3DBuilder",
        "Microsoft.Paint3D",
        // Multimedia & Entertainment
        "Microsoft.ZuneVideo",
        "Microsoft.WindowsSoundRecorder",
        "Microsoft.StickyNotes",
        "Microsoft.MicrosoftStickyNotes",
        "Microsoft.MicrosoftSolitaireCollection",
        "Microsoft.WindowsAlarms",
        "Microsoft.549981C3F5F10", // Cortana
        // Legacy & Redundant Utilities
        "Microsoft.Windows.DevHome",
        "Microsoft.WindowsMaps",
        "Microsoft.XboxApp", // Old Xbox Console Companion (Discontinued)
        "Microsoft.Windows.AIHub", // Copilot+ AI Hub (Copilot+ PCs)
        "Microsoft.MinecraftUWP", // Minecraft (Win10 consumer images)
        "Microsoft.NetworkSpeedTest", // Win10
        "Drawboard.DrawboardPDF",
        // Third-party (commonly pre-installed on OEM machines)
        "SpotifyAB.SpotifyMusic",
        "Clipchamp.Clipchamp",
        "Disney.37853FC22B2CE",
        "Amazon.com.Amazon",
        "4DF9E0F8.Netflix",
        "BytedancePte.Ltd.TikTok",
        "king.com.CandyCrushSaga",
        "king.com.CandyCrushSodaSaga",
        "king.com.BubbleWitch3Saga",
        "AmazonVideo.PrimeVideo",
        "Facebook.Instagram",
        "FACEBOOK.FACEBOOK",
        "7EE7776C.LinkedInforWindows",
        "Flipboard",
        "iHeartRadio",
        "PandoraMediaInc",
        "TuneInRadio",
        "Duolingo-LearnLanguagesforFree",
        "PicsArt-PhotoStudio",
        "WinZipUniversal",
        "AdobeSystemsIncorporated.AdobePhotoshopExpress",
        "OneCalendar",
        "NYTCrossword",
        "MarchofEmpires",
        "flaregamesGmbH.RoyalRevolt",
        "Asphalt8Airborne",
        "FarmVille2CountryEscape",
        "HiddenCity",
        "CaesarsSlotsFreeCasino",
        "COOKINGFEVER",
        "DisneyMagicKingdoms",
        "PhototasticCollage",
        "AutodeskSketchBook",
        "PolarrPhotoEditorAcademicEdition",
        "Sidia.LiveWallpaper",
        "HULULLC.HULUPLUS",
        "SlingTV",
        "DolbyLaboratories.DolbyAccess", // OEM audio app
    };

    /// <summary>AppX package names the bloatware scan marks as risky to remove.</summary>
    public static readonly HashSet<string> CautionApps = new()
    {
        // Core Utilities (default handlers for common file types)
        "Microsoft.WindowsCalculator",
        "Microsoft.WindowsPhotos",
        "Microsoft.MSPaint",
        "Microsoft.Paint",
        "Microsoft.WindowsNotepad",
        "Microsoft.WindowsCamera",
        "Microsoft.ScreenSketch", // Snipping Tool
        // Default browser (tied to WebView2-based apps and Windows features)
        "Microsoft.MicrosoftEdge",
        "Microsoft.MicrosoftEdge.Stable",
        // System Tools
        "Microsoft.WindowsStore",
        "Microsoft.StorePurchaseApp",
        "Microsoft.DesktopAppInstaller", // winget
        "Microsoft.WindowsTerminal",
        "Microsoft.WindowsTerminalPreview",
        "Microsoft.RemoteDesktop",
        "Microsoft.PowerAutomateDesktop",
        // Communication & Collaboration
        "Microsoft.WindowsCommunicationsApps", // Mail & Calendar
        "Microsoft.OutlookForWindows", // New Outlook
        "Microsoft.YourPhone", // Phone Link
        "MicrosoftWindows.CrossDevice", // Phone Link features in Explorer
        // Widgets & Search integration
        "Microsoft.StartExperiencesApp",
        "MicrosoftWindows.Client.WebExperience",
        "Microsoft.WidgetsPlatformRuntime",
        "Microsoft.BingSearch",
        // Default media handler
        "Microsoft.ZuneMusic", // Media Player
        // Security, Family & Support
        "MicrosoftCorporationII.MicrosoftFamily", // parental controls
        "MicrosoftCorporationII.MicrosoftSupportDiagnosticTool",
        "MicrosoftCorporationII.QuickAssist",
        "Microsoft.GetHelp", // Required by some Windows 11 Troubleshooters
        // Cloud & Productivity
        "Microsoft.OneDrive",
        "Microsoft.Whiteboard",
        "Microsoft.M365Companions",
        // Media Extensions (Essential for file format support)
        "Microsoft.HEIFImageExtension",
        "Microsoft.WebMediaExtensions",
        "Microsoft.WebpImageExtension",
        "Microsoft.RawImageExtension",
        "Microsoft.VP9VideoExtensions",
        "Microsoft.AV1VideoExtension",
        "Microsoft.HEVCVideoExtension",
        "Microsoft.MPEG2VideoExtension",
        // Xbox / Gaming Services
        "Microsoft.XboxIdentityProvider",
        "Microsoft.XboxSpeechToTextOverlay",
        "Microsoft.XboxGameOverlay",
        "Microsoft.XboxGamingOverlay",
        "Microsoft.Xbox.TCUI",
        "Microsoft.GamingApp",
        // OEM Software (drivers, updates & support from the hardware vendor)
        "AD2F1837.HPAIExperienceCenter",
        "AD2F1837.HPConnectedMusic",
        "AD2F1837.HPConnectedPhotopoweredbySnapfish",
        "AD2F1837.HPDesktopSupportUtilities",
        "AD2F1837.HPEasyClean",
        "AD2F1837.HPFileViewer",
        "AD2F1837.HPJumpStarts",
        "AD2F1837.HPPCHardwareDiagnosticsWindows",
        "AD2F1837.HPPowerManager",
        "AD2F1837.HPPrinterControl",
        "AD2F1837.HPPrivacySettings",
        "AD2F1837.HPQuickDrop",
        "AD2F1837.HPQuickTouch",
        "AD2F1837.HPRegistration",
        "AD2F1837.HPSupportAssistant",
        "AD2F1837.HPSureShieldAI",
        "AD2F1837.HPSystemInformation",
        "AD2F1837.HPWelcome",
        "AD2F1837.HPWorkWell",
        "AD2F1837.myHP",
        "DellInc.DellSupportAssistforPCs",
        "DellInc.DellDigitalDelivery",
        "DellInc.DellMobileConnect",
        "E046963F.LenovoCompanion",
        "LenovoCompanyLimited.LenovoVantageService",
        "LGElectronics.LGMonitorApp",
        "EclipseManager", // Dell OEM
        "ACGMediaPlayer", // OEM media player
        "ActiproSoftwareLLC", // OEM-bundled UI components
        "CyberLinkMediaSuiteEssentials", // OEM media suite
    };

    /// <summary>The per-user data directory under LocalApplicationData.</summary>
    public static string RootDirectory =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "LiteClean"
        );

    /// <summary>The data directory name used by builds that predate the rename.</summary>
    private const string LegacyRootDirectoryName = "optimizerDuck";

    /// <summary>
    ///     Carries a data directory left behind by a build that predates the rename over to the
    ///     current name, so settings, revert files and history survive it.
    /// </summary>
    public static void MigrateLegacyRootDirectory()
    {
        var legacyRoot = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            LegacyRootDirectoryName
        );

        MigrateRootDirectory(legacyRoot, RootDirectory);
    }

    /// <summary>Copies everything the target lacks, then drops the source directory.</summary>
    /// <param name="legacyRoot">The directory the older build used.</param>
    /// <param name="currentRoot">The directory the current build uses.</param>
    internal static void MigrateRootDirectory(string legacyRoot, string currentRoot)
    {
        if (
            string.Equals(legacyRoot, currentRoot, StringComparison.OrdinalIgnoreCase)
            || !Directory.Exists(legacyRoot)
        )
            return;

        try
        {
            CopyMissingEntries(legacyRoot, currentRoot);
            Directory.Delete(legacyRoot, true);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            // A data migration must never block startup. Whatever could not be copied or removed
            // stays where it was, and the application keeps using the current directory.
        }
    }

    /// <summary>Copies files and sub-directories that <paramref name="target" /> does not have yet.</summary>
    /// <param name="source">The directory to read from.</param>
    /// <param name="target">The directory to write to.</param>
    private static void CopyMissingEntries(string source, string target)
    {
        Directory.CreateDirectory(target);

        foreach (var directory in Directory.EnumerateDirectories(source))
            CopyMissingEntries(directory, Path.Combine(target, Path.GetFileName(directory)));

        foreach (var file in Directory.EnumerateFiles(source))
        {
            var destination = Path.Combine(target, Path.GetFileName(file));
            if (!File.Exists(destination))
                File.Copy(file, destination);
        }
    }

    /// <summary>The directory that holds downloaded and bundled resources.</summary>
    public static string ResourcesDirectory => Path.Combine(RootDirectory, "Resources");

    /// <summary>The directory that holds downloaded resources.</summary>
    public static string DownloadsDirectory => Path.Combine(ResourcesDirectory, "Downloads");

    /// <summary>The directory that holds bundled assets.</summary>
    public static string AssetsDirectory => Path.Combine(ResourcesDirectory, "Assets");

    /// <summary>The directory that holds one revert file per applied item.</summary>
    public static string RevertDirectory => Path.Combine(RootDirectory, "Revert");

    /// <summary>
    ///     Where what an apply did is recorded, one file per item. Separate from the revert data,
    ///     so a report outlives the revert file it describes.
    /// </summary>
    public static string HistoryDirectory => Path.Combine(RootDirectory, "History");

    /// <summary>Gets a value that indicates whether the OS is Windows 11 or later.</summary>
    public static bool IsWindows11OrGreater =>
        OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22000);
}
