using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolverV2.Model
{
    public class EncryptionHelper
    {
        private const int EncryptionKey = 123; // Klucz szyfrowania

        public int EncryptInt(int valueToEncrytpion)
        {
            return valueToEncrytpion ^ EncryptionKey;
        }

        public int DecryptInt(int valueToDecrytpion)
        {
            return valueToDecrytpion ^ EncryptionKey;
        }
    }
}
