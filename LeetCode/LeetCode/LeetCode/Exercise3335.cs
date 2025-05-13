using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LeetCode
{
    class Exercise3335 : IExercise
    {
        /*
            You are given a string s and an integer t, representing the number of transformations to perform. In one transformation, every character in s is replaced according to the following rules:

            If the character is 'z', replace it with the string "ab".
            Otherwise, replace it with the next character in the alphabet. For example, 'a' is replaced with 'b', 'b' is replaced with 'c', and so on.
            Return the length of the resulting string after exactly t transformations.

            Since the answer may be very large, return it modulo 109 + 7. 

            Example 1:

            Input: s = "abcyy", t = 2

            Output: 7

            Explanation:

            First Transformation (t = 1):
            'a' becomes 'b'
            'b' becomes 'c'
            'c' becomes 'd'
            'y' becomes 'z'
            'y' becomes 'z'
            String after the first transformation: "bcdzz"
            Second Transformation (t = 2):
            'b' becomes 'c'
            'c' becomes 'd'
            'd' becomes 'e'
            'z' becomes "ab"
            'z' becomes "ab"
            String after the second transformation: "cdeabab"
            Final Length of the string: The string is "cdeabab", which has 7 characters.
            Example 2:

            Input: s = "azbk", t = 1

            Output: 5

            Explanation:

            First Transformation (t = 1):
            'a' becomes 'b'
            'z' becomes "ab"
            'b' becomes 'c'
            'k' becomes 'l'
            String after the first transformation: "babcl"
            Final Length of the string: The string is "babcl", which has 5 characters.
         */

        public bool Execute()
        {
            //var result = LengthAfterTransformations("abcyy", 2);
            var result = LengthAfterTransformations("jqktcurgdvlibczdsvnsg", 7517);
            Console.WriteLine(result);            
            return true;
        }

        public int LengthAfterTransformations(string s, int t)
        {
            // Utilizar o modulo 10^9 + 7 para evitar overflow
            const int MOD = 1_000_000_007;

            // Frequência de cada letra no alfabeto
            var stringFreq = new int[26];
            foreach (var c in s)
                // Carregando as frequência da letras existentes
                stringFreq[c - 'a']++;

            for (int i = 0; i < t; i++)
            {
                // Criando uma nova lista de frequência para realizar a troca para proxima letra
                var tempStringFreq = new int[26];
                for (int j = 0; j < 26; j++)
                {
                    if (j < 25)
                    {
                        //Pulando a quantidade de letras para proxima letra
                        tempStringFreq[j+1] = stringFreq[j];
                        continue;
                    }
                    // Se for a letra 'z' (na posição 25) ela deve ser trocada por 'a' e 'b'
                    // Então, a letra 'a' (posição 0) deve receber a quantidade de letras 'z'
                    tempStringFreq[0] = stringFreq[25];
                    // E a letra 'b' (posição 1) deve receber a quantidade da letra 'b' atual + quantidade de letras 'z'
                    tempStringFreq[1] = (tempStringFreq[1] + stringFreq[25]) % MOD;
                }
                stringFreq = tempStringFreq;
            }
            // Somando todas as letras para obter o tamanho final da string
            return stringFreq.Aggregate((x, y) => (x + y) % MOD);
        }

    }
}
