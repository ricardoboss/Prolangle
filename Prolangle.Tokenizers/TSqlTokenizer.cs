using System.Text.RegularExpressions;
using Blism;
using Prolangle.Abstractions.Services;

namespace Prolangle.Tokenizers;

public class TSqlTokenizer : BaseTokenizer<GeneralTokenType>
{
    public static readonly TSqlTokenizer Instance = new();

    protected override IEnumerable<(Regex regex, GeneralTokenType type)> GetTokenDefinitions()
    {
        // whitespace + comments
        yield return (new(@"\s+"), GeneralTokenType.Whitespace);
        yield return (new(@"--.*?$"), GeneralTokenType.Comment); // single-line
        yield return (new(@"/\*[\s\S]*?\*/"), GeneralTokenType.Comment); // multi-line

        // string literals
        yield return (new(@"N?'([^']|'')*'"), GeneralTokenType.Text);

        // numbers
        yield return (new(@"\b\d+\.\d+([eE][+-]?\d+)?\b"), GeneralTokenType.Number);
        yield return (new(@"\b\d+([eE][+-]?\d+)?\b"), GeneralTokenType.Number);

        // variables
        yield return (new(@"@[A-Za-z_][A-Za-z0-9_]*"), GeneralTokenType.Identifier);

        // keywords (partial T-SQL list, expand if needed)
        yield return (new(@"\b(SELECT|FROM|WHERE|INSERT|INTO|VALUES|UPDATE|SET|DELETE|CREATE|ALTER|DROP|TABLE|VIEW|INDEX|PROCEDURE|FUNCTION|TRIGGER|PRIMARY|KEY|FOREIGN|CONSTRAINT|CHECK|DEFAULT|JOIN|INNER|LEFT|RIGHT|FULL|OUTER|ON|GROUP|BY|ORDER|HAVING|UNION|ALL|DISTINCT|TOP|CASE|WHEN|THEN|ELSE|END|AS|NULL|IS|IN|EXISTS|LIKE|AND|OR|NOT|BETWEEN|BEGIN|END|IF|ELSE|WHILE|RETURN|CAST|CONVERT|TRY_CAST|TRY_CONVERT|WITH|OVER|PARTITION|ROW_NUMBER|RANK|DENSE_RANK|NTILE)\b", RegexOptions.IgnoreCase), GeneralTokenType.Keyword);

        // identifiers (regular names, schema.object)
        yield return (new(@"[A-Za-z_][A-Za-z0-9_]*"), GeneralTokenType.Identifier);
        yield return (new(@"\[[^\]]+\]"), GeneralTokenType.Identifier); // quoted identifier

        // operators
        yield return (new(@"(\+|-|\*|/|%|=|<>|!=|<=|>=|<|>|&&|\|\|)"), GeneralTokenType.Operator);

        // punctuation
        yield return (new(@"[()\[\]\.,;]"), GeneralTokenType.Punctuation);
    }

    protected override GeneralTokenType UnknownTokenType => GeneralTokenType.Unknown;
}
