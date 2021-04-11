using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Business
{
    public class BusinessRules
    {
        /// <summary>
        /// Runs the given busines logics, if any of the ends with error,it returns the corresponding logic, else it returns null.
        /// </summary>
        /// <param name="logics">Business rules of type IResult.</param>
        /// <returns>Return null if all of the given logics ends with success, else it return the logic that gives the error.</returns>
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
