namespace TicTacToe.Model;

public class Symbol
{
    public Symbol(string symbol)
    {
        Value = symbol;
    }

    public string Value { get; }
}