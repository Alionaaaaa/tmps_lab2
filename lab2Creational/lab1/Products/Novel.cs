namespace tmps.Products
{
    public class Novel : Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Id { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }

        public Novel ShallowCopy()
        {
            return (Novel)this.MemberwiseClone();
        }
    }
}