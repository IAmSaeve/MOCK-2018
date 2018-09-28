using System;

namespace Skat
{
    /// <summary>
    /// Library for calutating car tax for both electric and motorised
    /// </summary>
    public class Afgift
    {
        /// <summary>
        /// Method for calculating the tax of an electric car.
        /// If the price is below or equal 200000 then the equation is as follows:
        /// Price of the car times 0.85.
        /// If the price is over 200000 then the equation is as following:
        /// Price of the car times 1.50 minus 130000.
        /// </summary>
        /// <param name="pris"></param>
        /// <returns>Returns the total tax as type double.</returns>
        public double BilAfgift(double pris)
        {
            if (pris <= 200000)
            {
                return (pris * 0.85);
            }
            else
            {
                return (pris * 1.50) - 130000;
            }
        }

        /// <summary>
        /// Method for calculating the tax of an electric car.
        /// If the price is below or equal 200000 then the equation is as follows:
        /// Price of the car times 0.85 times 0.20.
        /// If the price is over 200000 then the equation is as following:
        /// Price of the car times 1.50 minus 130000 times 0.20
        /// </summary>
        /// <param name="pris"></param>
        /// <returns>Returns the total tax as type double.</returns>
        public double ElBilAfgift(double pris)
        {
            if (pris <= 200000)
            {
                return (pris * 0.85) * 0.20;
            }
            else
            {
                return ((pris * 1.50) - 130000) * 0.20;
            }
        }
    }
}
