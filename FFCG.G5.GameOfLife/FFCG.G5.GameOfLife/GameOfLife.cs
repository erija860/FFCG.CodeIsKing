using System.Collections.Generic;
using System.Linq;
using FFCG.G5.GameOfLife.Rules;

namespace FFCG.G5.GameOfLife
{
    public class GameOfLife
    {
        private readonly int _columns;
        private readonly int _rows;

        public GameOfLife(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            Cells = new Cell[rows, columns];

            var rules = new List<ICellLiveRule>
            {
                new AliveCellWithFewerThanTwoAliveNeighboursShouldDieRule(),
                new AliveCellWithMoreThanThreeAliveNeighboursShouldDieRule(),
                new AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule(),
                new DeadCellWithThreeAliveNeighboursShouldLiveRule()
            };

            InitiateGrid(rules);
        }

        public Cell[,] Cells { get; private set; }

        private void InitiateGrid(List<ICellLiveRule> rules)
        {
            for (var row = 0; row <= Cells.GetUpperBound(0); row++)
                for (var column = 0; column <= Cells.GetUpperBound(1); column++)
                    Cells[row, column] = new Cell(false, rules);
        }

        public void ToggleCellStatus(int row, int column)
        {
            Cells[row, column].IsAlive = !Cells[row, column].IsAlive;
        }

        public void UpdateToNextGeneration()
        {
            var nextGenerationCells = new Cell[_rows, _columns];

            for (var row = 0; row <= Cells.GetUpperBound(0); row++)
                for (var column = 0; column <= Cells.GetUpperBound(1); column++)
                {
                    var neighbourCount = CalculateAliveNeighbourCount(row, column);
                    nextGenerationCells[row, column] = Cells[row, column].NextGenerationState(neighbourCount);
                }

            Cells = nextGenerationCells;
        }

        private int CalculateAliveNeighbourCount(int cellRow, int cellColumn)
        {
            var startRow = cellRow - 1 < 0 ? cellRow : cellRow - 1;
            var startColumn = cellColumn - 1 < 0 ? cellColumn : cellColumn - 1;
            var endRow = cellRow + 1 > _rows - 1 ? cellRow : cellRow + 1;
            var endColumn = cellColumn + 1 > _columns - 1 ? cellColumn : cellColumn + 1;

            var neighbourCells = new List<Cell>();

            for (var row = startRow; row <= endRow; row++)
                for (var column = startColumn; column <= endColumn; column++)
                    if (row != cellRow || column != cellColumn)
                        neighbourCells.Add(Cells[row, column]);

            return neighbourCells.Count(x => x.IsAlive);
        }
    }
}