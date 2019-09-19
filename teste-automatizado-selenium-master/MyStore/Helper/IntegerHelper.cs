using System;
using System.Threading;

namespace MyStore.Helper
{
    internal class IntegerHelper
    {
        private const int TEMPO_NOVA_SEMENTE = 1;

        protected IntegerHelper()
        {
        }

        public static int Random(int max)
        {
            Thread.Sleep(TEMPO_NOVA_SEMENTE);

            var random = new Random(DateTime.Now.Millisecond);

            return random.Next(max);
        }

        public static int Random(int min, int max)
        {
            Thread.Sleep(TEMPO_NOVA_SEMENTE);

            var random = new Random(DateTime.Now.Millisecond);

            return random.Next(min, max + 1);
        }
    }
}