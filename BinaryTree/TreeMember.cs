namespace BinaryTree
{
    public class TreeMember
    {
        public int Value;
        public TreeMember Left;
        public TreeMember Right;

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }
    }
}
