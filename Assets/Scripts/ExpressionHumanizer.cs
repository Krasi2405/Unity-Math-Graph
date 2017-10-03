using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class ExpressionHumanizer {

	
    public static string Humanize(string expression)
    {
        expression = HandleMultiplication(expression);
        expression = HandleSquaring(expression);
        expression = HandleAbsoluteValue(expression);
        return expression;
    }


    private static string HandleMultiplication(string expression)
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


    private static string HandleSquaring(string expression)
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


    private static string HandleAbsoluteValue(string expression)
    {
        string startExpression = expression;
        MatchCollection matchCollection = Regex.Matches(
            expression,
            @"\|(.+)\|");
        foreach (Match match in matchCollection)
        {
            expression = expression.Replace(
                match.ToString(),
                "Abs(" + match.Groups[1].ToString() + ")");
        }
        if(startExpression != expression)
        {
            return HandleAbsoluteValue(expression);
        }
        return expression;
    }





}
