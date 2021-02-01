using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvedProblemReducingDishes
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSatisfactionResult = 0;

            int[] feedback = {-2,5,-1,0,3,-3 };
            maxSatisfactionResult = maxSatisfaction(feedback);
         //   Console.WriteLine(maxSatisfactionResult);
            Console.ReadLine();
        }
        public static int maxSatisfaction(int[] satisfaction)
        {
            Array.Sort(satisfaction);
            int mult = 1;
            int maxsat = 0;
            int n = satisfaction.Length;
            int zeroOrPositiveIdx = -1;
            bool zeroOrPositiveIdxFound = false;
            int cummulativeSum = 0;

            for (int i = 0; i < n; i++)
            {
                if (!zeroOrPositiveIdxFound && satisfaction[i]>=0)
                {
                    zeroOrPositiveIdx = i - 1;
                    zeroOrPositiveIdxFound = true;
                }
                if(satisfaction[i]<0)
                {
                    continue;
                }
                maxsat += satisfaction[i] * mult;
                mult++;
                cummulativeSum += satisfaction[i];
            }

            while (zeroOrPositiveIdx >= 0)
            {
                int curSat = satisfaction[zeroOrPositiveIdx] + maxsat + cummulativeSum;
                if (curSat > maxsat)
                {
                    maxsat = curSat;
                }
                cummulativeSum += satisfaction[zeroOrPositiveIdx];
                zeroOrPositiveIdx--;
            }
           
            Console.WriteLine("Max Satisfaction : "+ maxsat);
            Console.WriteLine("Commulative Sum : " + cummulativeSum);
            return maxsat;
        }
    }
}
