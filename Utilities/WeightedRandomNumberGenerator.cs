using System;
using System.Linq;
using System.Security.Cryptography;

namespace DamsboSoftware.AlgorithmImplementations.Utilities
{
    public class WeightedRandomNumberGenerator
    {
        public int[] choiceWeights { get; set; }

        public WeightedRandomNumberGenerator()
        {
            this.choiceWeights = new int[0];
        }

        public WeightedRandomNumberGenerator(int[] weights) : this()
        {
            this.choiceWeights = weights;
        }

        public long NextLong()
        {

            long sumOfWeights = choiceWeights.Sum();
            long rnd = LongRandom(0, sumOfWeights, 8);
            for (var i = 0; i < choiceWeights.Length; i++)
            {
                if (rnd < choiceWeights[i])
                    return i;
                rnd -= choiceWeights[i];
            }

            throw new ArgumentException();
        }

        private long LongRandom(long min, long max, int bytes)
        {
            if (min > max) throw new ArgumentOutOfRangeException(nameof(min));
            if (min == max) return min;

            using (var rngCrypto = new RNGCryptoServiceProvider())
            {
                var data = new byte[bytes];
                rngCrypto.GetBytes(data);

                var generatedValue = Math.Abs(BitConverter.ToInt64(data, startIndex: 0));

                var diff = max - min;
                var mod = generatedValue % diff;

                return min + mod;
            }
        }
    }
}