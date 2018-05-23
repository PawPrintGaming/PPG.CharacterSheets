using System;

namespace PPG.CharacterSheets.ErrorHandling
{
    public class PPGException : Exception
    {
        public PPGException(string message)
            : base(message)
        {
        }
    }
}
