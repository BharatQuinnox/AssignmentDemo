using AutoMapper;
using Dapper;
using EBookShop.Core.Entities;
using EBookShop.Core.Interfaces;
using EBookShop.Infrastructure.DataModel;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EShop.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {

        protected readonly IDbConnectionFactory _dbConnectionFactory;
        protected readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public BookRepository(IDbConnectionFactory dbConnectionFactory, IConfiguration configuration, IMapper mapper)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _configuration = configuration;
            _mapper = mapper;
        }
        //Get Books from datbase
        public async Task<List<BookEntity>> GetBooks()
        {
            List<BookEntity> cartItemList = new List<BookEntity>();

            using (IDbConnection dbConnection = _dbConnectionFactory.CreateConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                dbConnection.Open();

                var cartitem = await dbConnection.QueryAsync<BookDataModel>(BookDataModel.SelectQuery, null, commandType: CommandType.Text);

                cartItemList = _mapper.Map<List<BookEntity>>(cartitem);

                return cartItemList;
            }

        }

        //Get Book by Id
        public async Task<BookEntity> GetBookById(int BookId)
        {
            BookEntity cartItemList = new BookEntity();

            using (IDbConnection dbConnection = _dbConnectionFactory.CreateConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                dbConnection.Open();
 
                var result = dbConnection.QueryFirstOrDefault<BookDataModel>(BookDataModel.SelectById, new { Id = BookId });
                
                cartItemList = _mapper.Map<BookEntity>(result);

                return cartItemList;
            }

        }

        //Insert Book
        public async Task<int> InsertBook(BookEntity bookEntity)
        {
            BookDataModel bookDataModel = new BookDataModel();
            bookDataModel = _mapper.Map<BookDataModel>(bookEntity);
            using (IDbConnection dbConnection = _dbConnectionFactory.CreateConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                dbConnection.Open();

              var result =  dbConnection.ExecuteScalar<int>(BookDataModel.InsertQuery, bookDataModel);
                return result;
            }
            return bookDataModel.Id;

        }

        //Update Book
        public async Task<bool> UpdateBook(BookEntity bookEntity)
        {

            BookDataModel bookDataModel = new BookDataModel();
            bookDataModel = _mapper.Map<BookDataModel>(bookEntity);
            using (IDbConnection dbConnection = _dbConnectionFactory.CreateConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                dbConnection.Open();
                dbConnection.Execute(BookDataModel.updateQuery, bookDataModel);
            }
            return true;
        }

        //Delete Book
        public async Task<bool> Delete(int BookId)
        {
 
            using (IDbConnection dbConnection = _dbConnectionFactory.CreateConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@bookIdToDelete", BookId);

                dbConnection.Open();

                var cartitem = dbConnection.Execute(BookDataModel.DeleteQuery, dynamicParameters, commandType: CommandType.Text);

                return true;
            }

        }
    }
}
