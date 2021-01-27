using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Route_Yapısı.Constraints;

namespace Route_Yapısı
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<RouteOptions>(options=> options.ConstraintMap.Add("custom",typeof(CustomConstraint)));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //    endpoints.MapDefaultControllerRoute();//default olarak sağlamış olduğum controller routu ile gelen istekleri eşleştiririm ve ona göre hangi controlleri tetikleyeceksem ona göre ayırt ederim.
                //     endpoints.MapControllerRoute("Default2", "{controller=home}/{controller=ındex}");//her bir controller routun ismi olması gerkir ve uniq olması gerekir.
                //özelleştirilmiş rotalar dahada özelleştirilmek istenirse
                //    endpoints.MapControllerRoute("Default3", "anasayfa",new { controller="Home", action="Index"});//bu şekildeki tanımalamalrda hangi controller nasıl tanımlanır bildirmek için 3. parametre devreye girer anonim olarak değer vermemiz gerekir.
                //bu şekilde url'ye bir parametre almıyosun direk statik urlye arkada yönlendirme sağlıyorsun buda ayrı bir kullanımdır.
                //eğer birden fazla rota tanımlayacaksan özelden genele doğru tanımlayın mesela şuan en üstteki en altta olmalı şuan. ilk özeller kontoler edilsinki enson genele gidebilsin.
                //  endpoints.MapControllerRoute("Default4", "{controller=Home}/{action=Index}/{id?}");
                //  endpoints.MapControllerRoute("Default5", "{controller=Home}/{action=Index}/{id:int?}/{x?}");//id int olmalı diyorum
                //        endpoints.MapControllerRoute("Default6", "{controller=Home}/{action=Index}/{id:int?}/{tc:length(12)?}");//tc:legnth(12) diyerek gelecek değerin uzunluğu 12 dedim max minde mevcut.
                //endpoints.MapControllerRoute("Default6", "{controller=Home}/{action=Index}/{id:custom }/{tc:length(12)?}");
                endpoints.MapControllers();
            });
        }
    }
}
