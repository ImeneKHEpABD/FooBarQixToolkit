﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBarQixToolkit
{
    public class FooBarQixOperations
    {
        #region Attributes
      
        public FooBarQixRuleContains foobarqixrulecontains;
        public FooBarQixRuleDividers foobarqixruledividers;
        #endregion

        #region Constructor      
        public FooBarQixOperations()
        {
            foobarqixrulecontains = new FooBarQixRuleContains();
            foobarqixruledividers = new FooBarQixRuleDividers();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Builds the string using the division rules.
        /// </summary>
        /// <param name="inputString">The  string number to be evaluated</param>
        /// <returns>The string returned after applying the divider and the container rules</returns>
        public string EvaluateRules(string inputString)
        {
            long parsedNumber = 0;
            var result = string.Empty;
            try
            {
                if (Int64.TryParse(inputString, out parsedNumber))
                {
                    result = foobarqixruledividers.ApplyRule(inputString);

                    result += BuildString(result, inputString);
                    if (string.IsNullOrEmpty(result))
                        result = inputString.ToString();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        /// <summary>
        /// Builds the string using the division rules.
        /// </summary>
        /// <param name="dividerresult">The string returned after applying the division rules</param>
        /// <param name="number">The number to be evaluated</param>
        /// <returns>The string returned after applying the contains rules</returns>
        public string BuildString(string dividerresult, string number)
        {
            var result = string.Empty;
            try
            {
                if ((string.IsNullOrEmpty(dividerresult.Trim())
                    && (!number.AsEnumerable<char>()
                    .Select(x => int.Parse(x.ToString()))
                    .Any(x => foobarqixruledividers.DicDividerRules.ContainsKey(x)))))
                {
                    result = number.Replace('0', '*');
                }
                else
                {
                    result = number.Aggregate(result, (current, t) => current + foobarqixrulecontains.ApplyRule(t.ToString()));
                }
            }
            catch (Exception ex)
            {
                
            }
            return result.ToString();
        }
        #endregion
    }
}
