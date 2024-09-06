namespace Prolangle.Helpers;

/// <summary>
/// A delegate that represents an asynchronous event handler.
/// </summary>
/// <remarks>
/// This basically mimics the <see cref="EventHandler{TEventArgs}"/> delegate,
/// but with the addition of the <see cref="CancellationToken"/> parameter and the
/// ability to await the invocation of the event handler.
/// </remarks>
/// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
public delegate Task AsyncEventHandler<in TEventArgs>(
	object? sender,
	TEventArgs e,
	CancellationToken cancellationToken = default
);
