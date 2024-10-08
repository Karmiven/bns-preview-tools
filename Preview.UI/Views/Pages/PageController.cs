﻿namespace Xylia.Preview.UI.Views.Pages;
internal interface IPageController
{
	object? Content { set; get; }

	string Name { get; }
}

internal class PageController<T>(string? name = null) : IPageController
{
	private object? _content;

	public string Name => name ?? ("Page_" + typeof(T).Name);

	public object? Content
	{
		set => _content = value;
		get => _content ??= Activator.CreateInstance(typeof(T));
	}
}