<Query Kind="Program" />

double Quantile(double[] array, double q)
{
	Array.Sort(array);
	double realIndex = q * (array.Length - 1);
	int index = (int)realIndex;
	double frac = realIndex - index;
	if (index + 1 < array.Length)
		return array[index] * (1 - frac) + array[index + 1] * frac;
	else
		return array[index];
}

void Main()
{
	var s = new double[] { 2.0, 1.0, 3.0};
	Console.WriteLine(Quantile(s, 0.0));  // 1.0
	Console.WriteLine(Quantile(s, 0.1));  // 1.2
	Console.WriteLine(Quantile(s, 0.2));  // 1.4
	Console.WriteLine(Quantile(s, 0.3));  // 1.6
	Console.WriteLine(Quantile(s, 0.4));  // 1.8
	Console.WriteLine(Quantile(s, 0.5));  // 2.0
	Console.WriteLine(Quantile(s, 0.6));  // 2.2
	Console.WriteLine(Quantile(s, 0.7));  // 2.4
	Console.WriteLine(Quantile(s, 0.8));  // 2.6
	Console.WriteLine(Quantile(s, 0.9));  // 2.8
	Console.WriteLine(Quantile(s, 1.0));  // 3.0
}

// You can define other methods, fields, classes and namespaces here