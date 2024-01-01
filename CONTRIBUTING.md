# Contributing to Prolangle

Here is an overview of what you can do to contribute and how to do it:

1. [Code of Conduct](#code-of-conduct)
2. [Report a bug](#report-a-bug)
3. [Request a feature](#request-a-feature)
4. [Contribute a language](#contribute-a-language)
    1. [Requesting a language](#requesting-a-language)
    2. [Adding a language](#adding-a-language)
5. [Contributing code](#contributing-code)
6. [Everything else](#everything-else)
7. [Legal](#legal)


## Code of Conduct

Please read and adhere to our [Code of Conduct] to ensure a positive and inclusive environment for all contributors.

## Report a bug

If you find a bug, please report it by [opening a bug report issue].

## Request a feature

If you want to request a feature, please do so by [opening a feature request issue].

## Contribute a language

### Requesting a language

To request a language that is not yet supported, please do so by looking for an [open issue for the language] and giving
it a thumbs up or [opening a language request issue] if there is none.

### Adding a language

To add a language, please do so by following these steps:

1. Fork the repository
2. Create a new branch with name `language/<languageName>`
3. Create a new class in the `Prolangle.Languages` folder with the name of the language you want to add
4. Extend `BaseLanguage` or implement the `ILanguage` interface
5. Add a `yield return new <languageName>()` to the `Prolangle.Services.LanguagesProvider.LanguageEnumerable` method
    - Make sure to add it in the correct order (alphabetical)
6. Commit and push your changes
7. Create a pull request against the `main` branch
8. Wait for the pull request to be reviewed and be ready to make changes if necessary

## Contributing code

If you want to contribute code, first make sure there exists an issue for it. If there is none, please check the other
sections of this document to see if you should [report a bug](#report-a-bug), [request a feature](#request-a-feature) or
[contribute a language](#contribute-a-language).

1. Fork the repository
2. Create a new branch with an appropriate name
    - If you are fixing a bug, name it `fix/<issue-number>-<short-description>`
    - If you are adding a feature, name it `feature/<issue-number>-<short-description>`
    - If you are adding a language, name it `language/<language-name>`
    - If you are doing something else, name it `<short-description>`
    - The branch name should be in `kebab-case`
3. Make your changes
4. Commit and push your changes
5. Create a pull request against the `main` branch
6. Wait for the pull request to be reviewed and be ready to make changes if necessary

## Everything else

If you want to contribute something else, please do so by [opening a blank issue] describing what you want to do.

## Legal

By contributing to this repository, you agree to license your contributions under the [projects license].


[Code of Conduct]: ./CODE_OF_CONDUCT.md

[opening a bug report issue]: https://github.com/ricardoboss/Prolangle/issues/new?template=bug_report.yml

[opening a feature request issue]: https://github.com/ricardoboss/Prolangle/issues/new?template=feature_request.yml

[open issue for the language]: https://github.com/ricardoboss/Prolangle/issues?q=is%3Aissue+is%3Aopen+sort%3Aupdated-desc+label%3Alanguage

[opening a language request issue]: https://github.com/ricardoboss/Prolangle/issues/new?template=language_request.yml

[opening a blank issue]: https://github.com/ricardoboss/Prolangle/issues/new

[projects license]: ./LICENSE
