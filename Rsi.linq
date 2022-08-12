<Query Kind="Program" />

// RSI

double[] ClipUpper(double[] array, double upThreshold)
{
	var clippedArray = new double[array.Length];
	for (int i = 0; i < array.Length; i++)
	{
		if (array[i] > upThreshold)
		{
			clippedArray[i] = upThreshold;
		}
		else
		{
			clippedArray[i] = array[i];
		}
	}
	
	return clippedArray;
}

double[] ClipLower(double[] array, double lowThreshold)
{
	var clippedArray = new double[array.Length];
	for (int i = 0; i < array.Length; i++)
	{
		if (array[i] < lowThreshold)
		{
			clippedArray[i] = lowThreshold;
		}
		else
		{
			clippedArray[i] = array[i];
		}
	}

	return clippedArray;
}

double[] Ewm(double[] array, double periods)
{
	var alpha = 1.0 / periods;
	var ewm = new double[array.Length];

	var den = new double[array.Length];
	var num = new double[array.Length];

	if (!Double. IsNaN(array[0]))
	{
		Console.WriteLine($"array[0] = {array[0]}");
		den[0] = 1.0;
		num[0] = array[0];
	}
	else
	{
		ewm[0] = double.NaN;
	}
	
	for (int i = 1; i < array.Length; i++)
	{
		den[i] = 1.0 + den[i-1] * (1-alpha);
		num[i] = array[i] + num[i-1] * (1-alpha);
		ewm[i] = num[i] / den[i];
	}

	if (Double.IsNaN(array[0]))
	{
		ewm[1] = double.NaN;
	}
	
	return ewm;
}

double[] Diff(double[] array)
{
	var result = new double[array.Length];
	
	result[0] = double.NaN;
	for (int i = 1; i<result.Length; i++)
	{
		result[i] = array[i] - array[i-1];
	}
	
	return result;
}

double[] Divide(double[] numerator, double[] denominator)
{
	var result = new double[numerator.Length];
	for (int i = 0; i < result.Length; i++)
	{
		result[i] = numerator[i] / denominator[i];
	}
	
	return result;
}

double[] Rsi(double[] closePrice, double periods)
{
	var diff = Diff(closePrice);
	var up = ClipLower(diff, lowThreshold: 0.0);
	var down = ClipUpper(diff, upThreshold: 0.0);
	for (int i = 0; i < down.Length; i++)
	{
		down[i] = down[i] * -1;
	}

	var maUp = Ewm(up, periods);
	var maDown = Ewm(down, periods);
	var div = Divide(maUp, maDown);
	var rsi = new double[closePrice.Length];
	for (int i = 0; i < rsi.Length; i++)
	{
		rsi[i] = 100 - (100 / (1.0 + div[i]));
	}
	
	return rsi;
}

void Main()
{
	var closePrice = new double[] {1, 4, 5, 6, 2, 9, 1, 34, 10};
	var periods = 2;
	var rsi = Rsi(closePrice, periods);
	Console.WriteLine(string.Join(",", rsi));
	/*
	NaN,NaN,100,100,21.951219512195124,79.08496732026144,29.584352078239604,88.57596191987307,39.92490613266583
	*/
}
