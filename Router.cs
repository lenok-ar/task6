namespace OverLoad
{
    internal abstract class CalculationHandler
    {
        private CalculationHandler? _nextHandler;

        public CalculationHandler SetNext(CalculationHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void Handle(string route, SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            _nextHandler?.Handle(route, firstMatrix, secondMatrix);
        }
    }

    internal class AdditionHandler : CalculationHandler
    {
        public override void Handle(string route, SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (route == "1")
            {
                Console.WriteLine($"\nРезультат сложения:\n\n{firstMatrix + secondMatrix}\n");
            }

            else
            {
                base.Handle(route, firstMatrix, secondMatrix);
            }
        }
    }

    internal class MultiplicationHandler : CalculationHandler
    {
        public override void Handle(string route, SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (route == "2")
            {
                Console.WriteLine($"\nРезультат умножения:\n\n{firstMatrix * secondMatrix}\n");
            }

            else
            {
                base.Handle(route, firstMatrix, secondMatrix);
            }
        }
    }

    internal class ComparisonHandler : CalculationHandler
    {
        public override void Handle(string route, SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            switch (route)
            {

                case "3":
                    Console.WriteLine($"\nПервая матрица больше второй: {firstMatrix > secondMatrix}\n");
                    break;

                case "4":
                    Console.WriteLine($"\nПервая матрица меньше второй: {firstMatrix < secondMatrix}\n");
                    break;

                case "5":
                    Console.WriteLine($"\nПервая матрица больше либо равна второй: {firstMatrix >= secondMatrix}\n");
                    break;

                case "6":
                    Console.WriteLine($"\nПервая матрица меньше либо равна второй: {firstMatrix <= secondMatrix}\n");
                    break;

                case "7":
                    Console.WriteLine($"\nМатрицы равны: {firstMatrix == secondMatrix}\n");
                    break;

                case "8":
                    Console.WriteLine($"\nМатрицы не равны: {firstMatrix != secondMatrix}\n");
                    break;

                default:
                    base.Handle(route, firstMatrix, secondMatrix);
                    break;
            }
        }
    }

    internal class UnaryOperationHandler : CalculationHandler
    {
        public override void Handle(string route, SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            switch (route)
            {
                case "9":
                    string result = firstMatrix ? "Да" : "Нет";
                    Console.WriteLine($"Все элементы положительные: {result}");
                    break;

                case "10":
                    Console.WriteLine($"Детерминант матрицы: {firstMatrix.Determinant()}\n");
                    break;

                case "11":
                    Console.WriteLine($"\nОбратная матрица:\n\n{firstMatrix.InverseMatrix()}\n");
                    break;

                case "12":
                    SquareMatrix clonedMatrix = firstMatrix.Clone();
                    Console.WriteLine($"\nСкопированная матрица:\n\n{clonedMatrix}");
                    break;

                case "13":
                    SquareMatrix transpositionMatrix = firstMatrix.Transposition();
                    Console.WriteLine($"\nТранспонированная матрица:\n\n{transpositionMatrix}");
                    break;

                case "14":
                    Console.WriteLine($"\nСлед матрицы: {firstMatrix.TraceMatrix()}");
                    break;

                case "15":
                    SquareMatrix diagonalizedMatrix = firstMatrix.DiagonalizeWithDelegate();
                    Console.WriteLine($"\nМатрица диагонального вида:\n\n{diagonalizedMatrix}");
                    break;

                default:
                    base.Handle(route, firstMatrix, secondMatrix);
                    break;
            }
        }
    }

    internal class DefaultHandler : CalculationHandler
    {
        public override void Handle(string route, SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            throw new InvalidMenuChoiceException("Недопустимый выбор", route);
        }
    }


    internal class Router
    {
        public delegate SquareMatrix MatrixOperation(SquareMatrix matrix1, SquareMatrix matrix2);
        public delegate bool MatrixComparison(SquareMatrix matrix1, SquareMatrix matrix2);
        public delegate SquareMatrix UnaryMatrixOperation(SquareMatrix matrix);
        public delegate string UnaryMatrixPredicate(SquareMatrix matrix);

        private CalculationHandler _calculationChain;

        public Router()
        {
            _calculationChain = new AdditionHandler();

            _calculationChain.SetNext(new MultiplicationHandler())
                             .SetNext(new ComparisonHandler())
                             .SetNext(new UnaryOperationHandler())
                             .SetNext(new DefaultHandler());
        }

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

            ViewMatrix(firstMatrix, secondMatrix);
            Console.WriteLine();

            _calculationChain.Handle(route, firstMatrix, secondMatrix);
        }
    }
}
