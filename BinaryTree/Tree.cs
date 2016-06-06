using System;

namespace BinaryTree
{
    public class Tree
    {
        private TreeMember _top;

        public TreeMember GetTop()
        {
            return _top;
        }

        private int minHeight(TreeMember knot)
        {
            if (knot == null) return 0;
            var leftH = minHeight(knot.Left);
            var rightH = minHeight(knot.Right);
            return Math.Min(leftH, rightH) + 1;
        }

        public static int Height(TreeMember knot)
        {
            if (knot == null) return 0;
            var leftH = Height(knot.Left);
            var rightH = Height(knot.Right);
            return Math.Max(leftH, rightH) + 1;
        }

        public void AddElement(int value)
        {
            AddElementRecursively(ref _top, value);
        }

        private void AddElementRecursively(ref TreeMember current, int value)
        {
            if (current == null)
            {
                current = new TreeMember { Value = value };
                return;
            }

            var leftH = minHeight(current.Left);
            var rightH = minHeight(current.Right);

            if (leftH <= rightH)
            {
                AddElementRecursively(ref current.Left, value);
            }
            else
            {
                AddElementRecursively(ref current.Right, value);
            }
        }
    }
}