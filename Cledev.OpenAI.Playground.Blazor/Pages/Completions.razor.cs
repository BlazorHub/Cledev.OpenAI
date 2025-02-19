﻿using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class CompletionsPage : ComponentBase
{
    [Inject] public IOpenAIClient OpenAIClient { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    protected bool IsLoading { get; set; }

    protected CreateCompletionRequest Request { get; set; } = null!;
    protected CreateCompletionResponse? Response { get; set; }

    public IList<string> CompletionModels { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Request = new CreateCompletionRequest
        {
            Model = CompletionsModel.TextDavinciV3.ToStringModel()
        };

        CompletionModels = Enum.GetValues(typeof(CompletionsModel)).Cast<CompletionsModel>().Select(x => x.ToStringModel()).ToList();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsRuntime.InvokeVoidAsync("addTooltips");
        }
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        Response = null;
        Response = await OpenAIClient.CreateCompletion(Request);
        IsLoading = false;

        if (Response is null)
        {
            // TODO: Display error message
        }
    }
}