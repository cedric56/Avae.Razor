using Avae.Razor.Components;
using Avae.Services;

namespace Avae.Razor;

internal class ContentDialogService(MudBlazor.IDialogService MudDialogService) : IContentDialogService
{
    public async Task<ContentDialogResult> ShowAsync(ContentDialogParams @params)
    {
        var dialog = await MudDialogService.ShowAsync<ContentDialog>(@params.Title,
        new MudBlazor.DialogParameters() { { nameof(ContentDialog.Parameters), @params } },
        new MudBlazor.DialogOptions() { BackdropClick = true });
        var result = await dialog.Result;
        @params.Closed?.Invoke();
        return result?.Data is ContentDialogResult cdr ? cdr : ContentDialogResult.None;
    }
}
