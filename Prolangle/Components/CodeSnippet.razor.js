export class CodeSnippet
{
    static highlightSnippet(elem, languageIdentifier) {
        hljs.configure({
            languages: [ languageIdentifier ]
        });

        hljs.highlightElement(elem);
    }
}
