namespace Kiwiland.Service;

public class Node
{
    private char _code;
    public char Code
    {
        get { return _code; }
    }
    public Node(char code)
    {
        _code = code;
    }
    public override string ToString()
    {
        return _code.ToString();
    }
    public override bool Equals(object other)
    {
        if(other.GetType() == typeof(Node))
        {
            return _code == (Node)other;
        }
        return _code ==  (char)other;
    }
    public static implicit operator char(Node city)
    {
        return city.Code;
    }

    public static implicit operator Node(char code)
    {
        return new Node(code);
    }
}
