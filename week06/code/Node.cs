public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if(Contains(value))
        {
            Console.WriteLine(value + " is already in Binary Tree. Duplicates not allowed.");
            return; 
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (Data == value)
        {
            return true;
        }
        if (value < Data)
        {
            return Left is not null && Left.Contains(value);
        }
        else
        {
            return Right is not null && Right.Contains(value);
        }
    }

    public int GetHeight() // calculating each subtree's side individually then returning the largest of the _root node
    {
        int leftHeight = Left?.GetHeight() ?? 0; // declear the left heights variable which will be returned with 1 addition (first call will be 1, second call will have the 1 return and it will add 1 so 2, then so forth and so on until there is not left)
        int rightHeight = Right?.GetHeight() ?? 0; // does the same thing as the left side except moving to the right now

        return 1 + Math.Max(leftHeight, rightHeight); // returning 1 + whatever the maximum size is, right or left.
    }
}