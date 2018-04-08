using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts
{
    public class GlobalGameState
    {
        private static readonly GlobalGameState instance = new GlobalGameState();

        public int Difficult { get; private set; }

        private GlobalGameState()
        {
            Difficult = 1;
        }

        public static void ChangeDifficult(int difficult)
        {
            instance.Difficult = difficult;
        }

        public static GlobalGameState GetInstance()
        {
            return instance;
        }
    }
}
