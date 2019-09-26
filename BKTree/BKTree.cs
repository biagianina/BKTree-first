using System;
using System.Collections.Generic;
using System.Text;

namespace BKTree
{
    public class CreateBKTree
    {
        private BKTreeNode rootNode;

        public void Add(string value)
        {
            if (rootNode != null)
            {
                AddToChildren(rootNode, value);
            }
            else
            {
                rootNode = new BKTreeNode(value);
            }
        }

        private void AddToChildren(BKTreeNode rootNode, string value)
        {
            int levenstheinDist = GetLevenstheinDistance(rootNode.Value, value);
            if (!rootNode.Children.ContainsKey(levenstheinDist))
            {
                rootNode.Children.Add(levenstheinDist, new BKTreeNode(value));
            }
            else
            {
                rootNode.Children.TryGetValue(levenstheinDist, out BKTreeNode current);
                int dist = GetLevenstheinDistance(current.Value, value);
                current.Children.Add(dist, new BKTreeNode(value));
            }
        }

        private int GetLevenstheinDistance(string first, string second)
        {
            int[,] distance;
            int n = first.Length;
            int m = second.Length;
            int cost;
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            distance = new int[n + 1, m + 1];
            for (int i = 0; i <= n; i++)
            {
                distance[i, 0] = i;
            }

            for (int j = 0; j <= m; j++)
            {
                distance[0, j] = j;
            }

            for (int i = 1; i <= n; i++)
            {
                char firstValueChar = first[i - 1];
                for (int j = 1; j <= m; j++)
                {
                    char secondValueChar = second[j - 1];
                    cost = firstValueChar == secondValueChar ? 0 : 1;

                    distance[i, j] = Math.Min(
                        Math.Min(
                            distance[i - 1, j] + 1,
                            distance[i, j - 1] + 1),
                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[n, m];
        }
    }
}