using System.Collections.Generic;
using System.Linq;
using FFCG.G5.GameOfLife.Rules;

namespace FFCG.G5.GameOfLife
{
    public class Cell
    {
        private readonly List<ICellLiveRule> _rules;

        public Cell(bool isAlive, List<ICellLiveRule> rules)
        {
            IsAlive = isAlive;
            _rules = rules;
        }

        public bool IsAlive { get; set; }

        public Cell NextGenerationState(int neighbourCount)
        {
            return new Cell(
                _rules.Any(x => x.ShouldLiveNextGeneration(neighbourCount, IsAlive)),
                _rules);
        }
    }
}