using Microsoft.AspNetCore.Components;
using MudBlazor;
using IDialogService = Avae.Services.IDialogService;

namespace Avae.Razor;

internal class DialogService(MudBlazor.IDialogService MudDialogService) : IDialogService
{
    private MarkupString SanitizeMessage(string message)
    {
        return (MarkupString)System.Text.RegularExpressions.Regex.Replace(System.Web.HttpUtility.HtmlEncode(message), "\r?\n|\r", "<br />");
    }

    public async Task ShowErrorAsync(Exception ex, string title = "Error")
    {
        await MudDialogService.ShowMessageBoxAsync(
            title,
            SanitizeMessage(ex.Message),
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            });
    }

    public async Task<bool> ShowOkAbortAsync(string message, string title = "Title")
    {
        return await MudDialogService.ShowMessageBoxAsync(
            title,
            SanitizeMessage(message),
            cancelText: "Abort",
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            }) ?? false;
    }

    public async Task ShowOkAsync(string message, string title = "Title")
    {
        await MudDialogService.ShowMessageBoxAsync(
            title,
            SanitizeMessage(message),
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            });
    }

    public async Task<bool> ShowOkCancelAsync(string message, string title = "Title")
    {
        return await MudDialogService.ShowMessageBoxAsync(
            title,
             SanitizeMessage(message),
            cancelText: "Cancel",
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            }) ?? false;
    }

    public async Task<int> ShowYesNoAbortAsync(string message, string title = "Title")
    {
        var result = await MudDialogService.ShowMessageBoxAsync(
            title,
             SanitizeMessage(message),
            yesText: "Yes",
            noText: "No",
            cancelText: "Abort",
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            });
        return result switch
        {
            true => 0,
            false => 1,
            _ => 2
        };
    }

    public async Task<bool> ShowYesNoAsync(string message, string title = "Title")
    {
        return await MudDialogService.ShowMessageBoxAsync(
            title,
             SanitizeMessage(message),
            yesText: "Yes",
            cancelText: "No",
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            }) ?? false;
    }

    public async Task<int> ShowYesNoCancelAsync(string message, string title = "Title")
    {
        var result = await MudDialogService.ShowMessageBoxAsync(
            title,
             SanitizeMessage(message),
            yesText: "Yes",
            noText: "No",
            cancelText: "Cancel",
            options: new DialogOptions
            {
                BackdropClick = true,
                CloseOnEscapeKey = true
            });
        return result switch
        {
            true => 0,
            false => 1,
            _ => 2
        };
    }
}
