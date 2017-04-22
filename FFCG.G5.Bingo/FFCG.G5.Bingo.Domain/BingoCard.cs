using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G5.Bingo.Domain
{
    public class BingoCard
    {
        private readonly int _columnsCount;
        private readonly int[,] _numbers;
        private readonly int _rowsCount;
        private List<int> _availableNumbers;

        public BingoCard(int rowsCount, int columnsCount)
        {
            _rowsCount = rowsCount;
            _columnsCount = columnsCount;
            _numbers = CreateBoardStructure(rowsCount, columnsCount);
            var totalCount = rowsCount * columnsCount;
            CreateListOfAvailableNumbers(totalCount);
        }

        public int[,] DrawNewRound()
        {
            if (IsBingo()) return new int[0, 0];
            var number = GetRandomNumber();
            MarkNumberAsDrawn(number);
            return _numbers;
        }

        private void CreateListOfAvailableNumbers(int totalCount)
        {
            var numbers = new List<int>();
            for (var i = 1; i <= totalCount; i++)
                numbers.Add(i);

            _availableNumbers = numbers;
        }

        private int[,] CreateBoardStructure(int rows, int columns)
        {
            var numbers = new int[rows, columns];

            for (var i = 0; i < columns; i++)
            {
                var currentColumn = new List<int>();
                var startingPoint = rows * i + 1;
                for (var j = 1; j <= rows; j++)
                {
                    currentColumn.Add(startingPoint);
                    startingPoint++;
                }

                for (var j = 0; j < rows; j++)
                {
                    numbers[j, i] = currentColumn.OrderBy(x => Guid.NewGuid()).First();
                    currentColumn.Remove(numbers[j, i]);
                }
            }
            return numbers;
        }

        public int GetRandomNumber()
        {
            var numberToReturn = _availableNumbers.OrderBy(x => Guid.NewGuid()).First();
            _availableNumbers.Remove(numberToReturn);
            return numberToReturn;
        }

        public void MarkNumberAsDrawn(int drawnNumber)
        {
            var coordinates = _numbers.CoordinatesOf(drawnNumber);
            _numbers[coordinates.row, coordinates.column] = 0;
        }

        public int[,] GetNumbers() => _numbers;

        public bool IsBingo()
        {
            for (var i = 0; i < _rowsCount; i++)
            {
                var isBingo = true;
                for (var j = 0; j < _columnsCount; j++)
                    if (_numbers[i, j] != 0)
                        isBingo = false;
                if (isBingo)
                    return true;
            }
            return false;
        }
    }

    public static class TwoDimensionalIntArrayExtensions
    {
        public static (int row, int column) CoordinatesOf<T>(this T[,] matrix, T value)
        {
            var width = matrix.GetLength(0);
            var height = matrix.GetLength(1);

            for (var x = 0; x < width; ++x)
                for (var y = 0; y < height; ++y)
                    if (matrix[x, y].Equals(value))
                        return (x, y);

            return (-1, -1);
        }
    }
}