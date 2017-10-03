using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class ExpressionHumanizer {

	
    public string Humanize(string expression)
    {
        expression = HandleMultiplication(expression);
        expression = HandleSquaring(expression);
        expression = HandleAbsoluteValue(expression);
        return expression;
    }


    private string HandleMultiplication(string expression)
    {
        MatchCollection matchCollection = Regex.Matches(expression, @"(\d+)(\w+)");
        foreach(Match match in matchCollection)
        {   
            expression = expression.Replace(
                match.ToString(), 
                match.Groups[1].ToString() + "*" + match.Groups[2]);
        }
        return expression;
    }


    private string HandleSquaring(string expression)
    {
        MatchCollection matchCollection = Regex.Matches(
            expression,
            // Handle any sort of combination between words and numbers.
            @"((\w+)\^(\w+))|((\d+)\^(\w+))|((\w+)\^(\d+))|((\d+)\^(\d+))");
        

        foreach (Match match in matchCollection)
        {
            expression = expression.Replace(
                match.ToString(),
                "Pow(" + match.Groups[2].ToString() + "," + match.Groups[3] + ")");
        }
        return expression;
    }


    private string HandleAbsoluteValue(string expression)
    {
        MatchCollection matchCollection = Regex.Matches(
            expression,
            @"\|(.+)\|");
        foreach (Match match in matchCollection)
        {
            expression = expression.Replace(
                match.ToString(),
                "Abs(" + match.Groups[1].ToString() + ")");
        }
        return expression;
    }





}
