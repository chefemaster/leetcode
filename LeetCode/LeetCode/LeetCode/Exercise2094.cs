using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    class Exercise2094
    {
        /*
You are given an integer array digits, where each element is a digit. The array may contain duplicates.

You need to find all the unique integers that follow the given requirements:

The integer consists of the concatenation of three elements from digits in any arbitrary order.
The integer does not have leading zeros.
The integer is even.
For example, if the given digits were [1, 2, 3], integers 132 and 312 follow the requirements.

Return a sorted array of the unique integers.

Example 1:

Input: digits = [2,1,3,0]
Output: [102,120,130,132,210,230,302,310,312,320]
Explanation: All the possible integers that follow the requirements are in the output array. 
Notice that there are no odd integers or integers with leading zeros.
Example 2:

Input: digits = [2,2,8,8,2]
Output: [222,228,282,288,822,828,882]
Explanation: The same digit can be used as many times as it appears in digits. 
In this example, the digit 8 is used twice each time in 288, 828, and 882. 
Example 3:

Input: digits = [3,7,5]
Output: []
Explanation: No even integers can be formed using the given digits.
        */

        public bool Execute()
        {
            int[] nums = { 2, 2, 8, 8, 2 };
            int[] result = FindNumbers(nums);
            Console.WriteLine(string.Join(", ", result));
            return true;
        }

        public int[] FindNumbers(int[] nums)
        {
            int[] freq = new int[10];
            foreach (var number in nums)
            {
                freq[number]++;
            }

            // Lista para armazenar o resultado em ordem
            List<int> result = new List<int>();
            int[] tempFreq = new int[10];

            // Verificar cada possivel número de três digitos (100-999)
            for (int num = 100; num < 1000; num += 2) //incremento de 2 para garantir apenas números pares
            {
                int hundred = num / 100; // primeiro dígito - centenas
                int ten = num / 10 % 10; // segundo dígito - dezenas
                int unit = num % 10; // terceiro dígito - unidades

                // copiar a frequência para verificação
                tempFreq[hundred]++;
                tempFreq[ten]++;
                tempFreq[unit]++;

                // verificar se temosos dígitos necessários
                if (tempFreq[hundred] <= freq[hundred] && tempFreq[ten] <= freq[ten] && tempFreq[unit] <= freq[unit])
                {
                    // se todos os dígitos estão disponíveis, adicionamos o número à lista
                    result.Add(num);
                }

                // reiniciar a frequência temporária
                tempFreq[hundred] = 0;
                tempFreq[ten] = 0;
                tempFreq[unit] = 0;
            }

            return result.ToArray();
        }
    }
}
