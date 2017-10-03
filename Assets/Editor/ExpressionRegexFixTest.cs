using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ExpressionRegexFixTest {


	[Test]
	public void T00ReturnsUnchangedExpression() {
        string expressionHuman = "2 + x";
        string expressionNCalc = "2 + x";
		Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
	}


    [Test]
    public void T01HandleMultiplication()
    {
        string expressionHuman = "2x";
        string expressionNCalc = "2*x";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }


    [Test]
    public void T02HandleMultipleMultiplications()
    {
        string expressionHuman = "2x + 4x + 20y";
        string expressionNCalc = "2*x + 4*x + 20*y";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }

    [Test]
    public void T03HandleSquaringNumber()
    {
        string expressionHuman = "x^2";
        string expressionNCalc = "Pow(x,2)";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }

    [Test]
    public void T04HandleMultipleSquaring()
    {
        string expressionHuman = "x^2 + 2^y";
        string expressionNCalc = "Pow(x,2) + Pow(2,y)";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }

    [Test]
    public void T05HandleAbsoluteValues()
    {
        string expressionHuman = "|2x + 5|";
        string expressionNCalc = "Abs(2*x + 5)";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }

    // FULL RUNS
    [Test]
    public void T06HandleAll00()
    {
        string expressionHuman = "|4x + y^2| + 5";
        string expressionNCalc = "Abs(4*x + Pow(y,2)) + 5";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }

    [Test]
    public void T06HandleAll01()
    {
        string expressionHuman = "|2 - |4x + y^2| + 5|";
        string expressionNCalc = "Abs(2 - Abs(4*x + Pow(y,2)) + 5)";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }

    [Test]
    public void T07HandleAll02()
    {
        string expressionHuman = "|2^3 + y^x + 2x|";
        string expressionNCalc = "Abs(Pow(2,3) + Pow(y,x) + 2*x)";
        Assert.AreEqual(expressionNCalc, ExpressionHumanizer.Humanize(expressionHuman));
    }
}
