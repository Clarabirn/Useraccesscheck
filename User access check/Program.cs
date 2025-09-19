
using System;

Console.WriteLine("=== Aktivitet 14:===");

// Inputs
Console.Write("Brugernavn: ");
string username = Console.ReadLine() ?? "";

Console.Write("Adgangskode: ");
string password = Console.ReadLine() ?? "";

Console.Write("Bruger-id (heltal >= 0): ");
string userIdText = Console.ReadLine() ?? "0";
uint userId = uint.TryParse(userIdText, out var tmp) ? tmp : 0;

// fra Aktivitet 13
bool userIsAdmin   = userId > 65536; // admin hvis id er større end 65536
bool usernameValid = username.Length >= 3; // mindst 3 tegn

// password: mindst ét af $, |, @ og skal indholde 20 cifra for admin, ellers 16)
bool hasRequiredSymbol = password.IndexOfAny(new[] { '$', '|', '@' }) >= 0;
int minLength = userIsAdmin ? 20 : 16;
bool passwordValid = hasRequiredSymbol && password.Length >= minLength;

// Output
Console.WriteLine("\n=== Resultat ===");
Console.WriteLine($"Bruger-id: {userId} -> {(userIsAdmin ? "ADMIN" : "IKKE-ADMIN")}");

if (usernameValid && passwordValid)
{
    Console.WriteLine($"✅ Adgang givet. Velkommen, {username}! ({(userIsAdmin ? "administrator" : "standardbruger")})");
}
else
{
    Console.WriteLine("⛔ Adgang nægtet. Der er problemer med dine oplysninger:");

    if (!usernameValid)
        Console.WriteLine("- Brugernavn skal være mindst 3 tegn.");

    if (!hasRequiredSymbol)
        Console.WriteLine("- Adgangskode skal indeholde mindst ét af tegnene $, | eller @.");

    if (password.Length < minLength)
        Console.WriteLine($"- Adgangskode skal være mindst {minLength} tegn ({(userIsAdmin ? "admin" : "ikke-admin")}).");
}
