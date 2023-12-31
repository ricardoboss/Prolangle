# How to add languages

1. Create a new class in the `Languages` folder with the name of the language you want to add
2. Implement the `ILanguage` interface (or extend `BaseLanguage`)
3. Add a `yield return new <languageName>()` to the `LanguagesProvider.LanguageEnumerable` method
   - Make sure to add it in the correct order (alphabetical)
