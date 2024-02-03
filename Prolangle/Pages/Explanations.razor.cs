using Microsoft.AspNetCore.Components;
using MudBlazor;
using Prolangle.Components;

namespace Prolangle.Pages;

/*
 * This heavily borrows from MudBlazor,
 * Copyright (c) MudBlazor 2021, licensed under MIT:
 * https://github.com/MudBlazor/MudBlazor/commit/62a4cee1a48eb97288be4d26f1e3b706d63df2bf
 */

public partial class Explanations : ComponentBase, IAsyncDisposable
{
	private Toc? Toc;

	private IScrollSpy? _scrollSpy;

	[Inject]
	private IScrollSpyFactory ScrollSpyFactory { get; set; } = null!;

	private string? _anchor;

	protected override void OnInitialized()
	{
		_scrollSpy = ScrollSpyFactory.Create();

		var relativePath = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
		if (relativePath.Contains('#') == true)
			_anchor = relativePath.Split(["#"], StringSplitOptions.RemoveEmptyEntries)[1];
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender && _scrollSpy is not null)
		{
			_scrollSpy.ScrollSectionSectionCentered += ScrollSpy_ScrollSectionSectionCentered;

			await _scrollSpy.StartSpying("page-section");
		}
	}

	public async Task AddSection(ExplanationSection section)
	{
		Sections.Add(section);

		if (_anchor is not null && _anchor == section.Id && _scrollSpy is not null)
		{
			await _scrollSpy.ScrollToSection(_anchor);
		}

		StateHasChanged();
	}

	private void ScrollSpy_ScrollSectionSectionCentered(object? sender, ScrollSectionCenteredEventArgs e)
	{
		Console.WriteLine("section centered");
		if (Toc is null)
			return;

		Toc.SetActiveSection(e.Id);
	}

	public async ValueTask DisposeAsync()
	{
		if (_scrollSpy is null)
			return;

		_scrollSpy.ScrollSectionSectionCentered -= ScrollSpy_ScrollSectionSectionCentered;

		await _scrollSpy.DisposeAsync();
	}
}
