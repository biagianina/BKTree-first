using System;
using Xunit;

namespace BKTree
{
    public class BKTreeTests
    {
        [Fact]
        public void PopulateTree()
        {
            var tree = new CreateBKTree();
            tree.Add("help");
            tree.Add("hell");
            tree.Add("helps");
            tree.Add("hello");
            tree.Add("shell");
            tree.Add("helper");
            tree.Add("loop");
            tree.Add("toop");
            Assert.NotNull(tree);
        }
    }
}
