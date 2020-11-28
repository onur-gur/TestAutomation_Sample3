
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomationTrendyolApiTest.Entities;

namespace TestAutomationTrendyolApiTest.TestSteps.API
{
    [TestFixture]
    [Binding, Scope(Feature = "ApiTestCase")]
    class ApiTestSteps
    {
        RestClient client;
        RestRequest request;

        public ApiTestSteps()
        {
            client = new RestClient("apiAddress");
        }

        [StepDefinition("Apinin boş olduğu doğrulanır")]
        public void VeriyfApiIsempty()
        {
            request = new RestRequest("/api/books/", Method.GET);
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            Books responseBody = JsonConvert.DeserializeObject<Books>(response.Content);
            Assert.AreEqual(0, responseBody.BookList.Count, "Api doludur");
        }

        [StepDefinition("Title parametresi girilmeden kitap eklenmeye çalışılır")]
        public void VerifyTitleIsRequired()
        {
            request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("author", "Dostoyevski");
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            ErrorLog errorResponse = JsonConvert.DeserializeObject<ErrorLog>(response.Content);
            Assert.AreEqual("Field 'author' is required", errorResponse.Error, "Yanlış hata mesajı");
        }

        [StepDefinition("Author parametresi girilmeden kitap eklenmeye çalışılır")]
        public void VerifyAuthorIsRequired()
        {
            request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("title", "Suç ve Ceza");
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            ErrorLog errorResponse = JsonConvert.DeserializeObject<ErrorLog>(response.Content);
            Assert.AreEqual("Field 'title' is required", errorResponse.Error, "Yanlış hata mesajı");
        }

        [StepDefinition("Title parametresi boş girilerek kitap eklenmeye çalışılır")]
        public void VerifyTitleCanNotBeEmpty()
        {
            request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("title", "");
            request.AddParameter("author", "Dostoveyski");
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            ErrorLog errorResponse = JsonConvert.DeserializeObject<ErrorLog>(response.Content);
            Assert.AreEqual("Field 'title' can not be empty", errorResponse.Error, "Yanlış hata mesajı");
        }

        [StepDefinition("Author parametresi  boş girilerek kitap eklenmeye çalışılır")]
        public void VerifyAuthorCanNotBeEmpty()
        {
            request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("author", "");
            request.AddParameter("title", "Suç ve Ceza");
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            ErrorLog errorResponse = JsonConvert.DeserializeObject<ErrorLog>(response.Content);
            Assert.AreEqual("Field 'author' can not be empty", errorResponse.Error, "Yanlış hata mesajı");
        }

        [StepDefinition("Id girilerek kitap eklenmeye çalışılır")]
        public void VerifyIdIsReadonlyParameter()
        {
            request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("author", "Dostoyevski");
            request.AddParameter("title", "Suç ve Ceza");
            request.AddParameter("id", "1");
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            ErrorLog errorResponse = JsonConvert.DeserializeObject<ErrorLog>(response.Content);
            Assert.AreEqual("Field 'author' can not be empty", errorResponse.Error, "Yanlış hata mesajı");
        }

        [StepDefinition("Kitap adı '(.*)', yazarı '(.*)' olan kitap eklenir")]
        public void VerifyAddBook(string bookName, string authorName)
        {
            request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("author", authorName);
            request.AddParameter("title", bookName);
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! " + response.ErrorMessage);
            Book book = JsonConvert.DeserializeObject<Book>(response.Content);
        }

        [StepDefinition("Eklenen Suç ve Ceza kitabı idsi ile çağrılarak eklendiği görülür")]
        public void VerifyAddedBookIsExist()
        {
            Book book = new Book();
            var request = new RestRequest("/api/books/" + book.Id, Method.GET);
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! ");
            Book existBook = JsonConvert.DeserializeObject<Book>(response.Content);
            Assert.AreEqual(book.AuthorName, existBook.AuthorName, "Yazar adı farklı-");
            Assert.AreEqual(book.Title, existBook.Title, "Kitap adı farklı");
            Assert.AreEqual(book.Id, existBook.Id, "Kitap id'si farklı");
        }

        [StepDefinition("Kitap adı '(.*)', yazarı '(.*)' olan kitap tekrar eklenmediği kontrol edilir")]
        public void VerifyExistBookCanNotAdded(string title, string authorName)
        {
            Book book = new Book();
            var request = new RestRequest("/api/books/", Method.PUT);
            request.AddParameter("author", authorName);
            request.AddParameter("title", title);
            var response = client.Execute(request);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server Error hatası alınmıştır");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response hata almıştır! ");
            ErrorLog error = JsonConvert.DeserializeObject<ErrorLog>(response.Content);
            Assert.AreEqual("The book is already exists", error.Error, "Yanlış hata mesajı");
        }
    }
}
