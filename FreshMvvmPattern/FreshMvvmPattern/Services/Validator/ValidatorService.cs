using System;
using System.Collections.Generic;
using System.Text;

namespace EsriNeaMvvmPattern.Services.Validator
{
    public class ValidatorService : IValidatorService
    {
        public int count = 0;
        public ValidatorService()
        {
            count++;
        }
        public void populate()
        {
            count += count + 100;
        }
    }
}
