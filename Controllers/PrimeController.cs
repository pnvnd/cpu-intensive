using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace cpu_intensive.Controllers
{
    [Route("api/[controller]")]
    public class PrimeController : Controller
    {
        // GET api/prime/5
        [HttpGet("{val}")]
        public string Get(int val)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long nthPrime = FindPrimeNumber(val);
            sw.Stop();
            return String.Format("{0} is prime number # {1}. Calculated in {2} milliseconds.", nthPrime, val, sw.ElapsedMilliseconds);
        }

        private long FindPrimeNumber(int n)
        {
            int count=0;
            long a = 2;
            while(count<n)
            {
                long b = 2;
                int prime = 1; // Check if prime number is found
                while(b * b <= a)
                {
                    if(a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if(prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
