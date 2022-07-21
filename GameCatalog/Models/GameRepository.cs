using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCatalog
{
    public class GameRepository
    {
        public List<Game> gameRepository { get; set; }

        public GameRepository()
        {
            gameRepository = GetGameInLibrary();
        }

        // Връща всички записи в таблицата

        public List<Game> GetGameInLibrary()
        {
            List<Game> listOfGames = new List<Game>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }

                SqlCommand query = new SqlCommand("SELECT * from Game", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Game game = new Game();
                    game.Id = (int)row["id"];
                    game.Title = row["Title"].ToString();
                    game.Developer = row["Developer"].ToString();
                    game.Genre = row["Genre"].ToString();
                    game.YearOfRelease = (int)row["YearOfRelease"];
                    game.Rating = (int)row["Rating"];
                    game.Price = (int)row["Price"];
                    listOfGames.Add(game);
                }
                return listOfGames;
            }
        }

        // Връща записите които съвпадат със Search Query стринга
        public List<Game> GetGameRepositorySearch(string searchQuery)
        {
            List<Game> listOfGames = new List<Game>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null.");
                }
                SqlCommand query = new SqlCommand("retRecords", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar);
                param.Value = searchQuery;
                query.Parameters.Add(param);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Game game = new Game();
                    game.Id = (int)row["id"];
                    game.Title = row["Title"].ToString();
                    game.Developer = row["Developer"].ToString();
                    game.Genre = row["Genre"].ToString();
                    game.YearOfRelease = (int)row["YearOfRelease"];
                    game.Rating = (int)row["Rating"];
                    game.Price = (int)row["Price"];
                    listOfGames.Add(game);
                }
                return listOfGames;
            }
        }
        public void addNewRecord(Game gameRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                else if (gameRecord == null)
                    throw new Exception("The passed argument 'gameRecord' is null");

                SqlCommand query = new SqlCommand("addRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pTitle", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pDeveloper", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pGenre", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pYearOfRelease", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pRating", SqlDbType.Int);
                SqlParameter param6 = new SqlParameter("pPrice", SqlDbType.Int);

                param1.Value = gameRecord.Title;
                param2.Value = gameRecord.Developer;
                param3.Value = gameRecord.Genre;
                param4.Value = gameRecord.YearOfRelease;
                param5.Value = gameRecord.Rating;
                param6.Value = gameRecord.Price;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);

                query.ExecuteNonQuery();
            }
        }
        public void DeleteRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null.");
                }

                SqlCommand query = new SqlCommand("deleteRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);
                query.ExecuteNonQuery();
            }
        }

        public void UpdateRecord(Game gameRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }

                SqlCommand query = new SqlCommand("updateRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTitle", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pDeveloper", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pGenre", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pYearOfRelease", SqlDbType.Int);
                SqlParameter param6 = new SqlParameter("pRating", SqlDbType.Int);
                SqlParameter param7 = new SqlParameter("pPrice", SqlDbType.Int);

                param1.Value = gameRecord.Id;
                param2.Value = gameRecord.Title;
                param3.Value = gameRecord.Developer;
                param4.Value = gameRecord.Genre;
                param5.Value = gameRecord.YearOfRelease;
                param6.Value = gameRecord.Rating;
                param7.Value = gameRecord.Price;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);
                query.Parameters.Add(param7);
                query.ExecuteNonQuery();
            }
        }
    }
}