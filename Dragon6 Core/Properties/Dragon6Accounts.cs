using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core
{
    internal class Accounts
    {
        public static readonly string UbisoftAccount = "ZHJhZ29uNkBkcmFnb25mcnVpdC5tbDpEckBnb25GcnVpdA==";
        public static CollectionReference Dragon6DB;

    }
    public class GoogleServices
    {
        private static readonly string FirestoreCollection = "dragon6";
        private static readonly string FirestoreName = "dragon6-224813";
        private static GoogleCredential creds;

        public static void SetupGoogleServices(IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                creds = GoogleCredential.FromFile(Path.Combine(environment.ContentRootPath, "google.json"));
                ChannelCredentials channelCredentials = creds.ToChannelCredentials();
                Channel channel = new Channel(FirestoreClient.DefaultEndpoint.ToString(), channelCredentials);

                Accounts.Dragon6DB = FirestoreDb.Create(FirestoreName, FirestoreClient.Create(channel)).Collection(FirestoreCollection);
            }
            else
                Accounts.Dragon6DB = FirestoreDb.Create(FirestoreName).Collection(FirestoreCollection);

        }
    }
}
