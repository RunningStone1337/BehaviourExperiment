using System;

public static class ArrayExtensions
{
    public static void CopyTo<T>(this T[] source, ref T[] target)
    {
        if (target == null || target.Length != source.Length)
            target = new T[source.Length];
        source.CopyTo(target, 0);
    }
    public static void CopyTo<T>(this T[,] source, ref T[,] target)
    {
        var sourceCols = source.GetLength(0);
        var sourceRows = source.GetLength(1);
        if (target == null)
        {
            target = new T[sourceCols, sourceRows];
            Array.Copy(source, target, sourceRows * sourceCols);
            return;
        }
        var targetCols = target.GetLength(0);
        var targetRows = target.GetLength(1);
        if (targetRows != sourceRows || targetCols != sourceCols)
        {
            if (targetRows > sourceRows)//обрезать ряды
            {
                if (targetCols > sourceCols)//обрезать ряды и столбцы
                    target = target.TryReduceArrayWithCopy(sourceRows, sourceCols);
                else if (targetCols < sourceCols)//обрезать ряды, добавить столбцы
                {
                    target = target.TryReduceArrayWithCopy(sourceRows, targetCols);
                    target = target.TryExtendArrayWithCopy(sourceRows, sourceCols);
                }
                else//только обрезать ряды
                    target = target.TryReduceArrayWithCopy(sourceRows, targetCols);
            }
            else if (targetRows < sourceRows)//�������� ����
            {
                if (targetCols < sourceCols)//� �������
                    target = target.TryExtendArrayWithCopy(sourceRows, sourceCols);
                else if (targetCols > sourceCols)//������ �������
                {
                    target = target.TryExtendArrayWithCopy(sourceRows, targetCols);
                    target = target.TryReduceArrayWithCopy(sourceRows, sourceCols);
                }
                else//������ �������� ����
                    target = target.TryExtendArrayWithCopy(sourceRows, targetCols);
            }
            else//������ �������
            {
                if (targetCols < sourceCols)//�������� �������
                    target = target.TryExtendArrayWithCopy(targetRows, sourceCols);
                else if (targetCols > sourceCols)//������ �������
                    target = target.TryReduceArrayWithCopy(targetRows, sourceCols);
            }
        }
        source.CopyArray(ref target, sourceRows, sourceCols);
    }

    public static T[] GetRowFromMatrix<T>(this T[,] matrix, int rowIndex)
    {
        var cols = matrix.GetLength(0);
        var res = new T[cols];
        for (int i = 0; i < cols; i++)
        {
            res[i] = matrix[i, rowIndex];
        }
        return res;
    }
    public static void InsertRow<T>(this T[,] matrix, T[] rowToInsert, int rowIndex)
    {
        var cols = matrix.GetLength(0);
        if (rowToInsert.Length != cols)
            throw new Exception($"Row size and matrix row size must be equal.\nMatrix rows length {cols}, insert row length {rowToInsert.Length}");
        var l = rowToInsert.Length;
        for (int i = 0; i < l; i++)
        {
            matrix[i, rowIndex] = rowToInsert[i];
        }
    }
    public static T[] TryExtendArray<T>(this T[] target, int newLenght)
    {
        if (target == null)
            return new T[newLenght];
        if (target.Length > newLenght)
            return target;
        T[] newArray = new T[newLenght];
        for (int i = 0; i < target.Length; i++)
            newArray[i] = target[i];
        return newArray;
    }

public static void FillDefault<T>(this T[,] matrix)
where T: new()
{
    var cols = matrix.GetLength(0);
    var rows = matrix.GetLength(1);
    for (int col = 0; col < cols; col++)
        for (int row = 0; row < rows; row++)
            matrix[col,row] = new T();
}

public static void FillEmptys<T>(this T[,] matrix)
where T: new()
{
    var cols = matrix.GetLength(0);
    var rows = matrix.GetLength(1);
    for (int col = 0; col < cols; col++)
        for (int row = 0; row < rows; row++)
            if(matrix[col,row] == null) 
                matrix[col,row] = new T();
}


public static void FillEmptys<T>(this T[] matrix)
where T: new()
{
    var cols = matrix.Length;
    for (int col = 0; col < cols; col++)
        if(matrix[col] == null) 
            matrix[col] = new T();
}

    public static T[,] TryExtendArrayWithCopy<T>(this T[,] source, int newRowsCount, int newColsCount)
    {
        if (source == null)
            return new T[newColsCount, newRowsCount];

        T[,] result;
        var collsDiff = newColsCount - source.GetLength(0);
        var rowsDiff = newRowsCount - source.GetLength(1);
        if (rowsDiff > 0 || collsDiff > 0)
        {
            result = GetCorrectSizeArr(source, newRowsCount, newColsCount, rowsDiff, collsDiff);

            var cols = source.GetLength(0);
            var rows = source.GetLength(1);
            CopyArray(source,ref result, rows, cols);
            return result;
        }
        else
            return source;
    }

    private static void CopyArray<T>(this T[,] source, ref T[,] result, int rows, int cols)
    {
        for (int i = 0; i < cols; i++)
            for (int j = 0; j < rows; j++)
                result[i, j] = source[i, j];
    }

    public static T[] TryReduceArray<T>(this T[] arrToReduce, int newLenght)
    {
        if (arrToReduce == null)
            return new T[newLenght];
        if (arrToReduce.Length < newLenght)
            return arrToReduce;
        T[] newArray = new T[newLenght];
        Array.Copy(arrToReduce, newArray, newLenght);
        return newArray;
    }

    public static T[,] TryReduceArrayWithCopy<T>(this T[,] source, int newRowsCount, int newColsCount)
    {
        if (source == null)
            return new T[newColsCount, newRowsCount];

        T[,] result;
        var collsDiff = source.GetLength(0) - newColsCount;
        var rowsDiff = source.GetLength(1) - newRowsCount;
        if (rowsDiff > 0 || collsDiff > 0)//размеры не совпадают
        {
            result = GetCorrectSizeArr(source, newRowsCount, newColsCount, rowsDiff, collsDiff);

            var cols = result.GetLength(0);
            var rows = result.GetLength(1);
            CopyArray(source, ref result, rows, cols);
            return result;
        }
        else
            return source;
    }

    private static T[,] GetCorrectSizeArr<T>(T[,] source, int newRowsCount, int newColsCount, int rowsDiff, int collsDiff)
    {
        T[,] result;
        if (rowsDiff > 0 && collsDiff <= 0)//только ряды
            result = new T[ source.GetLength(0), newRowsCount];
        else if (rowsDiff <= 0 && collsDiff > 0)//только столбцы
            result = new T[newColsCount, source.GetLength(1)];
        else
            result = new T[newColsCount, newRowsCount];
        return result;
    }
}