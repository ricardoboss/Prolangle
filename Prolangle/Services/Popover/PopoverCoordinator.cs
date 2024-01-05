using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Prolangle.Services.Popover;

// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedPositionalProperty.Global
public record BootstrapPopoverOptions(string content, string title, bool html, string trigger);
// ReSharper restore NotAccessedPositionalProperty.Global
// ReSharper restore InconsistentNaming

public class PopoverCoordinator(IJSRuntime jsRuntime) : IAsyncDisposable
{
	private IJSObjectReference? _jsModule;

	private const string JsClassName = nameof(PopoverCoordinator);

	public async Task ToggleAsync(ElementReference popoverElement, ElementReference titleElement, string serializedOptions)
	{
		// init once
		_jsModule ??= await jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./js/PopoverCoordinator.js");

		await _jsModule.InvokeVoidAsync($"{JsClassName}.toggle",
			popoverElement, titleElement, serializedOptions);
	}

	public async Task RemoveAsync(ElementReference popoverElement)
	{
		if (_jsModule is null)
			return;

		await _jsModule.InvokeVoidAsync($"{JsClassName}.destroy", popoverElement);
	}

	public async ValueTask DisposeAsync()
	{
		if (_jsModule is null)
			return;

		await _jsModule.DisposeAsync();
	}
}
