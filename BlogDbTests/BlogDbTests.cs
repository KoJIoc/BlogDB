using BlogDB;
using Org.BouncyCastle.Asn1.Tsp;
using System.Transactions;
using LibraryBlog.Blog;
using LibraryBlog.User;
namespace BlogDBTests
{
	[TestClass]
	public class BlogDbTests
	{
		[TestMethod]
		public void GetUserTesting()
		{
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			UserProfile user = functions.GetUser(1);
			Assert.AreEqual(expectedUser.Id, user.Id);
			Assert.AreEqual(expectedUser.Firstname, user.Firstname);
			Assert.AreEqual(expectedUser.Lastname, user.Lastname);
			Assert.AreEqual(expectedUser.Email, user.Email);
			Assert.AreEqual(expectedUser.Role, user.Role);
		}

		[TestMethod]
		public void CreateUserTesting()
		{

			Functions functions = new Functions();
			UserAuthorization expectedUserAuthorization = new UserAuthorization { Id = 1, Login = "login", Password = "password" };
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			functions.CreateUser(expectedUser, expectedUserAuthorization);
			UserProfile user = functions.GetUser(1);
			Assert.AreEqual(expectedUser.Id, user.Id);
			Assert.AreEqual(expectedUser.Firstname, user.Firstname);
			Assert.AreEqual(expectedUser.Lastname, user.Lastname);
			Assert.AreEqual(expectedUser.Email, user.Email);
			Assert.AreEqual(expectedUser.Role, user.Role);

		}
		[TestMethod]
		public void EditUserTesting()
		{
			Functions functions = new Functions();
			UserAuthorization expectedUserAuthorization = new UserAuthorization { Id = 1, Login = "login2", Password = "password2" };
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname2", Lastname = "lastname2", Email = "email2", Role = "role2" };
			functions.EditUser(expectedUser, expectedUserAuthorization);
			UserProfile user = functions.GetUser(1);
			Assert.AreEqual(expectedUser.Id, user.Id);
			Assert.AreEqual(expectedUser.Firstname, user.Firstname);
			Assert.AreEqual(expectedUser.Lastname, user.Lastname);
			Assert.AreEqual(expectedUser.Email, user.Email);
			Assert.AreEqual(expectedUser.Role, user.Role);

		}

		[TestMethod]
		public void DeleteUserTesting()
		{
			Functions functions = new Functions();
			bool undeleted = functions.DeleteUser(31);
			Assert.IsFalse(undeleted);
			bool deleted = functions.DeleteUser(1);
			Assert.IsTrue(deleted);
		}
		[TestMethod]
		public void GetArticleTesting()
		{
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname2", Lastname = "lastname2", Email = "email2", Role = "role2" };
			Article expectedArticle = new Article { Id = 1, Title = "title", Text = "text", Id_User = expectedUser.Id };
			Article article = functions.GetArticle(1);
			Assert.AreEqual(expectedArticle.Id, article.Id);
			Assert.AreEqual(expectedArticle.Id_User, article.Id_User);
			Assert.AreEqual(expectedArticle.Title, article.Title);
			Assert.AreEqual(expectedArticle.Text, article.Text);
		}
		[TestMethod]
		public void CreateArticleTesting()
		{
			
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			Article expectedArticle = new Article { Id = 1, Title = "title", Text = "text", Id_User = expectedUser.Id };
			functions.CreateArticle(expectedArticle, expectedUser);
			Article article = functions.GetArticle(1);
			Assert.AreEqual(expectedArticle.Id, article.Id);
			Assert.AreEqual(expectedArticle.Id_User, article.Id_User);
			Assert.AreEqual(expectedArticle.Title, article.Title);
			Assert.AreEqual(expectedArticle.Text, article.Text);
		}
		[TestMethod]
		public void EditArticleTesting()
		{
			Functions functions = new Functions();
			
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			Article expectedArticle = new Article { Id = 1, Title = "title2", Text = "text2", Id_User = expectedUser.Id };
			functions.EditArticle(expectedArticle);
			Article article = functions.GetArticle(1);
			Assert.AreEqual(expectedArticle.Id, article.Id);
			Assert.AreEqual(expectedArticle.Id_User, article.Id_User);
			Assert.AreEqual(expectedArticle.Title, article.Title);
			Assert.AreEqual(expectedArticle.Text, article.Text);
		}
		[TestMethod]
		public void DeleteArticleTesting()
		{
			Functions functions = new Functions();
			bool undeleted = functions.DeleteArticle(31);
			Assert.IsFalse(undeleted);
			bool deleted = functions.DeleteArticle(1);
			Assert.IsTrue(deleted);
		}
		[TestMethod]
		public void GetTagTesting()
		{
			Functions functions = new Functions();
			Tag expectedTag = new Tag { Id = 1, Title = "tag" };
			Tag tag = functions.GetTag(1);
			Assert.AreEqual(expectedTag.Id, tag.Id);
			Assert.AreEqual(expectedTag.Title, tag.Title);
		}
		[TestMethod]
		public void CreateTagTesting()
		{
			Functions functions = new Functions();
			Tag expectedTag = new Tag { Id = 1, Title = "tag" };
			functions.CreateTag(expectedTag);
			Tag tag = functions.GetTag(1);
			Assert.AreEqual(expectedTag.Id, tag.Id);
			Assert.AreEqual(expectedTag.Title, tag.Title);
		}
		[TestMethod]
		public void EditTagTesting()
		{
			Functions functions = new Functions();
			Tag expectedTag = new Tag { Id = 1, Title = "tag2" };
			functions.EditTag(expectedTag);
			Tag tag = functions.GetTag(1);
			Assert.AreEqual(expectedTag.Id, tag.Id);
			Assert.AreEqual(expectedTag.Title, tag.Title);
		}
		[TestMethod]
		public void DeleteTagTesting()
		{
			Functions functions = new Functions();
			bool undeleted = functions.DeleteTag(31);
			Assert.IsFalse(undeleted);
			bool deleted = functions.DeleteTag(1);
			Assert.IsTrue(deleted);
		}
		[TestMethod]
		public void AddTagTesting()
		{
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			Article expectedArticle = new Article { Id = 1, Title = "title", Text = "text", Id_User = expectedUser.Id };
			Tag expectedTag = new Tag { Id = 1, Title = "tag" };
			functions.AddTag(expectedArticle, expectedTag);
			ArticleTag articleTag = functions.GetArticleTag(1);
			Assert.AreEqual(articleTag.Id_Article, expectedArticle.Id);
			Assert.AreEqual(articleTag.Id_Tag, expectedTag.Id);
		}
		[TestMethod]
		public void DeleteArticleTag()
		{
			Functions functions = new Functions();
			bool undeleted = functions.DeleteArticleTag(31);
			Assert.IsFalse(undeleted);
			bool deleted = functions.DeleteArticleTag(1);
			Assert.IsTrue(deleted);
		}
		[TestMethod]
		public void GetCommentTesting()
		{
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			Article expectedArticle = new Article { Id = 1, Title = "title", Text = "text", Id_User = expectedUser.Id };
			Comment expectedComment = new Comment { Id = 1, Id_Article = expectedArticle.Id, Id_Commentator = expectedUser.Id, TextOfComment = "text" };
			Comment comment = functions.GetComment(1);
			Assert.AreEqual(expectedComment.Id, comment.Id);
			Assert.AreEqual(expectedComment.Id_Article, comment.Id_Article);
			Assert.AreEqual(expectedComment.Id_Commentator, comment.Id_Commentator);
			Assert.AreEqual(expectedComment.TextOfComment, comment.TextOfComment);
		}
		[TestMethod]
		public void CreateCommentTesting()
		{
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			Article expectedArticle = new Article { Id = 1, Title = "title", Text = "text", Id_User = expectedUser.Id };
			Comment expectedComment = new Comment { Id = 1, Id_Article = expectedArticle.Id, Id_Commentator = expectedUser.Id, TextOfComment = "text" };
			functions.CreateComment(expectedArticle, expectedComment, expectedUser);
			Comment comment = functions.GetComment(1);
			Assert.AreEqual(expectedComment.Id, comment.Id);
			Assert.AreEqual(expectedComment.Id_Article, comment.Id_Article);
			Assert.AreEqual(expectedComment.Id_Commentator, comment.Id_Commentator);
			Assert.AreEqual(expectedComment.TextOfComment, comment.TextOfComment);
		}
		[TestMethod]
		public void EditCommentTesting()
		{
			Functions functions = new Functions();
			UserProfile expectedUser = new UserProfile { Id = 1, Firstname = "firstname", Lastname = "lastname", Email = "email", Role = "role" };
			Article expectedArticle = new Article { Id = 1, Title = "title", Text = "text", Id_User = expectedUser.Id };
			Comment expectedComment = new Comment { Id = 1, Id_Article = expectedArticle.Id, Id_Commentator = expectedUser.Id, TextOfComment = "text2" };
			functions.EditComment(expectedComment);
			Comment comment = functions.GetComment(1);
			Assert.AreEqual(expectedComment.Id, comment.Id);
			Assert.AreEqual(expectedComment.Id_Article, comment.Id_Article);
			Assert.AreEqual(expectedComment.Id_Commentator, comment.Id_Commentator);
			Assert.AreEqual(expectedComment.TextOfComment, comment.TextOfComment);
		}
		[TestMethod]
		public void DeleteCommentTesting()
		{
			Functions functions = new Functions();
			bool undeleted = functions.DeleteComment(31);
			Assert.IsFalse(undeleted);
			bool deleted = functions.DeleteComment(1);
			Assert.IsTrue(deleted);
		}
	}


	[TestClass()]
	public class TaskTests
	{

	
		//[TestMethod()]
		//public void GetTaskDBTest()
		//{
		//	Functions functions = new Functions();
		//	TaskInfo task = new TaskInfo(1, "nameTask", "descr", 1, null, new DateTime(2023, 05, 26, 15, 57, 34), null, 1, 1);
		//	TaskInfo task1 = functions.GetTaskDB(1);
		//	Assert.IsTrue(task == task1);
		//}

		//[TestMethod()]
		//public void InsertTaskDBTest()
		//{
		//	using (TransactionScope ts = CreateTransactionScope())
		//	{
		//		Functions functions = new Functions();
		//		TaskInfo task = new TaskInfo("name", "descript", 1, new DateTime(2023, 05, 26, 15, 57, 34));
		//		UInt32 id = functions.InsertTaskDB(task);
		//		UInt32 id1 = functions.InsertTaskDB(task);
		//		TaskInfo task1 = functions.GetTaskDB(id);
		//		task.TaskId = id;
		//		Assert.AreNotEqual(id, id1);
		//		Assert.IsTrue(task == task1);
		//	}
		//}
		//[TestMethod()]
		//public void UpdateTaskDBTest()
		//{
		//	Functions functions = new Functions();
		//	using (TransactionScope ts = CreateTransactionScope())
		//	{
		//		TaskInfo task = new TaskInfo(1, "ser", "ddd", 1, null,
		//			new DateTime(2000, 01, 01, 01, 01, 01), null, 3, 1);
		//		functions.UpdateTaskDB(task);
		//		TaskInfo task1 = functions.GetTaskDB(1);
		//		Assert.IsTrue(task == task1);
		//	}
		//}

		//[TestMethod()]
		//public void DeleteUserDBTest()
		//{
		//	Functions functions = new Functions();
		//	using (TransactionScope ts = CreateTransactionScope())
		//	{
		//		bool undeleted = functions.DelTaskDB(111111111);
		//		Assert.IsFalse(undeleted);
		//		bool deleted = functions.DelTaskDB(1);
		//		Assert.IsTrue(deleted);
		//	}
		//}
	}
}