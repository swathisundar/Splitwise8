using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise_New.Service_Classes
{
    #region Request Token Class
    class RequestToken
    {
        string requestToken;
        string oauth_token;

        public string OauthToken
        {
            get { return oauth_token; }
            set { oauth_token = value; }
        }
        string oauth_token_secret;

        public string OauthTokenSecret
        {
            get { return oauth_token_secret; }
            set { oauth_token_secret = value; }
        }

        public RequestToken(string requestToken)
        {
            this.requestToken = requestToken;
            SplitRequestToken(this.requestToken);
        }
        /// <summary>
        /// Splits the request token into oauth_token and oauth_token_secret
        /// </summary>
        /// <param name="request"></param>
        private void SplitRequestToken(string request)
        {
            if (request != null)
            {
                String[] keyValPairs = request.Split('&');

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            OauthToken = splits[1];
                            break;
                        case "oauth_token_secret":
                            OauthTokenSecret = splits[1];
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region Auth Token Class
    class AuthToken
    {
        string authToken;
        
        string oauth_token;
        public string OauthToken
        {
            get { return oauth_token; }
            set { oauth_token = value; }
        }
        string oauth_verifier;

        public string OauthVerifier
        {
            get { return oauth_verifier; }
            set { oauth_verifier = value; }
        }

        public AuthToken(string authToken)
        {
            this.authToken = authToken;
            SplitAuthToken(this.authToken);
        }
        /// <summary>
        /// Splits the authentication token into oauth_token and oauth_verifier
        /// </summary>
        /// <param name="auth"></param>
        private void SplitAuthToken(string auth)
        {
            if (auth != null)
            {
                String[] keyValPairs = auth.Split('&');

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            OauthToken = splits[1];
                            break;
                        case "oauth_verifier":
                            OauthVerifier = splits[1];
                            break;
                    }
                }
            }
        }
    }
    #endregion
}
