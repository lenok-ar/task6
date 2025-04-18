namespace OverLoad
{
    internal class Router
    {
        public void ViewMatrix(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            Console.WriteLine($"\nПервая матрица:\n\n{firstMatrix}\n");
            Console.WriteLine($"\nВторая матрица:\n\n{secondMatrix}\n");

        }

        public void Routes(string route)
        {
            SquareMatrix firstMatrix = new SquareMatrix();
            SquareMatrix secondMatrix = new SquareMatrix();

            firstMatrix.EnteringNumber();
            secondMatrix.EnteringNumber();

            switch (route)
            {
                case "1":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nРезультат сложения:\n\n{firstMatrix + secondMatrix}\n");
                    break;

                case "2":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nРезультат сложения:\n\n{firstMatrix * secondMatrix}\n");
                    break;

                case "3":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nПервая матрица больше второй: {firstMatrix > secondMatrix}\n");
                    break;

                case "4":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nПервая матрица меньше второй: {firstMatrix < secondMatrix}\n");
                    break;

                case "5":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nПервая матрица больша либо равна второй: {firstMatrix >= secondMatrix}\n");
                    break;

                case "6":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nПервая матрица меньше либо равна второй: {firstMatrix <= secondMatrix}\n");
                    break;

                case "7":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nМатрицы равны: {firstMatrix == secondMatrix}\n");
                    break;

                case "8":
                    ViewMatrix(firstMatrix, secondMatrix);
                    Console.WriteLine($"\nМатрицы не равны: {firstMatrix != secondMatrix}\n");
                    break;

                case "9":
                    Console.WriteLine($"\nВходная матрица:\n\n{firstMatrix}");
                    string result = firstMatrix ? "Да" : "Нет";
                    Console.WriteLine($"Все элементы положительные: {result}");
                    break;

                case "10":
                    Console.WriteLine($"\nВходная матрица:\n\n{firstMatrix}");
                    Console.WriteLine($"Детерминант матрицы: {firstMatrix.Determinant()}\n");
                    break;

                case "11":
                    Console.WriteLine($"\nВходная матрица:\n\n{firstMatrix}");
                    Console.WriteLine($"\nОбратная матрица:\n\n{firstMatrix.InverseMatrix()}\n");
                    break;

                case "12":
                    Console.WriteLine($"\nВходная матрица:\n\n{firstMatrix}");
                    SquareMatrix clonedMatrix = firstMatrix.Clone();
                    Console.WriteLine($"\nСкопированная матрица:\n\n{clonedMatrix}");
                    break;

                case "13":
                    Console.WriteLine($"\nВходная матрица:\n\n{firstMatrix}");
                    SquareMatrix transpositionMatrix = firstMatrix.Transposition();
                    Console.WriteLine($"\nТранспонированная матрица:\n\n{transpositionMatrix}");
                    break;

                case "14":
                    Console.WriteLine($"\nВходная матрица:\n\n{firstMatrix}");
                    Console.WriteLine($"\nСлед матрицы: {firstMatrix.TraceMatrix()}");
                    break;

                default:
                    throw new InvalidMenuChoiceException("Недопустимый выбор", route);
            }
        }
    }
}
