namespace OverLoad
{
  internal class InvalidMenuChoiceException : Exception
  {
    public string MenuChoice { get; set; }

    public InvalidMenuChoiceException() : base("Некорректный выбор в меню") { }

    public InvalidMenuChoiceException(string message) : base(message) { }

    public InvalidMenuChoiceException(string message, string choice) : base(message)
    {
      MenuChoice = choice;
    }

    public InvalidMenuChoiceException(string message, Exception innerException) : base(message, innerException) { }
  }
}