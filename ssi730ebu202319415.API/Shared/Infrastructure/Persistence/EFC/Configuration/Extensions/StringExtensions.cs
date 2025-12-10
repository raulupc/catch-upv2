namespace ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// Extensions for strings. </summary>
/// <remarks> Author: Raul Hiroshi Tasayco Osorio </remarks>
public static class StringExtensions
{
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Concat(
            input.Select((character, index) =>
                index > 0 && char.IsUpper(character) ? "_" + character : character.ToString())
        ).ToLowerInvariant();
    }

    public static string ToPlural(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return input.EndsWith('y') ? input[..^1] + "ies" : input + "s";
    }
}