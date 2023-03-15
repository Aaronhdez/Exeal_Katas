namespace TicTacToe.Model;

public class Token
{
    public Token(string symbol)
    {
        Value = symbol;
    }

    public string Value { get; }
}