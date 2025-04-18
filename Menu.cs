namespace OverLoad
{
    internal class Menu
    {
        public void ViewMenu()
        {
            Router router = new Router();

            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "\nМеню:\n" +
                    "\n1. Сложить матрицы\n" +
                    "2. Перемножить матрицы\n" +
                    "3. Матрица больше?\n" +
                    "4. Матрица меньше?\n" +
                    "5. Матрица больше либо равна?\n" +
                    "6. Матрица меньше либо равна?\n" +
                    "7. Матрицы равны?\n" +
                    "8. Матрицы не равны?\n" +
                    "9. Элементы матрицы положительные?\n" +
                    "10. Найти детерминант матрицы\n" +
                    "11. Найти обратную матрицу\n" +
                    "12. Копировать матрицу\n" 
                );

                Console.Write("Что вы хотите сделать: ");
                string choice = Convert.ToString(Console.ReadLine());

                try
                {
                    router.Routes(choice);
                }

                catch (InvalidMenuChoiceException exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nОшибка: {exception}\n");

                    if (exception.MenuChoice != null)
                    {
                        Console.WriteLine($"Некорректный ввод: {exception.MenuChoice}");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                finally
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("\nНажмите кнопку для продолжения...");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}
