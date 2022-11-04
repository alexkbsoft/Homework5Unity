using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    /// <summary>
	/// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
	/// </summary>
	public void OnSumEvenNumbersInRange()
	{
    	int min = 7;
    	int max = 21;
    	var want = 98;
    	int got = SumEvenNumbersInRange(min, max);
    	string message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
    	Debug.Log($"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}");
	}

	/// <summary>
	/// Метод вычисляет сумму четных чисел в заданном диапазоне
	/// </summary>
	/// <param name="min">Минимальное значение диапазона</param>
	/// <param name="max">Максимальное значение диапазона</param>
	/// <returns>Сумма чисел четных чисел</returns>
	private int SumEvenNumbersInRange(int min, int max)
	{
        int accumulator = 0;
        for (int i = min; i <= max; i++)
        {
            accumulator += i % 2 == 0 ? i : 0;
        }

    	return accumulator;
	}

	/// <summary>
	/// Метод обработки события OnClick кнопки "Сумма четных чисел в заданном массиве"
	/// </summary>
	public void OnSumEvenNumbersInArray()
	{
    	int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
    	int want = 214;
    	int got = SumEvenNumbersInArray(array);
    	string message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
    	Debug.Log($"Сумма четных чисел в заданном массиве: {got} - {message}");
	}

	/// <summary>
	/// Метод вычисляет сумму четных чисел в массиве
	/// </summary>
	/// <param name="array">Исходный массив чисел</param>
	/// <returns>Сумма чисел четных чисел</returns>
	private int SumEvenNumbersInArray(int[] array)
	{
        int accumulator = 0;

        foreach(int i in array)
        {
            accumulator += i % 2 == 0 ? i : 0;
        }

    	return accumulator;
	}

	/// <summary>
	/// Метод обработки события OnClick кнопки "Поиск первого вхождения числа в массив"
	/// </summary>
	public void OnFirstOccurrence()
	{
    	// Первый тест, число присутствует в массиве
    	int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
    	int value = 34;
    	int want = 3;
    	int got = FirstOccurrence(array, value);
    	string message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
    	Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");

    	// Второй тест, число не присутствует в массиве
    	array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
    	value = 55;
    	want = -1;
    	got = FirstOccurrence(array, value);
    	message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
    	Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");
	}

	/// <summary>
	/// Метод производит поиск первого вхождения числа в массив
	/// </summary>
	/// <param name="array">Исходный массив</param>
	/// <param name="value">Искомое число</param>
	/// <returns>Индекс искомого числа в массиве или -1 если число отсутствует</returns>
	private int FirstOccurrence(int[] array, int value)
	{
    	int foundIndex = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                foundIndex = i;
                break;
            }
        }

    	return foundIndex;
	}

	/// <summary>
	/// Метод обработки события OnClick кнопки "Сортировка выбором"
	/// </summary>
	public void OnSelectionSort()
	{
    	int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
    	Debug.LogFormat("Исходный массив {0}", "[" + string.Join(",", originalArray) + "]");

    	int[] sortedArray = SelectionSort((int[])originalArray.Clone());
    	Debug.LogFormat("Результат сортировки {0}", "[" + string.Join(",", sortedArray) + "]");

    	int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
    	Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный");
	}

	/// <summary>
	/// Метод сортируем массив методом выбора
	/// </summary>
	/// <param name="array">Исходный массив</param>
	/// <returns>Отсортированный массив</returns>
	private int[] SelectionSort(int[] array)
	{
        LogArray(array, "Неотсортированный");
        for (int i = 0; i < array.Length; i++)
        {
            int foundIndex = i;
            for (int j = i; j < array.Length; j++)
            {
                foundIndex = array[j] < array[foundIndex] ? j : foundIndex;
            }

            if (foundIndex != i)
            {
                (array[i], array[foundIndex]) = (array[foundIndex], array[i]);
            }
        }

        LogArray(array, "Итог");
    	
    	return array;
	}

    private void LogArray(int[] array, string comment) {
        string result = "";
        const string delimiter = ",";

        for(int i = 0; i < array.Length; i++)
        {
            result += array[i] + (i + 1 == array.Length ? "" : delimiter);
        }

        Debug.LogFormat($"{comment} : {result}");
    }
}
