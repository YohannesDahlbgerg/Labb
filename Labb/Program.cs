using System;
using System.Numerics;
string input = "29535123p48723487597645723645";
bool found = false;
BigInteger totalSum = 0;

// loopar strängen
for (int i = 0; i < input.Length; i++)
{
    // kollar om tecknet är en siffra
    if (char.IsDigit(input[i]))
    {
        // startar loop från nästa index
        for (int j = i + 1; j < input.Length; j++)
        {
            // kollar om vi får en siffra
            if (char.IsDigit(input[j]))
            {
                // kollar om det är samma siffra som start siffran
                if (input[j] == input[i])
                {
                    // Skapa delsträngen mellan index i och j                    
                    string subString = input.Substring(i, j - i + 1);
                    string before = input.Substring(0, i);
                    string after = input.Substring(j + 1, input.Length - j - 1);
                    // Kontrollera om delsträngen är giltig

                    if (IsValidNumber(subString))
                    {
                        found = true;
                        Console.Write(before);
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(subString);
                        Console.ResetColor();
                        Console.WriteLine(after);

                        // Konvertera delsträngen till BigInteger och lägg till summan
                        BigInteger number = BigInteger.Parse(subString);
                        totalSum += number; // Addera till totalen

                        break;
                    }
                }
            }
            // Bryt loopen om vi stöter på något annat än siffror
            else
            {
                break;
            }
        }
    }
}

if (!found)
{
    Console.WriteLine("Icke giltiga delsträngar hittades.");
}

// Skriv ut summan av alla giltiga substrings
Console.WriteLine();
Console.WriteLine("Summan för alla substrings: " + totalSum);
// funktion för att kontrollera om delsträngen är 
static bool IsValidNumber(string number)
{
    // kontrollerar om den har minst 2 tecken och om start- och slutsiffran är lika
    return number.Length >= 2 &&
    number[0] == number[number.Length - 1];
}