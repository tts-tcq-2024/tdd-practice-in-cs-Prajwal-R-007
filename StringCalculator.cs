using System;

public class StringCalculator
{
    public int Add(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        string[] delimiters = { ",", "\n", "\\", ";", "//" };
        string[] numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        int total = 0;

        foreach (string number in numbers)
        {
            int parsedNumber = ParseNumber(number);
            if (parsedNumber < 1000)
            {
                total += parsedNumber;
            }
        }

        return total;
    }

    private int ParseNumber(string number)
    {
        if (int.TryParse(number, out int result))
        {
            if (result < 0)
            {
                throw new Exception("Negative numbers are not allowed: " + result);
            }
            return result;
        }
        else
        {
            throw new Exception("Invalid input: " + number);
        }
    }
}

