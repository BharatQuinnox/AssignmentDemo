namespace EBookShop.Infrastructure.DataModel
{
    public class BookDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string ISBN { get; set; }

        public const string InsertQuery = "INSERT INTO Books (Title, Author, Price, ISBN) VALUES (@Title, @Author, @Price, @ISBN);SELECT SCOPE_IDENTITY() AS LastInsertedID;";

        public const string updateQuery = "UPDATE Books SET Title = @Title, Author = @Author, Price = @Price, ISBN = @ISBN WHERE Id = @Id;";

        public const string DeleteQuery = "DELETE FROM Books WHERE Id = @bookIdToDelete;";

        public const string SelectQuery = "SELECT * FROM Books";

        public const string SelectById = "SELECT * FROM Books WHERE Id = @Id";


    }


}
