using NUnit.Framework;
using OrderedSymbolTableLesson;

namespace OrderedSymbolTableTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Testing()
        {
            var symbolTable = new OrderedSymbolTable<string, int>();

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

        [Test]
        public void TestingExtended()
        {
            var symbolTable = new OrderedSymbolTableExtended<string, int>();

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

            var min = symbolTable.Min();
            var max = symbolTable.Max();
            var floor = symbolTable.Floor("L");
            var ceiling = symbolTable.Ceiling("L");
            var floor2 = symbolTable.Floor("K");
            var ceiling2 = symbolTable.Ceiling("K");

        }
    }
}
