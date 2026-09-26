using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using optimizerDuck.Common.Extensions;
using optimizerDuck.Domain.Execution;
using optimizerDuck.Services.System.Primitives;

namespace optimizerDuck.UI.ViewModels.Dialogs;

public class OptimizationResultDialogViewModel : LocalizedObject
{
    /// <summary>
    ///     The failure texts Windows writes when it refuses an operation for lack of rights. A
    ///     refusal reads differently to the user than a step that simply went wrong, because
    ///     retrying it cannot succeed.
    /// </summary>
    private static readonly string[] RefusedForRightsMarkers =
    [
        ServiceStrings.CommonErrorAccessDenied,
        ServiceStrings.RegistryErrorUnauthorizedAccess,
        "denied by Windows",
    ];

    public OptimizationResultDialogViewModel(
        IEnumerable<Change> failedSteps,
        ChangeRecordOperation operation = ChangeRecordOperation.Apply
    )
    {
        var steps = failedSteps.ToList();

        // The rows are built here so a failure list reads in the UI language, falling back to the
        // English log text only when a step carries nothing else to show. The run the steps
        // belong to decides whether they read as applied or as put back.
        FailedSteps = new ObservableCollection<ChangeRecordStepViewModel>(
            steps.Select(step => new ChangeRecordStepViewModel(step, operation))
        );

        HasPermissionHint = ContainsRightsRefusal(steps);
    }

    public ObservableCollection<ChangeRecordStepViewModel> FailedSteps { get; }

    public int FailedCount => FailedSteps.Count;

    /// <summary>
    ///     Gets a value that indicates whether a failed step was refused for lack of rights, in
    ///     which case the dialog also says what the user has to do about it
    ///     (<c>OptimizationResultDialog.Hint.RequiresAdministrator</c>).
    /// </summary>
    public bool HasPermissionHint { get; }

    /// <summary>
    ///     Whether Windows refused any of these steps for lack of rights. Callers check this
    ///     before showing a failure at all, because a run refused for rights writes nothing and
    ///     the user can only fix it by running elevated.
    /// </summary>
    public static bool ContainsRightsRefusal(IEnumerable<Change> failedSteps) =>
        failedSteps.Any(WasRefusedForRights);

    /// <summary>Whether Windows refused the step because the caller has too few rights.</summary>
    private static bool WasRefusedForRights(Change change)
    {
        return WasRefused(change.Error) || WasRefused(change.ErrorDetail);

        static bool WasRefused(string? text) =>
            !string.IsNullOrEmpty(text)
            && RefusedForRightsMarkers.Any(marker =>
                text.Contains(marker, StringComparison.OrdinalIgnoreCase)
            );
    }
}
