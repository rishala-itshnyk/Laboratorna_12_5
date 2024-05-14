namespace Laboratorna_12_5.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void TestOrderStack()
    {
        // Arrange
        Stack<char> stack = new Stack<char>();
        stack.Push('b');
        stack.Push('c');
        stack.Push('a');

        // Act
        Stack<char> sortedStack = Program.OrderStack(stack);

        // Assert
        Assert.AreEqual('a', sortedStack.Pop());
        Assert.AreEqual('b', sortedStack.Pop());
        Assert.AreEqual('c', sortedStack.Pop());
    }
}