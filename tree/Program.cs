using System;
using System.Collections.Generic;

class Program
{

    class TreeNode
    {
        public char Value { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();
    }

    class Tree
    {
        public TreeNode Root { get; set; }
    }

    static int GetMaxBranches(TreeNode node)
    {
        if (node == null || node.Children.Count == 0)
            return 0;

        int maxBranches = 0;
        foreach (var child in node.Children)
            maxBranches = Math.Max(maxBranches, 1 + GetMaxBranches(child));

        return maxBranches;
    }

    static void PrintTree(TreeNode node, string indent = "", bool isLast = true)
    {
        if (node == null)
            return;

        Console.Write(indent);
        Console.Write(isLast ? "└── " : "├── ");
        Console.WriteLine(node.Value);

        indent += isLast ? "    " : "│   ";

        for (int i = 0; i < node.Children.Count; i++)
        {
            PrintTree(node.Children[i], indent, i == node.Children.Count - 1);
        }
    }

    static void Main(string[] args)
    {
        Tree tree = new Tree();
        tree.Root = new TreeNode { Value = 'A' };
        tree.Root.Children = new List<TreeNode> {
            new TreeNode { Value = 'B', Children = new List<TreeNode> {
                new TreeNode { Value = 'D' },
                new TreeNode { Value = 'E' },
            } },
            new TreeNode { Value = 'C', Children = new List<TreeNode> {
                new TreeNode { Value = 'F', Children = new List<TreeNode> {
                    new TreeNode { Value = 'H' },
                    new TreeNode { Value = 'I' },
                } },
                new TreeNode { Value = 'G', Children = new List<TreeNode> {
                    new TreeNode { Value = 'J' },
                    new TreeNode { Value = 'K', Children = new List<TreeNode> {
                        new TreeNode { Value = 'L' },
                        new TreeNode { Value = 'M' },
                    } },
                } },
            } },
        };

        Console.WriteLine(GetMaxBranches(tree.Root));
        Console.WriteLine();
        PrintTree(tree.Root);
    }
}
