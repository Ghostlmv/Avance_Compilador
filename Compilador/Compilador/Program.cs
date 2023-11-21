using System;
using System.Collections.Generic;
using System.IO;

class Token
{
    public string Type { get; set; }
    public string Value { get; set; }

    public Token(string type, string value)
    {
        Type = type;
        Value = value;
    }
}

class Lexer
{
    private string sourceCode;
    private List<Token> tokens;

    public Lexer(string code)
    {
        sourceCode = code;
        tokens = new List<Token>();
    }

    public List<Token> Tokenize()
    {
        // Split the source code into tokens based on spaces and newlines
        string[] words = sourceCode.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            // Identify keywords and literals
            if (word.Equals("si", StringComparison.OrdinalIgnoreCase) ||
                word.Equals("para", StringComparison.OrdinalIgnoreCase) ||
                word.Equals("mientras", StringComparison.OrdinalIgnoreCase))
            {
                tokens.Add(new Token("Keyword", word));
            }
            else
            {
                tokens.Add(new Token("Literal", word));
            }
        }

        return tokens;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese su código:");
        string userInput = Console.ReadLine();

        Console.WriteLine("Ingrese la cadena que desea contar:");
        string cadenaAContar = Console.ReadLine();

        // Crear el analizador léxico
        Lexer lexer = new Lexer(userInput);

        // Obtener los tokens
        List<Token> tokens = lexer.Tokenize();

        // Contador para la cadena específica
        int contadorCadena = 0;

        // Iterar a través de los tokens
        foreach (var token in tokens)
        {
            // Incrementar el contador cada vez que se encuentra la cadena específica
            if (token.Type == "Literal" && token.Value.Contains(cadenaAContar))
            {
                contadorCadena++;
            }
        }

        // Imprimir el resultado del contador
        Console.WriteLine($"\nLa cadena '{cadenaAContar}' se encontró {contadorCadena} veces.");
        Console.ReadKey();
    }
}
