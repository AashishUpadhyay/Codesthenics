using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class MaximumRectangle
	{
        private int _len = 0;
        private int _wid = 0;
        private int _area = 0;
        private char[][] _matrix;
        private int[][] _dp;
        public int Area(char[][] matrix)
		{
            _matrix = matrix;

            if (_matrix.Length == 0)
                return 0;

            _len = _matrix.Length;
            if (_matrix[0].Length > 0)
                _wid = _matrix[0].Length;

            _dp = new int[_len][];

            for (int i = 0; i < _len; i++)
                _dp[i] = new int[_wid];

            for (int i = 0; i < _len; i++)
            {
                for (int j = 0; j < _wid; j++)
                {
                    CalculateArea(i, j);
                }
            }

            return _area;
        }

        private void CalculateArea(int ri, int ci)
        {
            Stack<int> st = new Stack<int>();
            st.Push(ci - 1);

            int widIndex = -1;
            for (int j = ci; j < _wid; j++)
            {
                if (_matrix[ri][j] == '0')
                    break;

                widIndex = j;
                _dp[ri][j] = CalculateHeight(ri, j);

                if (st.Peek() == (ci - 1) || _dp[ri][st.Peek()] <= _dp[ri][j])
                    st.Push(j);
                else
                {
                    int li = st.Pop();
                    _area = Math.Max(_area, _dp[ri][li] * (j - st.Peek()-1));
                    j--;
                }
            }

            while (st.Count() > 0)
            {
                int li = st.Pop();
                if (li == (ci - 1))
                    continue;
                else if (st.Peek() == (ci - 1))
                {
                    _area = Math.Max(_area, _dp[ri][li] * (widIndex - (ci-1)));
                }
                else
                    _area = Math.Max(_area, _dp[ri][li] * (widIndex - st.Peek()));

            }
        }

        private int CalculateHeight(int i, int j)
        {
            int ht = 0;
            for (int m = i; m > -1; m--)
            {
                if (_matrix[m][j] == '0')
                    break;

                ht++;
            }
            return ht;
        }
    }

}
