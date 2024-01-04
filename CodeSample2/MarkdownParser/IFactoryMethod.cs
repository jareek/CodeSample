namespace FactFinderQuestions.Question2
{
    public interface IFactoryMethod<T> where T : IFactoryMethod<T>
    {
        static abstract T Create();
    }
}
