using System;

/// <summary>
/// <para> Отсчитать несколько элементов с конца </para>
/// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
/// </summary> 
/// <typeparam name="T"></typeparam>
/// <param name="enumerable"></param>
/// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
/// <returns></returns>
/// 
static class Program
{
    static void Main(string[] args)
    {
        var result=new[] { 1, 2, 3, 4 }.EnumerateFromTail(3);
        foreach(var i in result)
        {
            Console.WriteLine(i.ToString());
        }
    }
       
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        var count = enumerable.Count();
        if (tailLength == null || tailLength <= 0)
            tailLength=count;

        int i = 0;
        int? resultCount = tailLength > count ? count : count - tailLength;
        foreach (var item in enumerable)
        {
            yield return((item, i >= resultCount ? --tailLength : null));
            i++;
        }
    }

//Возможно ли реализовать такой метод выполняя перебор значений перечисления только 1 раз?
//Ответ: Реализованный метод перебирает перебор значений перечисления 1 раз
}