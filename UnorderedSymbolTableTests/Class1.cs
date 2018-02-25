using NUnit.Framework;
using UnorderedSymbolTableLesson;

namespace UnorderedSymbolTableTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Testing()
        {
            var symbolTable = new UnorderedSymbolTable<string, int>();

            symbolTable.Insert("S", 0);
            symbolTable.Insert("E", 1);
            symbolTable.Insert("A", 2);
            symbolTable.Insert("R", 3);
            symbolTable.Insert("C", 4);
            symbolTable.Insert("H", 5);
            symbolTable.Insert("E", 6);
            symbolTable.Insert("X", 7);
            symbolTable.Insert("A", 8);
            symbolTable.Insert("M", 9);
            symbolTable.Insert("P", 10);
            symbolTable.Insert("L", 11);
            symbolTable.Insert("E", 12);

        }
    }
}
