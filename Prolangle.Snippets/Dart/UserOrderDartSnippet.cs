using Prolangle.Abstractions.Languages;
using Prolangle.Abstractions.Snippets;

namespace Prolangle.Snippets.Dart;

public class UserOrderDartSnippet : ICodeSnippet
{
	public Guid Id { get; } = Guid.Parse("f3d24228-a2f5-4d07-a3af-9cf29159d5b4");

	public ILanguage Language => Languages.Dart.Instance;

	public string Filename => "order.dart";

	public string SourceCode =>
		"""
		Future<void> main() async {
			print('Fetching user order...');
			print(await createOrderMessage());
		}

		Future<String> createOrderMessage() async {
			var order = await fetchUserOrder();
			return 'Your order is: $order';
		}

		Future<String> fetchUserOrder() =>
			// Imagine that this function is
			// more complex and slow.
			Future.delayed(
				const Duration(seconds: 2),
				() => 'Large Latte',
			);
		""";
}
