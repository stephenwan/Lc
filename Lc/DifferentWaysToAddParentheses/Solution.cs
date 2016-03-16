using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lc.DifferentWaysToAddParentheses
{
    public class Solution
    {
        private readonly Dictionary<Tuple<int, int>, List<int>> _cachedSolution = new Dictionary<Tuple<int, int>, List<int>>();
        private int[] _numbers;
        private Operator[] _operators;


        public IList<int> DiffWaysToCompute(string input)
        {
            parseInputString(input);
            buildAll();

            var result = _cachedSolution[new Tuple<int, int>(0, _numbers.Length)];
            result.Sort();
            return result.ToList();
        }

        private enum Operator
        {
            Add,
            Minus,
            Multiply
        }

        private int calculate(int left, int right, Operator op)
        {
            switch (op)
            {
                case Operator.Add:
                    return left + right;
                case Operator.Minus:
                    return left - right;
                default:
                    return left*right;
            }
        }

        private void buildAll()
        {
            for (var i = 1; i <= _numbers.Length; i ++)
            {
                for (var j = 0; j <= _numbers.Length - i; j++)
                {
                    build(j, j + i);
                }
            }
        }

        private void build(int left, int right)
        {
            if (left == right - 1)
            {
                _cachedSolution[new Tuple<int, int>(left, right)] = new List<int> { _numbers[left]};
                return;
            }
           
            var result = new List<int>();
            for (var i = left; i < right - 1; i++)
            {
                var splitCaseResult = combine(left, i + 1, right);
                result.AddRange(splitCaseResult);
            }

            _cachedSolution[new Tuple<int, int>(left, right)] = result;
        }


        private IEnumerable<int> combine(int start, int mid, int end )
        {
            var leftKey = new Tuple<int, int>(start, mid);
            var rightKey = new Tuple<int, int>(mid, end);

            var midOperator = _operators[mid - 1];

            var result = new List<int>();

            foreach (var i in _cachedSolution[leftKey])
            {
                result.AddRange(_cachedSolution[rightKey].Select(j => calculate(i, j, midOperator)));
            }

            return result;
        }

        private void parseInputString(string input)
        {
            var curNumber = 0;
            var numberList = new List<int>();
            var operatorList = new List<Operator>();

            foreach (var t in input)
            {
                switch (t)
                {
                    case '+':
                        operatorList.Add(Operator.Add);
                        numberList.Add(curNumber);
                        curNumber = 0;
                        break;
                    case '-':
                        operatorList.Add(Operator.Minus);
                        numberList.Add(curNumber);
                        curNumber = 0;
                        break;
                    case '*':
                        operatorList.Add(Operator.Multiply);
                        numberList.Add(curNumber);
                        curNumber = 0;
                        break;
                    case ' ':
                        continue;
                    default:
                        curNumber = curNumber*10 + (t - '0');
                        break;
                }
            }

            numberList.Add(curNumber);

            _numbers = numberList.ToArray();
            _operators = operatorList.ToArray();
        }

        
    }
}
