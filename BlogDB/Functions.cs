using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Org.BouncyCastle.Asn1.X509;
using System.Data;
using LibraryBlog.User;
using LibraryBlog.Blog;
namespace BlogDB
{
	public class Functions
	{
		public UserProfile GetUser(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			UserProfile user = new UserProfile();
			MySqlCommand command = new MySqlCommand("SELECT * FROM `user_profile` WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				user.Id = (UInt32)reader["id"];
				user.Firstname = (string)reader["firstname"];
				user.Lastname = (string)reader["lastname"];
				user.Email = (string)reader["email"];
				user.Role = (string)reader["role"];
				user.DateOfRegistration = (DateTime)reader["date_registration"];
			}
			db.CloseConnection();
			return user;
		}
		public void CreateUser(UserProfile user, UserAuthorization userAuthorization)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("INSERT INTO `user_profile` (`firstname`, `lastname`, `email`, `date_registration`, `role`) VALUES (@firstname, @lastname, @email, @date_registration, @role)", db.GetConnection());
			command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = user.Firstname;
			command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = user.Lastname;
			command.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.Email;
			command.Parameters.Add("@date_registration", MySqlDbType.DateTime).Value = DateTime.Now;
			command.Parameters.Add("@role", MySqlDbType.VarChar).Value = user.Role;
			command.ExecuteNonQuery();
			MySqlCommand command2 = new MySqlCommand("INSERT INTO `user_authorization` (`login`, `password`) VALUES (@login, @password)", db.GetConnection());
			command2.Parameters.Add("@login", MySqlDbType.VarChar).Value = userAuthorization.Login;
			command2.Parameters.Add("@password", MySqlDbType.VarChar).Value = userAuthorization.Password;
			command2.ExecuteNonQuery();
			db.CloseConnection();
		}
		public void EditUser(UserProfile user, UserAuthorization userAuthorization)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("UPDATE `user_profile` SET firstname = @firstname, lastname = @lastname, email = @email, role=@role WHERE id =@id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = user.Id;
			command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = user.Firstname;
			command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = user.Lastname;
			command.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.Email;
			command.Parameters.Add("@role", MySqlDbType.VarChar).Value = user.Role;
			command.ExecuteNonQuery();
			MySqlCommand command2 = new MySqlCommand("UPDATE `user_authorization` SET login = @login, password = @password WHERE id=@id", db.GetConnection());
			command2.Parameters.Add("@id", MySqlDbType.UInt32).Value = userAuthorization.Id;
			command2.Parameters.Add("@login", MySqlDbType.VarChar).Value = userAuthorization.Login;
			command2.Parameters.Add("@password", MySqlDbType.VarChar).Value = userAuthorization.Password;
			command2.ExecuteNonQuery();
			db.CloseConnection();
		}

		public bool DeleteUser(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("DELETE FROM user_profile WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			MySqlCommand command2 = new MySqlCommand("DELETE FROM user_authorization WHERE id = @id", db.GetConnection());
			command2.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			if(command.ExecuteNonQuery()==1 && command2.ExecuteNonQuery()==1)
			{
				db.CloseConnection();
				return true;
			}
			db.CloseConnection();
			return false;
		}
		public Article GetArticle(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			Article article = new Article();
			MySqlCommand command = new MySqlCommand("SELECT * FROM `article` WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				article.Id = (UInt32)reader["id"];
				article.Id_User = (UInt32)reader["id_user"];
				article.Title = (string)reader["title"];
				article.Text = (string)reader["text"];
				article.DateOfCreation = (DateTime)reader["date_creation"];
			}
			db.CloseConnection();
			return article;
		}
		public void CreateArticle(Article article, UserProfile user)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command1 = new MySqlCommand("SELECT id FROM `user_profile` WHERE id = @id_user", db.GetConnection());
			command1.Parameters.Add("@id_user", MySqlDbType.UInt32).Value = user.Id;
			UInt32 id_user = (UInt32)command1.ExecuteScalar();
			MySqlCommand command = new MySqlCommand("INSERT INTO `article` (id_user, title, text, date_creation) VALUES (@id_user, @title, @text, @date_creation)", db.GetConnection());
			command.Parameters.Add("@id_user", MySqlDbType.UInt32).Value = id_user;
			command.Parameters.Add("@title", MySqlDbType.VarChar).Value = article.Title;
			command.Parameters.Add("@text", MySqlDbType.Text).Value = article.Text;
			command.Parameters.Add("@date_creation", MySqlDbType.DateTime).Value = DateTime.Now;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public void EditArticle(Article article)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("UPDATE `article` SET title = @title, text=@text, date_creation = @date_creation WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = article.Id;
			command.Parameters.Add("@title", MySqlDbType.VarChar).Value = article.Title;
			command.Parameters.Add("@text", MySqlDbType.Text).Value = article.Text;
			command.Parameters.Add("@date_creation", MySqlDbType.DateTime).Value = DateTime.Now;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public bool DeleteArticle(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("DELETE FROM article WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			if (command.ExecuteNonQuery() == 1)
			{
				db.CloseConnection();
				return true;
			}
			db.CloseConnection();
			return false;
		}
		public Tag GetTag(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			Tag tag = new Tag();
			MySqlCommand command = new MySqlCommand("SELECT * FROM `tag` WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				tag.Id = (UInt32)reader["id"];
				tag.Title = (string)reader["title"];
			}
			db.CloseConnection();
			return tag;
		}
		public void CreateTag(Tag tag)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("INSERT INTO `tag` (title) VALUES (@title)", db.GetConnection());
			command.Parameters.Add("@title", MySqlDbType.VarChar).Value = tag.Title;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public void EditTag(Tag tag)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("UPDATE `tag` SET title = @title WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = tag.Id;
			command.Parameters.Add("@title", MySqlDbType.VarChar).Value = tag.Title;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public void AddTag(Article article, Tag tag)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command1 = new MySqlCommand("SELECT id FROM `article` WHERE id = @id_article", db.GetConnection());
			command1.Parameters.Add("@id_article", MySqlDbType.UInt32).Value = article.Id;
			UInt32 id_article = (UInt32)command1.ExecuteScalar();
			MySqlCommand command2 = new MySqlCommand("SELECT id FROM `tag` WHERE id = @id_tag", db.GetConnection());
			command1.Parameters.Add("@id_tag", MySqlDbType.UInt32).Value = tag.Id;
			UInt32 id_tag = (UInt32)command1.ExecuteScalar();
			MySqlCommand command = new MySqlCommand("INSERT INTO `article_tag` (id_article, id_tag) VALUES (@id_article, @id_tag)", db.GetConnection());
			command.Parameters.Add("@id_article", MySqlDbType.UInt32).Value = id_article;
			command.Parameters.Add("@id_tag", MySqlDbType.UInt32).Value = id_tag;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public bool DeleteTag(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("DELETE FROM tag WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			if (command.ExecuteNonQuery() == 1)
			{
				db.CloseConnection();
				return true;
			}
			db.CloseConnection();
			return false;
		}
		public ArticleTag GetArticleTag(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			ArticleTag articleTag = new ArticleTag();
			MySqlCommand command = new MySqlCommand("SELECT * FROM `article_tag` WHERE id_article = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				articleTag.Id_Article = (UInt32)reader["id_article"];
				articleTag.Id_Tag = (UInt32)reader["id_tag"];
			}
			db.CloseConnection();
			return articleTag;
		}
		public bool DeleteArticleTag(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("DELETE FROM article_tag WHERE id_article = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			if (command.ExecuteNonQuery() == 1)
			{
				db.CloseConnection();
				return true;
			}
			db.CloseConnection();
			return false;
		}
		public Comment GetComment(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			Comment comment = new Comment();
			MySqlCommand command = new MySqlCommand("SELECT * FROM `comment` WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			MySqlDataReader reader = command.ExecuteReader();
			if (reader.Read())
			{
				comment.Id = (UInt32)reader["id"];
				comment.Id_Article = (UInt32)reader["id_article"];
				comment.Id_Commentator = (UInt32)reader["id_commentator"];
				comment.TextOfComment = (string)reader["text"];
			}
			db.CloseConnection();
			return comment;
		}
		public void CreateComment(Article article, Comment comment, UserProfile commentator)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command1 = new MySqlCommand("SELECT id FROM `user_profile` WHERE id = @id_commentator", db.GetConnection());
			command1.Parameters.Add("id_commentator", MySqlDbType.UInt32).Value = commentator.Id;
			UInt32 id_commentator = (UInt32)command1.ExecuteScalar();
			MySqlCommand command2 = new MySqlCommand("SELECT id FROM `article` WHERE id= @id_article", db.GetConnection());
			command1.Parameters.Add("id_user", MySqlDbType.UInt32).Value = article.Id;
			UInt32 id_article = (UInt32)command1.ExecuteScalar();
			MySqlCommand command = new MySqlCommand("INSERT INTO `comment` (id_article, id_commentator, text) VALUES (@id_article, @id_commentator, @text)", db.GetConnection());
			command.Parameters.Add("@id_article", MySqlDbType.UInt32).Value = id_article;
			command.Parameters.Add("@id_commentator", MySqlDbType.UInt32).Value = id_commentator;
			command.Parameters.Add("@text", MySqlDbType.Text).Value = comment.TextOfComment;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public void EditComment(Comment comment)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("UPDATE `comment` SET text = @text WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = comment.Id;
			command.Parameters.Add("@text", MySqlDbType.VarChar).Value = comment.TextOfComment;
			command.ExecuteNonQuery();
			db.CloseConnection();
		}
		public bool DeleteComment(UInt32 id)
		{
			DB db = new DB();
			db.OpenConnection();
			MySqlCommand command = new MySqlCommand("DELETE FROM comment WHERE id = @id", db.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.UInt32).Value = id;
			if (command.ExecuteNonQuery() == 1)
			{
				db.CloseConnection();
				return true;
			}
			db.CloseConnection();
			return false;
		}

	}
}
