namespace VIKTORINASS.Domain
{
    public class Answer
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public Answer(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
