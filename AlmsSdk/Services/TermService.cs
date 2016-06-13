using AlmsSdk.Domain;
using AlmsSdk.ServiceContracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Services
{
    using ServiceContracts;
    class TermService : BaseService, ITermService
    {
        #region Constants

        #endregion

        #region Ctor

        public TermService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion



        #region Methods

        public Term Get(Guid termGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/term/get?TermGuid={0}", termGuid), Method.GET);
            IRestResponse response = Client.Get<Term>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<Term>).Data;
            else { this.setError(response); return null; }
        }
        public IEnumerable<TermWeek> GetTermWeek(Guid termGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/term/termweek?termId={0}", termGuid), Method.GET);
            IRestResponse response = Client.Get<List<TermWeek>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<TermWeek>>).Data;
            else { this.setError(response); return null; }
        }
        public IEnumerable<Term> SerachTerm(string keyword)
        {
            IRestRequest request = new RestRequest(string.Format("/api/term/search?keywords={0}", Uri.EscapeUriString(keyword)), Method.GET);
            IRestResponse response = Client.Get<List<Term>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<Term>>).Data;
            else { this.setError(response); return null; }
        }

        #endregion
    }
}
