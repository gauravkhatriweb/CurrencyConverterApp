using System;
using System.Collections.Generic;

namespace CurrencyConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define a dictionary to store currency codes and their corresponding names
            // and exchange rates against 1 EUR
            Dictionary<string, (string, double)> currencyData = new Dictionary<string, (string, double)>()
            {
                { "USD", ("US Dollar", 1.0688) },
                { "JPY", ("Japanese Yen", 169.82) },
                { "BGN", ("Bulgarian Lev", 1.9558) },
                { "CZK", ("Czech Koruna", 24.949) },
                { "DKK", ("Danish Krone", 7.4580) },
                { "GBP", ("Pound Sterling", 0.84531) },
                { "HUF", ("Hungarian Forint", 396.93) },
                { "PLN", ("Polish Zloty", 4.3220) },
                { "RON", ("Romanian Leu", 4.9773) },
                { "SEK", ("Swedish Krona", 11.2445) },
                { "CHF", ("Swiss Franc", 0.9537) },
                { "ISK", ("Icelandic Krona", 149.10) },
                { "NOK", ("Norwegian Krone", 11.2685) },
                { "TRY", ("Turkish Lira", 35.1129) },
                { "AUD", ("Australian Dollar", 1.6031) },
                { "BRL", ("Brazilian Real", 5.8107) },
                { "CAD", ("Canadian Dollar", 1.4632) },
                { "CNY", ("Chinese Yuan Renminbi", 7.7602) },
                { "HKD", ("Hong Kong Dollar", 8.3401) },
                { "IDR", ("Indonesian Rupiah", 17597.85) },
                { "ILS", ("Israeli Shekel", 4.0097) },
                { "INR", ("Indian Rupee", 89.3150) },
                { "KRW", ("South Korean Won", 1484.58) },
                { "MXN", ("Mexican Peso", 19.5271) },
                { "MYR", ("Malaysian Ringgit", 5.0373) },
                { "NZD", ("New Zealand Dollar", 1.7427) },
                { "PHP", ("Philippine Peso", 62.920) },
                { "SGD", ("Singapore Dollar", 1.4468) },
                { "THB", ("Thai Baht", 39.150) },
                { "ZAR", ("South African Rand", 19.1241) }
                // Add more currencies as needed
            };

            bool continueApp = true; // Flag to control if the app should continue running

            while (continueApp)
            {
                // Display a welcome message and supported currencies
                Console.WriteLine("Welcome to the Currency Converter!");
                Console.WriteLine($"\nWe currently support conversions between {currencyData.Count} currencies:");
                Console.WriteLine("\nSupported Currencies:");
                foreach (var currency in currencyData)
                {
                    Console.WriteLine($"\t{currency.Key} - {currency.Value.Item1}");
                }

                // Get user input for the first currency to convert from
                Console.WriteLine("\n\nEnter the currency code you want to convert from (e.g., USD, EUR, JPY):");
                string fromCurrency = Console.ReadLine().ToUpper();

                // Validate user input for currency code
                if (!currencyData.ContainsKey(fromCurrency))
                {
                    Console.WriteLine("Invalid currency code. Please enter a valid code from the list.");
                    continue; // Restart the loop to allow user to enter valid input
                }

                // Get user input for the second currency to convert to
                Console.WriteLine("\nEnter the currency code you want to convert to (e.g., USD, EUR, JPY):");
                string toCurrency = Console.ReadLine().ToUpper();

                // Validate user input for currency code
                if (!currencyData.ContainsKey(toCurrency))
                {
                    Console.WriteLine("Invalid currency code. Please enter a valid code from the list.");
                    continue; // Restart the loop to allow user to enter valid input
                }

                // Placeholder logic to retrieve conversion rates (replace with actual conversion logic)
                double conversionRate = GetConversionRate(fromCurrency, toCurrency, currencyData);

                // Handle invalid conversion or error retrieving rates
                if (conversionRate <= 0)
                {
                    Console.WriteLine("Conversion rate unavailable. Please try again later.");
                    continue; // Restart the loop to allow user to enter valid input
                }

                // Get user input for the amount to convert
                Console.Write($"\nEnter the amount in {currencyData[fromCurrency].Item1}: ");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    // Calculate the converted amount
                    double convertedAmount = amount * conversionRate;

                    // Display the converted amount
                    Console.WriteLine($"\nConverted amount in {currencyData[toCurrency].Item1}: {convertedAmount:F2}"); // Format with two decimal places
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue; // Restart the loop to allow user to enter valid input
                }

                // Ask user if they want to perform another conversion
                Console.WriteLine("\nPress 'q' to quit or any other key to perform another conversion...");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    continueApp = false; // Set flag to false to exit the loop and end the program
                }
            }
        }

        // Placeholder method to simulate retrieving conversion rates (replace with actual implementation)
        static double GetConversionRate(string fromCurrency, string toCurrency, Dictionary<string, (string, double)> currencyData)
        {
            // In a real scenario, you'd implement logic to retrieve conversion rates from an API or local data
            // This example uses the provided data set
            if (currencyData.TryGetValue(toCurrency, out var toCurrencyData))
            {
                if (currencyData.TryGetValue(fromCurrency, out var fromCurrencyData))
                {
                    double exchangeRate = toCurrencyData.Item2 / fromCurrencyData.Item2;
                    return exchangeRate;
                }
            }

            return -1; // Indicate unavailable conversion rate
        }
    }
}
