using System.Web.Http;
using Unity;
using Unity.WebApi;
using ControleMatriculas.Api.Repositories;

namespace ControleMatriculas.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração do Unity
            var container = new UnityContainer();

            container.RegisterType<IAlunoRepository, AlunoRepository>();
            container.RegisterType<ITurmaRepository, TurmaRepository>();

            config.DependencyResolver = new UnityDependencyResolver(container);

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}