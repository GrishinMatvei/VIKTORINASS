namespace VIKTORINASS.Domain
{
    public class Question
    {
        public string PhotoUrl { get; private set; }
        public string Title { get; private set; }
        public int RightAnswerId { get; private set; }

        public Question(string photoUrl, string title, int rightAnswerId)
        {
            PhotoUrl = photoUrl;
            Title = title;
            RightAnswerId = rightAnswerId;
        }
    }
}
