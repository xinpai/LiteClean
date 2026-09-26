using optimizerDuck.Domain.Execution;
using optimizerDuck.Services.System.Primitives;
using optimizerDuck.UI.ViewModels.Dialogs;

namespace optimizerDuck.Test.UI.ViewModels;

public class OptimizationResultDialogViewModelTests
{
    private static Change Failed(string? error, string? errorDetail = null) =>
        new()
        {
            Name = ServiceStrings.RegistryName,
            Description = "Write registry value: HKLM\\Test\\A",
            Ok = false,
            Error = error,
            ErrorDetail = errorDetail,
        };

    [Fact]
    public void RefusedStep_ShowsTheAdministratorHint()
    {
        var viewModel = new OptimizationResultDialogViewModel(
            [Failed(ServiceStrings.CommonErrorAccessDenied)]
        );

        Assert.Equal(1, viewModel.FailedCount);
        Assert.True(viewModel.HasPermissionHint);
    }

    [Fact]
    public void DeniedDetail_AlsoShowsTheHint()
    {
        var viewModel = new OptimizationResultDialogViewModel(
            [
                Failed(
                    ServiceStrings.RegistryErrorUnauthorizedAccess,
                    ServiceStrings.Format(
                        ServiceStrings.RegistryErrorDetailAccessDeniedWrite,
                        @"HKLM\SOFTWARE\Policies\Microsoft\Dsh",
                        "AllowNewsAndInterests"
                    )
                ),
            ]
        );

        Assert.True(viewModel.HasPermissionHint);
    }

    [Fact]
    public void FailureForAnotherReason_ShowsNoHint()
    {
        var viewModel = new OptimizationResultDialogViewModel(
            [Failed(ServiceStrings.ServiceErrorChangeStartupTypeFailed)]
        );

        Assert.False(viewModel.HasPermissionHint);
    }
}
