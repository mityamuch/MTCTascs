
/// <summary>
/// Возвращает отсортированный по возрастанию поток чисел
/// </summary>
/// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
/// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
/// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
/// <returns>Отсортированный по возрастанию поток чисел.</returns>
/// 
static class Program
{
    static void Main(string[] args)
    {
        List<int> stream = new List<int>() { 0,5,5,5,6,7,4,3,3,8,2,1,1};
        var result = Sort(stream, 7, 8);
        foreach(var number in result)
        {
            Console.WriteLine(number);
        }
    }

    public static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var AllValues = new int[maxValue + 1];
        int min = 0;
        foreach (int number in inputStream)
        {
            ++AllValues[number];
            int max = number - sortFactor;
            while (min < max)
            {
                while (AllValues[min]-- > 0)
                    yield return min;
                ++min;
            }
        }
        while (min < AllValues.Length)
        {
            while (AllValues[min]-- > 0)
                yield return min;
            ++min;
        }
    }
}

//Известно, что потребители метода зачастую не будут вычитывать данные до конца.
//Оптимально ли Ваше решение с точки зрения скорости выполнения?

// O(N) где n количество элементов inputStream, быстрее нельзя 

//С точки зрения потребляемой памяти?

//память - const и ~8 КБ максиум массив AllValues  
