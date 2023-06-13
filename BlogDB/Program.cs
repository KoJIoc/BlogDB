using LibraryBlog.Blog;
using LibraryBlog.User;
namespace BlogDB
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Functions functions = new Functions();
			
			UserProfile user = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role"};
			UserAuthorization userAuthorization = new UserAuthorization { Id = 1, Login = "login", Password = "password" };
			Article article = new Article { Id = 1, Title = "title", Text = "text", Id_User = user.Id };
			Tag tag = new Tag { Id = 1, Title = "tag" };
			Comment comment = new Comment { Id = 1, Id_Article = article.Id, Id_Commentator = user.Id, TextOfComment = "text" };
			UserProfile user2 = new UserProfile { Id = 1, Firstname = "firstname2", Lastname = "lastname2", Email = "email2", Role = "role2" };
			UserAuthorization userAuthorization2 = new UserAuthorization { Id = 1, Login = "login2", Password = "password2" };
			//functions.CreateUser(user, userAuthorization);
			//functions.CreateArticle(article, user);
			//functions.CreateTag(tag);
			//functions.AddTag(article, tag);
			//functions.CreateComment(article, comment, user);
			//functions.DeleteComment(comment.Id);
			//functions.DeleteArticleTag(article.Id);
			//functions.DeleteTag(tag.Id);
			//functions.DeleteArticle(article.Id);
			//functions.DeleteUser(user.Id);
			//functions.EditUser(user2, userAuthorization2);

		}
	}
}