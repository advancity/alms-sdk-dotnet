using AlmsSdk.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;

namespace AlmsSdk.Services
{
    class UserService : IUserService
    {
        #region Constants

        private AuthConfig config = null;
        public DateTime RequestDate;
        HttpClient client = null;
        public Error LastError { get; private set; }

        #endregion

        #region Ctor

        public UserService(AuthConfig authConfig, string baseApiURI)
        {
            config = authConfig;
            client = new HttpClient() { BaseAddress = new Uri(baseApiURI) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        #region Methods

        public User Get(string Username)
        {
            User user = null;
            setClientHeaders();

            HttpResponseMessage response = client.GetAsync(string.Format("/api/user?username={0}", Username)).Result;
            if (!response.IsSuccessStatusCode)
                setError(response);
            else
                user = response.Content.ReadAsAsync<User>().Result;
            return user;
        }

        public IEnumerable<User> Search(string Keyword)
        {
            IEnumerable<User> users = null;
            setClientHeaders();

            HttpResponseMessage response = client.GetAsync(string.Format("/api/user/search?keyword={0}", Keyword)).Result;

            if (!response.IsSuccessStatusCode)
                setError(response);
            else
                users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            return users;
        }

        public bool Save(User User)
        {
            bool status = false;

            setClientHeaders();
            HttpResponseMessage response = client.PostAsJsonAsync("/api/user", User).Result;

            if (!response.IsSuccessStatusCode)
                setError(response);
            else
                status = true;
            return status;
        }

        public bool Delete(string Username)
        {
            bool status = false;
            setClientHeaders();
            HttpResponseMessage response = client.DeleteAsync(string.Format("/api/user?username={0}", Username)).Result;

            if (!response.IsSuccessStatusCode)
                setError(response);
            else
                status = true;
            return status;
        }

        public bool Update(User User)
        {
            bool status = false;
            setClientHeaders();
            HttpResponseMessage response = client.PutAsJsonAsync("/api/user", User).Result;

            if (!response.IsSuccessStatusCode)
                setError(response);
            else
                status = true;
            return status;
        }

        #endregion

        #region private methods

        private void setClientHeaders()
        {
            RequestDate = DateTime.UtcNow;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("alms-token", string.Format("apiAccessKey={0}, nonce={1}", config.ApiAccessKey, Utilities.GenerateNonce(config, RequestDate)));
            client.DefaultRequestHeaders.Date = RequestDate;
        }

        private void setError(HttpResponseMessage response)
        {
            LastError = new Error();
            LastError.ErrorCode = response.StatusCode.GetHashCode();
            var errorMessage = response.Content.ReadAsAsync<ServiceErrorMessage>().Result;
            LastError.ErrorMessage = errorMessage != null ? errorMessage.Message : "";
        }

        #endregion
    }
}
