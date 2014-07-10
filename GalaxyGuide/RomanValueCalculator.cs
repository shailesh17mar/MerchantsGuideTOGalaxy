using System;
using System.Collections.Generic;
using System.Globalization;

namespace GalaxyGuide
{
    public enum RomanChart
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }

    public class RomanValueCalculator
    {
        private List<RomanChart> _romanString;

        private RomanNumberValidationChainManager _validationChainManager;

        private DLVRepetitionValidator _validationChainHeader;

        public RomanValueCalculator()
        {
            _romanString=new List<RomanChart>();
            _validationChainHeader=new DLVRepetitionValidator();
            _validationChainManager = new RomanNumberValidationChainManager(_validationChainHeader);
            _validationChainManager.Setup();
        }

        public int Convert(string romanNumberString)
        {
            try
            {
                StringToEnumArray(romanNumberString);
                _validationChainHeader.Validate(_romanString);

                return CalculateValue();
            }
            catch (ArgumentException e)
            {
                throw;
            }

        }

        private void StringToEnumArray(string romanNumberString)
        {
            foreach (var c in romanNumberString)
            {
                _romanString.Add((RomanChart)Enum.Parse(typeof(RomanChart), c.ToString(CultureInfo.InvariantCulture), true));
            }
        }

        private int CalculateValue()
        {
            var sum = 0;
            for (var i = 0; i < _romanString.Count ; i++)
            {
                if (i < _romanString.Count-1)
                {
                    if ((int)_romanString[i] < (int)_romanString[i + 1])
                    {
                        sum = sum + (int)_romanString[i + 1] - (int)_romanString[i];
                        i++;
                        continue;
                    }
                }
                
                sum += (int)_romanString[i];
            }
            return sum;
        }

    }
}