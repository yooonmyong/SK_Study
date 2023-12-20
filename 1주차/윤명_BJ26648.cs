using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public static class BJ26648
    {
        private static int N;
        private static Dictionary<int, List<int>> dict;

        public static void Execute()
        {
///////////////////////////////////////////////////////////////////////// 입력
            var inputList = Console.ReadLine().Split(' ');

            N = int.Parse(inputList[0]);

            int[] muliArray = new int[N];
            int[] jungboArray = new int[N];
            int[] mathArray = new int[N];

            dict = new Dictionary<int, List<int>>();
            for (var i = 0; i < N; i++)
                dict[i] = new List<int>();

            var muliInput = Console.ReadLine().Split(' ');
            for (var j = 0; j < N; j++)
            {
                muliArray[j] = int.Parse(muliInput[j]);
                dict[j].Add(muliArray[j]);
            }

            var jungboInput = Console.ReadLine().Split(' ');
            for (var j = 0; j < N; j++)
            {
                jungboArray[j] = int.Parse(jungboInput[j]);
                dict[j].Add(jungboArray[j]);
            }

            var mathInput = Console.ReadLine().Split(' ');
            for (var j = 0; j < N; j++)
            {
                mathArray[j] = int.Parse(mathInput[j]);
                dict[j].Add(mathArray[j]);
            }
/////////////////////////////////////////////////////////////////////////

            for (var i = 0; i < N; i++)
            {
                dict[i].Sort();
            }

            var result = CheckScore(N - 1);

            if (result  > 0)
            {
                dict[result - 1][1] = dict[result][1] ;
                var result2 = CheckScore(N - 1);

                if (result2 > 0)
                {
                    dict[result - 1][1]--;
                    dict[result][1]++;

                    var result3 = CheckScore(N - 1);

                    if (result3 > 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
            return;
        }

        private static int CheckScore(int i)
        {
            if (i <= 0)
                return -1;

            return dict[i - 1][1] < dict[i][1] ? CheckScore(i - 1) : i;
        }
    }
}
