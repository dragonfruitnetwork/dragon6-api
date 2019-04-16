using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace DragonFruit.Six.Core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/");
            }

            app.UseStaticFiles(); //wwwroot enable
            app.UseMvc(); //Pages folder enable

            //database server
            GoogleServices.SetupGoogleServices(env);

            //datetime parsing error reduction
            CultureInfo ci = new CultureInfo("en-us");
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            //verified accounts
            foreach (JToken x in JArray.Parse(File.ReadAllText(Path.Combine(env.ContentRootPath, "Accounts.json"))))
            {
                AccountStatus.UsersList.Add(new AccountStatus
                {
                    GUID = (string)x["GUID"],
                    IsVerifed = (bool)x["IsVerified"],
                    IsBlocked = (bool)x["IsBlocked"],
                    YTLink = (string)x["YTLink"],
                    TwitchLink = (string)x["TwitchLink"]
                });
            }

            //ranked cards
            API.RankedCards.Setup(env);

            //setup forced garbage collection every 2 mins
            System.Timers.Timer GCTimer = new System.Timers.Timer()
            {
                Interval = new TimeSpan(0, 2, 0).TotalMilliseconds,
            };
            GCTimer.Elapsed += new ElapsedEventHandler(Collect);
            GCTimer.Start();
        }

        /// <summary>
        /// Forces the system to release all unused memory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Collect(object sender, ElapsedEventArgs e)
        {
            Task.Run(() => GC.Collect());
        }
    }
}
