﻿namespace SharedTrip
{
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //serviceCollection.Add<IUsersService, UsersService>();
        }

        public void Configure(List<Route> routeTable)
        {
            //new ApplicationDbContext().Database.Migrate();
        }
    }
}
