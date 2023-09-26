var romans = new Dictionary<char, int>()
{
    {'I', 1 },
    {'V' , 5},
    {'X' , 10},
    {'L' , 50},
    {'C' , 100 },
    {'D' , 500 },
    {'M' , 1000 }
};

bool containsInvalid;
while (true)
{
    Console.Write("Enter the Roman value: ");
    string s = Console.ReadLine();
    Check(s);
    if(containsInvalid) { break; }

    int result = 0;
    bool check = false;
    for (int i = 0; i < s.Length; i++)
    {
        check = false;
        foreach (var roman in romans)
        {
            if (s[i] == roman.Key)
            {
                if (i + 1 < s.Length)
                {
                    foreach (var roman1 in romans)
                    {
                        if (s[i + 1] == roman1.Key)
                        {
                            if (roman1.Value > roman.Value)
                            {
                                check = true;
                                result = result + (roman1.Value - roman.Value);
                                i++;
                                break;
                            }
                            else { result += roman.Value; break; }
                        }
                    }
                }
                if ((i == s.Length - 1) && !check)
                {
                    result += roman.Value;
                }
                break;
            }
        }
    }
    if (result >= 1 && result < 4000)
    {
        Console.WriteLine($"The Integer value: {result}");
        Console.WriteLine();
    }
    else 
    { 
        Console.WriteLine("Invalid value !");
        Console.WriteLine();
    }
}

void Check(string s)
{
    if (s.Length < 1 || s.Length > 15)
    {
        Console.WriteLine("The value is empty or too long !");
    }
    containsInvalid = s.Any(c => !(romans.Keys).Contains(c));
    if (containsInvalid)
    {
        Console.WriteLine("The string contains invalid values ");
    }
}